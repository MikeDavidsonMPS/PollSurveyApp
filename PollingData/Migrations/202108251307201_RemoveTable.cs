namespace PollingData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.Employee", new[] { "UserId" });
            AddColumn("dbo.ApplicationUser", "Admin", c => c.Boolean(nullable: false));
            DropTable("dbo.Employee");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Department = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            DropColumn("dbo.ApplicationUser", "Admin");
            CreateIndex("dbo.Employee", "UserId");
            AddForeignKey("dbo.Employee", "UserId", "dbo.ApplicationUser", "Id");
        }
    }
}
