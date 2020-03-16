namespace projetgestionproduit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taille : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produit", "Designation", c => c.String(maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produit", "Designation", c => c.String());
        }
    }
}
