using Microsoft.Extensions.Configuration;
using PostgresPosts.Models.Posts;
using PostgresPosts.Models.Repositories;
using Xunit;

namespace PostgresPost.Tests.Repositories
{
    public class PostRepositoryTest
    {
        private IRepository<PostPostViewModel, PutPostViewModel> _repository;
        public PostRepositoryTest()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .Build();
            _repository = new PostRepository(configuration);
        }

        [Fact]
        public void IRepository_ImplementsRightConcreteClass()
        {
            Assert.IsAssignableFrom<IRepository<PostPostViewModel, PutPostViewModel>>(_repository);
            Assert.IsAssignableFrom<BaseRepository>(_repository);
            Assert.NotNull(_repository.GetAll());
        }
    }
}
