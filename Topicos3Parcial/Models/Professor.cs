using ProjetoEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Topicos3Parcial.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Indentificador { get; set; }
        public Curso Curso { get; set; }
    }
}