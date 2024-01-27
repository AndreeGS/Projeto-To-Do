using API.Data;
using API.Models;
using API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDbContext _context;
        public UsuarioRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _context = sistemaTarefasDbContext;
        }
        public async Task<UsuarioModel> BuscarUsuarioPorEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<UsuarioModel>> BuscarUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, string email)
        {
            UsuarioModel usuarioPorId = await BuscarUsuarioPorEmail(email);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o email:{email} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _context.Usuarios.Update(usuarioPorId);
            await _context.SaveChangesAsync();

            return usuarioPorId;

        }


        public async Task<bool> Apagar(string email)
        {
            UsuarioModel usuarioPorId = await BuscarUsuarioPorEmail(email);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o email:{email} não foi encontrado no banco de dados.");
            }

            _context.Usuarios.Remove(usuarioPorId);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TarefaModel>> BuscarTarefasDoUsuario(int id)
        {
            return await _context.Tarefas.Where(u => u.UsuarioID == id).ToListAsync();
        }

        public async Task<UsuarioModel> Login(string email, string senha)
        {
            UsuarioModel dado = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

            if (dado == null)
            {
                throw new Exception("Usuário não encontrado ou senha incorreta");
            }

            if (dado.Email == email && dado.Password == senha)
            {
                return dado;
            }
            else
            {
                throw new Exception("Usuário não encontrado ou senha incorreta");
            }
        }
    }
}
