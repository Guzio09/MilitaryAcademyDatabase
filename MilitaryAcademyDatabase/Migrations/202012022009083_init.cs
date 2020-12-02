namespace MilitaryAcademyDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Academies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dormitories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        RoomsCount = c.Int(nullable: false),
                        Academy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Academies", t => t.Academy_Id)
                .Index(t => t.Academy_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Surname = c.String(),
                        PersonType = c.String(),
                        PhoneNumber = c.String(),
                        PersonRank = c.String(),
                        Dormitory_Id = c.Int(),
                        TrainingCycle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dormitories", t => t.Dormitory_Id)
                .ForeignKey("dbo.TrainingCycles", t => t.TrainingCycle_Id)
                .Index(t => t.Dormitory_Id)
                .Index(t => t.TrainingCycle_Id);
            
            CreateTable(
                "dbo.TrainingCycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StudentsCount = c.Int(nullable: false),
                        Academy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Academies", t => t.Academy_Id)
                .Index(t => t.Academy_Id);
            
            CreateTable(
                "dbo.AcademyObjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ObjectName = c.String(),
                        Street = c.String(),
                        Slots = c.Int(nullable: false),
                        TrainingCycle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingCycles", t => t.TrainingCycle_Id)
                .Index(t => t.TrainingCycle_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "TrainingCycle_Id", "dbo.TrainingCycles");
            DropForeignKey("dbo.AcademyObjects", "TrainingCycle_Id", "dbo.TrainingCycles");
            DropForeignKey("dbo.TrainingCycles", "Academy_Id", "dbo.Academies");
            DropForeignKey("dbo.People", "Dormitory_Id", "dbo.Dormitories");
            DropForeignKey("dbo.Dormitories", "Academy_Id", "dbo.Academies");
            DropIndex("dbo.AcademyObjects", new[] { "TrainingCycle_Id" });
            DropIndex("dbo.TrainingCycles", new[] { "Academy_Id" });
            DropIndex("dbo.People", new[] { "TrainingCycle_Id" });
            DropIndex("dbo.People", new[] { "Dormitory_Id" });
            DropIndex("dbo.Dormitories", new[] { "Academy_Id" });
            DropTable("dbo.AcademyObjects");
            DropTable("dbo.TrainingCycles");
            DropTable("dbo.People");
            DropTable("dbo.Dormitories");
            DropTable("dbo.Academies");
        }
    }
}
