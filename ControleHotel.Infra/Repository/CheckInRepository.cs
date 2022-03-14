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
    public class CheckInRepository : ICheckInRepository
    {

        public CheckInRepository(){ }
        public bool SaveCheckIn(CheckIn checkIn)
        {
            bool checkInRealizado;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                conn.Open();

                SqlTransaction transaction;
                var comando = "SP_FAZER_CHECKIN";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", checkIn.Codigo);
                cm.Parameters.AddWithValue("@Cod_Reserva", checkIn.CodReserva);
                cm.Parameters.AddWithValue("@Ativo", checkIn.Ativo);

                transaction = conn.BeginTransaction();
                cm.Transaction = transaction;

                try
                {
                    cm.ExecuteNonQuery();
                    transaction.Commit();
                    checkInRealizado = true;
                }
                catch
                {
                    transaction.Rollback();
                    checkInRealizado = false;
                }
            }

            return checkInRealizado;
        }
    }
}
