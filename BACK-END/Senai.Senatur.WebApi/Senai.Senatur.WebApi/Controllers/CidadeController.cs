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
    /// Controller responsável pelos endpoints referentes as cidades
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CidadeController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _cidadeRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private ICidadeRepository _cidadeRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public CidadeController()
        {
            _cidadeRepository = new CidadeRepository();
        }

        /// <summary>
        /// Lista todas as cidades
        /// </summary>
        /// <returns>Uma lista de cidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_cidadeRepository.Listar());
        }

        /// <summary>
        /// Busca uma cidade através do ID
        /// </summary>
        /// <param name="id">ID da cidade que será buscada</param>
        /// <returns>Uma cidade buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_cidadeRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova cidade
        /// </summary>
        /// <param name="novaCidade">Objeto novaCidade que será cadastrada</param>
        /// <returns>Status Ok e uma mensagem personalizada</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Cidades novaCidade)
        {
            // Faz a chamada para o método
            _cidadeRepository.Cadastrar(novaCidade);

            // Retorna um status code
            return Ok("Nova cidade cadastrada!");
        }

        /// <summary>
        /// Atualiza uma cidade existente
        /// </summary>
        /// <param name="id">ID da cidade que será atualizado</param>
        /// <param name="cidadeAtualizada">Objeto com as novas informações</param>
        /// <returns>Status Ok e uma mensagem personalizada</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Cidades cidadeAtualizada)
        {
            // Faz a chamada para o método
            _cidadeRepository.Atualizar(id, cidadeAtualizada);

            // Retorna um status code
            return Ok("Cidade atualizada!");
        }

        /// <summary>
        /// Deleta uma cidade existente
        /// </summary>
        /// <param name="id">ID da cidade que será deletada</param>
        /// <returns>Status Ok e uma mensagem personalizada</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _cidadeRepository.Deletar(id);

            // Retorna um status code
            return Ok("Cidade deletada!");
        }
        
    }
}