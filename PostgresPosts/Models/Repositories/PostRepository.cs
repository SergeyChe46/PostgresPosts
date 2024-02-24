
using Microsoft.AspNetCore.Mvc;
using PostgresPosts.Models.Posts;
using System.Data;

namespace PostgresPosts.Models.Repositories
{
    public class PostRepository : BaseRepository, IRepository<Post>
    {
        public PostRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<JsonResult> GetAll()
        {
            string query = @"SELECT PostId as ""PostId"",
                            PostTitle as ""PostTitle"",
                            PostBody as ""PostBody""
                            FROM Posts";

            DataTable table = new DataTable();
            await using (var command = dataSource.CreateCommand(query))
            {
                await using (var reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return new JsonResult(table);
        }
    }
}
