namespace ProductsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.ProductSubCategories",
                c => new
                    {
                        ProductSubcategoryID = c.Int(nullable: false, identity: true),
                        ProductCategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSubcategoryID)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryID, cascadeDelete: true)
                .Index(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ProductNumber = c.String(nullable: false),
                        SafetyStockLevel = c.Int(nullable: false),
                        StandardCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ListPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ModifiedDate = c.DateTime(nullable: false),
                        Size = c.String(maxLength: 50),
                        ProductLine = c.String(maxLength: 10),
                        ProductSubcategoryID = c.Int(nullable: false),
                        DiscontinuedDate = c.DateTime(nullable: false),
                        Color = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductSubCategories", t => t.ProductSubcategoryID, cascadeDelete: true)
                .Index(t => t.ProductSubcategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSubCategories", "ProductCategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.Products", "ProductSubcategoryID", "dbo.ProductSubCategories");
            DropIndex("dbo.Products", new[] { "ProductSubcategoryID" });
            DropIndex("dbo.ProductSubCategories", new[] { "ProductCategoryID" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductSubCategories");
            DropTable("dbo.ProductCategories");
        }
    }
}
