namespace projetgestionproduit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supprimerMortality : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Mortality");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Mortality",
                c => new
                    {
                        MortalityId = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        SmokerValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NonSmokerValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SmokerValueHic1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NonSmokerValueHic1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MortalityId);
            
        }
    }
}
