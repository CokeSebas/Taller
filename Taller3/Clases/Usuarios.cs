using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller3.Clases
{
    public class Usuarios
    {
        Conexion objConec = new Conexion();

        private string _rutClie;
        private string _nombClie;
        private string _apPatClie;
        private string _apMatClie;
        private string _direccion;
        private string _region;
        private string _provincia;
        private string _ciudad;
        private string _fono;
        private string _celular;
        private string _email;
        private string _usser;
        private string _pass;
        private string _nivel;
        private string _codEmp;
        private string _fecNac;
        private string _fecIng;
        private string _fecTer;
        private string _sueldo;

        public string RutClie
        {
            get
            {
                return _rutClie;
            }

            set
            {
                if (value.Length == 10)
                {
                    _rutClie = value;
                }
                else
                {
                    throw new Exception("Largo rut 10");
                }
            }
        }

        public string NombClie
        {
            get
            {
                return _nombClie;
            }

            set
            {
                if (value != "")
                {
                    _nombClie = value;
                }
                else
                {
                    throw new Exception("Nombre no puede estar Vacio");
                }
            }
        }

        public string ApPatClie
        {
            get
            {
                return _apPatClie;
            }

            set
            {
                if (value != "")
                {
                    _apPatClie = value;
                }
                else
                {
                    throw new Exception("Apellido Paterno no puede estar Vacio");
                }
                
            }
        }

        public string ApMatClie
        {
            get
            {
                return _apMatClie;
            }

            set
            {
                if (value != "")
                {
                    _apMatClie = value;
                }
                else
                {
                    throw new Exception("Apellido Materno no puede estar Vacio");
                }
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                if (value != "")
                {
                    _direccion = value;
                }
                else
                {
                    throw new Exception("Direccion no puede estar Vacio");
                }
            }
        }
    
        public string Celular
        {
            get
            {
                return _celular;
            }

            set
            {
                if (value != "")
                {
                    _celular = value;
                }
                else
                {
                    throw new Exception("Celular no puede estar Vacio");
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                if (value != "")
                {
                    _email = value;
                }
                else
                {
                    throw new Exception("Email no puede estar Vacio");
                }
            }
        }

        public string Usser
        {
            get
            {
                return _usser;
            }

            set
            {
                if (value != "")
                {
                    _usser = value;
                }
                else
                {
                    throw new Exception("Usuario no puede estar Vacio");
                }
            }
        }

        public string Pass
        {
            get
            {
                return _pass;
            }

            set
            {
                if (value != "")
                {
                    _pass = value;
                }
                else
                {
                    throw new Exception("Password no puede estar Vacio");
                }
            }
        }

        public string Nivel
        {
            get
            {
                return _nivel;
            }

            set
            {
                if (value != "0")
                {
                    _nivel = value;
                }
                else
                {
                    throw new Exception("Debe seleccionar un Cargo");
                }
            }
        }

        public string Region
        {
            get
            {
                return _region;
            }

            set
            {
                if (value != "0")
                {
                    _region = value;
                }
                else
                {
                    throw new Exception("Debe seleccionar una Region");
                }
            }
        }

        public string Provincia
        {
            get
            {
                return _provincia;
            }

            set
            {
                if (value != "0")
                {
                    _provincia = value;
                }
                else
                {
                    throw new Exception("Debe seleccionar una Region");
                }
            }
        }

        public string Ciudad
        {
            get
            {
                return _ciudad;
            }

            set
            {
                if (value != "0")
                {
                    _ciudad = value;
                }
                else
                {
                    throw new Exception("Debe seleccionar una Ciudad");
                }
                
            }
        }

        public string Fono
        {
            get
            {
                return _fono;
            }

            set
            {
                if (value != "")
                {
                    _fono = value;
                }
                else
                {
                    throw new Exception("Fono no puede estar Vacio");
                }   
            }
        }

        public string CodEmp
        {
            get
            {
                return _codEmp;
            }

            set
            {
                if (value != "")
                {
                    _codEmp = value;
                }
                else
                {
                    throw new Exception("Codigo Empleado no puede estar Vacio");
                }
            }
        }

        public string FecNac
        {
            get
            {
                return _fecNac;
            }

            set
            {
                _fecNac = value;
            }
        }

        public string FecIng
        {
            get
            {
                return _fecIng;
            }

            set
            {
                _fecIng = value;
            }
        }

        public string FecTer
        {
            get
            {
                return _fecTer;
            }

            set
            {
                _fecTer = value;
            }
        }

        public string Sueldo
        {
            get
            {
                return _sueldo;
            }

            set
            {
                _sueldo = value;
            }
        }

        //valida que el cliente no exista en la BD
        public bool validar(string tabla, string rut)
        {
            string condicion = "rutemp = '" + rut + "'";
            return objConec.validar(tabla, condicion);
        }

        public string guardarCliente()
        {
            string nomb = NombClie + " " + ApPatClie + " " + ApMatClie;
            string sql = "INSERT INTO cliente (idcliente, rutclie, nombre, direccion, fono, movil, email, usuario, password, id_region, id_provincia, id_comuna, fechaing) " +
                "VALUES (SEQ_CLIENTE.NEXTVAL, '" + RutClie + "', '" + nomb + "', '" + Direccion + "', "+Fono+", "+Celular+", '"+Email+"', '"+Usser+"', '"+Pass
                + "', (SELECT region_id FROM regiones WHERE region_nombre = '" + Region + "') "
                + ", (SELECT provincia_id FROM provincia WHERE provincia_nombre = '" + Provincia + "') "
                + ", (SELECT id_comuna FROM comuna WHERE comuna = '" + Ciudad + "'), SYSDATE)";

            return objConec.Insert2(sql);
        }

        public string guardarUsuario()
        {
            if (validar("empleado", RutClie)!=false)
            {
                string nomb = NombClie + " " + ApPatClie + " " + ApMatClie;
                return objConec.guardarEmpleado(CodEmp, RutClie, nomb, FecNac, FecIng, FecTer,
                                Fono, Celular, Direccion, Sueldo, Usser, Pass, Nivel, Region, Provincia, Ciudad);
            }
            else
            {
                return "Empleado ya Existe";
            }
        }

        public string modificaUsuario()
        {
            string nomb = NombClie + " " + ApPatClie + " " + ApMatClie;
            return objConec.modificaEmpl(CodEmp, RutClie, nomb, FecNac, FecIng, FecTer,
                                            Fono, Celular, Direccion, Sueldo, Usser, Pass, Nivel, Region, Provincia, Ciudad);
        }

        public string modificaCliente()
        {
            string nomb = NombClie + " " + ApPatClie + " " + ApMatClie;
            return objConec.modificaCli(RutClie, nomb,
                                            Fono, Celular, Direccion, Email, Region, Provincia, Ciudad);
        }

        public string eliminarUsuario(string rut)
        {
            return objConec.Eliminar("Empleado", "rutemp", rut);
        }

        public string eliminarCliente(string rut)
        {
            return objConec.Eliminar("cliente", "rutclie", rut);
        }

    }
}