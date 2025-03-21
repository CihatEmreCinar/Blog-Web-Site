namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mmig10Gallery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Title = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GalleryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Galleries");
        }
    }
}
