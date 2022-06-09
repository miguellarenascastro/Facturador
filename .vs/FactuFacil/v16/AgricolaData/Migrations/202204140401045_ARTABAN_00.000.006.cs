namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000006 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CONF.Categoria",
                c => new
                    {
                        IdCategoria = c.Long(nullable: false, identity: true),
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
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "CONF.Impuesto",
                c => new
                    {
                        IdImpuesto = c.Long(nullable: false, identity: true),
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
                .PrimaryKey(t => t.IdImpuesto);
            
            CreateTable(
                "CONT.Producto",
                c => new
                    {
                        IdProducto = c.Long(nullable: false, identity: true),
                        IdTipoItem = c.Long(nullable: false),
                        IdCategoria = c.Long(nullable: false),
                        IdUnidadMedida = c.Long(nullable: false),
                        IdImpuesto = c.Long(nullable: false),
                        Codigo = c.String(),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("CONF.Categoria", t => t.IdCategoria)
                .ForeignKey("CONF.Impuesto", t => t.IdImpuesto)
                .ForeignKey("CONF.TipoItem", t => t.IdTipoItem)
                .ForeignKey("CONF.UnidadMedida", t => t.IdUnidadMedida)
                .Index(t => t.IdTipoItem)
                .Index(t => t.IdCategoria)
                .Index(t => t.IdUnidadMedida)
                .Index(t => t.IdImpuesto);
            
            CreateTable(
                "CONF.TipoItem",
                c => new
                    {
                        IdTipoItem = c.Long(nullable: false, identity: true),
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
                .PrimaryKey(t => t.IdTipoItem);
            
            CreateTable(
                "CONF.UnidadMedida",
                c => new
                    {
                        IdUnidadMedida = c.Long(nullable: false, identity: true),
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
                .PrimaryKey(t => t.IdUnidadMedida);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CONT.Producto", "IdUnidadMedida", "CONF.UnidadMedida");
            DropForeignKey("CONT.Producto", "IdTipoItem", "CONF.TipoItem");
            DropForeignKey("CONT.Producto", "IdImpuesto", "CONF.Impuesto");
            DropForeignKey("CONT.Producto", "IdCategoria", "CONF.Categoria");
            DropIndex("CONT.Producto", new[] { "IdImpuesto" });
            DropIndex("CONT.Producto", new[] { "IdUnidadMedida" });
            DropIndex("CONT.Producto", new[] { "IdCategoria" });
            DropIndex("CONT.Producto", new[] { "IdTipoItem" });
            DropTable("CONF.UnidadMedida");
            DropTable("CONF.TipoItem");
            DropTable("CONT.Producto");
            DropTable("CONF.Impuesto");
            DropTable("CONF.Categoria");
        }
    }
}
