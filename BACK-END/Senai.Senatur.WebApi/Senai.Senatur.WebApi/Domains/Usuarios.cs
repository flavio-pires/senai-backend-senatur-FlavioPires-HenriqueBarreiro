using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuario
    /// </summary>
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve ter entre 5 e 30 caracteres.")]
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public TiposUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
