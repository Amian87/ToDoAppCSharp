namespace ToDoAppConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        ToDoListID = c.Int(nullable: false, identity: true),
                        ToDoListName = c.String(),
                    })
                .PrimaryKey(t => t.ToDoListID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToDoLists");
        }
    }
}
