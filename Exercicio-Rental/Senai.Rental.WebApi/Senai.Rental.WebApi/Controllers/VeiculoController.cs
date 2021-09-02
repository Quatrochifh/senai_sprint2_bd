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
    // ex: http://localhost:5000/api/veiculo
    [Route("api/[controller]")]
    //Define que é um controlador de API.
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private IVeiculoRepository _VeiculoRepository { get; set; }
        public VeiculoController()
        {
            _VeiculoRepository = new VeiculoRepository();           
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarIdUrl(int id, VeiculoDomain AtualizadoVeiculo)
        {
            VeiculoDomain veiculoBuscado = _VeiculoRepository.BuscarPorId(id);

            if (veiculoBuscado == null)
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
                _VeiculoRepository.AtualizarIdUrl(id, AtualizadoVeiculo);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



        // ex: http://localhost:5000/api/veiculo/3
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain veiculoBuscado = _VeiculoRepository.BuscarPorId(id);

            if (veiculoBuscado == null)
            {
                return NotFound("Nenhum veiculo encontrado!");
            }

            return Ok(veiculoBuscado);
        }



        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _VeiculoRepository.Cadastrar(novoVeiculo);

            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculo = _VeiculoRepository.ListarTodos();

            return Ok(listaVeiculo);
        }


        /// ex: http://localhost:5000/api/veiculo/excluir/9
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {

            _VeiculoRepository.Deletar(id);

            return NoContent();
        }


    }
}
