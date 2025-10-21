using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVehiculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region GESTOR DE VEHICULOS


            //Listas de vehiculos para registrar cada nuevo vehículo

            List<Coche> cochesRegistrados = new List<Coche> { };
            List<Moto> motosRegistradas = new List<Moto> { };
            List<Camion> caminonesRegistrados = new List<Camion> { };

            //Diseño del menú de consola

            bool salir = false;

            while (!salir)
            {
                //Menú gestor de vehículos
                Console.WriteLine("***GESTOR DE VEHICULOS***");
                Console.WriteLine("1 Registrar");
                Console.WriteLine("2 Listado");
                Console.WriteLine("3 Eliminar");
                Console.WriteLine("4 Salir");
                Console.WriteLine("Por favor, selecciona una opción introduciento uno de los números");
                Console.Write("Número: ");
                string Opcion = Console.ReadLine();

                switch (Opcion)
                {
                    // Acceso a registro de vehículos
                    case "1":
                        Console.WriteLine("***REGISTRO DE VEHICULOS***");
                        Console.WriteLine("1 Coches");
                        Console.WriteLine("2 Motos");
                        Console.WriteLine("3 Camiones");
                        Console.WriteLine("Por favor, selecciona una opción introduciento uno de los números");
                        Console.Write("Numero: ");
                        string tiposRegistro = Console.ReadLine();


                        switch (tiposRegistro)
                        {
                            //Registrar un nuevo coche
                            case "1":

                                if (tiposRegistro == "1")
                                {
                                    Coche auto = new Coche();
                                    Console.WriteLine("Registrando un nuevo coche");
                                    auto.Registrar();
                                    auto.Referencia();
                                    float impuestoCoche = 0.21f;
                                    auto.CalcularImpuesto(impuestoCoche);
                                    cochesRegistrados.Add(auto);
                                    auto.MostrarCoches(new List<Coche> { auto }); // Mostrar solo el nuevo registro de coche
                                }
                                break;
                            //Registrar una nueva moto
                            case "2":

                                if (tiposRegistro == "2")
                                {
                                    Moto moto = new Moto();
                                    Console.WriteLine("Registrando una nueva moto");
                                    moto.Registrar();
                                    moto.Referencia();
                                    float impuestoMoto = 0.11f;
                                    moto.CalcularImpuesto(impuestoMoto);
                                    motosRegistradas.Add(moto);
                                    moto.MostrarMotos(new List<Moto> { moto }); // Mostrar solo el nuevo registo de moto
                                }
                                break;

                            //Registrar un nuevo camion
                            case "3":

                                if (tiposRegistro == "3")
                                {
                                    Camion camion = new Camion();
                                    Console.WriteLine("Registrando un nuevo camion");
                                    camion.Registrar();
                                    camion.Referencia();
                                    float impuestoCamion = 0.45f;
                                    camion.CalcularImpuesto(impuestoCamion);
                                    caminonesRegistrados.Add(camion);
                                    camion.MostrarCamiones(new List<Camion> { camion }); // Mostrar solo el nuevo registo de camion
                                }
                                break;




                        }
                        break;
                    // Acceso a listado de vehículos
                    case "2":
                        Console.WriteLine("***LISTADO DE VEHICULOS***");
                        Console.WriteLine("1 Coches");
                        Console.WriteLine("2 Motos");
                        Console.WriteLine("3 Camiones");
                        Console.WriteLine("Por favor, selecciona una opción introduciento uno de los números");
                        Console.Write("Numero: ");
                        string tiposListar = Console.ReadLine();


                        switch (tiposListar)
                        {
                            //Acceso a lista de coches
                            case "1":

                                if (tiposListar == "1")
                                {
                                    Coche listaCoches = new Coche();
                                    listaCoches.MostrarCoches(cochesRegistrados, true);// Mostrar todos con detalles                                    
                                    float mantenimiento = 300;
                                    listaCoches.RealizarMantenimiento(mantenimiento);


                                }
                                break;
                            //Acceso lista de motos
                            case "2":

                                if (tiposListar == "2")
                                {
                                    Moto listaMotos = new Moto();
                                    listaMotos.MostrarMotos(motosRegistradas, true);// Mostrar todos con detalles                                    
                                    float mantenimiento = 99;
                                    listaMotos.RealizarMantenimiento(mantenimiento);


                                }
                                break;
                            //Acceso lista de camiones
                            case "3":

                                if (tiposListar == "3")
                                {
                                    Camion listaCamiones = new Camion();
                                    listaCamiones.MostrarCamiones(caminonesRegistrados, true);// Mostrar todos con detalles                                    
                                    float mantenimiento = 850;
                                    listaCamiones.RealizarMantenimiento(mantenimiento);


                                }
                                break;

                        }
                        break;
                    // Acceso a eliminar vehiculos 
                    case "3":
                        Console.WriteLine("***ELIMINAR DE VEHICULOS***");
                        Console.WriteLine("1 Coches");
                        Console.WriteLine("2 Motos");
                        Console.WriteLine("3 Camiones");
                        Console.WriteLine("Por favor, selecciona una opción introduciento uno de los números");
                        Console.Write("Numero: ");
                        string tiposEliminar = Console.ReadLine();


                        switch (tiposEliminar)
                        {
                            //Eliminar coches
                            case "1":

                                if (tiposEliminar == "1")
                                {
                                    Coche listaCoches = new Coche();
                                    listaCoches.MostrarCoches(cochesRegistrados, true);// Mostrar todos con detalles                                    
                                    float mantenimiento = 300;
                                    listaCoches.RealizarMantenimiento(mantenimiento);
                                    Console.WriteLine("---------------------");
                                    Console.WriteLine("Por favor, introduce el Nº de referencia para eliminar el coche deseado");
                                    Console.Write("Nº de referencia: ");

                                    if (int.TryParse(Console.ReadLine(), out int id))
                                    {
                                        listaCoches.EliminarCoche(cochesRegistrados, id);// Llamo al método para eliminar
                                        listaCoches.ActualizarId(cochesRegistrados);
                                    }
                                    else
                                    {
                                        Console.WriteLine("El Nº de referencia es inválido. Debe de ser un número entero");
                                    }

                                }
                                break;
                            //Eliminar motos
                            case "2":

                                if (tiposEliminar == "2")
                                {
                                    Moto listaMotos = new Moto();
                                    listaMotos.MostrarMotos(motosRegistradas, true);// Mostrar todos con detalles                                    
                                    float mantenimiento = 300;
                                    listaMotos.RealizarMantenimiento(mantenimiento);
                                    Console.WriteLine("---------------------");
                                    Console.WriteLine("Por favor, introduce el Nº de referencia para eliminar la moto deseada");
                                    Console.Write("Nº de referencia: ");

                                    if (int.TryParse(Console.ReadLine(), out int id))
                                    {
                                        listaMotos.EliminarMoto(motosRegistradas, id);// Llamo al método para eliminar
                                        listaMotos.ActualizarId(motosRegistradas);
                                    }
                                    else
                                    {
                                        Console.WriteLine("El Nº de referencia es inválido. Debe de ser un número entero");
                                    }

                                }
                                break;
                            //Eliminar camiones
                            case "3":

                                if (tiposEliminar == "3")
                                {
                                    Camion listaCamiones = new Camion();
                                    listaCamiones.MostrarCamiones(caminonesRegistrados, true);// Mostrar todos con detalles                                    
                                    float mantenimiento = 300;
                                    listaCamiones.RealizarMantenimiento(mantenimiento);
                                    Console.WriteLine("---------------------");
                                    Console.WriteLine("Por favor, introduce el Nº de referencia para eliminar el camión deseado");
                                    Console.Write("Nº de referencia: ");

                                    if (int.TryParse(Console.ReadLine(), out int id))
                                    {
                                        listaCamiones.EliminarCamion(caminonesRegistrados, id);// Llamo al método para eliminar
                                        listaCamiones.ActualizarId(caminonesRegistrados);
                                    }
                                    else
                                    {
                                        Console.WriteLine("El Nº de referencia es inválido. Debe de ser un número entero");
                                    }

                                }
                                break;
                        }
                        break;
                    // Salir del programa
                    case "4":
                        salir = true;
                        Console.WriteLine("Has salido del programa");
                        break;
                    // Última opción en caso de error
                    default:
                        Console.WriteLine("Opción NO disponible. Por favor inténtelo de nuevo.");
                        break;

                }


            }


            Console.ReadKey();
            #endregion
        }
    }
}
