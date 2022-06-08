namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000011 : DbMigration
    {
        public override void Up()
        {
            DropIndex("CONT.DocumentoDetalle", new[] { "IdProducto" });
            AddColumn("CONT.DocumentoDetalle", "DetalleDocumento", c => c.String());
            AlterColumn("CONT.DocumentoDetalle", "IdProducto", c => c.Long());
            CreateIndex("CONT.DocumentoDetalle", "IdProducto");
        }
        
        public override void Down()
        {
            DropIndex("CONT.DocumentoDetalle", new[] { "IdProducto" });
            AlterColumn("CONT.DocumentoDetalle", "IdProducto", c => c.Long(nullable: false));
            DropColumn("CONT.DocumentoDetalle", "DetalleDocumento");
            CreateIndex("CONT.DocumentoDetalle", "IdProducto");
        }
    }
}
