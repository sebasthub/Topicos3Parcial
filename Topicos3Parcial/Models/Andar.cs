using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoEnsalamento.Models
{
    public class Andar
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(4, ErrorMessage = "O indentificador não pode ter mais de 4 letras ou numeros")]
        public string Indentificador { get; set;}
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int BlocoId { get; set; }
        public Bloco Bloco { get; set; }

        public ICollection<Sala> Sala { get; set; }

    }
}