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
        //private static string strCadena = "Data Source=" + "localhost" + "; User Id= " + "taller" + "; Password=" + "taller" + ";";

        //conexion Jorge
        private static string strCadena = "Data Source=" + "localhost" + "; User Id= " + "portafolio" + "; Password=" + "1234" + ";";

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

        public OracleDataAdapter ListaPrueba()
        {
            cmd = "SELECT * FROM prueba";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            OracleDataAdapter conecto2 = new OracleDataAdapter(cmd, m);
            return conecto2;
        }

        public OracleDataAdapter LlenarGrilla(string tabla)
        {
            cmd = "SELECT * FROM "+tabla;
            OpenConnection();
            query = new OracleCommand(cmd, m);
            OracleDataAdapter conecto2 = new OracleDataAdapter(cmd, m);
            return conecto2;
        }

        public void comitear()
        {
            OpenConnection();

            cmd = "COMMIT";
            query = new OracleCommand(cmd, m);
            query.ExecuteNonQuery();
            closeConnection();
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
                comitear();
                return "ok";
            }
            catch (Exception error)
            {
                //return "INSERT INTO "+ tabla + " VALUES("+campos+")";
                return error.Message;
            }
        }

        //funciona
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
                return sql + error.Message;
                //return error.Message;
            }
        }

        //funciona
        public string guardarEmpleado(string codEmp, string rutEmp, string nombEmp, string apPat, string apMat, string fecNac, string fecIngr, 
                                      string fecTerm, string fono, string movil, string direccion, string sueldo, string usuario, 
                                      string password, string cargo, string region, string provincia, string comuna)
        {
            try{
                OpenConnection();
                OracleCommand comando = new OracleCommand("sp_empleado", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("codemp", codEmp);
                comando.Parameters.Add("rutemp", rutEmp);
                comando.Parameters.Add("nombre", nombEmp);
                comando.Parameters.Add("apellido1", apPat);
                comando.Parameters.Add("apellido2", apMat);
                comando.Parameters.Add("fenac", fecNac);
                comando.Parameters.Add("feingreso", fecIngr);
                comando.Parameters.Add("fetermino", fecTerm);
                comando.Parameters.Add("fono", fono);
                comando.Parameters.Add("movil", movil);
                comando.Parameters.Add("direccion", direccion);
                comando.Parameters.Add("sueldo", sueldo);
                comando.Parameters.Add("usuario", usuario);
                comando.Parameters.Add("password", password);
                comando.Parameters.Add("cargo", cargo);
                comando.Parameters.Add("region", region);
                comando.Parameters.Add("provincia", provincia);
                comando.Parameters.Add("comuna", comuna);
                comando.ExecuteNonQuery();
                return "Registro de Empleado Exitoso";
                //CerrarConexion();
            }
            catch (Exception error)
            {

                return error.Message;
            }
        }


        //funciona
        public string modificaEmpl(string codEmp, string rutEmp, string nombEmp, string apPat, string apMat, string fecNac, string fecIngr,
                                      string fecTerm, string fono, string movil, string direccion, string sueldo, string usuario,
                                      string password, string cargo, string region, string provincia, string comuna)
        {
            try
            {
                OpenConnection();
                OracleCommand comando = new OracleCommand("sp_modificaEmpleado", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_codemp", codEmp);
                comando.Parameters.Add("p_rutemp", rutEmp);
                comando.Parameters.Add("p_nombre", nombEmp);
                comando.Parameters.Add("p_apellido1", apPat);
                comando.Parameters.Add("p_apellido2", apMat);
                comando.Parameters.Add("p_fenac", fecNac);
                comando.Parameters.Add("p_feingreso", fecIngr);
                comando.Parameters.Add("p_fetermino", fecTerm);
                comando.Parameters.Add("p_fono", fono);
                comando.Parameters.Add("p_movil", movil);
                comando.Parameters.Add("p_direccion", direccion);
                comando.Parameters.Add("p_sueldo", sueldo);
                comando.Parameters.Add("p_usuario", usuario);
                comando.Parameters.Add("p_password", password);
                comando.Parameters.Add("p_cargo", cargo);
                comando.Parameters.Add("p_region", region);
                comando.Parameters.Add("p_provincia", provincia);
                comando.Parameters.Add("p_comuna", comuna);
                comando.ExecuteNonQuery();
                return "Modificacion Empleado Exitosa";
                //CerrarConexion();
            }
            catch (Exception error)
            {

                return error.Message;
            }
        }

        //funciona
        public string modificaEmpr(string nombEmpr, string rutEmpr, string giro, string direc, string telefono, string correo, string region, string provincia, string ciudad)
        {
            try
            {
                OpenConnection();
                OracleCommand comando = new OracleCommand("sp_modEmpresa", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_nombEmpr", nombEmpr);
                comando.Parameters.Add("p_rutempr", rutEmpr);
                comando.Parameters.Add("p_giro", giro);
                comando.Parameters.Add("p_direccion", direc);
                comando.Parameters.Add("p_telefono", telefono);
                comando.Parameters.Add("p_correo", correo);
                comando.Parameters.Add("p_region", region);
                comando.Parameters.Add("p_provincia", provincia);
                comando.Parameters.Add("p_comuna", ciudad);
                comando.ExecuteNonQuery();
                return "Modificacion Empresa Exitosa";
                //CerrarConexion();
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }
        
        //Elimina registro d ebase datos, funciona
        public string Eliminar(string tabla, string campo, string condicion)
        {
            try
            {
                OpenConnection();
                cmd = "DELETE FROM " + tabla + " WHERE " + campo +" = '" + condicion +"'";
                query = new OracleCommand(cmd, m);
                query.ExecuteNonQuery();
                closeConnection();
                comitear();
                return "ok";
            }
            catch (Exception error)
            {
                return error.Message;
                //return cmd;
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

        //funciona
        public OracleDataReader datosEmpleado(string condicion)
        {
            cmd = "SELECT * FROM empleado WHERE rutemp = '"+condicion+"'";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

        //funciona
        public OracleDataReader datosEmpresa()
        {
            cmd = "SELECT nombre_empresa, rut_empresa, giro_empresa, direccion, telefono, correo, region_nombre, provincia_nombre, comuna " +
                "FROM datosempresa JOIN regiones ON region_id = idregion " +
                "JOIN provincia ON idprovincia = provincia_id " +
                "JOIN comuna ON idcomuna = id_comuna";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

        //funciona
        public OracleDataAdapter datosSucursal()
        {
            cmd = "SELECT nombsucursal, direccion, telefono, region_nombre, provincia_nombre, comuna " +
                "FROM sucursal JOIN regiones ON region_id = idregion " +
                "JOIN provincia ON idprovincia = provincia_id " +
                "JOIN comuna ON idcomuna = id_comuna";
            
            OpenConnection();
            query = new OracleCommand(cmd, m);
            OracleDataAdapter conecto2 = new OracleDataAdapter(cmd, m);
            return conecto2;
        }

        //
        public string guardarSucursal(string nombSuc, string direcSuc, string telefono, string region, string provincia, string comuna)
        {
            try
            {
                OpenConnection();
                OracleCommand comando = new OracleCommand("sp_ingSucursal", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_nombSuc", nombSuc);
                comando.Parameters.Add("p_direccion", direcSuc);
                comando.Parameters.Add("p_telefono", telefono);
                comando.Parameters.Add("p_region", region);
                comando.Parameters.Add("p_provincia", provincia);
                comando.Parameters.Add("p_comuna", comuna);
                comando.ExecuteNonQuery();
                return "Registro de Sucursal Exitoso";
                //CerrarConexion();
            }
            catch (Exception error)
            {

                return error.Message;
            }
        }

        //funciona
        public OracleDataReader llenarCombo(string tabla, string order)
        {
            cmd = "SELECT * FROM " + tabla + " ORDER BY " + order;
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

        //funciona
        public OracleDataReader llenarComboProvincias(string region)
        {
            cmd = "SELECT * FROM provincia WHERE region_id = (SELECT region_id FROM regiones WHERE region_nombre = '" + region + "') ORDER BY provincia_id";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

        //funciona
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