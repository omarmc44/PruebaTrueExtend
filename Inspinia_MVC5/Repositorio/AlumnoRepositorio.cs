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
    public class AlumnoRepositorio
    {
        private SqlConnection cnx;

        private void connection()
        {
            String cadena = ConfigurationManager.ConnectionStrings["CNX_COLEGIO"].ToString();
            cnx = new SqlConnection(cadena);
        }

        //LISTAR TIPO DE ESTUDIANTE
        public List<AlumnoModel> AlumnoLista()
        {
            connection();//Llama a la cadena de conexión
            List<AlumnoModel> AlumnoLista = new List<AlumnoModel>();
            SqlCommand sql = new SqlCommand("PRC_ALUMNO_SELECT", cnx);
            sql.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            cnx.Open();
            da.Fill(dt);
            cnx.Close();


            foreach (DataRow dr in dt.Rows)
            {

                AlumnoLista.Add(
                                new AlumnoModel //Hace referencia al modelo
                                {
                                    AlmunoId = Convert.ToInt32(dr["ALUMNO_ID"]),
                                    TipoEstudianteId = Convert.ToInt32(dr["TIPO_ESTUDIANTE_ID"]),
                                    TipoEstudiante = Convert.ToString(dr["TIPO_ESTUDIANTE"]),
                                    AlumnoNombre = Convert.ToString(dr["ALUMNO_NOMBRE"]),
                                    AlumnoApaterno = Convert.ToString(dr["ALUMNO_APATERNO"]),
                                    AlumnoAmaterno = Convert.ToString(dr["ALUMNO_AMATERNO"]),
                                    Timestamp = Convert.ToString(dr["TIMESTAMP"])
                                });
            }

            return AlumnoLista;

        }

        public bool AlumnoInsert(AlumnoModel obj)
        {
            connection(); //Llama a la cadena de conexión
            SqlCommand sql = new SqlCommand("PRC_ALUMNO_INSERT", cnx);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@TIPO_ESTUDIANTE_ID", obj.TipoEstudianteId);
            sql.Parameters.AddWithValue("@ALUMNO_NOMBRE", obj.AlumnoNombre);
            sql.Parameters.AddWithValue("@ALUMNO_APATERNO", obj.AlumnoApaterno);
            sql.Parameters.AddWithValue("@ALUMNO_AMATERNO", obj.AlumnoAmaterno);

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

        public bool AlumnoUpdate(AlumnoModel obj)
        {
            connection(); //Llama a la cadena de conexión
            SqlCommand sql = new SqlCommand("PRC_ALUMNO_UPDATE", cnx);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@ALUMNO_ID", obj.AlmunoId);
            sql.Parameters.AddWithValue("@ALUMNO_NOMBRE", obj.AlumnoNombre);
            sql.Parameters.AddWithValue("@ALUMNO_APATERNO", obj.AlumnoApaterno);
            sql.Parameters.AddWithValue("@ALUMNO_AMATERNO", obj.AlumnoAmaterno);
            sql.Parameters.AddWithValue("@TIPO_ESTUDIANTE_ID", obj.TipoEstudianteId);//obj llama a variable de modelo

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

        public bool AlumnoDelete(int id)
        {
            connection(); //Llama a la cadena de conexión
            SqlCommand sql = new SqlCommand("PRC_ALUMNO_DELETE", cnx);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@ALUMNO_ID", id);

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