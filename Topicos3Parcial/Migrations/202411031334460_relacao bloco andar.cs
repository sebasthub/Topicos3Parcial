namespace Topicos3Parcial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacaoblocoandar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Andars", "BlocoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Andars", "BlocoId");
            AddForeignKey("dbo.Andars", "BlocoId", "dbo.Blocoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Andars", "BlocoId", "dbo.Blocoes");
            DropIndex("dbo.Andars", new[] { "BlocoId" });
            DropColumn("dbo.Andars", "BlocoId");
        }
    }
}
