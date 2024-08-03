using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositories
{
    public class ContatoRepository : IContatoRepository

    {
        private readonly AppDbContext _context;

        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Contato> buscarTodos()
        {
            return _context.Contatos.ToList();
        }

        public Contato Adicionar(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }


    }
}
