using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taller3.Clases
{
    public class Vehiculo
    {
        private string _patente;
        private string _modelo;
        private int _tipoVehi;
        private int _codMarca;

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

        public int TipoVehi
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

        public int CodMarca
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
    }
}