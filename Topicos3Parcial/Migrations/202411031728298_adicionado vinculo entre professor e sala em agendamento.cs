namespace Topicos3Parcial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionadovinculoentreprofessoresalaemagendamento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agendamentoes", "Professor_Id", "dbo.Professors");
            DropForeignKey("dbo.Agendamentoes", "Sala_Id", "dbo.Salas");
            DropIndex("dbo.Agendamentoes", new[] { "Professor_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Sala_Id" });
            RenameColumn(table: "dbo.Agendamentoes", name: "Professor_Id", newName: "ProfessorId");
            RenameColumn(table: "dbo.Agendamentoes", name: "Sala_Id", newName: "SalaId");
            AlterColumn("dbo.Agendamentoes", "ProfessorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Agendamentoes", "SalaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Agendamentoes", "ProfessorId");
            CreateIndex("dbo.Agendamentoes", "SalaId");
            AddForeignKey("dbo.Agendamentoes", "ProfessorId", "dbo.Professors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Agendamentoes", "SalaId", "dbo.Salas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentoes", "SalaId", "dbo.Salas");
            DropForeignKey("dbo.Agendamentoes", "ProfessorId", "dbo.Professors");
            DropIndex("dbo.Agendamentoes", new[] { "SalaId" });
            DropIndex("dbo.Agendamentoes", new[] { "ProfessorId" });
            AlterColumn("dbo.Agendamentoes", "SalaId", c => c.Int());
            AlterColumn("dbo.Agendamentoes", "ProfessorId", c => c.Int());
            RenameColumn(table: "dbo.Agendamentoes", name: "SalaId", newName: "Sala_Id");
            RenameColumn(table: "dbo.Agendamentoes", name: "ProfessorId", newName: "Professor_Id");
            CreateIndex("dbo.Agendamentoes", "Sala_Id");
            CreateIndex("dbo.Agendamentoes", "Professor_Id");
            AddForeignKey("dbo.Agendamentoes", "Sala_Id", "dbo.Salas", "Id");
            AddForeignKey("dbo.Agendamentoes", "Professor_Id", "dbo.Professors", "Id");
        }
    }
}
