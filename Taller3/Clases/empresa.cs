using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller3.Clases
{
    public class Empresa
    {
        Conexion objConec = new Conexion();

        private string _nombEmpr;
        private string _rutEmpr;
        private string _giroEmpr;
        private string _direcEmpr;
        private string _telefonoEmpr;
        private string _correoEmpr;
        private string _region;
        private string _provincia;
        private string _comuna;

        public string NombEmpr
        {
            get
            {
                return _nombEmpr;
            }

            set
            {
                _nombEmpr = value;
            }
        }

        public string RutEmpr
        {
            get
            {
                return _rutEmpr;
            }

            set
            {
                _rutEmpr = value;
            }
        }

        public string GiroEmpr
        {
            get
            {
                return _giroEmpr;
            }

            set
            {
                _giroEmpr = value;
            }
        }

        public string TelefonoEmpr
        {
            get
            {
                return _telefonoEmpr;
            }

            set
            {
                _telefonoEmpr = value;
            }
        }

        public string CorreoEmpr
        {
            get
            {
                return _correoEmpr;
            }

            set
            {
                _correoEmpr = value;
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

        public string Comuna
        {
            get
            {
                return _comuna;
            }

            set
            {
                _comuna = value;
            }
        }

        public string DirecEmpr
        {
            get
            {
                return _direcEmpr;
            }

            set
            {
                _direcEmpr = value;
            }
        }

        public string modificaEmpr()
        {
            return objConec.modificaEmpr(NombEmpr, RutEmpr, GiroEmpr, DirecEmpr, TelefonoEmpr, CorreoEmpr, Region, Provincia, Comuna);
        }
    }
}