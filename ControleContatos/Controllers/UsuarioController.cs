using ControleContatos.Data;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
