using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller3.Clases
{
    public class Empleado
    {
        private int _codEmp;
        private string _rutEmp;
        private string _nombEmp;
        private string _apPatEmp;
        private string _apMatEmp;
        private int _idCargo;
        private string _fecNacEmp;
        private string _fecIngrEmp;
        private string _fecTermEmp;
        private int _fono;
        private string _movil;
        private int _comuna;
        private int _ciudad;
        private string _direccion;
        private int _sueldo;
        private string _usser;
        private string _pass;

        public int CodEmp
        {
            get
            {
                return _codEmp;
            }

            set
            {
                _codEmp = value;
            }
        }

        public string RutEmp
        {
            get
            {
                return _rutEmp;
            }

            set
            {
                _rutEmp = value;
            }
        }

        public string NombEmp
        {
            get
            {
                return _nombEmp;
            }

            set
            {
                _nombEmp = value;
            }
        }

        public string ApPatEmp
        {
            get
            {
                return _apPatEmp;
            }

            set
            {
                _apPatEmp = value;
            }
        }

        public string ApMatEmp
        {
            get
            {
                return _apMatEmp;
            }

            set
            {
                _apMatEmp = value;
            }
        }

        public int IdCargo
        {
            get
            {
                return _idCargo;
            }

            set
            {
                _idCargo = value;
            }
        }

        public string FecNacEmp
        {
            get
            {
                return _fecNacEmp;
            }

            set
            {
                _fecNacEmp = value;
            }
        }

        public string FecIngrEmp
        {
            get
            {
                return _fecIngrEmp;
            }

            set
            {
                _fecIngrEmp = value;
            }
        }

        public string FecTermEmp
        {
            get
            {
                return _fecTermEmp;
            }

            set
            {
                _fecTermEmp = value;
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

        public string Movil
        {
            get
            {
                return _movil;
            }

            set
            {
                _movil = value;
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

        public int Sueldo
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