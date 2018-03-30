using Colegio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Colegio.Repositorio
{
    public class TipoEstudianteRepositorio
    {
        private SqlConnection cnx;

        private void connection()
        {
            String cadena = ConfigurationManager.ConnectionStrings["CNX_COLEGIO"].ToString();
            cnx = new SqlConnection(cadena);
        }

        //LISTAR TIPO DE ESTUDIANTE
        public List<TipoEstudianteModel> TipoEstudianteLista()
        {
            connection();//Llama a la cadena de conexión
            List<TipoEstudianteModel> TipoLista = new List<TipoEstudianteModel>();
            SqlCommand sql = new SqlCommand("PRC_TIPO_ESTUDIANTE_SELECT", cnx);
            sql.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            cnx.Open();
            da.Fill(dt);
            cnx.Close();


            foreach (DataRow dr in dt.Rows)
            {

                TipoLista.Add(
                                new TipoEstudianteModel //Hace referencia al modelo
                                {
                                    TipoEstudianteId = Convert.ToInt32(dr["TIPO_ESTUDIANTE_ID"]),
                                    TipoEstudiante = Convert.ToString(dr["TIPO_ESTUDIANTE"])
                                });
            }

            return TipoLista;

        }

        public bool TipoEstudianteInsert(TipoEstudianteModel obj)
        {
            connection(); //Llama a la cadena de conexión
            SqlCommand sql = new SqlCommand("PRC_TIPO_ESTUDIANTE_INSERT", cnx);
            sql.CommandType = CommandType.StoredProcedure;
            //sql.Parameters.AddWithValue("@TIPO_ESTUDIANTE_ID", obj.TipoEstudianteId);
            sql.Parameters.AddWithValue("@TIPO_ESTUDIANTE", obj.TipoEstudiante);

            cnx.Open();
            int i = sql.ExecuteNonQuery();
            cnx.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool TipoEstudianteUpdate(TipoEstudianteModel obj)
        {
            connection(); //Llama a la cadena de conexión
            SqlCommand sql = new SqlCommand("PRC_TIPO_ESTUDIANTE_UPDATE", cnx);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@TIPO_ESTUDIANTE_ID", obj.TipoEstudianteId);
            sql.Parameters.AddWithValue("@TIPO_ESTUDIANTE", obj.TipoEstudiante);//obj llama a variable de modelo

            cnx.Open();
            int i = sql.ExecuteNonQuery();
            cnx.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool TipoEstudianteDelete(int id)
        {
            connection(); //Llama a la cadena de conexión
            SqlCommand sql = new SqlCommand("PRC_TIPO_ESTUDIANTE_DELETE", cnx);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@TIPO_ESTUDIANTE_ID", id);

            cnx.Open();
            int i = sql.ExecuteNonQuery();
            cnx.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}