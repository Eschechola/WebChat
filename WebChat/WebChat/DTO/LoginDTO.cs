using System.ComponentModel.DataAnnotations;

namespace WebChat.DTO
{
    public class LoginDTO
    {
        public string Hash { get; set; }

        [Required(ErrorMessage = "* O EMAIL deve ser inserido.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "* Você deve inserir um email válido.")]
        [MinLength(10, ErrorMessage = "* O EMAIL deve ter no mínimo 10 caracteres")]
        [MaxLength(180, ErrorMessage = "* O EMAIL deve ter no máximo 180 caracteres")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "* O NOME deve ser inserido.")]
        [MinLength(3, ErrorMessage = "* O NOME deve ter no mínimo 3 caracteres")]
        [MaxLength(40, ErrorMessage = "* O NOME deve ter no máximo 40 caracteres")]
        public string Name { get; set; }
    }
}
