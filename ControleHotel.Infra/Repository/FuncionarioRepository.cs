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
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public FuncionarioRepository()
        {
            _enderecoRepository = new EnderecoRepository();
        }

        public bool DesativarFuncionario(Guid? cod)
        {
            bool funcDesativado;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                var comando = "UPDATE Funcionario SET Ativo = 0 WHERE Codigo = @Cod; UPDATE Funcionario_Usuario SET Ativo = 0 WHERE Codigo = @Cod;";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.Text
                };

                cm.Parameters.AddWithValue("@Cod", cod);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    funcDesativado = true;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    funcDesativado = false;
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return funcDesativado;
        }

        public Funcionario GetFuncionarioByCod(Guid? cod)
        {
            Funcionario func = null;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_FUNCIONARIO_COD";
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
                            func = new Funcionario(cod: Guid.Parse(dr["Cod_Func"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), ctps: dr["CTPS"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, email: dr["Email"].ToString(), salario: Convert.ToDouble(dr["Salario"]), cargo: dr["Cargo"].ToString(), dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            func.AdicionarComplemento(endereco);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }

            return func;
        }

        public Funcionario GetFuncionarioByCpf(string cpf)
        {
            Funcionario func = null;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_FUNCIONARIO_CPF";
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
                            func = new Funcionario(cod: Guid.Parse(dr["Cod_Func"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), ctps: dr["CTPS"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, email: dr["Email"].ToString(), salario: Convert.ToDouble(dr["Salario"]), cargo: dr["Cargo"].ToString(), dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            func.AdicionarComplemento(endereco);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return func;
        }

        public IEnumerable<Funcionario> GetFuncionarioByName(string nome, string sobrenome)
        {
            List<Funcionario> funcionarios = new();

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_FUNCIONARIO_NOME";
                SqlCommand cm = new SqlCommand(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Usuario", nome);
                cm.Parameters.AddWithValue("@Senha", sobrenome);

                Funcionario func = null;
                Endereco endereco = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            func = new Funcionario(cod: Guid.Parse(dr["Cod_Func"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), ctps: dr["CTPS"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, email: dr["Email"].ToString(), salario: Convert.ToDouble(dr["Salario"]), cargo: dr["Cargo"].ToString(), dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            func.AdicionarComplemento(endereco);

                            funcionarios.Add(func);

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return funcionarios;
        }

        public IEnumerable<Funcionario> GetFuncionarios()
        {
            List<Funcionario> funcionarios = new();

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_FUNCIONARIOS";
                SqlCommand cm = new SqlCommand(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                Funcionario func = null;
                Endereco endereco = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            func = new Funcionario(cod: Guid.Parse(dr["Cod_Func"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), ctps: dr["CTPS"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, email: dr["Email"].ToString(), salario: Convert.ToDouble(dr["Salario"]), cargo: dr["Cargo"].ToString(), dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            func.AdicionarComplemento(endereco);

                            funcionarios.Add(func);

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return funcionarios;
        }

        public bool SaveFuncionario(Funcionario func)
        {
            bool funcInserido;

            var enderecoInserido = _enderecoRepository.SaveEndereco(func.Endereco);

            if (enderecoInserido)
            {
                using (SqlConnection conn = new(DbHelper.ConnectionString))
                {
                    conn.Open();

                    SqlTransaction transaction;
                    var comando = "SP_CADASTRAR_FUNCIONARIO";
                    SqlCommand cm = new(comando, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cm.Parameters.AddWithValue("@Cod", func.Codigo);
                    cm.Parameters.AddWithValue("@Nome", func.Nome);
                    cm.Parameters.AddWithValue("@Sobrenome", func.Sobrenome);
                    cm.Parameters.AddWithValue("@Cpf", func.Cpf);
                    cm.Parameters.AddWithValue("@Rg", func.Rg);
                    cm.Parameters.AddWithValue("@Ctps", func.Ctps);
                    cm.Parameters.AddWithValue("@Email", func.Email);
                    cm.Parameters.AddWithValue("@Cod_Endereco", func.CodEndereco);
                    cm.Parameters.AddWithValue("@Cargo", func.Cargo);
                    cm.Parameters.AddWithValue("@Salario", func.Salario);
                    cm.Parameters.AddWithValue("@Data_Nascimento", func.DataNascimento.Date.ToUniversalTime());
                    cm.Parameters.AddWithValue("@Data_Cadastro", func.DataCadastro.Date.ToUniversalTime());
                    cm.Parameters.AddWithValue("@Ativo", func.Ativo);

                    transaction = conn.BeginTransaction();
                    cm.Transaction = transaction;

                    try
                    {
                        cm.ExecuteNonQuery();
                        transaction.Commit();
                        funcInserido = true;
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        funcInserido = false;
                        throw new Exception(ex.Message, ex.InnerException);
                    }
                }
            }
            else
            {
                funcInserido = false;
            }

            return funcInserido;
        }

        public bool UpdateFuncionario(Funcionario func)
        {
            bool funcAtualizado;

            var enderecoAtualizado = _enderecoRepository.UpdateEndereco(func.Endereco);

            if (enderecoAtualizado)
            {
                using (SqlConnection conn = new(DbHelper.ConnectionString))
                {
                    conn.Open();

                    SqlTransaction transaction;
                    var comando = "UPDATE Funcionario SET Nome = @Nome, Sobrenome = @Sobrenome, Email = @Email, Cargo = @Cargo, Salario = @Salario WHERE Codigo = @Cod";
                    SqlCommand cm = new(comando, conn)
                    {
                        CommandType = CommandType.Text
                    };

                    cm.Parameters.AddWithValue("@Nome", func.Nome);
                    cm.Parameters.AddWithValue("@Sobrenome", func.Sobrenome);
                    cm.Parameters.AddWithValue("@Email", func.Email);
                    cm.Parameters.AddWithValue("@Cargo", func.Cargo);
                    cm.Parameters.AddWithValue("@Salario", func.Salario);
                    cm.Parameters.AddWithValue("@Cod", func.Codigo);

                    transaction = conn.BeginTransaction();
                    cm.Transaction = transaction;

                    try
                    {
                        cm.ExecuteNonQuery();
                        transaction.Commit();
                        funcAtualizado = true;
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        funcAtualizado = false;
                        throw new Exception(ex.Message, ex.InnerException);
                    }
                }
            }
            else
            {
                funcAtualizado = false;
            }

            return funcAtualizado;
        }
    }
}
