using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesChapterSix.Mocking
{
    public class InstallerHelper
    {
        private string setupDestinationFile;
        private readonly IFileDownloader _fileDownloader;
        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _fileDownloader.DownloadFile(string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),setupDestinationFile);
                return true;
            }
            catch (WebException ex)
            {
                return false;
            }
        }
    }
}
