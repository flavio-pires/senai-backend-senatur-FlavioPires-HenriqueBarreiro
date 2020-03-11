using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    /// <summary>
    /// Repository responsavel pelas Cidades
    /// </summary> 

    public class CidadeRepository : ICidadeRepository
    {
        SenaturContext ctx = new SenaturContext();

        /// <summary>
        /// Atualizar uma cidade
        /// </summary>
        /// <param name="id">Id da cidade que sera atualizada</param>
        /// <param name="cidadeAtualizada">Objeto com as informações atualizadas</param>
        public void Atualizar(int id, Cidades cidadeAtualizada)
        {
            // Busca uma Cidade através do id
            Cidades cidadeBuscada = ctx.Cidades.Find(id);

            // Verifica se o nome da cidade foi informado
            if (cidadeAtualizada.NomeCidade != null)
            {
                // Atribui os novos valores aos campos existentes
                cidadeBuscada.NomeCidade = cidadeAtualizada.NomeCidade;
            }

            // Atualiza a cidade que foi buscado
            ctx.Cidades.Update(cidadeBuscada);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma Cidade através do ID
        /// </summary>
        /// <param name="id">ID da cidade que será buscada</param>
        /// <returns>Retorna a cidade buscada</returns>
        public Cidades BuscarPorId(int id)
        {
            // Retorna o primeira cidade encontrado para o ID informado
            return ctx.Cidades.FirstOrDefault(e => e.IdCidade == id);
        }

        /// <summary>
        /// Cadastra uma nova Cidade
        /// </summary>
        /// <param name="novaCidade">Objeto novaCidade que será cadastrado</param>
        public void Cadastrar(Cidades novaCidade)
        {
            // Adiciona esta novoCidade
            ctx.Cidades.Add(novaCidade);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar uma cidade
        /// </summary>
        /// <param name="id">ID da cidade que sera atualizada</param>
        public void Deletar(int id)
        {
            // Busca uma cidade através do id
            Cidades cidadeBuscada = ctx.Cidades.Find(id);

            // Remove a cidade que foi buscado
            ctx.Cidades.Remove(cidadeBuscada);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as Cidades
        /// </summary>
        /// <returns>Uma lista de Cidades</returns>
        public List<Cidades> Listar()
        {
            // Retorna uma lista com todas as Cidades
            return ctx.Cidades.ToList();
        }
    }
}
