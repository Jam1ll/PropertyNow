using System.ComponentModel.DataAnnotations;

namespace PropertyNow.Core.Application.DTOs.User
{
    public class ForgotPasswordWithTokenDto
    {
        [Required]
        public string UserName { get; set; } = null!;
    }

}
