using ExemploAPI.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace ExemploAPI.Models.Request
{
    public class NovoJogoViewModel
    {
      
        [Required(ErrorMessage = "Nome é obrigatorio")]
        [MinLength(3, ErrorMessage = "Nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(255, ErrorMessage = "Nome deve ter no maximo 255 caracteres.")]
        public string Nome { get; set; }
        [Required]
        [CpfValidation(ErrorMessage = "CPF invalido")]
        public string Cpf { get; set; }
        [Required]
        [Range(1, 60, ErrorMessage = "Valor invalido")]
        public int primeiroNro { get; set; }
        [Required]
        [Range(1, 60, ErrorMessage = "Valor invalido")]
        public int segundoNro { get; set; }
        [Required]
        [Range(1, 60, ErrorMessage = "Valor invalido")]
        public int terceiroNro { get; set; }
        [Required]
        [Range(1, 60, ErrorMessage = "Valor invalido")]
        public int quartoNro { get; set; }
        [Required]
        [Range(1, 60, ErrorMessage = "Valor invalido")]
        public int quintoNro { get; set; }
        [Required]
        [Range(1, 60, ErrorMessage = "Valor invalido")]
        public int sextoNro { get; set; }
        public DateTime dataJogo { get; set; }
    }
}
