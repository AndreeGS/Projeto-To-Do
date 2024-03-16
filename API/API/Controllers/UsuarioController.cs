using API.Dtos;
using API.Models;
using API.Repositorios.Interfaces;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITokenService _tokenService;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, ITokenService tokenService) 
        {
            _usuarioRepositorio = usuarioRepositorio;   
            _tokenService = tokenService;
        }

        [HttpPost("Cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPost("Login")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Login(LoginDto login)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Login(login);

            var token =  _tokenService.GenerateToken(login);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Usuario = usuario, Token = token });

        }

        [HttpGet]
        [Authorize]
        public async Task <ActionResult<List<UsuarioModel>>> BuscarUsuarios()
        {
            List<UsuarioModel> usuario = await _usuarioRepositorio.BuscarUsuarios();
            return Ok(usuario);
        }

        [HttpGet("{email}")]
        [Authorize]

        public async Task<ActionResult<UsuarioModel>> BuscarUsuarioPorEmail(string email)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarUsuarioPorEmail(email);
            return Ok(usuario);
        }

        [HttpGet("{id}/Tarefas")]
        [Authorize]

        public async Task<ActionResult<List<TarefaModel>>> BuscarTarefasDoUsuario(int id)
        {
            List<TarefaModel> usuario = await _usuarioRepositorio.BuscarTarefasDoUsuario(id);
            return Ok(usuario);
        }


        [HttpPut("{id}")]
        [Authorize]

        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, string email)
        {
            usuarioModel.Email = email;

            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, email);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<UsuarioModel>> Deletar(string email)
        {

           bool apagado = await _usuarioRepositorio.Apagar(email);
            return Ok(apagado);
        }
    }
}
