using ControleContatos.Models;

namespace ControleContatos.Repositories
{
    public interface IUsuarioRepository
    {

        Usuario BuscarPorLogin(string login);
        Usuario BuscarPorEmailELogin(string email, string login);
        List<Usuario> BuscarTodos();
        Usuario BuscarPorId(int id);
        Usuario Adicionar(Usuario usuario);
        Usuario Editar(Usuario usuario);

        Usuario AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        bool Apagar(int id);
    }
}
