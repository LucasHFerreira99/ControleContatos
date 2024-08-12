using ControleContatos.Filters;
using ControleContatos.Models;
using ControleContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    [PaginaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _repository;

        public ContatoController(IContatoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var contatos = _repository.buscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var contato = _repository.BuscarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var contato = _repository.BuscarPorId(id);
            return View(contato);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Criar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel cadastrar contato, tente novamente! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Editar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Editar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel editar contato, tente novamente! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                var confirma = _repository.Apagar(id);
                if (confirma == true)
                {
                    TempData["MensagemSucesso"] = "Contato excluido com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não foi possivel deletar contato, tente novamente!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não foi possivel excluir contato, tente novamente! Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }


        }

    }
}
