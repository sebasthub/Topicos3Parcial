using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEnsalamento.Models
{
    public class Andar
    {
        public int Id { get; set; }
        public string Indentificador { get; set;}
        public int BlocoId { get; set; }
        public Bloco Bloco { get; set; }
    }
}