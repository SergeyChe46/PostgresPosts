using Npgsql;

namespace PostgresPosts.Models.Repositories
{
    public abstract class BaseRepository
    {
        protected NpgsqlDataSource dataSource;
        protected BaseRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("PostsDatabase")!;
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            dataSource = dataSourceBuilder.Build();
        }
    }
}
