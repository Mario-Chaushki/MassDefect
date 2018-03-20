namespace MassDefect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anomalies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginPlanetId = c.Int(nullable: false),
                        TeleportPlanetId = c.Int(nullable: false),
                        Planet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planets", t => t.Planet_Id)
                .ForeignKey("dbo.Planets", t => t.OriginPlanetId)
                .ForeignKey("dbo.Planets", t => t.TeleportPlanetId)
                .Index(t => t.OriginPlanetId)
                .Index(t => t.TeleportPlanetId)
                .Index(t => t.Planet_Id);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SunId = c.Int(nullable: false),
                        SolarSystemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SolarSystems", t => t.SolarSystemId)
                .ForeignKey("dbo.Stars", t => t.SunId)
                .Index(t => t.SunId)
                .Index(t => t.SolarSystemId);
            
            CreateTable(
                "dbo.SolarSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SolarSystemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SolarSystems", t => t.SolarSystemId)
                .Index(t => t.SolarSystemId);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        HomePlanetId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stars", t => t.HomePlanetId)
                .Index(t => t.HomePlanetId);
            
            CreateTable(
                "dbo.AnomalyVictims",
                c => new
                    {
                        AnomalyId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnomalyId, t.PersonId })
                .ForeignKey("dbo.Anomalies", t => t.AnomalyId, cascadeDelete: true)
                .ForeignKey("dbo.Persons", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.AnomalyId)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnomalyVictims", "PersonId", "dbo.Persons");
            DropForeignKey("dbo.AnomalyVictims", "AnomalyId", "dbo.Anomalies");
            DropForeignKey("dbo.Persons", "HomePlanetId", "dbo.Stars");
            DropForeignKey("dbo.Anomalies", "TeleportPlanetId", "dbo.Planets");
            DropForeignKey("dbo.Anomalies", "OriginPlanetId", "dbo.Planets");
            DropForeignKey("dbo.Planets", "SunId", "dbo.Stars");
            DropForeignKey("dbo.Planets", "SolarSystemId", "dbo.SolarSystems");
            DropForeignKey("dbo.Stars", "SolarSystemId", "dbo.SolarSystems");
            DropForeignKey("dbo.Anomalies", "Planet_Id", "dbo.Planets");
            DropIndex("dbo.AnomalyVictims", new[] { "PersonId" });
            DropIndex("dbo.AnomalyVictims", new[] { "AnomalyId" });
            DropIndex("dbo.Persons", new[] { "HomePlanetId" });
            DropIndex("dbo.Stars", new[] { "SolarSystemId" });
            DropIndex("dbo.Planets", new[] { "SolarSystemId" });
            DropIndex("dbo.Planets", new[] { "SunId" });
            DropIndex("dbo.Anomalies", new[] { "Planet_Id" });
            DropIndex("dbo.Anomalies", new[] { "TeleportPlanetId" });
            DropIndex("dbo.Anomalies", new[] { "OriginPlanetId" });
            DropTable("dbo.AnomalyVictims");
            DropTable("dbo.Persons");
            DropTable("dbo.Stars");
            DropTable("dbo.SolarSystems");
            DropTable("dbo.Planets");
            DropTable("dbo.Anomalies");
        }
    }
}
