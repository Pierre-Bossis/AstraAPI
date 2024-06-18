using Astra.BLL.Interfaces;
using AstraAPI.Models.User;
using AstraAPI.Tools;
using AstraAPI.Tools.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserBLLService _repo;
        private readonly JwtGenerator _jwtGenerator;

        public AuthController(IUserBLLService repo, JwtGenerator jwtGenerator)
        {
            _repo = repo;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterFormDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repo.Register(dto.Pseudo, dto.MotDePasse, dto.Email);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginFormDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                ConnectedUserDTO ConnectedUser = _repo.Login(dto.Email, dto.MotDePasse).ToDto();
                string token = _jwtGenerator.Generate(ConnectedUser);
                return Ok(token);
            }
            catch
            {
                return BadRequest("Email ou mot de passe incorrect.");
            }
        }

        [HttpGet("getbypseudo/{pseudo}")]
        public IActionResult GetId(string pseudo)
        {
            IEnumerable<SearchUserDTO> users =  _repo.GetId(pseudo).Select(u=>u.ToDtoSearch());
            return Ok(users);
        }

    }
}
