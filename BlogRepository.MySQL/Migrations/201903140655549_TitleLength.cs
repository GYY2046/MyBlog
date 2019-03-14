namespace BlogRepository_MySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitleLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(maxLength: 20, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(unicode: false));
        }
    }
}
