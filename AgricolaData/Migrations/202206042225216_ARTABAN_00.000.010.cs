namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000010 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("CONT.DocumentoCabecera", "IdTipoDocumentoModificado", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("CONT.DocumentoCabecera", "IdTipoDocumentoModificado", c => c.Long(nullable: false));
        }
    }
}
