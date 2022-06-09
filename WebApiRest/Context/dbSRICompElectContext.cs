using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiRest.Context
{
    public partial class dbSRICompElectContext : DbContext
    {
        public dbSRICompElectContext()
        {
        }

        public dbSRICompElectContext(DbContextOptions<dbSRICompElectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbdatosfacturacionelectronica> Tbdatosfacturacionelectronicas { get; set; }
        public virtual DbSet<Tbdocumentosfacturacionelectronica> Tbdocumentosfacturacionelectronicas { get; set; }
        public virtual DbSet<TbrutasXml> TbrutasXmls { get; set; }

        public virtual DbSet<CasaComercial> CasaComercials { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ComprobanteCompra> ComprobanteCompras { get; set; }
        public virtual DbSet<ComprobanteVentum> ComprobanteVenta { get; set; }
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Local> Locals { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Secuencial> Secuencials { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseNpgsql("Host=localhost;Database=dbinduapp;Username=postgres;Password=12345");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
