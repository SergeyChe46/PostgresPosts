using Microsoft.AspNetCore.Mvc;
using PostgresPosts.Models.Posts;
using PostgresPosts.Models.Repositories;

namespace PostgresPosts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IRepository<PostPostViewModel, PutPostViewModel> _repository;
        public PostController(IRepository<PostPostViewModel, PutPostViewModel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var table = await _repository.GetAll();
            return Ok(table);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostPostViewModel postViewModel)
        {
            await _repository.Post(postViewModel);
            return CreatedAtAction(nameof(Post), postViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PutPostViewModel putPostView)
        {
            await _repository.Put(putPostView);
            return CreatedAtAction(nameof(Post), putPostView);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var guidId = Guid.Parse(id);
            await _repository.Delete(guidId);
            return Ok(id);
        }
    }
}
