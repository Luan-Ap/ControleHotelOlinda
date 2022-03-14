using ControleHotel.Dominio.Entidades;
using ControleHotel.Dominio.Interfaces.Repository;
using ControleHotel.Infra.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleHotel.Infra.Repository
{
    public class CheckOutRepository : ICheckOutRepository
    {
        public bool SaveCheckOut(CheckOut checkOut, RegistroPagamento registro = null)
        {
            bool checkOutRealizado;

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                SqlCommand cm = new()
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                string comando = "";

                if(registro == null)
                {
                    comando = "SP_REALIZAR_CHECK_OUT";

                    cm.Parameters.AddWithValue("@Cod_CheckOut", checkOut.Codigo);
                    cm.Parameters.AddWithValue("@Cod_Hospedagem", checkOut.CodHospedagem);
                    cm.Parameters.AddWithValue("@Ativo", checkOut.Ativo);
                }
                else
                {
                    comando = "SP_REALIZAR_CHECK_OUT_CONSUMOS";

                    cm.Parameters.AddWithValue("@Cod_CheckOut", checkOut.Codigo);
                    cm.Parameters.AddWithValue("@Cod_Hospedagem", checkOut.CodHospedagem);
                    cm.Parameters.AddWithValue("@Forma_Pagto", registro.Forma.ToString());
                    cm.Parameters.AddWithValue("@Valor", registro.Valor);
                    cm.Parameters.AddWithValue("@Data_Pagto", registro.DataPagto);
                    cm.Parameters.AddWithValue("@Ativo", checkOut.Ativo);
                }

                cm.Connection = conn;
                cm.CommandText = comando;

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    checkOutRealizado = true;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    checkOutRealizado = false;
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return checkOutRealizado;
        }
    }
}
