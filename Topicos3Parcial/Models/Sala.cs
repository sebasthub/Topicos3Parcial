using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEnsalamento.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime HorarioDisponivel { get; set; }
        public String Descricao { get; set; }
        public String Nome { get; set; }
        public Curso Curso { get; set; } = null;
    }
}