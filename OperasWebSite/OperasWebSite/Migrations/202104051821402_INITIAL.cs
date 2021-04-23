namespace OperasWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INITIAL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operas",
                c => new
                    {
                        OperaId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Year = c.Int(nullable: false),
                        Composer = c.String(),
                    })
                .PrimaryKey(t => t.OperaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Operas");
        }
    }
}
