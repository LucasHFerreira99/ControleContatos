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
        public Usuario BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
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
            usuario.SetSenhaHash();
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
        public Usuario AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            Usuario usuarioDb = BuscarPorId(alterarSenhaModel.Id);

            if (usuarioDb == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");
        
            if(!usuarioDb.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuarioDb.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!!");
        
            usuarioDb.SetNovaSenha(alterarSenhaModel.NovaSenha);
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