
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManager;

namespace VehicleManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region VEHICLE MANAGER

            // Lists to register each new vehicle
            List<Car> registeredCars = new List<Car> { };
            List<Motorbike> registeredMotorbikes = new List<Motorbike> { };
            List<Truck> registeredTrucks = new List<Truck> { };

            // Console menu design
            bool exit = false;

            while (!exit)
            {
                // Vehicle manager menu
                Console.WriteLine("***GESTOR DE VEHICULOS***");
                Console.WriteLine("1 Registrar");
                Console.WriteLine("2 Listado");
                Console.WriteLine("3 Eliminar");
                Console.WriteLine("4 Salir");
                Console.WriteLine("Por favor, selecciona una opción introduciendo uno de los números");
                Console.Write("Número: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    // Access to vehicle registration
                    case "1":
                        Console.WriteLine("***REGISTRO DE VEHICULOS***");
                        Console.WriteLine("1 Coches");
                        Console.WriteLine("2 Motos");
                        Console.WriteLine("3 Camiones");
                        Console.WriteLine("Por favor, selecciona una opción introduciendo uno de los números");
                        Console.Write("Número: ");
                        string registrationType = Console.ReadLine();

                        switch (registrationType)
                        {
                            case "1":
                                Car car = new Car();
                                Console.WriteLine("Registrando un nuevo coche");
                                car.Register();
                                car.Reference();
                                float carTax = 0.21f;
                                car.CalculateTax(carTax);
                                registeredCars.Add(car);
                                car.ShowCars(new List<Car> { car });
                                break;

                            case "2":
                                Motorbike motorbike = new Motorbike();
                                Console.WriteLine("Registrando una nueva moto");
                                motorbike.Register();
                                motorbike.Reference();
                                float motorbikeTax = 0.11f;
                                motorbike.CalculateTax(motorbikeTax);
                                registeredMotorbikes.Add(motorbike);
                                motorbike.ShowMotorbikes(new List<Motorbike> { motorbike });
                                break;

                            case "3":
                                Truck truck = new Truck();
                                Console.WriteLine("Registrando un nuevo camion");
                                truck.Register();
                                truck.Reference();
                                float truckTax = 0.45f;
                                truck.CalculateTax(truckTax);
                                registeredTrucks.Add(truck);
                                truck.ShowTrucks(new List<Truck> { truck });
                                break;
                        }
                        break;


                    // Access to vehicle listing
                    case "2":
                        Console.WriteLine("***LISTADO DE VEHICULOS***");
                        Console.WriteLine("1 Coches");
                        Console.WriteLine("2 Motos");
                        Console.WriteLine("3 Camiones");
                        Console.WriteLine("Por favor, selecciona una opción introduciendo uno de los números");
                        Console.Write("Número: ");
                        string listingType = Console.ReadLine();

                        switch (listingType)
                        {
                            // Access to car list
                            case "1":
                                Car carList = new Car();
                                carList.ShowCars(registeredCars, true); // Show all with details
                                float carMaintenance = 300;
                                carList.PerformMaintenance(carMaintenance);
                                break;

                            // Access to motorbike list
                            case "2":
                                Motorbike motorbikeList = new Motorbike();
                                motorbikeList.ShowMotorbikes(registeredMotorbikes, true); // Show all with details
                                float motorbikeMaintenance = 99;
                                motorbikeList.PerformMaintenance(motorbikeMaintenance);
                                break;

                            // Access to truck list
                            case "3":
                                Truck truckList = new Truck();
                                truckList.ShowTrucks(registeredTrucks, true); // Show all with details
                                float truckMaintenance = 850;
                                truckList.PerformMaintenance(truckMaintenance);
                                break;
                        }
                        break;


                    // Access to vehicle deletion
                    case "3":
                        Console.WriteLine("***ELIMINAR DE VEHICULOS***");
                        Console.WriteLine("1 Coches");
                        Console.WriteLine("2 Motos");
                        Console.WriteLine("3 Camiones");
                        Console.WriteLine("Por favor, selecciona una opción introduciendo uno de los números");
                        Console.Write("Número: ");
                        string deletionType = Console.ReadLine();

                        switch (deletionType)
                        {
                            // Delete cars
                            case "1":
                                Car carList = new Car();
                                carList.ShowCars(registeredCars, true);
                                float carMaintenance = 300;
                                carList.PerformMaintenance(carMaintenance);
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Por favor, introduce el Nº de referencia para eliminar el coche deseado");
                                Console.Write("Nº de referencia: ");

                                if (int.TryParse(Console.ReadLine(), out int carId))
                                {
                                    carList.DeleteCar(registeredCars, carId);
                                    carList.UpdateIds(registeredCars);
                                }
                                else
                                {
                                    Console.WriteLine("El Nº de referencia es inválido. Debe de ser un número entero");
                                }
                                break;

                            // Delete motorbikes
                            case "2":
                                Motorbike motorbikeList = new Motorbike();
                                motorbikeList.ShowMotorbikes(registeredMotorbikes, true);
                                float motorbikeMaintenance = 300;
                                motorbikeList.PerformMaintenance(motorbikeMaintenance);
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Por favor, introduce el Nº de referencia para eliminar la moto deseada");
                                Console.Write("Nº de referencia: ");

                                if (int.TryParse(Console.ReadLine(), out int motorbikeId))
                                {
                                    motorbikeList.DeleteMotorbike(registeredMotorbikes, motorbikeId);
                                    motorbikeList.UpdateIds(registeredMotorbikes);
                                }
                                else
                                {
                                    Console.WriteLine("El Nº de referencia es inválido. Debe de ser un número entero");
                                }
                                break;

                            // Delete trucks
                            case "3":
                                Truck truckList = new Truck();
                                truckList.ShowTrucks(registeredTrucks, true);
                                float truckMaintenance = 300;
                                truckList.PerformMaintenance(truckMaintenance);
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Por favor, introduce el Nº de referencia para eliminar el camión deseado");
                                Console.Write("Nº de referencia: ");

                                if (int.TryParse(Console.ReadLine(), out int truckId))
                                {
                                    truckList.DeleteTruck(registeredTrucks, truckId);
                                    truckList.UpdateIds(registeredTrucks);
                                }
                                else
                                {
                                    Console.WriteLine("El Nº de referencia es inválido. Debe de ser un número entero");
                                }
                                break;
                        }
                        break;

                    // Exit the program
                    case "4":
                        exit = true;
                        Console.WriteLine("Has salido del programa");
                        break;

                    // Default option in case of error
                    default:
                        Console.WriteLine("Opción NO disponible. Por favor inténtelo de nuevo.");
                        break;
                }

                Console.ReadKey();

                #endregion
            }
        }
}
