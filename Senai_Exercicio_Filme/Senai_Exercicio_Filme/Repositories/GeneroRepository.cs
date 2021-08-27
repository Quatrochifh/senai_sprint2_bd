using Senai_Exercicio_Filme.Domains;
using Senai_Exercicio_Filme.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Exercicio_Filme.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string stringConexao = @"Data Source=LAPTOP-DF9B3HCO\SQLEXPRESS; initial catalog=CATALOGO; user Id=sa; pwd=senai@132";


        public void AtualizarIdCorpo(GeneroDomain GeneroAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int IDGenero, GeneroDomain GeneroAtualizado)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int IDGenero)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain NovoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IDGenero)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            using (SqlConnection conexaoSql = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idGenero,nomeGenero FROM GENERO;";


                //Isso vai abrir a conexâo com o banco de dados
                conexaoSql.Open();

                //isso ira percocer a tabela de banco de dados
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, conexaoSql))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        GeneroDomain genero = new GeneroDomain()
                        {

                            idGenero = Convert.ToInt32(rdr[0]),


                            nomeGenero = rdr[1].ToString()
                        };

                        listaGenero.Add(genero);
                    }
                }
            };
            return listaGenero;
        }
    }
}
