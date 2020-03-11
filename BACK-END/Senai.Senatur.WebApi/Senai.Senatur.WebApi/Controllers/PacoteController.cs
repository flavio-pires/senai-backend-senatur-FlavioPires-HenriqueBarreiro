using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos pacotes
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PacoteController : ControllerBase
    {
        private IPacoteRepository _pacoteRepository;

        public PacoteController()
        {
            _pacoteRepository = new PacoteRepository();
        }

        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns>Uma lista de pacotes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_pacoteRepository.Listar());
        }

        /// <summary>
        /// Busca um pacote através do ID
        /// </summary>
        /// <param name="id">ID do pacote que será buscado</param>
        /// <returns>Um pacote buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_pacoteRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="novoPacote">Objeto novoPacote que será cadastrado</param>
        /// <returns>Status Ok e uma mensagem personalizada</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            // Faz a chamada para o método
            _pacoteRepository.Cadastrar(novoPacote);

            // Retorna um status code
            return Ok("Novo pacote cadastrado!");
        }

        /// <summary>
        /// Atualiza um pacote existente
        /// </summary>
        /// <param name="id">ID do pacote que será atualizado</param>
        /// <param name="pacoteAtualizado">Objeto com as novas informações</param>
        /// <returns>Status Ok e uma mensagem personalizada</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacotes pacoteAtualizado)
        {
            // Faz a chamada para o método
            _pacoteRepository.Atualizar(id, pacoteAtualizado);

            // Retorna um status code
            return Ok("Pacote atualizado!");
        }

        /// <summary>
        /// Deleta um pacote existente
        /// </summary>
        /// <param name="id">ID do pacote que será deletado</param>
        /// <returns>Status Ok e uma mensagem personalizada</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _pacoteRepository.Deletar(id);

            // Retorna um status code
            return Ok("Pacote deletado!");
        }
    }
}