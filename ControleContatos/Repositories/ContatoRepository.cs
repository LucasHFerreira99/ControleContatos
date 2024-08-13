using ControleContatos.Data;
using ControleContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleContatos.Repositories
{
    public class ContatoRepository : IContatoRepository

    {
        private readonly AppDbContext _context;

        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Contato> buscarTodos(int usuarioId)
        {
            return _context.Contatos.Where(x=> x.UsuarioId == usuarioId).ToList();
        }

        public Contato BuscarPorId(int id)
        {
            return _context.Contatos.Find(id);
        }

        public Contato Adicionar(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public Contato Editar(Contato contato)
        {
            var contatoDb = BuscarPorId(contato.ContatoId);

            if (contatoDb == null) throw new System.Exception("Houve um erro ao atualizar o contato!");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _context.Contatos.Update(contatoDb);
            _context.SaveChanges();
            return contatoDb;
        }

        public bool Apagar(int id)
        {
            var contato = _context.Contatos.FirstOrDefault(contato => contato.ContatoId == id);

            if (contato is null) throw new System.Exception("Houve um erro ao encontrar o contato para exclusão!");

            _context.Contatos.Remove(contato);
            _context.SaveChanges();
            return true;
        }
    }
}
