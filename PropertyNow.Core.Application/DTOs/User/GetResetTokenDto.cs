using System.ComponentModel.DataAnnotations;

namespace PropertyNow.Core.Application.DTOs.User
{
    public class GetResetTokenDto
    {
        [Required]
        public string UserName { get; set; } = null!;
    }
}