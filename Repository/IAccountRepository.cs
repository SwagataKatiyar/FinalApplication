using FinalApplication.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FinalApplication.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);
        Task<IdentityResult> CreateUserAsync(RegisterViewModel userModel);
        Task GenerateEmailConfirmationTokenAsync(ApplicationClass user);
        Task GenerateForgotPasswordTokenAsync(ApplicationClass user);
        Task<ApplicationClass> GetUserByEmailAsync(string email);
        Task<SignInResult> PasswordSignInAsync(LoginViewModel loginModel);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
        Task SignOutAsync();
        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
    }
}