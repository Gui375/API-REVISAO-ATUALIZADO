using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAPI.Domain.Entities
{
    public class NovoJogo
    {
        [Required(ErrorMessage = "Nome é obrigatorio")]
        [MinLength(3, ErrorMessage = "Nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(255, ErrorMessage = "Nome deve ter no maximo 255 caracteres.")]
        public string Nome { get; set; }
        [Required]
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
