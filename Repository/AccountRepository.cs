using FinalApplication.Models;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalApplication.Services;
using FinalApplication.Services.EmailServices;

namespace FinalApplication.Repository
{

    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationClass> _userManager;
        private readonly SignInManager<ApplicationClass> _signInManager;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;



        public AccountRepository(UserManager<ApplicationClass> userManager, SignInManager<ApplicationClass> signInManager,
            IUserService userService, IEmailService emailService, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
        }



     


        public async Task<IdentityResult> CreateUserAsync(RegisterViewModel userModel)
        {
            var user = new ApplicationClass()
            {

                loginId = userModel.loginId,
                Email = userModel.Email,
                UserName = userModel.UserId,
                PasswordHash = userModel.Pwd,
                UserId = userModel.UserId,
                DOB = userModel.DOB,
                Gender = userModel.Gender


            };
            var result = await _userManager.CreateAsync(user, userModel.Pwd);
            if (result.Succeeded)
            {

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (!string.IsNullOrEmpty(token))
                {
                    await SendEmailConfirmationEmail(user, token);
                }
            }
            return result;
        }



        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var UserId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(UserId);
            return await _userManager.ChangePasswordAsync(user, model.Pwd, model.NewPwd);
        }


        public async Task<ApplicationClass> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
        {
            return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
        }


        public async Task GenerateEmailConfirmationTokenAsync(ApplicationClass user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailConfirmationEmail(user, token);
            }
        }


        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model)
        {
            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
        }


        public async Task GenerateForgotPasswordTokenAsync(ApplicationClass user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token);
            }
        }

        private async Task SendForgotPasswordEmail(ApplicationClass user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;



            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(appDomain + confirmationLink, user.UserId,token))
                }
            };

            await _emailService.SendEmailForEmailConfirmation(options);
        }




        private async Task SendEmailConfirmationEmail(ApplicationClass user, string token)
        {

            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(appDomain + confirmationLink, user.UserId,token))
                }
            };

            await _emailService.SendEmailForEmailConfirmation(options);
        }


        public async Task<SignInResult> PasswordSignInAsync(LoginViewModel loginModel)
        {
            return await _signInManager.PasswordSignInAsync(loginModel.UserId, loginModel.Pwd, loginModel.RememberMe, true);
        }




        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
