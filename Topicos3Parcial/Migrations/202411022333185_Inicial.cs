namespace Topicos3Parcial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
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
                        HorarioDisponivel = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        Nome = c.String(),
                        Curso_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursoes", t => t.Curso_Id)
                .Index(t => t.Curso_Id);
            
            CreateTable(
                "dbo.Andars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Indentificador = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blocoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Indentificador = c.String(),
                        Unidade_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Unidades", t => t.Unidade_ID)
                .Index(t => t.Unidade_ID);
            
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
            DropForeignKey("dbo.Blocoes", "Unidade_ID", "dbo.Unidades");
            DropForeignKey("dbo.Agendamentoes", "Sala_Id", "dbo.Salas");
            DropForeignKey("dbo.Salas", "Curso_Id", "dbo.Cursoes");
            DropForeignKey("dbo.Agendamentoes", "Professor_Id", "dbo.Professors");
            DropForeignKey("dbo.Professors", "Curso_Id", "dbo.Cursoes");
            DropIndex("dbo.Blocoes", new[] { "Unidade_ID" });
            DropIndex("dbo.Salas", new[] { "Curso_Id" });
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
