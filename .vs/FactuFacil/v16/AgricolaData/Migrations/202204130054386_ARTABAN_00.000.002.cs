namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CONF.DocumentoPuntoVenta",
                c => new
                    {
                        IdDocumentoporPuntoVenta = c.Long(nullable: false, identity: true),
                        IdEmpresa = c.Long(nullable: false),
                        IdTipoDocumento = c.Long(nullable: false),
                        IdPuntoVenta = c.Long(nullable: false),
                        Secuencia = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdDocumentoporPuntoVenta)
                .ForeignKey("CONF.Empresa", t => t.IdEmpresa)
                .ForeignKey("CONF.PuntoVenta", t => t.IdPuntoVenta)
                .ForeignKey("CONF.TipoDocumento", t => t.IdTipoDocumento)
                .Index(t => t.IdEmpresa)
                .Index(t => t.IdTipoDocumento)
                .Index(t => t.IdPuntoVenta);
            
            CreateTable(
                "CONF.PuntoVenta",
                c => new
                    {
                        IdPuntoVenta = c.Long(nullable: false, identity: true),
                        IdEstablecimiento = c.Long(nullable: false),
                        Nombre = c.String(),
                        Codigo = c.String(),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdPuntoVenta)
                .ForeignKey("CONF.Establecimiento", t => t.IdEstablecimiento)
                .Index(t => t.IdEstablecimiento);
            
            CreateTable(
                "CONF.Establecimiento",
                c => new
                    {
                        IdEstablecimiento = c.Long(nullable: false, identity: true),
                        IdEmpresa = c.Long(nullable: false),
                        Nombre = c.String(),
                        Codigo = c.String(),
                        Direccion = c.String(),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdEstablecimiento)
                .ForeignKey("CONF.Empresa", t => t.IdEmpresa)
                .Index(t => t.IdEmpresa);
            
            CreateTable(
                "CONF.TipoDocumento",
                c => new
                    {
                        IdTipoDocumento = c.Long(nullable: false, identity: true),
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
                .PrimaryKey(t => t.IdTipoDocumento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CONF.DocumentoPuntoVenta", "IdTipoDocumento", "CONF.TipoDocumento");
            DropForeignKey("CONF.DocumentoPuntoVenta", "IdPuntoVenta", "CONF.PuntoVenta");
            DropForeignKey("CONF.PuntoVenta", "IdEstablecimiento", "CONF.Establecimiento");
            DropForeignKey("CONF.Establecimiento", "IdEmpresa", "CONF.Empresa");
            DropForeignKey("CONF.DocumentoPuntoVenta", "IdEmpresa", "CONF.Empresa");
            DropIndex("CONF.Establecimiento", new[] { "IdEmpresa" });
            DropIndex("CONF.PuntoVenta", new[] { "IdEstablecimiento" });
            DropIndex("CONF.DocumentoPuntoVenta", new[] { "IdPuntoVenta" });
            DropIndex("CONF.DocumentoPuntoVenta", new[] { "IdTipoDocumento" });
            DropIndex("CONF.DocumentoPuntoVenta", new[] { "IdEmpresa" });
            DropTable("CONF.TipoDocumento");
            DropTable("CONF.Establecimiento");
            DropTable("CONF.PuntoVenta");
            DropTable("CONF.DocumentoPuntoVenta");
        }
    }
}
