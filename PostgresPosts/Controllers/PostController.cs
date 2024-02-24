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
        public async Task<ActionResult> Post(PostPostViewModel postViewModel)
        {
            await _repository.Post(postViewModel);
            return Created(nameof(Post), new { postTitle = postViewModel.PostTitle, postBody = postViewModel.PostBody });
        }
    }
}
