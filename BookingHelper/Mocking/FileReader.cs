using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcercisesChapterSix.Mocking
{
    public interface IFileReader
    {
        string Read(string fileName);
    }

    public class MockFileReader : IFileReader
    {
        public string Read(string fileName)
        {
            return "";
        }
    }

    public class FileReader: IFileReader
    {
        public string Read(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
