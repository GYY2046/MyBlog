namespace BlogRepository_MySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClickCount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Content = c.String(unicode: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        ModifyDate = c.DateTime(nullable: false, precision: 0),
                        Author = c.String(unicode: false),
                        IsPublish = c.Boolean(nullable: false),
                        ClickCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
