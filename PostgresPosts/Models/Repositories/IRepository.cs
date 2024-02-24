using Microsoft.AspNetCore.Mvc;

namespace PostgresPosts.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<JsonResult> GetAll();
    }
}
