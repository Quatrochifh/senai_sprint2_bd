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
    // ex: http://localhost:5000/api/aluguel
    [Route("api/[controller]")]
    //Define que é um controlador de API.
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }
        public AluguelController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaCliente = _AluguelRepository.ListarTodos();

            return Ok(listaCliente);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarIdUrl(int id, AluguelDomain AtualizadoAluguel)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (aluguelBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Aluguel não encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _AluguelRepository.AtualizarIdUrl(id, AtualizadoAluguel);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // ex: http://localhost:5000/api/aluguel/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarPorId(id);

            if (aluguelBuscado == null)
            {
                return NotFound("Nenhum aluguel encontrado!");
            }

            return Ok(aluguelBuscado);
        }


        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _AluguelRepository.Cadastrar(novoAluguel);

            return StatusCode(201);
        }

        /// ex: http://localhost:5000/api/aluguel/excluir/9
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {

            _AluguelRepository.Deletar(id);

            return NoContent();
        }
    }
}
