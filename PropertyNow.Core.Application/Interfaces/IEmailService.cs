using PropertyNow.Core.Application.DTOs.Email;

namespace PropertyNow.Core.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto emailRequestDto);
        Task SendEmailAsync(string toEmail, string subject, string message);
    }
}