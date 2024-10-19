using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class empleados
    {
        public string Cedula;
        public string Nombre;
        public string Direccion;
        public string Telefono;
        public double Salario;

        public empleados(string cedula, string nombre, string direccion, string telefono, double salario)
        {
            Cedula = cedula;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Salario = salario;
        }
    }
}