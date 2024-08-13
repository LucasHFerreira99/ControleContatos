using ControleContatos.Helper;
using ControleContatos.Models;
using ControleContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // Se o usuario estiver logado, redirecionar para a HOME
            if(_sessao.BuscarSessaoDoUsuario() != null)
                return RedirectToAction("Index", "Home");

            return View();
        }


        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepository.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha do usuário é inválida. Por favor, tente novamente!";
                        return View("Index");
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente!";
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar o seu login, tente novamente. Detalhes do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepository.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if(usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        TempData["MensagemSucesso"] = $"Enviamos para o seu e-mail cadastrado uma nova senha.";
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["MensagemErro"] = $"Não conseguimos redefinir a sua senha. Por favor, verifique os dados informados!";
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir a sua senha, tente novamente. Detalhes do erro: {ex.Message}";
                return RedirectToAction("RedefinirSenha");
            }
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }


    }
}
