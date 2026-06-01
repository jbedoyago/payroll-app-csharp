using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase2JeiksonBedoya
{
    public class Nomina
    {
        public int Identificacion { get; set; }
        public string Nombre { get; set;}
        public string Genero { get; set;}
        public string Cargo { get; set;}
        public double DiasLaborados { get; set;}
        public string FechaRegistro { get; set;}
        public double SalarioDia { get; set;}

        public double SalarioDevengado(double DiasLaborados, double SalarioDia)
        {
            double valorDevengado = 0;
            valorDevengado = DiasLaborados * SalarioDia;
            return valorDevengado;
        }
    }
}
