namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000008 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CONT.ArchivoOrden",
                c => new
                    {
                        IdArchivoOrden = c.Long(nullable: false, identity: true),
                        IdEmpresa = c.Long(nullable: false),
                        FechaOrden = c.DateTime(nullable: false),
                        UsuarioCarga = c.String(),
                        Detalle = c.String(),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdArchivoOrden);
            
            CreateTable(
                "CONT.FilaArchivoOrden",
                c => new
                    {
                        IdFilaArchivoOrden = c.Long(nullable: false, identity: true),
                        IdArchivoOrden = c.Long(nullable: false),
                        NumCedula = c.String(),
                        NombrePersona = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdFilaArchivoOrden)
                .ForeignKey("CONT.ArchivoOrden", t => t.IdArchivoOrden)
                .Index(t => t.IdArchivoOrden);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CONT.FilaArchivoOrden", "IdArchivoOrden", "CONT.ArchivoOrden");
            DropIndex("CONT.FilaArchivoOrden", new[] { "IdArchivoOrden" });
            DropTable("CONT.FilaArchivoOrden");
            DropTable("CONT.ArchivoOrden");
        }
    }
}
