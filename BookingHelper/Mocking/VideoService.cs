using ExercisesChapterSix.Mocking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExcercisesChapterSix.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideoRepository _videoRepository;

        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _videoRepository = repository ?? new VideoRepository();
        }

        public string ReadVideoTitle()
        {
            var obj = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(obj);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }


        public string GetUnprocessedVideosAsCsv()
        {
            var videosIds = new List<int>();

            var videos = _videoRepository.GetUnprocessedVideos();

            foreach(var v in videos)
            {
                videosIds.Add(v.Id);
            }

            return String.Join(",", videosIds);       
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}
