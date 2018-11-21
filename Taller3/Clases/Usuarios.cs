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

        public string RutClie
        {
            get
            {
                return _rutClie;
            }

            set
            {
                _rutClie = value;
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
                _nombClie = value;
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
                _apPatClie = value;
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
                _apMatClie = value;
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
                _direccion = value;
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
                _celular = value;
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
                _email = value;
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
                _usser = value;
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
                _pass = value;
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
                _nivel = value;
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
                _region = value;
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
                _provincia = value;
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
                _ciudad = value;
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
                _fono = value;
            }
        }

        public string guardarUsuario()
        {
            string sql = "INSERT INTO cliente (idcliente, rutclie, nombre, apepat, apemat, direccion, fono, movil, email, usuario, password, id_region, id_provincia, id_comuna) " +
                "VALUES (SEQ_CLIENTE.NEXTVAL, '" + RutClie + "', '" + NombClie + "', '" + ApPatClie+ 
                "', '" + ApMatClie+ "', '" + Direccion + "', "+Fono+", "+Celular+", '"+Email+"', '"+Usser+"', '"+Pass
                + "', (SELECT region_id FROM regiones WHERE region_nombre = '" + Region + "') "
                + ", (SELECT provincia_id FROM provincia WHERE provincia_nombre = '" + Provincia + "') "
                + ", (SELECT id_comuna FROM comuna WHERE comuna = '" + Ciudad + "'))";

            //objConec.Actualizar("cliente", "id_region, id_provincia, fono, movil, email, usuario, password, id_comuna", )

            return objConec.Insert2(sql);
            //return objConec.Insert("cliente", sql);

            /*return objConec.Insert("cliente", "SEQ_CLIENTE.NEXTVAL, '" + RutClie + "', '" + NombClie + "', '" + ApPatClie + "', '" + ApMatClie + "', '" + Direccion
                         + "', '(SELECT region_id FROM regiones WHERE region_nombre = '" + Region + "'), "
                         + "'(SELECT provincia_id FROM provincia WHERE provincia_nombre = '" + Provincia + "'), "
                         + "'" + Fono + "', '" + Celular + "', '" + Email + "', '" + Usser + "', '" + Pass + "', "
                         + "'(SELECT id_comuna FROM comuna WHERE comuna = '" + Ciudad + "')'");*/
        }

    }
}