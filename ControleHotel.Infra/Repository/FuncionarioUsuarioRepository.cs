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
    public class FuncionarioUsuarioRepository : IFuncionarioUsuarioRepository
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioUsuarioRepository()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        public IEnumerable<FuncionarioUsuario> GetFuncionarioUsuario()
        {
            List<FuncionarioUsuario> funcionarios = new();

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_FUNCIONARIOS_USUARIOS";
                SqlCommand cm = new SqlCommand(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                FuncionarioUsuario func = null;
                Endereco endereco = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            func = new FuncionarioUsuario(cod: Guid.Parse(dr["Codigo"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), ctps: dr["CTPS"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, email: dr["Email"].ToString(), salario: Convert.ToDouble(dr["Salario"]), cargo: dr["Cargo"].ToString(), usuario: dr["Usuario"].ToString(), senha: dr["Senha"].ToString(), nivelAcesso: Convert.ToInt32(dr["Acesso"]), dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Endereco"]));

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

        public FuncionarioUsuario GetFuncionarioUsuarioByCod(Guid? cod)
        {
            FuncionarioUsuario func = null;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_FUNCIONARIO_USUARIO_COD";
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
                            func = new FuncionarioUsuario(cod: Guid.Parse(dr["Codigo"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), ctps: dr["CTPS"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, email: dr["Email"].ToString(), salario: Convert.ToDouble(dr["Salario"]), cargo: dr["Cargo"].ToString(), usuario: dr["Usuario"].ToString(), senha: dr["Senha"].ToString(), nivelAcesso: Convert.ToInt32(dr["Acesso"]), dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Endereco"]));

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

        public FuncionarioUsuario GetFuncionarioUsuarioByLogin(string usuario, string senha)
        {
            FuncionarioUsuario func = null;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_FUNCIONARIO_USUARIO_LOGIN";
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
                            func = new FuncionarioUsuario(cod: Guid.Parse(dr["Codigo"].ToString()), nome: dr["Nome"].ToString(), sobrenome: dr["Sobrenome"].ToString(), cpf: dr["CPF"].ToString(), rg: dr["RG"].ToString(), ctps: dr["CTPS"].ToString(), codEndereco: Guid.Parse(dr["Cod_Endereco"].ToString()), endereco: null, email: dr["Email"].ToString(), salario: Convert.ToDouble(dr["Salario"]), cargo: dr["Cargo"].ToString(), usuario: dr["Usuario"].ToString(), senha: dr["Senha"].ToString(), nivelAcesso: Convert.ToInt32(dr["Acesso"]), dataNasc: Convert.ToDateTime(dr["Nascimento"]), dataCad: Convert.ToDateTime(dr["Cadastro"]), ativo: Convert.ToBoolean(dr["Ativo_Func"]));

                            endereco = new Endereco(cod: Guid.Parse(dr["Cod_Endereco"].ToString()), textEndereco: dr["Endereco"].ToString(), num: dr["Numero"].ToString(), cep: dr["CEP"].ToString(), telefone: dr["Telefone"].ToString(), estado: dr["Estado"].ToString(), ativo: Convert.ToBoolean(dr["Ativo_Endereco"]));

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

        public bool SaveFuncionarioUsuario(FuncionarioUsuario func)
        {
            bool usuarioInserido;

            var funcInserido = _funcionarioRepository.SaveFuncionario(func);

            if (funcInserido == true)
            {
                using (SqlConnection conn = new(DbHelper.ConnectionString))
                {
                    conn.Open();

                    SqlTransaction transaction;
                    var comando = "SP_CADASTRAR_FUNCIONARIO_USUARIO";
                    SqlCommand cm = new(comando, conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cm.Parameters.AddWithValue("@Cod", func.Codigo);
                    cm.Parameters.AddWithValue("@Usuario", func.Usuario);
                    cm.Parameters.AddWithValue("@Senha", func.Senha);
                    cm.Parameters.AddWithValue("@Nivel", func.NivelAcesso);
                    cm.Parameters.AddWithValue("@Ativo", func.Ativo);

                    transaction = conn.BeginTransaction();
                    cm.Transaction = transaction;

                    try
                    {
                        cm.ExecuteNonQuery();
                        transaction.Commit();
                        usuarioInserido = true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        usuarioInserido = false;
                    }
                }
            }
            else
            {
                usuarioInserido = false;
            }

            return usuarioInserido;
        }

        public bool UpdateFuncionarioUsuario(FuncionarioUsuario func)
        {
            bool funcAtualizado;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                var comando = "UPDATE Funcionario_Usuario SET Usuario = @Usuario, Senha = @Senha, Nivel_Acesso = @Acesso WHERE Codigo = @Cod";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.Text
                };

                cm.Parameters.AddWithValue("@Usuario", func.Usuario);
                cm.Parameters.AddWithValue("@Senha", func.Senha);
                cm.Parameters.AddWithValue("@Acesso", func.NivelAcesso);
                cm.Parameters.AddWithValue("@Cod", func.Codigo);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    funcAtualizado = true;
                }
                catch
                {
                    transaction.Rollback();
                    funcAtualizado = false;
                }
            }

            return funcAtualizado;
        }
    }
}
