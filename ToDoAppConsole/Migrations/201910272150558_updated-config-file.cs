namespace ToDoAppConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedconfigfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        ListName = c.String(),
                    })
                .PrimaryKey(t => t.ListID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        ListID = c.Int(nullable: false),
                        TaskDescription = c.String(),
                        CompletionDate = c.DateTime(nullable: true),
                        TaskStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tasks");
            DropTable("dbo.Lists");
        }
    }
}
