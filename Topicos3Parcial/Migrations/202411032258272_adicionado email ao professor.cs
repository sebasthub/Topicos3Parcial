namespace Topicos3Parcial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionadoemailaoprofessor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professors", "Email", c => c.String());
            AlterColumn("dbo.Professors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Professors", "Indentificador", c => c.String(nullable: false));
            AlterColumn("dbo.Cursoes", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Salas", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Salas", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Andars", "Indentificador", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Blocoes", "Indentificador", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blocoes", "Indentificador", c => c.String(maxLength: 4));
            AlterColumn("dbo.Andars", "Indentificador", c => c.String(maxLength: 4));
            AlterColumn("dbo.Salas", "Nome", c => c.String());
            AlterColumn("dbo.Salas", "Descricao", c => c.String());
            AlterColumn("dbo.Cursoes", "Nome", c => c.String());
            AlterColumn("dbo.Professors", "Indentificador", c => c.String());
            AlterColumn("dbo.Professors", "Name", c => c.String());
            DropColumn("dbo.Professors", "Email");
        }
    }
}
