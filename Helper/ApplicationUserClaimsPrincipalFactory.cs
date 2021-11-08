using FinalApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace FinalApplication.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationClass, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationClass> userManager, 
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            :base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationClass user)
        {
            var identity = await  base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Username", user.UserName ?? ""));
      
            return identity;
        }
    }
}
