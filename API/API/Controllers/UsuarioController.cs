using API.Models;
using API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;    
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpGet("Login")]
        public async Task<ActionResult<UsuarioModel>> Login(string email, string password)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Login(email, password);

            return Ok(usuario);
        }

        [HttpGet]
        public async Task <ActionResult<List<UsuarioModel>>> BuscarUsuarios()
        {
            List<UsuarioModel> usuario = await _usuarioRepositorio.BuscarUsuarios();
            return Ok(usuario);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UsuarioModel>> BuscarUsuarioPorEmail(string email)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarUsuarioPorEmail(email);
            return Ok(usuario);
        }

        [HttpGet("{id}/Tarefas")]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTarefasDoUsuario(int id)
        {
            List<TarefaModel> usuario = await _usuarioRepositorio.BuscarTarefasDoUsuario(id);
            return Ok(usuario);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, string email)
        {
            usuarioModel.Email = email;

            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, email);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Deletar(string email)
        {

           bool apagado = await _usuarioRepositorio.Apagar(email);
            return Ok(apagado);
        }
    }
}
