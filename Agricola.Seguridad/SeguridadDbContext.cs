using Agricola.Seguridad.Configurations;
using Agricola.Seguridad.Entidades;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricola.Seguridad
{
    public class SeguridadDbContext : IdentityDbContext<AgricolaUser, AgricolaRoles, long, AgricolaUserLogin,
         AgricolaUserRole, AgricolaUserClaims>
    {
        public SeguridadDbContext(string contextName = "DefaultConnection") : base(contextName)
        {

        }

        // MODULE: Security
        public virtual DbSet<Permission> Permisos { get; set; }
        public virtual DbSet<SecurityArea> AreasSeguridad { get; set; }
        public virtual DbSet<SecurityLevel> NivelesSeguridad { get; set; }

        // MODULE: Localization
        // Geography
   

        // Navigation
      

        public static SeguridadDbContext Create()
        {
            return new SeguridadDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AgricolaRoles>().ToTable("Roles", "SGR").Property(p => p.Id).HasColumnName("IdRol");
            modelBuilder.Entity<AgricolaUser>().ToTable("Usuarios", "SGR").Property(p => p.Id).HasColumnName("IdUsuario");
            modelBuilder.Entity<AgricolaUserRole>().ToTable("RolesUsuarios", "SGR").Property(p => p.RoleId).HasColumnName("IdRol");
            modelBuilder.Entity<AgricolaUserRole>().Property(p => p.UserId).HasColumnName("IdUsuario");
            modelBuilder.Entity<AgricolaUserLogin>().ToTable("LoginsUsuarios", "SGR").Property(p => p.UserId).HasColumnName("IdUsuario");
            modelBuilder.Entity<AgricolaUserClaims>().ToTable("ClaimsUsuarios", "SGR").Property(p => p.Id).HasColumnName("IdClaim");
            modelBuilder.Entity<AgricolaUserClaims>().Property(p => p.UserId).HasColumnName("IdUsuario");

            modelBuilder.Configurations.Add(new PermissionConfiguration());
            modelBuilder.Configurations.Add(new SecurityAreaConfiguration());
            modelBuilder.Configurations.Add(new SecurityLevelConfiguration());

        }
    }
}
