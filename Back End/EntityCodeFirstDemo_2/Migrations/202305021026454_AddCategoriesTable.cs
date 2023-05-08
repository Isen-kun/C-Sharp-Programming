namespace EntityCodeFirstDemo_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("SET IDENTITY_INSERT Categories ON");

            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Web Development'), (2, 'Programming Languages');");
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
