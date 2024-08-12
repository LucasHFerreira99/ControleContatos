using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositories
{
    public class UsuarioRepository : IUsuarioRepository

    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }


        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public List<Usuario> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario Adicionar(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario Editar(Usuario usuario)
        {
            var usuarioDb = BuscarPorId(usuario.UsuarioId);

            if (usuarioDb == null) throw new System.Exception("Houve um erro ao atualizar o usuário! Usuário não encontrado!");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.Now;


            _context.Usuarios.Update(usuarioDb);
            _context.SaveChanges();
            return usuarioDb;
        }

        public bool Apagar(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.UsuarioId == id);

            if (usuario is null) throw new System.Exception("Houve um erro ao encontrar o usuário para exclusão!");

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }


    }
}