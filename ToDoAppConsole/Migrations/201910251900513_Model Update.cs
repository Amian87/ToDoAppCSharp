namespace ToDoAppConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate : DbMigration
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
                        CompletionDate = c.String(),
                    })
                .PrimaryKey(t => t.TaskID);
            
            DropTable("dbo.ToDoLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        ToDoListID = c.Int(nullable: false, identity: true),
                        ToDoListName = c.String(),
                    })
                .PrimaryKey(t => t.ToDoListID);
            
            DropTable("dbo.Tasks");
            DropTable("dbo.Lists");
        }
    }
}
