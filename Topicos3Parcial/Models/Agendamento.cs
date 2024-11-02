using ProjetoEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Topicos3Parcial.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public Professor Professor { get; set; }
        public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Boolean Recorrente { get; set; }
    }
}