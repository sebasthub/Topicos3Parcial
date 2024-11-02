using ProjetoEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Topicos3Parcial.Models
{
    public class AgendamentoDbContext: DbContext
    {
        public AgendamentoDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Bloco> Blocos { get; set;}
        public DbSet<Curso> Cursos { get; set;}
        public DbSet<Professor> Professores { get; set;}
        public DbSet<Andar> Andares { get; set;}
        public DbSet<Sala> Salas { get; set;}
        public DbSet<Agendamento> Agendamentos { get; set;}
    }
}