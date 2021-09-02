using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string stringConexaoVei = @"Data Source=LAPTOP-DF9B3HCO\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";
        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain AtualizadoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexaoVei))
            {
                string queryUpdateUrl = "UPDATE VEICULO SET PlacaVeiculo = @PlacaVeiculo WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@PlacaVeiculo", AtualizadoVeiculo.PlacaVeiculo);
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using(SqlConnection con = new SqlConnection(stringConexaoVei))
            {
                string querySelectById = "SELECT idVeiculo, idEmpresa, idModelo, PlacaVeiculo FROM VEICULO WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),

                            idEmpresa = Convert.ToInt32(reader["idEmpresa"]),

                            idModelo = Convert.ToInt32(reader["idModelo"]),

                            PlacaVeiculo = reader["PlacaVeiculo"].ToString()
                        };

                        return veiculoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection conexaoSql = new SqlConnection(stringConexaoVei))
            {
                string queryInsert = " INSERT INTO VEICULO(idEmpresa,idModelo,PlacaVeiculo) VALUES(@idEmpresa, @idModelo,@PlacaVeiculo)";

                conexaoSql.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, conexaoSql))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);

                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);

                    cmd.Parameters.AddWithValue("@PlacaVeiculo", novoVeiculo.PlacaVeiculo);
                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection conexaoSql = new SqlConnection(stringConexaoVei))
            {
                // Define a query a ser executada passando o id do gênero como parâmetro
                string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, conexaoSql))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    conexaoSql.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculo = new List<VeiculoDomain>();

            using (SqlConnection conexaoSql = new SqlConnection(stringConexaoVei))
            {
                string querySelectALL = "SELECT idVeiculo, idEmpresa, idModelo, PlacaVeiculo FROM VEICULO;";

                conexaoSql.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, conexaoSql))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        VeiculoDomain veiculo = new VeiculoDomain()
                        {

                            idVeiculo = Convert.ToInt32(rdr[0]),
                            idEmpresa = Convert.ToInt32(rdr[1]),
                            idModelo = Convert.ToInt32(rdr[2]),
                            PlacaVeiculo = rdr[1].ToString(),
                        };
                        listaVeiculo.Add(veiculo);
                    }
                }

            };
            return listaVeiculo;
        }
    }
}
