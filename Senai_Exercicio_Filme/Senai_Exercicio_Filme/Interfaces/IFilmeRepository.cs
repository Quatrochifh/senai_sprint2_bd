using Senai_Exercicio_Filme.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Exercicio_Filme.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> ListarTodos();

        FilmeDomain BuscarPorId(int IDFilme);

        void Cadastrar(FilmeDomain NovoFilme);

        void AtualizarIdCorpo(FilmeDomain FilmeAtualizadoCorpo);

        void AtualizarIdUrl(int IDFilme, FilmeDomain filmeAtualizadoURL);

        void Deletar(int IDFilme);
    }
}
