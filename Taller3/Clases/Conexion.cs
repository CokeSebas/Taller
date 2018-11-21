using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace Taller3.Clases
{
    public class Conexion
    {

        //private static OracleConnection Conexion01 = new OracleConnection();

        //conexion alexis
        private static string strCadena = "Data Source=" + "localhost" + "; User Id= " + "taller" + "; Password=" + "taller" + ";";

        //conexion Jorge
        //private static string strCadena = "Data Source=" + "localhost" + "; User Id= " + "portafolio" + "; Password=" + "1234" + ";";

        public OracleConnection m = new OracleConnection(strCadena);
        string cmd = "";
        OracleCommand query;
        public OracleDataReader registros;
        private List<Cliente> clientes = new List<Cliente>();

        public bool OpenConnection()
        {
            try
            {
                /* usuario>Nombre de usuario en oracgle 11g
                 * pass>password de usuario en oracle 11g
                 * servidor> representa el servidor de nuestra maquina o el nombre de ella
                 * */
                m = new OracleConnection(strCadena);
                // abrimos la conexion
                m.Open();
                return true;
            }
            catch (Exception) //si ocurre un error
            {
                return false;
            }
        }
        //metodo para cerrar la conexion
        public bool closeConnection(){
            try
            {
                m.Close();
                return true;
            }
            catch (Exception) //si ocurre un error
            {
                return false;
            }

        }
       
        //funnciona
        public string Insert(string tabla, string campos)
        {
            try{
                OpenConnection();

                cmd = "INSERT INTO "+ tabla + " VALUES("+campos+")";
                query = new OracleCommand(cmd, m);
                query.ExecuteNonQuery();
                closeConnection();
                return "ok";
            }
            catch (Exception error)
            {
                //return "INSERT INTO "+ tabla + " VALUES("+campos+")";
                return error.Message;
            }
        }

        public string Insert2(string sql)
        {
            try
            {
                OpenConnection();

                cmd = sql;
                query = new OracleCommand(cmd, m);
                query.ExecuteNonQuery();
                closeConnection();
                return "ok";
            }
            catch (Exception error)
            {
                return sql;
                //return error.Message;
            }
        }

        //Elimina registro d ebase datos
        public string Eliminar(string tabla, string campo, string condicion)
        {
            try
            {
                OpenConnection();
                cmd = "DELETE FROM " + tabla + " WHERE " + campo +" = '" + condicion +"'";
                query = new OracleCommand(cmd, m);
                query.ExecuteNonQuery();
                closeConnection();
                return "ok";
            }
            catch (Exception error)
            {
                return error.Message;
            }
            
        }

        //actualizar datos, Funciona
        public string Actualizar(string tabla, string campos, string condicion)
        {
            try
            {
                OpenConnection();
                cmd = "UPDATE " + tabla + " SET " + campos + " WHERE " + condicion;
                query = new OracleCommand(cmd, m);
                query.ExecuteNonQuery();
                closeConnection();
                return "ok";
            }
            catch (Exception error)
            {
                return error.Message;
            }
            
        
        }

        public OracleDataAdapter ListaPrueba()
        {
            cmd = "SELECT * FROM prueba";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            OracleDataAdapter conecto2 = new OracleDataAdapter(cmd, m);
            return conecto2;
            /*registros = query.ExecuteReader();

            while (registros.Read())
            {
                Cliente objC = new Cliente();
                //string sexo, estadoCivil;

                objC.NombClie = registros["nombre"].ToString();
                objC.ApPatClie = registros["apellido"].ToString();
                clientes.Add(objC);
            }
            return clientes;*/
        }

        public OracleDataReader llenarCombo(string tabla, string order)
        {

            cmd = "SELECT * FROM " + tabla + " ORDER BY " + order;
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

        public OracleDataReader llenarComboProvincias(string region)
        {
            cmd = "SELECT * FROM provincia WHERE region_id = (SELECT region_id FROM regiones WHERE region_nombre = '" + region + "') ORDER BY provincia_id";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

        public OracleDataReader llenarComboCiud(string provincia)
        {
            cmd = "SELECT * FROM comuna WHERE id_provincia = (SELECT provincia_id FROM provincia WHERE provincia_nombre = '" + provincia + "') ORDER BY id_comuna";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

    }
}