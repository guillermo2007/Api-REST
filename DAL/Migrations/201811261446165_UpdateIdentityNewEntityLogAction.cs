namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdentityNewEntityLogAction : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
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
            
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.LogActions");
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
