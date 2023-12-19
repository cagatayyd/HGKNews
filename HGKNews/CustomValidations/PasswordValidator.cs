using HGKNews.Entities;
using Microsoft.AspNetCore.Identity;

namespace HGKNews.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();
            if (password!.ToLower().ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new() { Code = "PasswordContainUserName", Description = "Şifre alanı kullanıcı adı içeremez." });

            }
            if (password!.ToLower().StartsWith("1234"))
            {
                errors.Add(new() { Code = "PasswordNoContain1234", Description = "Şifre alanı ardışık sayı içeremez." });
            }
            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
