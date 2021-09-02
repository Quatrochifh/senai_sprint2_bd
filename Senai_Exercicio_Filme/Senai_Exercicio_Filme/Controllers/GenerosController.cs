using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Exercicio_Filme.Domains;
using Senai_Exercicio_Filme.Interfaces;
using Senai_Exercicio_Filme.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Exercicio_Filme.Controllers
{
    [Produces("application/json")]


    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _GeneroRepository { get; set; }

        public GenerosController()
        {
            _GeneroRepository = new GeneroRepository();
        }

        [HttpGet]
        //IActionResult = Resultado de uma açâo.
        //Get() = nome generico
        public IActionResult Get()
        {
            //Devolver uma Lista de generos
            //Se conectar com o Repositorio.

            //Aqui é criado uma lista com o nome listaGenero onde ira receber os dados
            List<GeneroDomain> listaGenero = _GeneroRepository.ListarTodos();

            // ira retornar os status code 200(Ok) com a listaGenero no formato JSON
             return Ok(listaGenero);
        }


        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain NovoGenero)
        {
            _GeneroRepository.Cadastrar(NovoGenero);

            return StatusCode(201);
        }


        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// ex: http://localhost:5000/api/generos/excluir/9
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _GeneroRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return NoContent();
        }

    }
}
