namespace ToDoAppConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcompletionDatetostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "CompletionDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "CompletionDate", c => c.DateTime(nullable: false));
        }
    }
}
