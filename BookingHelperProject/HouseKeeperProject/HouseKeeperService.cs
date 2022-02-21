using BookingHelperProject;
using FinalExercises.HouseKeeperProject;
using FinalExercises.interfaces;
using FinalExercises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExercises
{
    public class HouseKeeperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatementGenerator _statementGenerator;
        private readonly IEmailSender _emailSender;
        private readonly IXtraMessageBox _xtraMessageBox;

        public HouseKeeperService(IUnitOfWork unitOfWork, 
            IStatementGenerator statementGenerator, 
            IEmailSender emailSender, 
            IXtraMessageBox xtraMessageBox)
        {
            _unitOfWork = unitOfWork;
            _statementGenerator = statementGenerator;
            _emailSender = emailSender;
            _xtraMessageBox = xtraMessageBox;
        }

        public void SendStatementEmails(DateTime statementDate)
        {
            var housekeepers = _unitOfWork.Query<Housekeeper>();

            foreach (var housekeeper in housekeepers)
            {
                if (string.IsNullOrWhiteSpace(housekeeper.Email))
                    continue;

                var statementFilename = _statementGenerator.SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);

                if (string.IsNullOrWhiteSpace(statementFilename))
                    continue;

                var emailAddress = housekeeper.Email;
                var emailBody = housekeeper.StatementEmailBody;

                try
                {
                    _emailSender.EmailFile(emailAddress, emailBody, statementFilename,
                        string.Format("Sandpiper Statement {0:yyyy-MM} {1}", statementDate, housekeeper.FullName));
                }
                catch (Exception e)
                {
                    _xtraMessageBox.Show(e.Message, string.Format("Email failure: {0}", emailAddress),
                        MessageBoxButtons.OK);
                   
                }
            }
        }
    }
}
