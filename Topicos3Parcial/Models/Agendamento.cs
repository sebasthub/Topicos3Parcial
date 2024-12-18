﻿using ProjetoEnsalamento.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Topicos3Parcial.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int SalaId { get; set; }
        public Sala Sala { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DataFutura(ErrorMessage = "A data não pode ser anterior à data atual.")]
        public DateTime Horario { get; set; }
        public Boolean Recorrente { get; set; }
    }

    public class DataFuturaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime data = Convert.ToDateTime(value);

            if (data < DateTime.Now)
            {
                return new ValidationResult("A data não pode ser anterior à data atual.");
            }

            return ValidationResult.Success;
        }
    }

}