namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000007 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CONT.DocumentoDetalle",
                c => new
                    {
                        IdDocumentoDetalle = c.Long(nullable: false, identity: true),
                        IdDocumentoCabecera = c.Long(nullable: false),
                        IdProducto = c.Long(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdUnidadMedida = c.Long(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdRetenFuente = c.Long(),
                        IdRetenIva = c.Long(),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdDocumentoDetalle)
                .ForeignKey("CONT.DocumentoCabecera", t => t.IdDocumentoCabecera)
                .ForeignKey("CONT.Producto", t => t.IdProducto)
                .ForeignKey("CONF.UnidadMedida", t => t.IdUnidadMedida)
                .Index(t => t.IdDocumentoCabecera)
                .Index(t => t.IdProducto)
                .Index(t => t.IdUnidadMedida);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CONT.DocumentoDetalle", "IdUnidadMedida", "CONF.UnidadMedida");
            DropForeignKey("CONT.DocumentoDetalle", "IdProducto", "CONT.Producto");
            DropForeignKey("CONT.DocumentoDetalle", "IdDocumentoCabecera", "CONT.DocumentoCabecera");
            DropIndex("CONT.DocumentoDetalle", new[] { "IdUnidadMedida" });
            DropIndex("CONT.DocumentoDetalle", new[] { "IdProducto" });
            DropIndex("CONT.DocumentoDetalle", new[] { "IdDocumentoCabecera" });
            DropTable("CONT.DocumentoDetalle");
        }
    }
}
