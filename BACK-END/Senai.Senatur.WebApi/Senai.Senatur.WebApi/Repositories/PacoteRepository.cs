using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    /// <summary>
    /// Repository responsavel pelos Pacotes
    /// </summary>
    public class PacoteRepository : IPacoteRepository
    {
        SenaturContext ctx = new SenaturContext();

        /// <summary>
        /// Atualizar um Pacote 
        /// </summary>
        /// <param name="id">ID do pacote que sera atualizado</param>
        /// <param name="pacoteAtualizado">Objeto com as informações atualizadas</param>
        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {
            // Busca um pacote através do id
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            // Verifica se o nome do pacote foi informado
            if (pacoteAtualizado.NomePacote != null)
            {
                // Atribui os novos valores ao campos existentes
                pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            }

            // Atualiza o pacote que foi buscado
            ctx.Pacotes.Update(pacoteBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um pacote através do ID
        /// </summary>
        /// <param name="id">ID do pacote que será buscado</param>
        /// <returns>Um pacote buscado</returns>
        public Pacotes BuscarPorId(int id)
        {
            // Retorna o primeiro Pacote encontrado para o ID informado
            return ctx.Pacotes.FirstOrDefault(e => e.IdPacote == id);
        }

        /// <summary>
        /// Cadastra um novo Pacote
        /// </summary>
        /// <param name="novoPacote">Objeto novoPacote que será cadastrado</param>
        public void Cadastrar(Pacotes novoPacote)
        {
            // Adiciona este novoPacote
            ctx.Pacotes.Add(novoPacote);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar um pacote 
        /// </summary>
        /// <param name="id">ID do pacot5e que sera deletado</param>
        public void Deletar(int id)
        {
            // Busca um Pacote através do id
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            // Remove o Pacote que foi buscado
            ctx.Pacotes.Remove(pacoteBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Pacotes
        /// </summary>
        /// <returns>Uma lista de Pacotes</returns>
        public List<Pacotes> Listar()
        {
            // Retorna uma lista com todas as informações dos Pacotes
            return ctx.Pacotes.ToList();
        }
    }
}
