using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    /// <summary>
    /// Repository responsavel pelos Usuarios
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        SenaturContext ctx = new SenaturContext();

        /// <summary>
        /// Atualizar um Usuario
        /// </summary>
        /// <param name="id">ID do Usuario que sera atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as informações atualizadas</param>
        public void Atualizar(int id, Usuarios usuarioAtualizado)
        {
            // Busca um usuario através do id
            Usuarios usuarioBuscado = ctx.Usuarios.Find(id);

            // Verifica se o Email do usuario foi informado
            if (usuarioAtualizado.Email != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            // Atualiza o Usuario que foi buscado
            ctx.Usuarios.Update(usuarioBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um usuario através do ID
        /// </summary>
        /// <param name="id">ID do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        public Usuarios BuscarPorId(int id)
        {
            // Retorna o primeiro Usuario encontrado para o ID informado
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void Cadastrar(Usuarios novoUsuario)
        {
            // Adiciona este novoUsuario
            ctx.Usuarios.Add(novoUsuario);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar um usuario
        /// </summary>
        /// <param name="id">ID do usuario que sera deleado</param>
        public void Deletar(int id)
        {
            // Busca um usuario através do id
            Usuarios usuarioBuscado = ctx.Usuarios.Find(id);

            // Remove o usuario que foi buscado
            ctx.Usuarios.Remove(usuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuarios 
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Usuarios> Listar()
        {
            // Retorna uma lista com todas as informações dos Usuarios
            return ctx.Usuarios.ToList();
        }
    }
}
