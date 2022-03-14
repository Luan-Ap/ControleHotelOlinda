using ControleHotel.Dominio.Entidades;
using ControleHotel.Dominio.Interfaces.Repository;
using ControleHotel.Infra.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteRepository()
        {
            _enderecoRepository = new EnderecoRepository();
        }

        public bool DesativarCliente(Guid? cod)
        {
            bool clienteDesativado;

            using(SqlConnection conn = new(DbHelper.ConnectionString))
            {
                SqlTransaction transaction;
                var comando = "UPDATE Cliente SET Ativo = 0 WHERE Codigo = @Cod";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.Text
                };

                cm.Parameters.AddWithValue("@Cod", cod);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    conn.Open();
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    clienteDesativado = true;
                }
                catch
                {
                    transaction.Rollback();
                    clienteDesativado = false;
                }
            }

            return clienteDesativado;
        }

        public Cliente GetClienteByCod(Guid? cod)
        {
            Cliente cliente = null;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_CLIENTE_COD";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", cod);

                Endereco endereco = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cliente = new Cliente(cod: Guid.Parse(dr["Cod_Cliente"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), email: dr["Email"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Cliente"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Cliente"]));

                            cliente.AdicionarComplemento(endereco);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }

            return cliente;
        }

        public Cliente GetClienteByCpf(string cpf)
        {
            Cliente cliente = null;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_CLIENTE_CPF";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cpf", cpf);

                Endereco endereco = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cliente = new Cliente(cod: Guid.Parse(dr["Cod_Cliente"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), email: dr["Email"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Cliente"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Cliente"]));

                            cliente.AdicionarComplemento(endereco);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return cliente;
        }

        public Cliente GetClienteByLogin(string usuario, string senha)
        {
            Cliente cliente = null;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_CLIENTE_LOGIN";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Usuario", usuario);
                cm.Parameters.AddWithValue("@Senha", senha);

                Endereco endereco = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cliente = new Cliente(cod: Guid.Parse(dr["Cod_Cliente"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), email: dr["Email"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Cliente"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Cliente"]));

                            cliente.AdicionarComplemento(endereco);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return cliente;
        }

        public IEnumerable<Cliente> GetClienteByName(string nome, string sobrenome)
        {
            List<Cliente> clientes = new();

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_CLIENTE_NOME";
                SqlCommand cm = new SqlCommand(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Nome", nome);
                cm.Parameters.AddWithValue("@Sobrenome", sobrenome);

                Cliente cliente = null;
                Endereco endereco = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cliente = new Cliente(cod: Guid.Parse(dr["Cod_Cliente"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), email: dr["Email"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Cliente"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Cliente"]));

                            cliente.AdicionarComplemento(endereco);

                            clientes.Add(cliente);

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return clientes;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            List<Cliente> clientes = new();

            using(SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_CLIENTES";
                SqlCommand cm = new SqlCommand(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                Cliente cliente = null;
                Endereco endereco = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();
                    
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cliente = new Cliente(cod: Guid.Parse(dr["Cod_Cliente"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), email: dr["Email"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Cliente"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Cliente"]));

                            cliente.AdicionarComplemento(endereco);

                            clientes.Add(cliente);

                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return clientes;
        }

        public bool SaveCliente(Cliente cliente)
        {
            bool clienteInserido;

            var enderecoInserido = _enderecoRepository.SaveEndereco(cliente.Endereco);

            if (enderecoInserido)
            {
                using (SqlConnection conn = new(DbHelper.ConnectionString))
                {
                    conn.Open();

                    SqlTransaction transaction;
                    var comando = "SP_CADASTRAR_CLIENTE";
                    SqlCommand cm = new(comando, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cm.Parameters.AddWithValue("@Cod", cliente.Codigo);
                    cm.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cm.Parameters.AddWithValue("@Sobrenome", cliente.Sobrenome);
                    cm.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    cm.Parameters.AddWithValue("@Rg", cliente.Rg);
                    cm.Parameters.AddWithValue("@Email", cliente.Email);
                    cm.Parameters.AddWithValue("@Cod_Endereco", cliente.CodEndereco);
                    cm.Parameters.AddWithValue("@Data_Nascimento", cliente.DataNascimento.Date.ToUniversalTime());
                    cm.Parameters.AddWithValue("@Data_Cadastro", cliente.DataCadastro.Date.ToUniversalTime());
                    cm.Parameters.AddWithValue("@Ativo", cliente.Ativo);

                    transaction = conn.BeginTransaction();
                    cm.Transaction = transaction;

                    try
                    {
                        cm.ExecuteNonQuery();
                        transaction.Commit();
                        clienteInserido = true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        clienteInserido = false;
                    }
                }
            }
            else
            {
                clienteInserido = false;
            }

            return clienteInserido;
        }

        public bool UpdateCliente(Cliente cliente)
        {
            bool clienteAtualizado;

            var enderecoAtualizado = _enderecoRepository.UpdateEndereco(cliente.Endereco);

            if (enderecoAtualizado)
            {
                using (SqlConnection conn = new(DbHelper.ConnectionString))
                {
                    conn.Open();

                    SqlTransaction transaction;
                    var comando = "UPDATE Cliente SET Nome = @Nome, Sobrenome = @Sobrenome, Email = @Email WHERE Codigo = @Cod";
                    SqlCommand cm = new(comando, conn)
                    {
                        CommandType = CommandType.Text
                    };

                    cm.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cm.Parameters.AddWithValue("@Sobrenome", cliente.Sobrenome);
                    cm.Parameters.AddWithValue("@Email", cliente.Email);
                    cm.Parameters.AddWithValue("@Cod", cliente.Codigo);

                    transaction = conn.BeginTransaction();
                    cm.Transaction = transaction;

                    try
                    {
                        cm.ExecuteNonQuery();
                        transaction.Commit();
                        clienteAtualizado = true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        clienteAtualizado = false;
                    }
                }
            }
            else
            {
                clienteAtualizado = false;
            }

            return clienteAtualizado;
        }
    }
}
