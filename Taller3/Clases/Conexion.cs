﻿using System;
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
        //private static string strCadena = "Data Source=" + "localhost" + "; User Id= " + "portafolio" + "; Password=" + "1234" + ";";
        private static string strCadena = "Data Source=" + "localhost" + "; User Id= " + "serviexpress" + "; Password=" + "1234" + ";";

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
        public string guardarEmpleado(string codEmp, string rutEmp, string nombEmp, string fecNac, string fecIngr, 
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

        public string guardarVehiculo(string patente, string modelo, string anio, string tipoVeh, string marca,
                                      string color, string rutCli)
        {
            try
            {
                OpenConnection();
                OracleCommand comando = new OracleCommand("SP_INGvehiculo", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_patente", patente);
                comando.Parameters.Add("p_modelo", modelo);
                comando.Parameters.Add("p_anio", anio);
                comando.Parameters.Add("p_tipoVeh", tipoVeh);
                comando.Parameters.Add("p_marca", marca);
                comando.Parameters.Add("p_color", color);
                comando.Parameters.Add("p_rutCli", rutCli);
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
        public string modificaEmpl(string codEmp, string rutEmp, string nombEmp, string fecNac, string fecIngr,
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

        public string modificaCli(string rutCli, string nomCli, 
                                string fono, string movil, string direccion, string email, 
                                string region, string provincia, string comuna)
        {
            try
            {
                OpenConnection();
                OracleCommand comando = new OracleCommand("sp_modCli", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_rutcli", rutCli);
                comando.Parameters.Add("p_nombre", nomCli);
                comando.Parameters.Add("p_fono", fono);
                comando.Parameters.Add("p_movil", movil);
                comando.Parameters.Add("p_direccion", direccion);
                comando.Parameters.Add("p_email", email);
                comando.Parameters.Add("p_region", region);
                comando.Parameters.Add("p_provincia", provincia);
                comando.Parameters.Add("p_comuna", comuna);
                comando.ExecuteNonQuery();
                return "ok";
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
                return "ok";
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
        public OracleDataReader datosCliente(string condicion)
        {
            cmd = "SELECT * FROM cliente JOIN regiones ON region_id = id_region  " +
                "JOIN provincia ON id_provincia = provincia_id " +
                "JOIN comuna USING (id_comuna) WHERE rutclie = '" + condicion + "'";
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

        public OracleDataAdapter datosProveedor()
        {
            cmd = "SELECT Rutprov, nombre, giro, fono, movil, email, fe_registro, direprov, region_nombre, provincia_nombre, comuna " +
                "FROM proveedor " +
                "JOIN regiones ON region_id = idregion " +
                "JOIN provincia ON idprovincia = provincia_id " +
                "JOIN comuna ON idcomuna = id_comuna";

            OpenConnection();
            query = new OracleCommand(cmd, m);
            OracleDataAdapter conecto2 = new OracleDataAdapter(cmd, m);
            return conecto2;
        }

        //funciona
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

        public string guardarProveedor(string fecIng, string rutProv, string nombreProv, string direc, string giro, string telefono, string movil, string email, string region, string provincia, string comuna)
        {
            try
            {
                OpenConnection();
                OracleCommand comando = new OracleCommand("SP_INGPROVEEDOR", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_fecIng", fecIng);
                comando.Parameters.Add("p_rutProv", rutProv);
                comando.Parameters.Add("p_nombre", nombreProv);
                comando.Parameters.Add("p_direccion", direc);
                comando.Parameters.Add("p_giro", giro);
                comando.Parameters.Add("p_telefono", telefono);
                comando.Parameters.Add("p_movil", movil);
                comando.Parameters.Add("p_email", email);
                comando.Parameters.Add("p_region", region);
                comando.Parameters.Add("p_provincia", provincia);
                comando.Parameters.Add("p_comuna", comuna);
                comando.ExecuteNonQuery();
                return "ok";
                //CerrarConexion();
            }
            catch (Exception error)
            {

                return error.Message;
            }
        }

        public string guardarReparacion(string descrip, string diagn, string fechaIng, string fechaFin, string patente, string rutCli, string presu, string estado, string hrIni, string hrFinal)
        {
            try
            {
                OpenConnection();
                OracleCommand comando = new OracleCommand("SP_INGREPAR", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_descrip", descrip);
                comando.Parameters.Add("p_diag", diagn);
                comando.Parameters.Add("p_fecIni", fechaIng);
                comando.Parameters.Add("p_fecFin", fechaFin);
                comando.Parameters.Add("p_patente", patente);
                comando.Parameters.Add("p_rutClie", rutCli);
                comando.Parameters.Add("p_presu", presu);
                comando.Parameters.Add("p_estado", estado);
                comando.Parameters.Add("p_hrIni", hrIni);
                comando.Parameters.Add("p_hrFin", hrFinal);
                comando.ExecuteNonQuery();
                return "ok";
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

        public OracleDataReader llenarComboVehiculo(string rutCli)
        {
            cmd = "SELECT * FROM vehiculo WHERE idcliente = (SELECT idcliente FROM cliente WHERE rutclie = '" + rutCli +"' AND ROWNUM <= 1)";
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

        public bool inicioSesion(string usuario, string pass)
        {
            cmd = "SELECT * FROM empleado WHERE usuario = '"+usuario+"' AND password = '"+pass+"'";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();
            if (registros.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //validar existe, funciona correcto
        public bool validar(string tabla, string condicion)
        {
            cmd = "SELECT COUNT(*) AS count FROM " + tabla + " WHERE " + condicion;
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();
            if (registros.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
            //retorna true si el dato esta ingresado.
            //retorna false si el dato no esta ingresado.
        }

        public OracleDataReader datosReparacion(string condicion)
        {
            cmd = "SELECT * FROM reparacion WHERE nrodcto= '" + condicion + "'";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

        public string addServicio(string idRepar, string idRepues, string idServ)
        {
            try
            {
                OpenConnection();
                OracleCommand comando = new OracleCommand("sp_AddDetRep", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_idRep", idRepar);
                comando.Parameters.Add("p_idRepues", idRepues);
                comando.Parameters.Add("p_idServ", idServ);
                comando.ExecuteNonQuery();
                return "ok";
                //CerrarConexion();
            }
            catch (Exception error)
            {

                return error.Message;
            }
        }

        public string quitarServicio(string nroDcto, string idServ)
        {
            try
            {
                OpenConnection();
                cmd = "DELETE FROM detalle_reparacion " +
                    "WHERE idreparacion = (SELECT idreparacion FROM reparacion WHERE nrodcto = '" + nroDcto + "' AND ROWNUM <= 1) " +
                    "AND idservicios = (SELECT idservicios FROM servicios WHERE descripserv = '"+ idServ + "' AND ROWNUM <= 1)";
                query = new OracleCommand(cmd, m);
                query.ExecuteNonQuery();
                closeConnection();
                comitear();
                return "ok";
                //return cmd;
            }
            catch (Exception error)
            {
                return error.Message;
                //return cmd;
            }
        }

        public string quitarRepuesto(string nroDcto, string idRepuesto)
        {
            try
            {
                OpenConnection();
                cmd = "DELETE FROM detalle_reparacion " +
                    "WHERE idreparacion = (SELECT idreparacion FROM reparacion WHERE nrodcto = '" + nroDcto + "' AND ROWNUM <= 1) " +
                    "AND idrepuesto = (SELECT idrepuesto FROM repuestos WHERE descriprepuesto = '" + idRepuesto + "' AND ROWNUM <= 1)";
                query = new OracleCommand(cmd, m);
                query.ExecuteNonQuery();
                closeConnection();
                comitear();
                return "ok";
                //return cmd;
            }
            catch (Exception error)
            {
                return error.Message;
                //return cmd;
            }
        }

        public OracleDataAdapter datosServicios(string nroDcto)
        {
            cmd = "SELECT descripserv, costoserv FROM detalle_reparacion JOIN servicios USING(idservicios) WHERE idreparacion = (SELECT idreparacion FROM reparacion WHERE nrodcto = '"+nroDcto+"')";

            OpenConnection();
            query = new OracleCommand(cmd, m);
            OracleDataAdapter conecto2 = new OracleDataAdapter(cmd, m);
            return conecto2;
        }

        public OracleDataAdapter datosGrillaRepuesto(string nroDcto)
        {
            cmd = "SELECT descriprepuesto, valorneto FROM detalle_reparacion JOIN repuestos USING (idrepuesto) WHERE idreparacion = (SELECT idreparacion FROM reparacion WHERE nrodcto = '" + nroDcto + "')";

            OpenConnection();
            query = new OracleCommand(cmd, m);
            OracleDataAdapter conecto2 = new OracleDataAdapter(cmd, m);
            return conecto2;
        }

        public OracleDataReader buscaID(string tabla, string campo, string param)
        {
            cmd = "SELECT * FROM " + tabla + " where " + campo + " = '" + param + "'";
            OpenConnection();

            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

        public string guardarRepuesto(string codRepues, string descrp, string serie, string nroParte, string proveedor, 
                    string neto, string bodega, string stock, string tipoRepues, string marca, string tipoVeh)
        {
            try
            {
                OpenConnection();
                OracleCommand comando = new OracleCommand("SP_INGREPUESTO", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_codRepue", codRepues);
                comando.Parameters.Add("p_desc", descrp);
                comando.Parameters.Add("p_serie", serie);
                comando.Parameters.Add("p_nroParte", nroParte);
                comando.Parameters.Add("p_proveedor", proveedor);
                comando.Parameters.Add("p_valorNe", neto);
                comando.Parameters.Add("p_bod", bodega);
                comando.Parameters.Add("p_stock", stock);
                comando.Parameters.Add("p_tipoRepues", tipoRepues);
                comando.Parameters.Add("p_marca", marca);
                comando.Parameters.Add("p_tipoVeh", tipoVeh);
                comando.ExecuteNonQuery();
                return "ok";
                //CerrarConexion();
            }
            catch (Exception error)
            {

                return error.Message;
            }
        }

        public OracleDataReader datosRepuesto(string condicion)
        {
            cmd = "SELECT * FROM repuestos JOIN proveedor USING (idproveedor) " +
                "JOIN bodega USING(codbod) " +
                "JOIN tiporepuesto USING (idtiporepuesto) " +
                "JOIN marca ON idmarca = codmarca " +
                "JOIN tipoVehiculo ON idtipovehiculo = id_tipovehiculo " +
                "WHERE codrepuesto = '" + condicion + "'";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

        public OracleDataAdapter LlenarGrillaRepuestos()
        {
            cmd = "SELECT codrepuesto, descriprepuesto, serie, nroparte, nombre, valorneto, descripbod, stock, " +
                "destiporepuesto, descripmarca, tipovehiculo " +
                "FROM repuestos " +
                "JOIN proveedor USING(idproveedor) " +
                "JOIN bodega USING(codbod) " +
                "JOIN tiporepuesto USING(idtiporepuesto) " +
                "JOIN marca ON idmarca = codmarca " +
                "JOIN tipoVehiculo ON idtipovehiculo = id_tipovehiculo";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            OracleDataAdapter conecto2 = new OracleDataAdapter(cmd, m);
            return conecto2;
        }

        public OracleDataReader datosReparacionLista(string condicion)
        {
            cmd = "SELECT nombre, SUM(costoitem) + SUM(costorepuesto) as neto, ROUND((SUM(costoitem) + SUM(costorepuesto))*1.19) as total  " +
                "FROM reparacion JOIN cliente USING(idcliente) " +
                "JOIN detalle_reparacion USING(idreparacion)" +
                " WHERE nrodcto= '" + condicion + "' AND estado = 4 GROUP BY nombre";
            OpenConnection();
            query = new OracleCommand(cmd, m);
            registros = query.ExecuteReader();

            return registros;
        }

        public string guardarVenta(string nroDoc, string cliente, string fechaVent, string total, string tipoDoc)
        {
            try
            {
                OpenConnection();
                OracleCommand comando = new OracleCommand("SP_ADDVENTA", m);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("p_nroDcto", nroDoc);
                comando.Parameters.Add("p_cliente", cliente);
                comando.Parameters.Add("p_fechaVenta", fechaVent);
                comando.Parameters.Add("p_total", total);
                comando.Parameters.Add("p_tipoDoc", tipoDoc);
                comando.ExecuteNonQuery();
                return "ok";
                //CerrarConexion();
            }
            catch (Exception error)
            {

                return error.Message;
            }
        }

        public OracleDataAdapter DatosReparaciones()
        {
            cmd = "SELECT descripreparacion, diagnostico, fe_inicio, fe_final, nombre, presupuesto, " +
                "estadoreparacion.estado, hr_inicio, hr_final, nrodcto " +
                "FROM reparacion JOIN cliente USING(idcliente) " +
                "JOIN estadoreparacion ON(idestadrep = reparacion.estado)";

            OpenConnection();
            query = new OracleCommand(cmd, m);
            OracleDataAdapter conecto2 = new OracleDataAdapter(cmd, m);
            return conecto2;
        }


    }
}