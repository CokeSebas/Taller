using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller3.Clases
{
    public class Ventas
    {
        Conexion objConec = new Conexion();

        private string _desc;
        private string _diag;
        private string _fechaIni;
        private string _fechaFin;
        private string _idVehi;
        private string _idCliente;
        private string _presupuesto;
        private string _idMecanico;
        private string _estado;
        private string _hrIni;
        private string _hrFin;
        private string _costoTotal;

        public string Desc
        {
            get
            {
                return _desc;
            }

            set
            {
                _desc = value;
            }
        }

        public string Diag
        {
            get
            {
                return _diag;
            }

            set
            {
                _diag = value;
            }
        }

        public string FechaIni
        {
            get
            {
                return _fechaIni;
            }

            set
            {
                _fechaIni = value;
            }
        }

        public string FechaFin
        {
            get
            {
                return _fechaFin;
            }

            set
            {
                _fechaFin = value;
            }
        }

        public string IdVehi
        {
            get
            {
                return _idVehi;
            }

            set
            {
                _idVehi = value;
            }
        }

        public string IdCliente
        {
            get
            {
                return _idCliente;
            }

            set
            {
                _idCliente = value;
            }
        }

        public string Presupuesto
        {
            get
            {
                return _presupuesto;
            }

            set
            {
                _presupuesto = value;
            }
        }

        public string IdMecanico
        {
            get
            {
                return _idMecanico;
            }

            set
            {
                _idMecanico = value;
            }
        }

        public string Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

        public string HrIni
        {
            get
            {
                return _hrIni;
            }

            set
            {
                _hrIni = value;
            }
        }

        public string HrFin
        {
            get
            {
                return _hrFin;
            }

            set
            {
                _hrFin = value;
            }
        }

        public string CostoTotal
        {
            get
            {
                return _costoTotal;
            }

            set
            {
                _costoTotal = value;
            }
        }
        //private string _presupuesto;

        public string registrarVenta()
        {
            string sql = "INSERT INTO reparacion () VALUES ()";
            return objConec.Insert2(sql);
        }
    }
}