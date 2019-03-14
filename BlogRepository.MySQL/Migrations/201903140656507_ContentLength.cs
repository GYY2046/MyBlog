namespace BlogRepository_MySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String(maxLength: 2000, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String(unicode: false));
        }
    }
}
