namespace Topicos3Parcial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacaoblocounidade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blocoes", "Unidade_ID", "dbo.Unidades");
            DropIndex("dbo.Blocoes", new[] { "Unidade_ID" });
            RenameColumn(table: "dbo.Blocoes", name: "Unidade_ID", newName: "UnidadeId");
            AlterColumn("dbo.Blocoes", "UnidadeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blocoes", "UnidadeId");
            AddForeignKey("dbo.Blocoes", "UnidadeId", "dbo.Unidades", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blocoes", "UnidadeId", "dbo.Unidades");
            DropIndex("dbo.Blocoes", new[] { "UnidadeId" });
            AlterColumn("dbo.Blocoes", "UnidadeId", c => c.Int());
            RenameColumn(table: "dbo.Blocoes", name: "UnidadeId", newName: "Unidade_ID");
            CreateIndex("dbo.Blocoes", "Unidade_ID");
            AddForeignKey("dbo.Blocoes", "Unidade_ID", "dbo.Unidades", "ID");
        }
    }
}
