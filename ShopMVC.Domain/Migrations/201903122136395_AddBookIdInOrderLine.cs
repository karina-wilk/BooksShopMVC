namespace ShopMVC.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookIdInOrderLine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderLines", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderLines", "BookId");
            AddForeignKey("dbo.OrderLines", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderLines", "BookId", "dbo.Books");
            DropIndex("dbo.OrderLines", new[] { "BookId" });
            DropColumn("dbo.OrderLines", "BookId");
        }
    }
}
