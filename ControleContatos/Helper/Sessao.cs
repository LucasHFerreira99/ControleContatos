using ControleContatos.Models;
using Newtonsoft.Json;

namespace ControleContatos.Helper
{
    public class Sessao : ISessao
    {

        private readonly IHttpContextAccessor _context;

        public Sessao(IHttpContextAccessor context)
        {
            _context = context;
        }

        public Usuario BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _context.HttpContext.Session.SetString("sessaoUsuarioLogado" , valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _context.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
