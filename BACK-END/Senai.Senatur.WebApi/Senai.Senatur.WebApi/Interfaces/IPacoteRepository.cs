using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo Pacote Repository
    /// </summary>
    interface IPacoteRepository
    {
        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns>Retorna uma lista com todos os pacotes</returns>
        List<Pacotes> Listar();

        /// <summary>
        /// Busca um pacote pelo Id
        /// </summary>
        /// <param name="id">Id do pacote que será buscado</param>
        /// <returns>Retorna o pacote buscado através do Id</returns>
        Pacotes BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="novoPacote">Objeto que será cadastrado o novoPacote</param>
        void Cadastrar(Pacotes novoPacote);

        /// <summary>
        /// Átualiza um pacote existente
        /// </summary>
        /// <param name="id">Id do pacote que será atualizado</param>
        /// <param name="pacoteAtualizado">Objeto que armazenará os dados do pacote atualizado</param>
        void Atualizar(int id, Pacotes pacoteAtualizado);

        /// <summary>
        /// Deleta um pacote existente
        /// </summary>
        /// <param name="id">Id do pacote que será deletado</param>
        void Deletar(int id);
    }
}
