using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System.IO;
    namespace CASO_EMPLEADO
    {
        internal class Program
        {
            static int max_emp = 50;
            static string[] nombres_empl = new string[max_emp];
            static string[] correo_emp = new string[max_emp];
            static int cont_empl = 0;
            static string rutaArchivo = "empleados_datos.txt";

            static public void Titulo()
            {
                Console.WriteLine("**************************************************");
                Console.WriteLine("**SISTEMA DE EMPLEADOS ARREGLOS Y CADENAS**");
                Console.WriteLine("**************************************************");
            }

            static public void Registrar_empleado()
            {
                Console.WriteLine("*****REGISTRO DE EMPLEADO*****");
                if (cont_empl >= max_emp)
                {
                    Console.WriteLine("Capacidad maxima alcanzada");
                    return;
                }
                Console.WriteLine("Ingresar nombres y apellidos: ");
                string nombres = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(nombres))
                {
                    Console.WriteLine("Error: El nombres no puede estar vacío..!");
                    return;
                }

                string nombres_MAyus = nombres.ToUpper();
                string[] partes = nombres_MAyus.Split(' ');
                string primer_nombre;
                if (partes.Length > 0)
                    primer_nombre = partes[0];
                else
                    primer_nombre = "Usuario";
                string correo = $"{primer_nombre.ToLower()}@upn.edu.pe";
                nombres_empl[cont_empl] = nombres_MAyus;
                correo_emp[cont_empl] = correo;
                cont_empl++;
            }

            static public void buscar_emp()
            {
                Console.WriteLine("*****BUSCAR EMPLEADO*****");
                Console.WriteLine("****************************************");
                if (cont_empl == 0)
                {
                    Console.WriteLine("No hay empleados registrados");
                    return;
                }
                Console.Write("Ingrese el nombre del empleado a buscar: ");
                string buscar_nombre = Console.ReadLine()?.Trim().ToUpper();
                if (string.IsNullOrEmpty(buscar_nombre))
                    return;
                bool encontrado = false;
                for (int i = 0; i < cont_empl; i++)
                {
                    if (nombres_empl[i].Contains(buscar_nombre))
                    {
                        Console.WriteLine("Nombre: " + nombres_empl[i] + " correo: " + correo_emp[i]);
                        encontrado = true;
                    }
                }
                if (!encontrado)
                {
                    Console.WriteLine("Empleado no encontrado");
                }
            }

            static public void ordenar_alfabeticamente()
            {
                if (cont_empl <= 1)
                {
                    Console.WriteLine("No hay suficientes empleados para ordenar");
                    return;
                }
                for (int i = 0; i < cont_empl - 1; i++)
                {
                    for (int j = 0; j < cont_empl - 1 - i; j++)
                    {
                        if (string.Compare(nombres_empl[j], nombres_empl[j + 1]) > 0)
                        {
                            string temp_nombre = nombres_empl[j];
                            nombres_empl[j] = nombres_empl[j + 1];
                            nombres_empl[j + 1] = temp_nombre;

                            string temp_correo = correo_emp[j];
                            correo_emp[j] = correo_emp[j + 1];
                            correo_emp[j + 1] = temp_correo;
                        }
                    }
                }
            }

            static public void mostrar()
            {
                Console.WriteLine("*****LISTADO DE EMPLEADOS*****");
                Console.WriteLine("****************************************");
                if (cont_empl == 0)
                {
                    Console.WriteLine("No hay empleados registrados");
                    return;
                }
                Console.WriteLine("Nombres y apellidos\t\tCorreo corporativo");
                for (int i = 0; i < cont_empl; i++)
                {
                    Console.WriteLine(nombres_empl[i] + "\t\t" + correo_emp[i]);
                }
            }

            static public void Guardar_datos_archivo()
            {
                Console.WriteLine("*****GUARDAR DATOS DESDE ARCHIVO*****");
                Console.WriteLine("****************************************");
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("Archivo no existe");
                    return;
                }
            }

            static public void Leer_datos_archivo()
            {
                Console.WriteLine("*****LEER DATOS DESDE ARCHIVO*****");
                Console.WriteLine("****************************************");
                if (cont_empl == 0)
                {
                    Console.WriteLine("No hay empleados registrados para guardar.");
                    return;
                }
                string[] lineas = new string[cont_empl];
                for (int i = 0; i < cont_empl; i++)
                {
                    lineas[i] = nombres_empl[i] + "," + correo_emp[i];
                }
                File.WriteAllLines(rutaArchivo, lineas);
                Console.WriteLine("¡Datos guardados correctamente en el archivo!");
            }

            static public void Cargar_datos_archivo()
            {
                Console.WriteLine("*****CARGAR DATOS DESDE ARCHIVO*****");
                Console.WriteLine("****************************************");
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("Archivo no existe");
                    return;
                }
                string[] lineas = File.ReadAllLines(rutaArchivo);
                cont_empl = 0;
                for (int i = 0; i < lineas.Length && i < max_emp; i++)
                {
                    string[] partes = lineas[i].Split(',');
                    if (partes.Length == 2)
                    {
                        nombres_empl[cont_empl] = partes[0];
                        correo_emp[cont_empl] = partes[1];
                        cont_empl++;
                    }
                }
            }

            static void Main(string[] args)
            {
                int opc = 0;
                while (opc != 8)
                {
                    Console.Clear();
                    Console.WriteLine("[1]Registrar empleado");
                    Console.WriteLine("[2]Buscar empleado");
                    Console.WriteLine("[3]Ordenar alfabéticamente");
                    Console.WriteLine("[4]Mostrar empleados");
                    Console.WriteLine("[5]Guardar datos en archivo");
                    Console.WriteLine("[6]Leer datos en archivo");
                    Console.WriteLine("[7]Cargar datos en archivo");
                    Console.WriteLine("[8]Salir");
                    Console.Write("Ingresar opcion: ");
                    if (!int.TryParse(Console.ReadLine(), out opc))
                    {
                        Console.WriteLine("Error: Ingrese una opción numérica");
                        continue;
                    }
                    switch (opc)
                    {
                        case 1:
                            Registrar_empleado(); break;
                        case 2:
                            buscar_emp(); break;
                        case 3:
                            ordenar_alfabeticamente(); break;
                        case 4:
                            mostrar(); break;
                        case 5:
                            Guardar_datos_archivo(); break;
                        case 6:
                            Leer_datos_archivo(); break;
                        case 7:
                            Cargar_datos_archivo(); break;
                        case 8:
                            Console.WriteLine("Gracias por usar el sistema"); break;
                        default:
                            Console.WriteLine("Opcion no válida"); break;
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}








