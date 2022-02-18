using ExercisesChapterSix.Mocking;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestExercisesPartSix.Mocking
{
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader = new Mock<IFileDownloader>();
        private InstallerHelper _installerHelper;

        [Fact]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            var res = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.False(res);
        }

        [Fact]
        public void DownloadInstaller_DownloadFails_ReturnTrue()
        {
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
           
            var res = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.True(res);
        }

    }
}
