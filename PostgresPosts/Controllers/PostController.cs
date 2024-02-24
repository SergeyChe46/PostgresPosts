using Microsoft.AspNetCore.Mvc;
using PostgresPosts.Models.Posts;
using PostgresPosts.Models.Repositories;

namespace PostgresPosts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IRepository<Post> _repository;
        public PostController(IRepository<Post> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var table = await _repository.GetAll();
            return Ok(table);
        }
    }
}
