using Agricola.Seguridad.Entidades;
using Agricola.Seguridad.Stores;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Agricola.Seguridad.Managers
{
    public class AdministradorUsuariosAgricola : UserManager<AgricolaUser, long>
    {
        public AdministradorUsuariosAgricola(AgricolaUserStore store)
            : base(store)
        {
            Store = store;
        }

        public async Task<ClaimsIdentity> AuthenticateUserAsync(AgricolaUser user, string authenticationType)
        {
            var userIdentity = await CreateIdentityAsync(user, authenticationType);

            // Personalizar los claims
            userIdentity.AddClaim(new Claim("TextClaim", "ClaimValue"));
            userIdentity.AddClaim(new Claim("FechaRegistroUsuario", user.FechaRegistro.ToString(), ClaimValueTypes.DateTime));

            return userIdentity;
        }

        public static AdministradorUsuariosAgricola Create(IdentityFactoryOptions<AdministradorUsuariosAgricola> options,
            IOwinContext context)
        {
            var manager = new AdministradorUsuariosAgricola(new AgricolaUserStore(context.Get<SeguridadDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AgricolaUser, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<AgricolaUser, long>(
                        dataProtectionProvider.Create("Servidor de Seguridad"));
            return manager;
        }

        public static AdministradorUsuariosAgricola CreateDefault()
        {
            return new AdministradorUsuariosAgricola(new AgricolaUserStore(new SeguridadDbContext()));
        }

        public async Task<IdentityResult> ManualResetPasswordAsync(long userId, string password)
        {
            var user = await FindByIdAsync(userId);
            if (user == null)
                return IdentityResult.Failed("No se ha encontrado ese usuario.");

            if (!(Store is IUserPasswordStore<AgricolaUser, long> store))
            {
                return IdentityResult.Failed("El UserStore usado no implementa PasswordStore");
            }

            var newPasswordHash = this.PasswordHasher.HashPassword(password);
            try
            {
                await store.SetPasswordHashAsync(user, newPasswordHash);
                await store.UpdateAsync(user);
            }
            catch (Exception e)
            {
                return IdentityResult.Failed("Error interno: " + e.Message);
            }
            return IdentityResult.Success;
        }

        public List<AgricolaUser> GetUsersInRole(long roleId)
        {
            return this.Users.Where(c => c.Roles.Any(r => r.RoleId == roleId)).ToList();
        }

        public List<AgricolaUser> GetUsersInRole(long roleId, long userId)
        {
            return this.Users.Where(c => c.Roles.Any(r => r.RoleId == roleId) && c.Id != userId).ToList();
        }
    }

}
