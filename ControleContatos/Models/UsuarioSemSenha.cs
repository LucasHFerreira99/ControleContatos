using ControleContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class UsuarioSemSenha
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido! ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário!")]
        public PerfilEnum? Perfil { get; set; }
    }
}
