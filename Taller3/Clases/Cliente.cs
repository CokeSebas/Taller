using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller3.Clases
{
    public class Cliente
    {
        private string _rutClie;
        private string _nombClie;
        private string _apPatClie;
        private string _apMatClie;
        private string _direccion;
        private int _comuna;
        private int _ciudad;
        private int _fono;
        private string _celular;
        private string _email;
        private string _usser;
        private string _pass;

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

        public int Comuna
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

        public int Ciudad
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

        public int Fono
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
    }
}