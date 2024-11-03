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
                        Horario = c.DateTime(nullable: false),
                        Recorrente = c.Boolean(nullable: false),
                        Professor_Id = c.Int(),
                        Sala_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.Professor_Id)
                .ForeignKey("dbo.Salas", t => t.Sala_Id)
                .Index(t => t.Professor_Id)
                .Index(t => t.Sala_Id);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Indentificador = c.String(),
                        Curso_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursoes", t => t.Curso_Id)
                .Index(t => t.Curso_Id);
            
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
                        Indentificador = c.String(),
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
                        Indentificador = c.String(),
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
            DropForeignKey("dbo.Agendamentoes", "Sala_Id", "dbo.Salas");
            DropForeignKey("dbo.Agendamentoes", "Professor_Id", "dbo.Professors");
            DropForeignKey("dbo.Professors", "Curso_Id", "dbo.Cursoes");
            DropForeignKey("dbo.Salas", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Salas", "AndarId", "dbo.Andars");
            DropForeignKey("dbo.Blocoes", "UnidadeId", "dbo.Unidades");
            DropForeignKey("dbo.Andars", "BlocoId", "dbo.Blocoes");
            DropIndex("dbo.Blocoes", new[] { "UnidadeId" });
            DropIndex("dbo.Andars", new[] { "BlocoId" });
            DropIndex("dbo.Salas", new[] { "CursoId" });
            DropIndex("dbo.Salas", new[] { "AndarId" });
            DropIndex("dbo.Professors", new[] { "Curso_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Sala_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Professor_Id" });
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
