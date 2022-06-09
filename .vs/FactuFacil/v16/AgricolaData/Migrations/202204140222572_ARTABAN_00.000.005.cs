namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000005 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CONT.DocumentoCabecera",
                c => new
                    {
                        IdDocumentoCabecera = c.Long(nullable: false, identity: true),
                        IdTipoDocumento = c.Long(nullable: false),
                        IdEmpresa = c.Long(nullable: false),
                        IdEstablecimiento = c.Long(nullable: false),
                        IdPuntoVenta = c.Long(nullable: false),
                        FechaEmision = c.DateTime(nullable: false),
                        IdPersona = c.Long(nullable: false),
                        Descripcion = c.String(),
                        FechaVencimiento = c.DateTime(nullable: false),
                        DireccionMatriz = c.String(),
                        DireccionSucursal = c.String(),
                        NumDocumento = c.Int(nullable: false),
                        Info1Direccion = c.String(),
                        Info2Email = c.String(),
                        IdFormaPago = c.Long(nullable: false),
                        IdTipoDocumentoModificado = c.Long(nullable: false),
                        ComprobanteModifica = c.String(),
                        RazonModificacion = c.String(),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdDocumentoCabecera)
                .ForeignKey("CONF.Empresa", t => t.IdEmpresa)
                .ForeignKey("CONF.Establecimiento", t => t.IdEstablecimiento)
                .ForeignKey("CONF.FormaPago", t => t.IdFormaPago)
                .ForeignKey("CONF.Persona", t => t.IdPersona)
                .ForeignKey("CONF.PuntoVenta", t => t.IdPuntoVenta)
                .ForeignKey("CONF.TipoDocumento", t => t.IdTipoDocumento)
                .Index(t => t.IdTipoDocumento)
                .Index(t => t.IdEmpresa)
                .Index(t => t.IdEstablecimiento)
                .Index(t => t.IdPuntoVenta)
                .Index(t => t.IdPersona)
                .Index(t => t.IdFormaPago);
            
            CreateTable(
                "CONF.FormaPago",
                c => new
                    {
                        IdFormaPago = c.Long(nullable: false, identity: true),
                        Codigo = c.String(),
                        Nombre = c.String(),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdFormaPago);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CONT.DocumentoCabecera", "IdTipoDocumento", "CONF.TipoDocumento");
            DropForeignKey("CONT.DocumentoCabecera", "IdPuntoVenta", "CONF.PuntoVenta");
            DropForeignKey("CONT.DocumentoCabecera", "IdPersona", "CONF.Persona");
            DropForeignKey("CONT.DocumentoCabecera", "IdFormaPago", "CONF.FormaPago");
            DropForeignKey("CONT.DocumentoCabecera", "IdEstablecimiento", "CONF.Establecimiento");
            DropForeignKey("CONT.DocumentoCabecera", "IdEmpresa", "CONF.Empresa");
            DropIndex("CONT.DocumentoCabecera", new[] { "IdFormaPago" });
            DropIndex("CONT.DocumentoCabecera", new[] { "IdPersona" });
            DropIndex("CONT.DocumentoCabecera", new[] { "IdPuntoVenta" });
            DropIndex("CONT.DocumentoCabecera", new[] { "IdEstablecimiento" });
            DropIndex("CONT.DocumentoCabecera", new[] { "IdEmpresa" });
            DropIndex("CONT.DocumentoCabecera", new[] { "IdTipoDocumento" });
            DropTable("CONF.FormaPago");
            DropTable("CONT.DocumentoCabecera");
        }
    }
}
