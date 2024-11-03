using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Topicos3Parcial.Models;

namespace ProjetoEnsalamento.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public String Nome { get; set; }

        public ICollection<Sala> Sala { get; set; }
        public ICollection<Professor> Professores { get; set; }
    }
}