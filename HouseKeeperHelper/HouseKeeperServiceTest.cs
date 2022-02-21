using FinalExercises;
using FinalExercises.HouseKeeperProject;
using FinalExercises.interfaces;
using FinalExercises.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HouseKeeperTest
{
    public class HouseKeeperServiceTests
    {
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IStatementGenerator> statementGenerator;
        private Mock<IEmailSender> emailSender;
        private Mock<IXtraMessageBox> messageBox;
        private HouseKeeperService service;
        private DateTime date;
        private Housekeeper _houseKeeper;
        private string _statementFileName = "fileName";

        public HouseKeeperServiceTests()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                new Housekeeper {Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c"}
            }.AsQueryable());

            statementGenerator = new Mock<IStatementGenerator>();
            emailSender = new Mock<IEmailSender>();
            messageBox = new Mock<IXtraMessageBox>();

            service = new HouseKeeperService(unitOfWork.Object,
                statementGenerator.Object,
                emailSender.Object,
                messageBox.Object);

            date = new DateTime(2017, 1, 1);
            _houseKeeper = new Housekeeper { Email = "a", FullName = "b", Oid= 1, StatementEmailBody = "c"};


        }

        [Fact]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {

            service.SendStatementEmails(date);

            statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid,_houseKeeper.FullName, date));
            
        }

        [Fact]
        public void SendStatementEmails_HouseKeeperEmailIsNull_ShouldNotGenerateStatement()
        {
            _houseKeeper.Email = null;
            service.SendStatementEmails(date);
            statementGenerator.Reset();
            statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, date),Times.Never);
        }

        [Fact]
        public void SendStatementEmails_HouseKeeperEmailIsWhiteSpace_ShouldNotGenerateStatement()
        {
            _houseKeeper.Email = " ";
            service.SendStatementEmails(date);
            statementGenerator.Reset();
            statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, date), Times.Never);
        }

        [Fact]
        public void SendStatementEmails_HouseKeeperEmailIsEmpty_ShouldNotGenerateStatement()
        {
            _houseKeeper.Email = "";
            service.SendStatementEmails(date);
            statementGenerator.Reset();
            statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, date), Times.Never);
        }

        [Fact]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            statementGenerator.Reset();
            statementGenerator.Setup(sg =>
                sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (date))).Returns(_statementFileName);

            service.SendStatementEmails(date);

            emailSender.Verify(es => es.EmailFile(_houseKeeper.Email, _houseKeeper.StatementEmailBody, _statementFileName, It.IsAny<string>()));
        }

        [Fact]
        public void SendStatementEmails_StatementFileIsNull_ShouldNotEmailTheStatement()
        {
            statementGenerator.Reset();
            statementGenerator.Setup(sg =>
                sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (date))).Returns(()=>null);

            service.SendStatementEmails(date);

            emailSender.Verify(es => es.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void SendStatementEmails_StatementFileNameIshitespace_ShouldNotEmailTheStatement()
        {

            _statementFileName = "";
            service.SendStatementEmails(date);

            emailSender.Verify(es => es.EmailFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

    }
}