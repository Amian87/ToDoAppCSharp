namespace ToDoAppConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedannotationstomodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "TaskDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "CompletionDate", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "TaskDescription", c => c.String());
            AlterColumn("dbo.Tasks", "CompletionDate", c => c.DateTime());
        }
    }
}
