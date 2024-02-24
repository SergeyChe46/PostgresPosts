using Microsoft.Extensions.Configuration;
using PostgresPosts.Controllers;
using PostgresPosts.Models.Repositories;
using Xunit;

namespace PostgresPost.Tests.Controllers
{
    public class PostControllerTest
    {
        private PostController _controller;
        public PostControllerTest()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .Build();
            _controller = new PostController(new PostRepository(configuration));
        }

        [Theory]
        [InlineData("123-123-123")]
        [InlineData("dsadasda")]
        [InlineData("1-1-1-1-1")]
        public async Task PostControllerDeleteMethod_ThrowFormatException(string postId)
        {
            await Assert.ThrowsAsync<FormatException>(async () => await _controller.Delete(postId));
        }

        [Theory]
        [InlineData(null)]
        public async Task PostControllerDeleteMethod_ThrowArgumentOfNullException(string postId)
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _controller.Delete(postId));
        }
    }
}
