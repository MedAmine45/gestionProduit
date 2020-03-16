namespace projetgestionproduit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorie",
                c => new
                    {
                        CategorieID = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.CategorieID);
            
            CreateTable(
                "dbo.Produit",
                c => new
                    {
                        ProduitID = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        Prix = c.Double(nullable: false),
                        Quantite = c.Int(nullable: false),
                        CategorieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProduitID)
                .ForeignKey("dbo.Categorie", t => t.CategorieID, cascadeDelete: true)
                .Index(t => t.CategorieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produit", "CategorieID", "dbo.Categorie");
            DropIndex("dbo.Produit", new[] { "CategorieID" });
            DropTable("dbo.Produit");
            DropTable("dbo.Categorie");
        }
    }
}
