namespace projetgestionproduit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class designation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categorie", "NomCategorie", c => c.String());
            DropColumn("dbo.Categorie", "Designation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categorie", "Designation", c => c.String());
            DropColumn("dbo.Categorie", "NomCategorie");
        }
    }
}
