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


        /// <summary>
        /// Cadastro um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto nomeGenero com as informações que serão cadastradas.</param>
        public void Cadastrar(GeneroDomain NovoGenero)
        {
            using (SqlConnection conexaoSql = new SqlConnection(stringConexao))
            {
                // "INSERT INTO GENERO (nomeGenero) VALUES ('teste')"
                // "INSERT INTO GENERO (nomeGenero) VALUES ('Joana D'Arc')"  / erro de sintaxe, com o efeito Joana D'Arc
                // "INSERT INTO GENERO (nomeGenero) VALUES ('')DROP TABLE FILME--')"   / isso permite uma SQL Injection

                // string queryInsert = "INSERT INTO GENERO (nomeGenero) VALUES ('" + NovoGenero.nomeGenero + "')";
                // Não usar dessa forma, pois pode causar o efeito Joana D'Arc

                // Além de permitir SQL Injectionpor exemplo:
                // "nomeGenero" : "')DROP TABLE FILME--"
                // Ao tentar cadastrar usando o comando acima, irá deletar a tabela FILME do banco de dados
                // https://www.devmedia.com.br/sql-injection/6102

                string queryInsert = "INSERT INTO GENERO(nomeGenero) VALUES(@nomeGenero)";

                //Isso vai abrir a conexâo com o banco de dados
                conexaoSql.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, conexaoSql))
                {
                    cmd.Parameters.AddWithValue("@nomeGenero", NovoGenero.nomeGenero);

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idGenero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection conexaoSql = new SqlConnection(stringConexao))
            {
                // Define a query a ser executada passando o id do gênero como parâmetro
                string queryDelete = "DELETE FROM GENERO WHERE idGenero = @idGenero";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, conexaoSql))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @idGenero
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);

                    // Abre a conexão com o banco de dados
                    conexaoSql.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
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
