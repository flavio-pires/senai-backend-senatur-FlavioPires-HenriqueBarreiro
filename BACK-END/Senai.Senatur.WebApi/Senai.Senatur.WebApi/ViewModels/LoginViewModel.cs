﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.ViewModels
{
    /// <summary>
    /// Classe responsável pelo modelo de Login
    /// </summary>
    public class LoginViewModel
    {
        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe o e-mail")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe a senha")]
        // Define o tipo do dado
        [DataType(DataType.Password)]
        // Define o tamanho da senha
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A senha deve ter entre 5 e 30 caracteres.")]
        public string Senha { get; set; }
    }
}
