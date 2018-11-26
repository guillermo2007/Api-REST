namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialiseProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogActions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateTimeAction = c.DateTime(nullable: false),
                        OperationName = c.String(),
                        ScopeType = c.String(),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.LogActions");
        }
    }
}
