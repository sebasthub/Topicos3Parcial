namespace Topicos3Parcial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criadorelacaoprofessorcurso : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Professors", "Curso_Id", "dbo.Cursoes");
            DropIndex("dbo.Professors", new[] { "Curso_Id" });
            RenameColumn(table: "dbo.Professors", name: "Curso_Id", newName: "CursoId");
            AlterColumn("dbo.Professors", "CursoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Professors", "CursoId");
            AddForeignKey("dbo.Professors", "CursoId", "dbo.Cursoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Professors", "CursoId", "dbo.Cursoes");
            DropIndex("dbo.Professors", new[] { "CursoId" });
            AlterColumn("dbo.Professors", "CursoId", c => c.Int());
            RenameColumn(table: "dbo.Professors", name: "CursoId", newName: "Curso_Id");
            CreateIndex("dbo.Professors", "Curso_Id");
            AddForeignKey("dbo.Professors", "Curso_Id", "dbo.Cursoes", "Id");
        }
    }
}
