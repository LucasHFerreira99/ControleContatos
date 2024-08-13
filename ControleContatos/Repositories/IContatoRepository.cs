using ControleContatos.Models;

namespace ControleContatos.Repositories
{
    public interface IContatoRepository
    {
        List<Contato> buscarTodos(int usuarioId);
        Contato BuscarPorId(int id);
        Contato Adicionar(Contato contato);
        Contato Editar(Contato contato);
        bool Apagar(int id);
    }
}
