namespace EntityCodeFirstDemo_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(nullable:false));
            Sql("UPDATE courses SET Name = Title");
            DropColumn("dbo.Courses", "Title");
            //RenameColumn("dbo.Courses", "Title", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable:false));
            Sql("UPDATE courses SET Title = Name");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
