using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace API___Tarefa1.Dtos
{
    public class FornecedorDTO
    {
        [Required]
       
        public int Id { get; set; }

        [Required]
        [MinLength(3)]  // valor da propriedade anotada deve ter pelo menos 3 caracteres de comprimento.
                        // Se o valor fornecido for menor que isso, a validação falhará e um erro será gerado.
        public string NomeFantasia { get; set; }

        [Required]
        [MinLength(3)]  // valor da propriedade anotada deve ter pelo menos 3 caracteres de comprimento.
                        // Se o valor fornecido for menor que isso, a validação falhará e um erro será gerado.
        public string RazaoSocial { get; set; }

        [Required]
        [StringLength(14)] //totalidade dos caracteres permitida é 14
        public string CNPJ { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        [MinLength(2), MaxLength(2)] // a propriedade anotada pode ter no máximo 2 caracteres EX: RO.
        public string Estado { get; set; }

        [Required]
        
        public string Telefone { get; set; }

        [Required]
     
        public string Email { get; set; }

        [Required]
        public string Responsavel { get; set; }
    }
}
