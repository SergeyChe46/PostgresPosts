using Microsoft.AspNetCore.Mvc;

namespace PostgresPosts.Models.Repositories
{
    public interface IRepository<TPost, TPut> where TPost : class where TPut : class
    {
        Task<JsonResult> GetAll();
        Task Post(TPost entity);
    }
}
