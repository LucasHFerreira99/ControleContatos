using ControleContatos.Enums;

namespace ControleContatos.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
