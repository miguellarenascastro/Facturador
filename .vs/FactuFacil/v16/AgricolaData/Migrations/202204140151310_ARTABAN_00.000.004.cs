namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CONF.Persona",
                c => new
                    {
                        IdPersona = c.Long(nullable: false, identity: true),
                        IdTipoTipoPersona = c.Long(nullable: false),
                        EsContribuyenteEspecial = c.Boolean(nullable: false),
                        Ruc = c.String(),
                        RazonSocial = c.String(),
                        NombreComercial = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        Extranjero = c.Boolean(nullable: false),
                        Correo = c.String(),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdPersona)
                .ForeignKey("CONF.TipoPersona", t => t.IdTipoTipoPersona)
                .Index(t => t.IdTipoTipoPersona);
            
            CreateTable(
                "CONF.TipoPersona",
                c => new
                    {
                        IdTipoPersona = c.Long(nullable: false, identity: true),
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
                .PrimaryKey(t => t.IdTipoPersona);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CONF.Persona", "IdTipoTipoPersona", "CONF.TipoPersona");
            DropIndex("CONF.Persona", new[] { "IdTipoTipoPersona" });
            DropTable("CONF.TipoPersona");
            DropTable("CONF.Persona");
        }
    }
}
