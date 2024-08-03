using ControleContatos.Models;
using ControleContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
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

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            _repository.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
