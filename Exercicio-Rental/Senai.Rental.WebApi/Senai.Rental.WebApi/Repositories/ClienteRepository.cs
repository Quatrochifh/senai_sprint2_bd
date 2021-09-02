using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private string stringConexao = @"Data Source=LAPTOP-DF9B3HCO\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=senai@132";

        public void AtualizarIdUrl(int idCliente, ClienteDomain AtualizadoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE CLIENTE SET nomeCliente = @nomeCliente WHERE idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", AtualizadoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeCliente, idCliente, sobrenomeCliente, cpfCliente FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),

                            nomeCliente = reader["nomeCliente"].ToString(),

                            sobrenomeCliente = reader["sobrenomeCliente"].ToString(),

                            cpfCliente = reader["cpfCliente"].ToString()
                        };

                        return clienteBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection conexaoSql = new SqlConnection(stringConexao))
            {
                string queryInsert = " INSERT INTO CLIENTE(nomeCliente,sobrenomeCliente,cpfCliente) VALUES(@nomeCliente, @sobrenomeCliente,@cpfCliente)";

                conexaoSql.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, conexaoSql))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);

                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);

                    cmd.Parameters.AddWithValue("@cpfCliente", novoCliente.cpfCliente);
                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection conexaoSql = new SqlConnection(stringConexao))
            {
                // Define a query a ser executada passando o id do gênero como parâmetro
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, conexaoSql))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @idGenero
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    // Abre a conexão com o banco de dados
                    conexaoSql.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaCliente = new List<ClienteDomain>();

            using (SqlConnection conexaoSql = new SqlConnection(stringConexao))
            { 
                string querySelectALL = "SELECT idCliente, nomeCliente, sobrenomeCliente, cpfCliente FROM CLIENTE;";

                conexaoSql.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, conexaoSql))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        ClienteDomain cliente = new ClienteDomain()
                        {

                            idCliente = Convert.ToInt32(rdr[0]),
                            nomeCliente = rdr[1].ToString(),
                            sobrenomeCliente = rdr[2].ToString(),
                            cpfCliente = rdr[3].ToString()
                        };
                        listaCliente.Add(cliente);
                    }
                }

            };
            return listaCliente;
        }
    }
}
