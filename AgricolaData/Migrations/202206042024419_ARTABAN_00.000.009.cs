namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000009 : DbMigration
    {
        public override void Up()
        {
            AddColumn("CONT.ArchivoOrden", "DetalleFacturas", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("CONT.ArchivoOrden", "DetalleFacturas");
        }
    }
}
