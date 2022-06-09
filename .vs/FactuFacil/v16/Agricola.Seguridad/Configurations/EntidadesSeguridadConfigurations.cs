using Agricola.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricola.Seguridad.Configurations
{
    public class PermissionConfiguration : EntityTypeConfiguration<Permission>
    {
        public PermissionConfiguration()
        {
            ToTable("Permisos", "SGR");

            HasKey(c => c.IdPermiso);

            HasRequired(c => c.AreaSeguridad)
                .WithMany(c => c.Permisos)
                .HasForeignKey(c => c.IdArea);
        }
    }

    public class SecurityAreaConfiguration : EntityTypeConfiguration<SecurityArea>
    {
        public SecurityAreaConfiguration()
        {
            ToTable("SeguridadAreas", "SGR");

            HasKey(c => c.IdArea);
        }
    }

    public class SecurityLevelConfiguration : EntityTypeConfiguration<SecurityLevel>
    {
        public SecurityLevelConfiguration()
        {
            ToTable("SeguridadNiveles", "SGR");

            HasKey(c => c.IdNivel);
        }
    }

}
