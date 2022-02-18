using ExcercisesChapterSix.Mocking;

namespace ExcersisesChapterSix
{
    public class Program
    {
        public static void Main()
        {
            var service = new VideoService(new MockFileReader());
            var title = service.ReadVideoTitle();
        }
    }
}