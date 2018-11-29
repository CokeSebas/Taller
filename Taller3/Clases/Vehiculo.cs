using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller3.Clases
{
    public class Vehiculo
    {

        Conexion objConec = new Conexion();

        private string _patente;
        private string _modelo;
        private string _tipoVehi;
        private string _codMarca;
        private string _color;
        private string _anio;
        private string _rutCli;

        public string Patente
        {
            get
            {
                return _patente;
            }

            set
            {
                _patente = value;
            }
        }

        public string Modelo
        {
            get
            {
                return _modelo;
            }

            set
            {
                _modelo = value;
            }
        }

        public string TipoVehi
        {
            get
            {
                return _tipoVehi;
            }

            set
            {
                _tipoVehi = value;
            }
        }

        public string CodMarca
        {
            get
            {
                return _codMarca;
            }

            set
            {
                _codMarca = value;
            }
        }

        public string Color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }

        public string Anio
        {
            get
            {
                return _anio;
            }

            set
            {
                _anio = value;
            }
        }

        public string RutCli
        {
            get
            {
                return _rutCli;
            }

            set
            {
                _rutCli = value;
            }
        }

        public string guardarVeh()
        {
            return objConec.guardarVehiculo(Patente, Modelo, Anio, TipoVehi, CodMarca, Color, RutCli);
        }
    }
}