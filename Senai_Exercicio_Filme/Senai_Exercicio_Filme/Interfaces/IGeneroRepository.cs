using Senai_Exercicio_Filme.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Exercicio_Filme.Interfaces
{
    interface IGeneroRepository
    {
        List<GeneroDomain> ListarTodos();

        GeneroDomain BuscarPorId(int IDGenero);

        void Cadastrar(GeneroDomain NovoGenero);

        void AtualizarIdCorpo(GeneroDomain GeneroAtualizado);

        void AtualizarIdUrl(int IDGenero, GeneroDomain GeneroAtualizado);

        void Deletar(int IDGenero);
    }
}
