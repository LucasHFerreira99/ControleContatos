using ControleContatos.Models;

namespace ControleContatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(Usuario usuario);
        void RemoverSessaoDoUsuario();
        Usuario BuscarSessaoDoUsuario();
    }
}
