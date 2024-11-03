namespace Topicos3Parcial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfessorId = c.Int(nullable: false),
                        SalaId = c.Int(nullable: false),
                        Horario = c.DateTime(nullable: false),
                        Recorrente = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.ProfessorId, cascadeDelete: true)
                .ForeignKey("dbo.Salas", t => t.SalaId, cascadeDelete: true)
                .Index(t => t.ProfessorId)
                .Index(t => t.SalaId);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Indentificador = c.String(),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursoes", t => t.CursoId, cascadeDelete: true)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        HorarioDisponivel = c.Int(nullable: false),
                        Descricao = c.String(),
                        Nome = c.String(),
                        AndarId = c.Int(nullable: false),
                        CursoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Andars", t => t.AndarId, cascadeDelete: true)
                .ForeignKey("dbo.Cursoes", t => t.CursoId)
                .Index(t => t.AndarId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Andars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Indentificador = c.String(maxLength: 4),
                        BlocoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blocoes", t => t.BlocoId, cascadeDelete: true)
                .Index(t => t.BlocoId);
            
            CreateTable(
                "dbo.Blocoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Indentificador = c.String(maxLength: 4),
                        UnidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Unidades", t => t.UnidadeId, cascadeDelete: true)
                .Index(t => t.UnidadeId);
            
            CreateTable(
                "dbo.Unidades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Localização = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salas", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Salas", "AndarId", "dbo.Andars");
            DropForeignKey("dbo.Blocoes", "UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Andars", "BlocoId", "dbo.Blocoes");
            DropForeignKey("dbo.Agendamentoes", "SalaId", "dbo.Salas");
            DropForeignKey("dbo.Professors", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Agendamentoes", "ProfessorId", "dbo.Professors");
            DropIndex("dbo.Blocoes", new[] { "UnidadeId" });
            DropIndex("dbo.Andars", new[] { "BlocoId" });
            DropIndex("dbo.Salas", new[] { "CursoId" });
            DropIndex("dbo.Salas", new[] { "AndarId" });
            DropIndex("dbo.Professors", new[] { "CursoId" });
            DropIndex("dbo.Agendamentoes", new[] { "SalaId" });
            DropIndex("dbo.Agendamentoes", new[] { "ProfessorId" });
            DropTable("dbo.Unidades");
            DropTable("dbo.Blocoes");
            DropTable("dbo.Andars");
            DropTable("dbo.Salas");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Professors");
            DropTable("dbo.Agendamentoes");
        }
    }
}
