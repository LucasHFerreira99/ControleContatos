using ControleContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido! ")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
