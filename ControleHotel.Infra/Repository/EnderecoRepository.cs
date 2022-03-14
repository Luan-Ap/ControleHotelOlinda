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
    public class EnderecoRepository : IEnderecoRepository
    {
        public bool SaveEndereco(Endereco endereco)
        {
            bool enderecoInserido;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                var comando = "SP_CADASTRAR_ENDERECO";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", endereco.Codigo);
                cm.Parameters.AddWithValue("@Endereco", endereco.TextoEndereco);
                cm.Parameters.AddWithValue("@Num", endereco.Numero);
                cm.Parameters.AddWithValue("@Cep", endereco.Cep);
                cm.Parameters.AddWithValue("@Tel", endereco.Telefone);
                cm.Parameters.AddWithValue("@Estado", endereco.Estado);
                cm.Parameters.AddWithValue("@Ativo", endereco.Ativo);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    enderecoInserido = true;
                }
                catch
                {
                    transaction.Rollback();
                    enderecoInserido = false;
                }
            }

            return enderecoInserido;
        }

        public bool UpdateEndereco(Endereco endereco)
        {
            bool enderecoAtualizado;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                var comando = "UPDATE Endereco SET Endereco = @Endereco, Numero = @Num, Cep = @Cep, Telefone = @Tel, Estado =  @Estado, Ativo = @Ativo WHERE Codigo = @Cod";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.Text
                };

                cm.Parameters.AddWithValue("@Endereco", endereco.TextoEndereco);
                cm.Parameters.AddWithValue("@Num", endereco.Numero);
                cm.Parameters.AddWithValue("@Cep", endereco.Cep);
                cm.Parameters.AddWithValue("@Tel", endereco.Telefone);
                cm.Parameters.AddWithValue("@Estado", endereco.Estado);
                cm.Parameters.AddWithValue("@Ativo", endereco.Ativo);
                cm.Parameters.AddWithValue("@Cod", endereco.Codigo);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    enderecoAtualizado = true;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    enderecoAtualizado = false;
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return enderecoAtualizado;
        }
    }
}
