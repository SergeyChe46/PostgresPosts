
using Microsoft.AspNetCore.Mvc;
using PostgresPosts.Models.Posts;
using System.Data;

namespace PostgresPosts.Models.Repositories
{
    public class PostRepository : BaseRepository, IRepository<PostPostViewModel, PutPostViewModel>
    {
        public PostRepository(IConfiguration configuration) : base(configuration) { }

        public async Task Delete(Guid id)
        {
            string query = @"DELETE FROM Posts
                            WHERE PostId = @PostId";
            await using (var command = dataSource.CreateCommand(query))
            {
                command.Parameters.AddWithValue("@PostId", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<JsonResult> GetAll()
        {
            string query = @"SELECT PostId as ""PostId"",
                            PostTitle as ""PostTitle"",
                            PostBody as ""PostBody""
                            FROM Posts";

            DataTable table = new DataTable();
            await using (var command = dataSource.CreateCommand(query))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                    table.Load(reader);
            }
            return new JsonResult(table);
        }

        public async Task Post(PostPostViewModel entity)
        {
            string query = @"INSERT INTO Posts(PostTitle, PostBody)
                            VALUES(@PostTitle, @PostBody)";
            await using var command = dataSource.CreateCommand(query);
            {
                command.Parameters.AddWithValue("@PostTitle", entity.PostTitle);
                command.Parameters.AddWithValue("@PostBody", entity.PostBody);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task Put(PutPostViewModel entity)
        {
            string query = @"UPDATE Posts
                            SET PostTitle = @PostTitle, 
                            PostBody = @PostBody
                            WHERE PostId = @PostId";
            await using (var command = dataSource.CreateCommand(query))
            {
                command.Parameters.AddWithValue("@PostId", entity.PostId);
                command.Parameters.AddWithValue("@PostTitle", entity.PostTitle);
                command.Parameters.AddWithValue("@PostBody", entity.PostBody);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
