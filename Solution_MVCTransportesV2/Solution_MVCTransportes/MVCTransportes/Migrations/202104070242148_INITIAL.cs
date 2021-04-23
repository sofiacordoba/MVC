namespace MVCTransportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INITIAL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chofers",
                c => new
                    {
                        ChoferId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        DNI = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                        Ciudad = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ChoferId);
            
            CreateTable(
                "dbo.Vehiculoes",
                c => new
                    {
                        Matricula = c.String(nullable: false, maxLength: 128),
                        Modelo = c.String(),
                        Marca = c.String(nullable: false),
                        Caracteristicas = c.String(nullable: false),
                        ChoferAsignado_ChoferId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Matricula)
                .ForeignKey("dbo.Chofers", t => t.ChoferAsignado_ChoferId, cascadeDelete: true)
                .Index(t => t.ChoferAsignado_ChoferId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculoes", "ChoferAsignado_ChoferId", "dbo.Chofers");
            DropIndex("dbo.Vehiculoes", new[] { "ChoferAsignado_ChoferId" });
            DropTable("dbo.Vehiculoes");
            DropTable("dbo.Chofers");
        }
    }
}
