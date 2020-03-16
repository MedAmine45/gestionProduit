namespace projetgestionproduit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredCategorie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categorie", "NomCategorie", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categorie", "NomCategorie", c => c.String());
        }
    }
}
