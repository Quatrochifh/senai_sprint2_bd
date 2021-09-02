using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {

        private string stringConexaoAlu = @"Data Source=LAPTOP-DF9B3HCO\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarIdUrl(int idAluguel, AluguelDomain AtualizadoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexaoAlu))
            {
                string queryUpdateUrl = "UPDATE ALUGUEL SET Descricao = @Descricao WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Descricao", AtualizadoAluguel.Descricao);
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {

            using (SqlConnection con = new SqlConnection(stringConexaoAlu))
            {
                string querySelectById = "SELECT idAluguel, idVeiculo, idCliente, Descricao FROM ALUGUEL WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"]),

                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),

                            idCliente = Convert.ToInt32(reader["idCliente"]),

                            Descricao = reader["Descricao"].ToString()
                        };

                        return aluguelBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection conexaoSql = new SqlConnection(stringConexaoAlu))
            {
                string queryInsert = " INSERT INTO ALUGUEL(idVeiculo,idCliente,Descricao) VALUES(@idVeiculo, @idCliente,@Descricao)";

                conexaoSql.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, conexaoSql))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);

                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);

                    cmd.Parameters.AddWithValue("@Descricao", novoAluguel.Descricao);
                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection conexaoSql = new SqlConnection(stringConexaoAlu))
            {
                // Define a query a ser executada passando o id do gênero como parâmetro
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, conexaoSql))
                {                  
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    
                    conexaoSql.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAluguel = new List<AluguelDomain>();

            using (SqlConnection conexaoSql = new SqlConnection(stringConexaoAlu))
            {
                string querySelectALL = "SELECT idAluguel, idVeiculo, idCliente, Descricao FROM ALUGUEL;";

                conexaoSql.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, conexaoSql))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        AluguelDomain aluguel = new AluguelDomain()
                        {

                            idAluguel = Convert.ToInt32(rdr[0]),
                            idVeiculo = Convert.ToInt32(rdr[1]),
                            idCliente = Convert.ToInt32(rdr[2]),
                            Descricao = rdr[1].ToString(),                                                   
                        };
                        listaAluguel.Add(aluguel);
                    }
                }

            };
            return listaAluguel;
        }
    }
}
