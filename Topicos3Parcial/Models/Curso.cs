using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Topicos3Parcial.Models;

namespace ProjetoEnsalamento.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public String Nome { get; set; }

        public ICollection<Sala> Sala { get; set; }
        public ICollection<Professor> Professores { get; set; }
    }
}