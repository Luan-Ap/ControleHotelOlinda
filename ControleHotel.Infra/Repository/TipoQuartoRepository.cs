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
    public class TipoQuartoRepository : ITipoQuartoRepository
    {
        public TipoQuarto GetTipoQuartoByCod(Guid? cod)
        {
            TipoQuarto tipoQuarto = null;

            using (SqlConnection conn = new SqlConnection(DbHelper.ConnectionString))
            {
                var comando = "SP_SELECIONAR_TIPO_QUARTO_CODIGO";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cm.Parameters.AddWithValue("@Cod", cod);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            tipoQuarto = new TipoQuarto(cod: Guid.Parse(dr["Cod_Tipo"].ToString()), valor: Convert.ToDouble(dr["Valor"]), tipo: dr["Tipo"].ToString(), maxAcomp: Convert.ToInt32(dr["Max_Acompanhantes"]), ativo: Convert.ToBoolean(dr["Ativo_Tipo"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }

            return tipoQuarto;
        }

        public IEnumerable<TipoQuarto> GetTiposQuarto()
        {
            List<TipoQuarto> tipoQuartos = new();

            using (SqlConnection conn = new(DbHelper.ConnectionString))
            {
                var comando = "SP_LISTAR_TIPO_QUARTOS";
                SqlCommand cm = new(comando, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                TipoQuarto tipo = null;

                try
                {
                    conn.Open();
                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            tipo = new TipoQuarto(cod: Guid.Parse(dr["Cod_Tipo"].ToString()), valor: Convert.ToDouble(dr["Valor"]), tipo: dr["Tipo"].ToString(), maxAcomp: Convert.ToInt32(dr["Max_Acompanhantes"]), ativo: Convert.ToBoolean(dr["Ativo_Tipo"]));

                            tipoQuartos.Add(tipo);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return tipoQuartos;
        }
    }
}
