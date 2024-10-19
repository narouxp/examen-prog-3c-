using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class menu
    {
        private empleados[] empleados;
        private int contador;

        public menu()
        {
            empleados = new empleados[10];
            contador = 0;
        }

        public void ConsultarEmpleados()
        {
            Console.WriteLine("Lista de Empleados:");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"Cédula: {empleados[i].Cedula}, Nombre: {empleados[i].Nombre}, Dirección: {empleados[i].Direccion}, Teléfono: {empleados[i].Telefono}, Salario: {empleados[i].Salario}");
            }
        }

        public void ModificarEmpleado(string cedula)
        {
            for (int i = 0; i < contador; i++)
            {
                if (empleados[i].Cedula == cedula)
                {
                    Console.WriteLine("Ingrese el nuevo nombre:");
                    empleados[i].Nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese la nueva dirección:");
                    empleados[i].Direccion = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo teléfono:");
                    empleados[i].Telefono = Console.ReadLine();
                    Console.WriteLine("Ingrese el nuevo salario:");
                    empleados[i].Salario = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Empleado modificado exitosamente.");
                    return;
                }
            }
            Console.WriteLine("Empleado no encontrado.");
        }

        public void AgregarEmpleado(string cedula, string nombre, string direccion, string telefono, double salario)
        {
            if (contador < 10)
            {
                empleados[contador] = new empleados(cedula, nombre, direccion, telefono, salario);
                contador++;
                Console.WriteLine("Empleado agregado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se pueden agregar más empleados. El arreglo está lleno.");
            }
        }

        public void ListarEmpleadosOrdenados()
        {
            var empleadosOrdenados = empleados.Take(contador).OrderBy(e => e.Nombre).ToArray();
            Console.WriteLine("Empleados ordenados por nombre:");
            foreach (var empleado in empleadosOrdenados)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre}, Cédula: {empleado.Cedula}, Dirección: {empleado.Direccion}, Teléfono: {empleado.Telefono}, Salario: {empleado.Salario}");
            }
        }

        public void CalcularPromedioSalarios()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            double sumaSalarios = empleados.Take(contador).Sum(e => e.Salario);
            double promedio = sumaSalarios / contador;
            Console.WriteLine($"El promedio de los salarios es: {promedio}");
        }

        public void MostrarSubMenuReportes()
        {
            int opcion;
            do
            {
                Console.WriteLine("Submenú de Reportes:");
                Console.WriteLine("1. Listar todos los empleados ordenados por nombre");
                Console.WriteLine("2. Calcular y mostrar el promedio de los salarios");
                Console.WriteLine("3. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ListarEmpleadosOrdenados();
                        break;
                    case 2:
                        CalcularPromedioSalarios();
                        break;
                    case 3:
                        Console.WriteLine("Volviendo al menú principal...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 3);
        }

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú de Opciones:");
                Console.WriteLine("1. Agregar Empleado");
                Console.WriteLine("2. Consultar Empleados");
                Console.WriteLine("3. Modificar Empleado");
                Console.WriteLine("4. Reportes");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese la cédula:");
                        string cedula = Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese la dirección:");
                        string direccion = Console.ReadLine();
                        Console.WriteLine("Ingrese el teléfono:");
                        string telefono = Console.ReadLine();
                        Console.WriteLine("Ingrese el salario:");
                        double salario = Convert.ToDouble(Console.ReadLine());
                        AgregarEmpleado(cedula, nombre, direccion, telefono, salario);
                        break;
                    case 2:
                        ConsultarEmpleados();
                        break;
                    case 3:
                        Console.WriteLine("Ingrese la cédula del empleado a modificar:");
                        string cedulaModificar = Console.ReadLine();
                        ModificarEmpleado(cedulaModificar);
                        break;
                    case 4:
                        MostrarSubMenuReportes();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 5);
        }
    }
}