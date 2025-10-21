using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVehiculos
{
    #region Clases
    // CLASE MADRE VEHICULO
    public abstract class Vehiculo
    {

        // DEFINICION DE LAS PROPIEDADES BASICAS

        private static int contador = 0;


        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Puertas { get; set; }
        public int Año { get; set; }
        public float Precio { get; set; }
        public abstract void Referencia();



        // FUNCION BASICA DE ENTRADA DE DATOS PARA REGISTRAR CADA VEHICULO
        public virtual void Registrar()
        {

            Console.Write("Marca: ");
            Marca = Console.ReadLine();

            Console.Write("Modelo: ");
            Modelo = Console.ReadLine();

            Console.Write("Año: ");
            Año = int.Parse(Console.ReadLine());

            Console.Write("Precio: ");
            Precio = float.Parse(Console.ReadLine());

        }


        //FUNCION PARA MOSTRAR EL NUEVO REGISTRO EN EL MOMENTO DE HACERLO
        public void MostrarVehiculo()
        {
            Console.WriteLine($"Marca: {Marca} - Modelo: {Modelo} - Año: {Año} - Precio: {Precio} Euros");
        }

        //--------------


        //FUNCION PARA MOSTRAR LOS VEHICULOS CON MAS DATOS EN LA SECCION DE LISTA
        public virtual void MostrarVehiculoLista()
        {
            Console.WriteLine($" Nº Referencia: {Id} - Marca: {Marca} - Modelo: {Modelo} - Año: {Año}  - Precio base: {Precio}");
        }

        //------------



        //FUNCION CALCULAR IMPUESTO QUE SE APLICA A CADA VEHICULO POR SU TAMAÑO
        public virtual void CalcularImpuesto(float impuesto)
        {

            Console.WriteLine("{0}", (impuesto * Precio) + Precio);
        }

    }

    //*****CLASE COCHE********
    public class Coche : Vehiculo, IMantenimiento
    {



        //Funcion constructora Coche
        public Coche()
        {
        }

        //Funcion virtual de Registro modificada (POLIMORFISMO)
        public override void Registrar()
        {
            base.Registrar();
            Console.Write("Nº Puertas: ");
            Puertas = int.Parse(Console.ReadLine());
        }

        //Función para mostrar los coches agregados en una lista con datos básicos (SOBRECARGA 1)
        // Se muestra cada vez que se agrega un coche nuevo
        public void MostrarCoches(List<Coche> coche)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("***NUEVO COCHE REGISTRADO***");
            Console.WriteLine("----------------------------");

            foreach (var v in coche)
            {

                v.MostrarVehiculo();
            }
            Console.WriteLine("¡¡Felicidades!!, el registro se ha realizado correctamente");
            Console.WriteLine("-----------------------------------------");
        }

        //Función virtual calcular impuesto modificada (POLIMORFISMO)
        public override void CalcularImpuesto(float impuesto)
        {
            Console.WriteLine("Impuesto extra del {0} % sobre el precio del coche: {1} Euros", impuesto, impuesto * Precio);
        }

        //Función para generar un número de referencia
        private static int contadorCoche = 0;
        public override void Referencia()
        {
            contadorCoche++;
            Id = contadorCoche;
        }



        //Función virtual Mostrar vehiculos modificada(POLIMORFISMO)
        //Vuelo a definir el mensaje para definir un orden de las variables
        public override void MostrarVehiculoLista()
        {
            Console.WriteLine($" Nº Referencia: {Id} - Marca: {Marca} - Modelo: {Modelo} - Año: {Año} - Nº de puertas: {Puertas} - Precio base: {Precio}");
        }


        //Función para mostrar los coches agregados en una lista con datos ampliados (SOBRECARGA 2)
        // Se muestra cada vez que se accede a la lista de coches
        public void MostrarCoches(List<Coche> coche, bool mostrardetalles)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("***LISTADO DE COCHES***");
            Console.WriteLine("-----------------------");

            foreach (var v in coche)
            {
                Console.WriteLine("***Características***");
                v.MostrarVehiculoLista();

            }


        }
        // Función heredada del interface Mantenimiento para definir la cantidad del mantenimiento anual (INTERFACE)
        public void RealizarMantenimiento(float cantidadManten)
        {

            float IVA = 0.18f;

            Console.WriteLine("Coste del mantenimiento anual del coche es de {0} Euros, más un IVA de {1}. En total: {2} Euros", cantidadManten, IVA, (cantidadManten * IVA) + cantidadManten);
            Console.WriteLine("-----------------------");
        }

        //Función para eliminar registro de coche a traves de su número de referencia
        public void EliminarCoche(List<Coche> cochesRegistrados, int id)
        {

            var cocheAEliminar = cochesRegistrados.FirstOrDefault(c => c.Id == id);
            if (cocheAEliminar != null)
            {
                cochesRegistrados.Remove(cocheAEliminar);
                Console.WriteLine($"Coche con ID {id} eliminado correctamente.");
                Console.WriteLine("-----------------------");

            }
            else
            {
                Console.WriteLine($"No se encontró ningún coche con ID {id}.");
            }

        }

        //Funcion para actualizar los números de referencia de cada coche, cada vez que eliminamos alguno.
        public void ActualizarId(List<Coche> cochesRegistrados)
        {
            int nuevoId = 1;
            foreach (var coche in cochesRegistrados)
            {
                coche.Id = nuevoId;
                nuevoId++;
            }
        }



    }

    //*****CLASE MOTO********
    public class Moto : Vehiculo, IMantenimiento
    {

        //Función constructora
        public Moto() { }

        //Función para mostrar las motos agregadas en una lista con datos básicos (SOBRECARGA 1)
        // Se muestra cada vez que se agrega una moto nueva
        public void MostrarMotos(List<Moto> motos)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("***NUEVA MOTO REGISTRADA***");
            Console.WriteLine("----------------------------");

            foreach (var v in motos)
            {

                v.MostrarVehiculo();
            }
            Console.WriteLine("¡¡Felicidades!!, el registro se ha realizado correctamente");
            Console.WriteLine("-----------------------");
        }

        //Función calcular impuesto modificada(POLIMORFISMO)
        public override void CalcularImpuesto(float impuesto)
        {
            Console.WriteLine("Impuesto extra del {0} % sobre el precio de la moto: {1} Euros", impuesto, impuesto * Precio);
        }


        //Función para generar un número de referencia
        private static int contadorMoto = 0;
        public override void Referencia()
        {
            contadorMoto++;
            Id = contadorMoto;
        }


        //Función para mostrar las motos agregadas en una lista con datos amplios (SOBRECARGA 2)
        // Se muestra cada vez que se accede a la lista general de motos
        public void MostrarMotos(List<Moto> moto, bool mostrardetalles)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("***LISTADO DE MOTOS***");
            Console.WriteLine("-----------------------");

            foreach (var v in moto)
            {
                Console.WriteLine("***Características***");
                v.MostrarVehiculoLista();

            }


        }
        // Función heredada del interface Mantenimiento para definir la cantidad del mantenimiento anual (INTERFACE)
        public void RealizarMantenimiento(float cantidadManten)
        {

            float IVA = 0.11f;

            Console.WriteLine("Coste del mantenimiento anual de la moto es de {0} Euros, más un IVA de {1}. En total: {2} Euros", cantidadManten, IVA, (cantidadManten * IVA) + cantidadManten);
            Console.WriteLine("-----------------------");
        }


        //Función para eliminar registro de moto a traves de su número de referencia
        public void EliminarMoto(List<Moto> motosRegistradas, int id)
        {

            var motoAEliminar = motosRegistradas.FirstOrDefault(c => c.Id == id);
            if (motoAEliminar != null)
            {
                motosRegistradas.Remove(motoAEliminar);
                Console.WriteLine($"Coche con ID {id} eliminado correctamente.");
                //Console.WriteLine("Pulse la tecla espacio para continuar");
                Console.WriteLine("-----------------------");

            }
            else
            {
                Console.WriteLine($"No se encontró ningún coche con ID {id}.");
            }

        }

        //Funcion para actualizar los números de referencia de cada moto, cada vez que eliminamos alguna.
        public void ActualizarId(List<Moto> motosRegistradas)
        {
            int nuevoId = 1;
            foreach (var moto in motosRegistradas)
            {
                moto.Id = nuevoId;
                nuevoId++;
            }
        }
    }

    //*****CLASE CAMION********
    public class Camion : Vehiculo
    {
        //Función constructora
        public Camion() { }

        //Funcion virtual de Registro modificada (POLIMORFISMO)
        public override void Registrar()
        {
            base.Registrar();
            Console.Write("Nº Puertas: ");
            Puertas = int.Parse(Console.ReadLine());
        }

        //Función para mostrar los camiones agregados en una lista con datos básicos (SOBRECARGA 1)
        // Se muestra cada vez que se agrega un camión nuevo
        public void MostrarCamiones(List<Camion> camion)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("***NUEVO CAMION REGISTRADO***");
            Console.WriteLine("----------------------------");

            foreach (var v in camion)
            {

                v.MostrarVehiculo();
            }
            Console.WriteLine("¡¡Felicidades!!, el registro se ha realizado correctamente");
            Console.WriteLine("-----------------------");
        }

        //Función calcular impuesto modificada (POLIMORFISMO)
        public override void CalcularImpuesto(float impuesto)
        {
            Console.WriteLine("Impuesto extra del {0} % sobre el precio del camion: {1} Euros", impuesto, impuesto * Precio);
        }

        //Función para generar un número de referencia
        private static int contadorCamion = 0;
        public override void Referencia()
        {
            contadorCamion++;
            Id = contadorCamion;
        }

        //Función virtual Mostrar vehiculos modificada(POLIMORFISMO)
        //Vuelo a definir el mensaje para definir un orden de las variables
        public override void MostrarVehiculoLista()
        {
            Console.WriteLine($" Nº Referencia: {Id} - Marca: {Marca} - Modelo: {Modelo} - Año: {Año} - Nº de puertas: {Puertas} - Precio base: {Precio}");
        }

        //Función para mostrar los coches agregados en una lista con datos amplios (SOBRECARGA 2)
        // Se muestra cada vez que se accede a la lista general
        public void MostrarCamiones(List<Camion> camion, bool mostrardetalles)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("***LISTADO DE CAMIONES***");
            Console.WriteLine("-----------------------");

            foreach (var v in camion)
            {
                Console.WriteLine("***Características***");
                v.MostrarVehiculoLista();

            }


        }
        //Función heredada del interface Mantenimiento para definir la cantidad del mantenimiento anual (INTERFACE) 
        public void RealizarMantenimiento(float cantidadManten)
        {

            float IVA = 0.45f;

            Console.WriteLine("Coste del mantenimiento anual del camion es de {0} Euros, más un IVA de {1}. En total: {2} Euros", cantidadManten, IVA, (cantidadManten * IVA) + cantidadManten);
            Console.WriteLine("-----------------------");
        }

        //Función para eliminar registro de camión a traves de su número de referencia
        public void EliminarCamion(List<Camion> camionesRegistrados, int id)
        {

            var camionAEliminar = camionesRegistrados.FirstOrDefault(c => c.Id == id);
            if (camionAEliminar != null)
            {
                camionesRegistrados.Remove(camionAEliminar);
                Console.WriteLine($"Coche con ID {id} eliminado correctamente.");
                Console.WriteLine("-----------------------");

            }
            else
            {
                Console.WriteLine($"No se encontró ningún coche con ID {id}.");
            }

        }

        //Funcion para actualizar los números de referencia de cada camión, cada vez que eliminamos alguno.
        public void ActualizarId(List<Camion> camionesRegistrados)
        {
            int nuevoId = 1;
            foreach (var camion in camionesRegistrados)
            {
                camion.Id = nuevoId;
                nuevoId++;
            }
        }
    }

    #endregion
}
