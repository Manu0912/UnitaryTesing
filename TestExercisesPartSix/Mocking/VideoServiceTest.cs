using ExcercisesChapterSix.Mocking;
using ExercisesChapterSix.Mocking;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace TestExercisesPartSix
{
    
    public class VideoServiceTest
    {

        [Fact]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var service = new VideoService(fileReader.Object);

            var res = service.ReadVideoTitle();

            Assert.Contains("Error", res);
        }

        [Fact]
        public void GetUnprocessedVideosAsCsv_VideosProcessed_ReturnEmptyString()
        {
            var repo = new Mock<IVideoRepository>();
            var fileReader = new Mock<IFileReader>();
            var videoService = new VideoService(fileReader.Object, repo.Object);

            repo.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = videoService.GetUnprocessedVideosAsCsv();

            Assert.Equal("", result);
        }

        [Fact]
        public void GetUnprocessedVideosAsCsv_FewUnprocessedVideos_ReturnStringWithVideosId()
        {
            var repo = new Mock<IVideoRepository>();
            var fileReader = new Mock<IFileReader>();
            var videoService = new VideoService(fileReader.Object, repo.Object);

            repo.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video> { 
                new Video() {Id = 1},
                new Video() {Id = 2},
                new Video() {Id = 3},
                new Video() {Id = 4},
            });

            var result = videoService.GetUnprocessedVideosAsCsv();

            Assert.Equal("1,2,3,4", result);
        }
    }
}