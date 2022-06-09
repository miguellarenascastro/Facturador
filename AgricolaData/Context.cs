using Agricola.Seguridad;
using AgricolaData.Configuration;
using AgricolaData.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloData
{
    public class Context : SeguridadDbContext
    {
        //public Context(string connectionString) : base(connectionString)
        //{
        //}

        //public Context() : base("DefaultConnection")
        //{
        //}

        // public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Cat_Usuarios> Cat_Usuarios { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }


        public virtual DbSet<Establecimiento> Establecimientos { get; set; }
        public virtual DbSet<PuntoVenta> PuntoVentas { get; set; }
        public virtual DbSet<DocumentoPuntoVenta> DocumentoPuntoVenta { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }


        public virtual DbSet<TipoPersona> TipoPersonas { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }

        public virtual DbSet<FormaPago> FormaPagos { get; set; }
        public virtual DbSet<DocumentoCabecera> DocumentoCabecera { get; set; }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<TipoItem> TipoItems { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedidas { get; set; }
        public virtual DbSet<Impuesto> Impuestos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<DocumentoDetalle> DocumentoDetalles { get; set; }

        public virtual DbSet<ArchivoOrden> ArchivoOrdens { get; set; }
        public virtual DbSet<FilaArchivoOrden> FilaArchivoOrdens { get; set; }

        public new static Context Create()
        {
            return new Context();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Cat_UsuariosConfig());
            modelBuilder.Configurations.Add(new EmpresaConfig());

            modelBuilder.Configurations.Add(new EstablecimientoConfig());
            modelBuilder.Configurations.Add(new PuntoVentaConfig());
            modelBuilder.Configurations.Add(new DocumentoPuntoVentaConfig());
            modelBuilder.Configurations.Add(new TipoDocumentoConfig());

            modelBuilder.Configurations.Add(new TipoPersonaConfig());
            modelBuilder.Configurations.Add(new PersonasConfig());


            modelBuilder.Configurations.Add(new FormaPagoConfig());
            modelBuilder.Configurations.Add(new DocumentoCabeceraConfig());

            modelBuilder.Configurations.Add(new CategoriaConfig());
            modelBuilder.Configurations.Add(new TipoItemConfig());
            modelBuilder.Configurations.Add(new UnidadMedidaConfig());
            modelBuilder.Configurations.Add(new ImpuestoConfig());
            modelBuilder.Configurations.Add(new ProductoConfig());

            modelBuilder.Configurations.Add(new DocumentoDetalleConfig());

            modelBuilder.Configurations.Add(new ArchivoOrdenConfig());
            modelBuilder.Configurations.Add(new FilaArchivoOrdenConfig());
        }
    }

    
}
