using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Exercicio_Filme.Domains
{
    public class FilmeDomain
    {
        public int IDFilme { get; set; }
        public int IDGenero { get; set; }
        public string NomeFilme { get; set; }
        public GeneroDomain Genero { get; set; }
    }
}
