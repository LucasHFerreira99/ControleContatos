using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }

        [Required(ErrorMessage = "Digite o nome do contato!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido! ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do contato!")]
        [Phone(ErrorMessage = "O celular informado não é valido!")]
        public string Celular { get; set; }

    }
}
