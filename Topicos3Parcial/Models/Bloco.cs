using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoEnsalamento.Models
{
    public class Bloco
    {
        public int Id { get; set; }
        public string Indentificador { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
        public ICollection<Andar> Andares { get; set; }
    }
}