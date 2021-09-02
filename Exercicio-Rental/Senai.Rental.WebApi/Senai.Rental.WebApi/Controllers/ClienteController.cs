using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato domino/api/nomeController.
    // ex: http://localhost:5000/api/cliente
    [Route("api/[controller]")]
    //Define que é um controlador de API.
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _ClienteRepository { get; set; }
         public ClienteController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaCliente = _ClienteRepository.ListarTodos();
            
            return Ok(listaCliente);
        }

        // ex: http://localhost:5000/api/cliente/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound("Nenhum gênero encontrado!");
            }

            return Ok(clienteBuscado);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, ClienteDomain AtualizadoCliente)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Cliente não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _ClienteRepository.AtualizarIdUrl(id, AtualizadoCliente);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }




        [HttpPost]
        public IActionResult Post(ClienteDomain novoCliente)
        {
            _ClienteRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }

        /// ex: http://localhost:5000/api/cliente/excluir/9
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _ClienteRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return NoContent();
        }




    }
}
