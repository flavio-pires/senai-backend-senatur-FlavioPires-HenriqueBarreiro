using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    /// <summary>
    /// Repository responsavel pelos Tipos de Usuario
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SenaturContext ctx = new SenaturContext();

        /// <summary>
        /// Atualizar um Tipo de Usuario
        /// </summary>
        /// <param name="id">ID do tipo que sera atualizap</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com as informações atualizadas</param>
        public void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            // Busca um Tipo de Usuario através do id
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuario.Find(id);

            // Verifica se o nome do Tipo de Usuario foi informado
            if (tipoUsuarioAtualizado.Titulo != null)
            {
                // Atribui os novos valores ao campos existentes
                tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;
            }

            // Atualiza o pacote que foi buscado
            ctx.TiposUsuario.Update(tipoUsuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um TipoUsuario através do ID
        /// </summary>
        /// <param name="id">ID do TipoUSuario que será buscado</param>
        /// <returns>Um Tipo de usuario buscado</returns>
        public TiposUsuario BuscarPorId(int id)
        {
            // Retorna o primeiro Tipo de usuario encontrado para o ID informado
            return ctx.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo TipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            // Adiciona este novoTipoUsuario
            ctx.TiposUsuario.Add(novoTipoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar um Tipo de usuario
        /// </summary>
        /// <param name="id">ID do tipo de usuario que sera deletado</param>
        public void Deletar(int id)
        {
            // Busca um tipoUsuario através do id
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuario.Find(id);

            // Remove o tipoUsuario que foi buscado
            ctx.TiposUsuario.Remove(tipoUsuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os TiposUsuario
        /// </summary>
        /// <returns>Uma lista de TiposUsuario</returns>
        public List<TiposUsuario> Listar()
        {
            // Retorna uma lista com todas as informações dos estúdios
            return ctx.TiposUsuario.ToList();
        }
    }
}
