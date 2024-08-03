using ControleContatos.Models;

namespace ControleContatos.Repositories
{
    public interface IContatoRepository
    {
        List<Contato> buscarTodos();
        Contato Adicionar(Contato contato);
    }
}
