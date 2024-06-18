using Astra.BLL.Interfaces;
using AstraAPI.Models.Post;
using AstraAPI.Tools;
using AstraAPI.Tools.Mappers;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace AstraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostBLLService _repo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PostController(IPostBLLService repo, IWebHostEnvironment hostingEnvironment)
        {
            _repo = repo;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<PostDTO> posts = _repo.GetAll().Select(p => p.ToDto());
            return Ok(posts);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            PostDTO post = _repo.GetOne(id).ToDto();

            if(post is not null)
                return Ok(post);
            return BadRequest("Aucun post trouvé.");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] PostFormDTO dto)
        {
            List<string> PicturesPath = new();

            if (dto.Image1 is not null)
                PicturesPath.Add(await ImageConverter.SaveImage(dto.Image1, "Posts", _hostingEnvironment));
            if (dto.Image2 is not null)
                PicturesPath.Add(await ImageConverter.SaveImage(dto.Image2, "Posts", _hostingEnvironment));
            if (dto.Image3 is not null)
                PicturesPath.Add(await ImageConverter.SaveImage(dto.Image3, "Posts", _hostingEnvironment));
            if (dto.Image4 is not null)
                PicturesPath.Add(await ImageConverter.SaveImage(dto.Image4, "Posts", _hostingEnvironment));

            _repo.Create(dto.ToBLL(),PicturesPath);
            return Ok();
        }
    }
}
