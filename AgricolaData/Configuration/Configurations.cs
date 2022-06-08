using AgricolaData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgricolaData.Configuration
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuarios>
    {
        public UsuarioConfig()
        {
            ToTable("Usuarios", "SEG");
            HasKey(x => x.IdUsuario);
        }
    }

    public class Cat_UsuariosConfig : EntityTypeConfiguration<Cat_Usuarios>
    {
        public Cat_UsuariosConfig()
        {
            ToTable("Cat_Usuarios", "SEG");
            HasKey(x => x.IdUsuario);
        }
    }
 
    public class EmpresaConfig : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfig()
        {
            ToTable("Empresa", "CONF");
            HasKey(x => x.IdEmpresa);
        }
    }


    public class EstablecimientoConfig : EntityTypeConfiguration<Establecimiento>
    {
        public EstablecimientoConfig()
        {
            ToTable("Establecimiento", "CONF");
            HasKey(x => x.IdEstablecimiento);

            HasRequired(x => x.Empresa).WithMany().HasForeignKey(c => c.IdEmpresa).WillCascadeOnDelete(false);
        }
    }

    public class PuntoVentaConfig : EntityTypeConfiguration<PuntoVenta>
    {
        public PuntoVentaConfig()
        {
            ToTable("PuntoVenta", "CONF");
            HasKey(x => x.IdPuntoVenta);

            HasRequired(x => x.Establecimiento).WithMany().HasForeignKey(c => c.IdEstablecimiento).WillCascadeOnDelete(false);
        }
    }

    public class DocumentoPuntoVentaConfig : EntityTypeConfiguration<DocumentoPuntoVenta>
    {
        public DocumentoPuntoVentaConfig()
        {
            ToTable("DocumentoPuntoVenta", "CONF");
            HasKey(x => x.IdDocumentoporPuntoVenta);

            HasRequired(x => x.PuntoVenta).WithMany().HasForeignKey(c => c.IdPuntoVenta).WillCascadeOnDelete(false);
            HasRequired(x => x.TipoDocumento).WithMany().HasForeignKey(c => c.IdTipoDocumento).WillCascadeOnDelete(false);
            HasRequired(x => x.Empresa).WithMany().HasForeignKey(c => c.IdEmpresa).WillCascadeOnDelete(false);
        }
    }


    public class TipoDocumentoConfig : EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoConfig()
        {
            ToTable("TipoDocumento", "CONF");
            HasKey(x => x.IdTipoDocumento);
        }
    }


    public class TipoPersonaConfig : EntityTypeConfiguration<TipoPersona>
    {
        public TipoPersonaConfig()
        {
            ToTable("TipoPersona", "CONF");
            HasKey(x => x.IdTipoPersona);
        }
    }


    public class PersonasConfig : EntityTypeConfiguration<Persona>
    {
        public PersonasConfig()
        {
            ToTable("Persona", "CONF");
            HasKey(x => x.IdPersona);

            HasRequired(x => x.TipoPersona).WithMany().HasForeignKey(c => c.IdTipoTipoPersona).WillCascadeOnDelete(false);

        }
    }

    public class FormaPagoConfig : EntityTypeConfiguration<FormaPago>
    {
        public FormaPagoConfig()
        {
            ToTable("FormaPago", "CONF");
            HasKey(x => x.IdFormaPago);
        }
    }

    public class DocumentoCabeceraConfig : EntityTypeConfiguration<DocumentoCabecera>
    {
        public DocumentoCabeceraConfig()
        {
            ToTable("DocumentoCabecera", "CONT");
            HasKey(x => x.IdDocumentoCabecera);

            HasRequired(x => x.Persona).WithMany().HasForeignKey(c => c.IdPersona).WillCascadeOnDelete(false);
            HasRequired(x => x.TipoDocumento).WithMany().HasForeignKey(c => c.IdTipoDocumento).WillCascadeOnDelete(false);
            HasRequired(x => x.Empresa).WithMany().HasForeignKey(c => c.IdEmpresa).WillCascadeOnDelete(false);
            HasRequired(x => x.Establecimiento).WithMany().HasForeignKey(c => c.IdEstablecimiento).WillCascadeOnDelete(false);
            HasRequired(x => x.PuntoVenta).WithMany().HasForeignKey(c => c.IdPuntoVenta).WillCascadeOnDelete(false);
            HasRequired(x => x.FormaPago).WithMany().HasForeignKey(c => c.IdFormaPago).WillCascadeOnDelete(false);

        }
    }


    public class TipoItemConfig : EntityTypeConfiguration<TipoItem>
    {
        public TipoItemConfig()
        {
            ToTable("TipoItem", "CONF");
            HasKey(x => x.IdTipoItem);
        }
    }

    public class CategoriaConfig : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfig()
        {
            ToTable("Categoria", "CONF");
            HasKey(x => x.IdCategoria);
        }
    }


    public class UnidadMedidaConfig : EntityTypeConfiguration<UnidadMedida>
    {
        public UnidadMedidaConfig()
        {
            ToTable("UnidadMedida", "CONF");
            HasKey(x => x.IdUnidadMedida);
        }
    }

    public class ImpuestoConfig : EntityTypeConfiguration<Impuesto>
    {
        public ImpuestoConfig()
        {
            ToTable("Impuesto", "CONF");
            HasKey(x => x.IdImpuesto);
        }
    }

    public class ProductoConfig : EntityTypeConfiguration<Producto>
    {
        public ProductoConfig()
        {
            ToTable("Producto", "CONT");
            HasKey(x => x.IdProducto);

            HasRequired(x => x.TipoItem).WithMany().HasForeignKey(c => c.IdTipoItem).WillCascadeOnDelete(false);
            HasRequired(x => x.Categoria).WithMany().HasForeignKey(c => c.IdCategoria).WillCascadeOnDelete(false);
            HasRequired(x => x.UnidadMedida).WithMany().HasForeignKey(c => c.IdUnidadMedida).WillCascadeOnDelete(false);
            HasRequired(x => x.Impuesto).WithMany().HasForeignKey(c => c.IdImpuesto).WillCascadeOnDelete(false);
        }
    }

    public class DocumentoDetalleConfig : EntityTypeConfiguration<DocumentoDetalle>
    {
        public DocumentoDetalleConfig()
        {
            ToTable("DocumentoDetalle", "CONT");
            HasKey(x => x.IdDocumentoDetalle);

            HasRequired(x => x.DocumentoCabecera).WithMany().HasForeignKey(c => c.IdDocumentoCabecera).WillCascadeOnDelete(false);
            HasOptional(x => x.Producto).WithMany().HasForeignKey(c => c.IdProducto).WillCascadeOnDelete(false);
            HasRequired(x => x.UnidadMedida).WithMany().HasForeignKey(c => c.IdUnidadMedida).WillCascadeOnDelete(false);
         
        }
    }


    public class ArchivoOrdenConfig : EntityTypeConfiguration<ArchivoOrden>
    {
        public ArchivoOrdenConfig()
        {
            ToTable("ArchivoOrden", "CONT");
            HasKey(x => x.IdArchivoOrden);
        }
    }


    public class FilaArchivoOrdenConfig : EntityTypeConfiguration<FilaArchivoOrden>
    {
        public FilaArchivoOrdenConfig()
        {
            ToTable("FilaArchivoOrden", "CONT");
            HasKey(x => x.IdFilaArchivoOrden);

            HasRequired(x => x.ArchivoOrden).WithMany().HasForeignKey(c => c.IdArchivoOrden).WillCascadeOnDelete(false);
        }
    }


}
