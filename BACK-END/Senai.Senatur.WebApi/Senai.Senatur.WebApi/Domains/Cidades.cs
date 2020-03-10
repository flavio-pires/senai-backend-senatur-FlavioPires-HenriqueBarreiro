using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class Cidades
    {
        /// <summary>
        /// Classe que representa a entidade Cidades
        /// </summary>
        public Cidades()
        {
            Pacotes = new HashSet<Pacotes>();
        }

        public int IdCidade { get; set; }

        //Define que a propriedade é obrigatória
        [Required(ErrorMessage ="O nome da cidade é obrigatório!")]
        public string NomeCidade { get; set; }

        public ICollection<Pacotes> Pacotes { get; set; }
    }
}
