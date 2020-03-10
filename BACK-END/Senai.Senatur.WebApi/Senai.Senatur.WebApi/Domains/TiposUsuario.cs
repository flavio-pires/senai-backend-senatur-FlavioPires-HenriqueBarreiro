using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade TiposUsuario
    /// </summary>
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage ="O titulo do tipo de usuário é obrigatório!")]
        public string Titulo { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
