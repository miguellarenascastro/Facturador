namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("CONF.Empresa", "NumContribuyenteEspecial", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("CONF.Empresa", "NumContribuyenteEspecial");
        }
    }
}
