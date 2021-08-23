namespace SCM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        EmailAddressId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        EmailType = c.Int(nullable: false),
                        Contact_ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.EmailAddressId)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId)
                .Index(t => t.Contact_ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailAddresses", "Contact_ContactId", "dbo.Contacts");
            DropIndex("dbo.EmailAddresses", new[] { "Contact_ContactId" });
            DropTable("dbo.EmailAddresses");
            DropTable("dbo.Contacts");
        }
    }
}
