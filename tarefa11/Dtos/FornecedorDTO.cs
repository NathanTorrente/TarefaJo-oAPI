using System.ComponentModel.DataAnnotations;

namespace API___Tarefa1.Dtos
{
    public class FornecedorDTO
    {
        [Required]
        [MinLength(3)]
        public string NomeFantasia { get; set; }

        [Required]
        [MinLength(3)]
        public string RazaoSocial { get; set; }

        [Required]
     
        public string CNPJ { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        [MinLength(2), MaxLength(2)]
        public string Estado { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Responsavel { get; set; }
    }
}
