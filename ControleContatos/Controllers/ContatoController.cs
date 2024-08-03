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
            _repository.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Editar(Contato contato)
        {
            _repository.Editar(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            var confirma = _repository.Apagar(id);
            if (confirma != true) throw new Exception("Houve um erro ao excluir!");
            return RedirectToAction("Index");
        }

    }
}
