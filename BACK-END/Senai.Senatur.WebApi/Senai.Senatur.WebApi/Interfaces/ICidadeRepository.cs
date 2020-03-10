using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo Cidades Repository
    /// </summary>
    interface ICidadeRepository
    {
        /// <summary>
        /// Lista todas as cidades
        /// </summary>
        /// <returns>Retorna uma lista de todas as cidades</returns>
        List<Cidades> Listar();

        /// <summary>
        /// Busca uma cidade pelo Id
        /// </summary>
        /// <param name="id">Id da cidade que será buscada</param>
        /// <returns>Retorna a cidade buscada pelo Id</returns>
        Cidades BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova cidade
        /// </summary>
        /// <param name="novaCidade">Objeto que armazenará a nova cidade que será cadastrada</param>
        void Cadastrar(Cidades novaCidade);

        /// <summary>
        /// Atualiza uma cidade existente
        /// </summary>
        /// <param name="id">Id da cidade que será atualizada</param>
        /// <param name="cidadeAtualizada">Objeto com as novas informações</param>
        void Atualizar(int id, Cidades cidadeAtualizada);

        /// <summary>
        /// Deleta uma cidade existente
        /// </summary>
        /// <param name="id">Id da cidade que será deletada</param>
        void Deletar(int id);
    }
}
