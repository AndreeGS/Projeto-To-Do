using API.Dtos;
using API.Models;

namespace API.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarUsuarios();
        Task<UsuarioModel> BuscarUsuarioPorEmail(string email);

        Task<UsuarioModel> Adicionar(UsuarioModel usuario);

        Task<UsuarioModel> Atualizar(UsuarioModel usuario, string email);

        Task<bool> Apagar(string email);

        Task<List<TarefaModel>> BuscarTarefasDoUsuario(int id);

        Task<UsuarioModel> Login(LoginDto login);

    }
}
