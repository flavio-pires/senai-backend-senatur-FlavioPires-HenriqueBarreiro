using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Pacotes
    /// </summary>
    public partial class Pacotes
    {
        public int IdPacote { get; set; }

        [Required(ErrorMessage = "O nome do pacote é obrigatório!")]
        public string NomePacote { get; set; }

        [Required(ErrorMessage = "A descrição do pacote é obrigatória!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de ida do pacote é obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime DataIda { get; set; }

        [Required(ErrorMessage = "A data de volta do pacote é obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime DataVolta { get; set; }

        [Required(ErrorMessage = "O valor do pacote é obrigatório!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O ativo do pacote é obrigatório!")]
        public bool? Ativo { get; set; }
        public int? IdCidade { get; set; }

        public Cidades IdCidadeNavigation { get; set; }
    }
}
