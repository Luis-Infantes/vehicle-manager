
using VehicleManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManager
{
    #region Classes
    // Abstract base class for vehicles
    public abstract class Vehicle
    {
        // Basic properties
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Doors { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }

        public abstract void Reference();

        // Basic input function to register each vehicle
        public virtual void Register()
        {
            Console.Write("Marca: ");
            Brand = Console.ReadLine();

            Console.Write("Modelo: ");
            Model = Console.ReadLine();

            Console.Write("Año: ");
            Year = int.Parse(Console.ReadLine());

            Console.Write("Precio: ");
            Price = float.Parse(Console.ReadLine());
        }

        // Show the new record at the moment of creation
        public void ShowVehicle()
        {
            Console.WriteLine($"Marca: {Brand} - Modelo: {Model} - Año: {Year} - Precio: {Price} Euros");
        }

        // Show vehicles with more details in the list section
        public virtual void ShowVehicleInList()
        {
            Console.WriteLine($" Nº Referencia: {Id} - Marca: {Brand} - Modelo: {Model} - Año: {Year}  - Precio base: {Price}");
        }

        // Calculate tax based on vehicle size
        public virtual void CalculateTax(float taxRate)
        {
            Console.WriteLine("{0}", (taxRate * Price) + Price);
        }
    }



    //*****CAR CLASS********
    public class Car : Vehicle, IMaintenance
    {
        // Constructor
        public Car()
        {
        }

        // Overridden Register function (POLYMORPHISM)
        public override void Register()
        {
            base.Register();
            Console.Write("Nº Puertas: ");
            Doors = int.Parse(Console.ReadLine());
        }

        // Overloaded function to show newly added cars (OVERLOAD 1)
        public void ShowCars(List<Car> cars)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("***NUEVO COCHE REGISTRADO***");
            Console.WriteLine("----------------------------");

            foreach (var v in cars)
            {
                v.ShowVehicle();
            }

            Console.WriteLine("¡¡Felicidades!!, el registro se ha realizado correctamente");
            Console.WriteLine("-----------------------------------------");
        }

        // Overridden tax calculation function (POLYMORPHISM)
        public override void CalculateTax(float taxRate)
        {
            Console.WriteLine("Impuesto extra del {0} % sobre el precio del coche: {1} Euros", taxRate, taxRate * Price);
        }

        // Reference number generator
        private static int carCounter = 0;
        public override void Reference()
        {
            carCounter++;
            Id = carCounter;
        }

        // Overridden function to show cars in list (POLYMORPHISM)
        public override void ShowVehicleInList()
        {
            Console.WriteLine($" Nº Referencia: {Id} - Marca: {Brand} - Modelo: {Model} - Año: {Year} - Nº de puertas: {Doors} - Precio base: {Price}");
        }

        // Overloaded function to show detailed car list (OVERLOAD 2)
        public void ShowCars(List<Car> cars, bool showDetails)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("***LISTADO DE COCHES***");
            Console.WriteLine("-----------------------");

            foreach (var v in cars)
            {
                Console.WriteLine("***Características***");
                v.ShowVehicleInList();
            }
        }

        // Interface function to define annual maintenance cost
        public void PerformMaintenance(float maintenanceCost)
        {
            float VAT = 0.18f;

            Console.WriteLine("Coste del mantenimiento anual del coche es de {0} Euros, más un IVA de {1}. En total: {2} Euros", maintenanceCost, VAT, (maintenanceCost * VAT) + maintenanceCost);
            Console.WriteLine("-----------------------");
        }

        // Function to delete a car by reference ID
        public void DeleteCar(List<Car> registeredCars, int id)
        {
            var carToDelete = registeredCars.FirstOrDefault(c => c.Id == id);
            if (carToDelete != null)
            {
                registeredCars.Remove(carToDelete);
                Console.WriteLine($"Coche con ID {id} eliminado correctamente.");
                Console.WriteLine("-----------------------");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún coche con ID {id}.");
            }
        }

        // Function to update reference IDs after deletion
        public void UpdateIds(List<Car> registeredCars)
        {
            int newId = 1;
            foreach (var car in registeredCars)
            {
                car.Id = newId;
                newId++;
            }
        }
    }



    //*****MOTORBIKE CLASS********
    public class Motorbike : Vehicle, IMaintenance
    {
        // Constructor
        public Motorbike() { }

        // Overloaded function to show newly added motorbikes (OVERLOAD 1)
        public void ShowMotorbikes(List<Motorbike> motorbikes)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("***NUEVA MOTO REGISTRADA***");
            Console.WriteLine("----------------------------");

            foreach (var v in motorbikes)
            {
                v.ShowVehicle();
            }

            Console.WriteLine("¡¡Felicidades!!, el registro se ha realizado correctamente");
            Console.WriteLine("-----------------------");
        }

        // Overridden tax calculation function (POLYMORPHISM)
        public override void CalculateTax(float taxRate)
        {
            Console.WriteLine("Impuesto extra del {0} % sobre el precio de la moto: {1} Euros", taxRate, taxRate * Price);
        }

        // Reference number generator
        private static int motorbikeCounter = 0;
        public override void Reference()
        {
            motorbikeCounter++;
            Id = motorbikeCounter;
        }

        // Overloaded function to show detailed motorbike list (OVERLOAD 2)
        public void ShowMotorbikes(List<Motorbike> motorbikes, bool showDetails)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("***LISTADO DE MOTOS***");
            Console.WriteLine("-----------------------");

            foreach (var v in motorbikes)
            {
                Console.WriteLine("***Características***");
                v.ShowVehicleInList();
            }
        }

        // Interface function to define annual maintenance cost
        public void PerformMaintenance(float maintenanceCost)
        {
            float VAT = 0.11f;

            Console.WriteLine("Coste del mantenimiento anual de la moto es de {0} Euros, más un IVA de {1}. En total: {2} Euros", maintenanceCost, VAT, (maintenanceCost * VAT) + maintenanceCost);
            Console.WriteLine("-----------------------");
        }

        // Function to delete a motorbike by reference ID
        public void DeleteMotorbike(List<Motorbike> registeredMotorbikes, int id)
        {
            var motorbikeToDelete = registeredMotorbikes.FirstOrDefault(m => m.Id == id);
            if (motorbikeToDelete != null)
            {
                registeredMotorbikes.Remove(motorbikeToDelete);
                Console.WriteLine($"Coche con ID {id} eliminado correctamente.");
                Console.WriteLine("-----------------------");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún coche con ID {id}.");
            }
        }

        // Function to update reference IDs after deletion
        public void UpdateIds(List<Motorbike> registeredMotorbikes)
        {
            int newId = 1;
            foreach (var motorbike in registeredMotorbikes)
            {
                motorbike.Id = newId;
                newId++;
            }
        }
    }



    //*****TRUCK CLASS********
    public class Truck : Vehicle
    {
        // Constructor
        public Truck() { }

        // Overridden Register function (POLYMORPHISM)
        public override void Register()
        {
            base.Register();
            Console.Write("Nº Puertas: ");
            Doors = int.Parse(Console.ReadLine());
        }

        // Overloaded function to show newly added trucks (OVERLOAD 1)
        public void ShowTrucks(List<Truck> trucks)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("***NUEVO CAMION REGISTRADO***");
            Console.WriteLine("----------------------------");

            foreach (var v in trucks)
            {
                v.ShowVehicle();
            }

            Console.WriteLine("¡¡Felicidades!!, el registro se ha realizado correctamente");
            Console.WriteLine("-----------------------");
        }

        // Overridden tax calculation function (POLYMORPHISM)
        public override void CalculateTax(float taxRate)
        {
            Console.WriteLine("Impuesto extra del {0} % sobre el precio del camion: {1} Euros", taxRate, taxRate * Price);
        }

        // Reference number generator
        private static int truckCounter = 0;
        public override void Reference()
        {
            truckCounter++;
            Id = truckCounter;
        }

        // Overridden function to show trucks in list (POLYMORPHISM)
        public override void ShowVehicleInList()
        {
            Console.WriteLine($" Nº Referencia: {Id} - Marca: {Brand} - Modelo: {Model} - Año: {Year} - Nº de puertas: {Doors} - Precio base: {Price}");
        }

        // Overloaded function to show detailed truck list (OVERLOAD 2)
        public void ShowTrucks(List<Truck> trucks, bool showDetails)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("***LISTADO DE CAMIONES***");
            Console.WriteLine("-----------------------");

            foreach (var v in trucks)
            {
                Console.WriteLine("***Características***");
                v.ShowVehicleInList();
            }
        }

        // Interface function to define annual maintenance cost
        public void PerformMaintenance(float maintenanceCost)
        {
            float VAT = 0.45f;

            Console.WriteLine("Coste del mantenimiento anual del camion es de {0} Euros, más un IVA de {1}. En total: {2} Euros", maintenanceCost, VAT, (maintenanceCost * VAT) + maintenanceCost);
            Console.WriteLine("-----------------------");
        }

        // Function to delete a truck by reference ID
        public void DeleteTruck(List<Truck> registeredTrucks, int id)
        {
            var truckToDelete = registeredTrucks.FirstOrDefault(t => t.Id == id);
            if (truckToDelete != null)
            {
                registeredTrucks.Remove(truckToDelete);
                Console.WriteLine($"Coche con ID {id} eliminado correctamente.");
                Console.WriteLine("-----------------------");
            }
            else
            {
                Console.WriteLine($"No se encontró ningún coche con ID {id}.");
            }
        }

        // Function to update reference IDs after deletion
        public void UpdateIds(List<Truck> registeredTrucks)
        {
            int newId = 1;
            foreach (var truck in registeredTrucks)
            {
                truck.Id = newId;
                newId++;
            }
        }
    }


    #endregion
}
