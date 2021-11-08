using FinalApplication.Models;
using System.Threading.Tasks;

namespace FinalApplication.Services.EmailServices
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptionsptions);
        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);
        Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
    }
}