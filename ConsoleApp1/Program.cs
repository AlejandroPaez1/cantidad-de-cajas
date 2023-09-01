using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {


        enum Opcion
        {
            CalcularPorCM = 1,
            CalcularPorMts = 2,
            RecomendarCajas = 3,
            Salir = 0
        }

        static void Main(string[] args)
        {


            bool entrada = false;

            Opcion opcion = Opcion.Salir; // Inicializamos con la opción "Salir"

            //Console.WriteLine("escribe que valor vas usar \n " +
            //    "1. calular por CM\n" +
            //    "2. Calcular por Mts\n" +
            //    "3. caja recomendada de tu producto");

            Console.WriteLine("Escribe el número de la opción que deseas:");
            Console.WriteLine($"{(int)Opcion.CalcularPorCM}. Calcular por CM");
            Console.WriteLine($"{(int)Opcion.CalcularPorMts}. Calcular por Mts");
            Console.WriteLine($"{(int)Opcion.RecomendarCajas}. Recomendación de tamaño cajas");
            Console.WriteLine($"{(int)Opcion.Salir}. Salir");


            while (!entrada)
            {
                try
                {
                    //opcion = int.Parse(Console.ReadLine());

                    opcion = (Opcion)Enum.Parse(typeof(Opcion), Console.ReadLine());


                    switch (opcion)
                    {
                        case Opcion.CalcularPorCM:
                            Console.WriteLine("Opción ingresar valores por centímetros");
                            OpcionCm();
                            entrada = true;
                            break;
                        case Opcion.CalcularPorMts:
                            Console.WriteLine("Opción ingresar valores por Metros");
                            MetrosCubicos();
                            entrada = true;
                            break;
                        case Opcion.RecomendarCajas:
                            Console.WriteLine("Recomendación de tamaño cajas");
                            entrada = true;
                            RecomendarCajas();
                            break;
                        case Opcion.Salir:
                            Console.WriteLine("Saliendo del programa");
                            entrada = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Introduce un número válido.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Opción no válida. Introduce un número válido.");

                }

            }




        }



        private static Medidas insertarDatos()
        {

            Medidas medidas = new Medidas();

            Console.Write("ancho: ");
            medidas.anchocm = double.Parse(Console.ReadLine());

            Console.Write("largo: ");
            medidas.largoCm = double.Parse(Console.ReadLine());

            Console.Write("alto: ");
            medidas.altocm = double.Parse(Console.ReadLine());

            Console.Write("Caja de las mismas medidas o esfera:  ");
            medidas.objeto = double.Parse(Console.ReadLine());

            return medidas;
        }


        private static double CalcularVolumen(double ancho, double largo, double alto) => ancho * largo * alto;


        private static double CalcularVolumenEsfera(double tamanoEsfera)
        {
            //sacar mitad del tamaño total
            double radio = tamanoEsfera / 2;
            double volumen = (4.0 / 3.0) * Math.PI * Math.Pow(radio, 3);
            //Console.WriteLine("el volumen esfera es " + volumen);
            return volumen;
        }

        static double ConvertirAmts(double nConvertir) => nConvertir / 100;

        private static double ConvertirAcm(double nConvertir) => nConvertir * 100;


        //opciones 
        static void MetrosCubicos()
        {

            bool entrada = false;

            while (!entrada)
            {
                try
                {
                    Medidas medidas = insertarDatos();

                    double rVolumen = CalcularVolumen(medidas.anchocm, medidas.largoCm, medidas.altocm);
                    Console.WriteLine("el cvolumen del contedor es: {0} m3", rVolumen);

                    double vProductocm = CalcularVolumen(medidas.objeto, medidas.objeto, medidas.objeto);
                    Console.WriteLine("el volumen del producto es: m3  " + vProductocm);

                    double resultado = rVolumen / vProductocm;
                    Console.WriteLine("Caben {0} cajas del mismo tamaño", (int)resultado);


                    entrada = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("No es numero pa.");
                    //throw; para terminar eol programa de ejecucion 
                }

            }

        }

        static void OpcionCm()
        {
            bool entrada = false;


            while (!entrada)
            {
                try
                {
                    Console.WriteLine("Ingresa las dimensiones de tu producto en centímetros:");

                    Medidas medidas = insertarDatos();
                    //double resultado = cuantoscaben(largoCm,anchocm, altocm,objeto);
                    CuantosCabenVolumen(medidas.largoCm, medidas.anchocm, medidas.altocm, medidas.objeto);
                    entrada = true;

                }
                catch
                {
                    Console.WriteLine("Dato incorrecto");
                }


            }



        }

        static void CuantosCabenVolumen(double largo, double ancho, double alto, double objeto)
        {
            //Volumen de un caja con las mismas dimensiones 
            double volumenCajaObjeto = CalcularVolumen((float)objeto, (float)objeto, (float)objeto);

            //calcula el tamaño de la esfera
            double esfera = CalcularVolumenEsfera(objeto);

            //se calcula el volumen de la caja que ingreso el usuario
            double volumenCaja = CalcularVolumen((float)ancho, (float)largo, (float)alto);

            Console.WriteLine("volumen del contenedor: " + volumenCaja);
            Console.WriteLine("volumen caja objeto: " + volumenCajaObjeto);
            Console.WriteLine("Volumen esfera: " + esfera);



            double resultado = volumenCaja / volumenCajaObjeto;
            double resultadoEsfera = volumenCaja / esfera;


            Console.WriteLine("\nel total de cajas dentro del contenedor es {0} piezas", resultado);


            Console.WriteLine("caben {0} esferas dentro del contenedor ", (int)resultadoEsfera);

            //return resultado;

        }


        static void RecomendarCajas()
        {

            Console.WriteLine("Ingresa las dimensiones de tu producto en centímetros:");

            Console.Write("Ancho: ");
            int anchoProducto = int.Parse(Console.ReadLine());
            Console.Write("Largo: ");
            int largoProducto = int.Parse(Console.ReadLine());
            Console.Write("Alto: ");
            int altoProducto = int.Parse(Console.ReadLine());

            Producto productoUsuario = new Producto("Producto 1", anchoProducto, largoProducto, altoProducto);


            // Dimensiones disponibles de las cajas (ancho x largo x alto)
            List<Caja> cajas = new List<Caja>
                {
                    new Caja(26, 56, 30),
                    new Caja(20, 10, 20),
                    new Caja(30, 30, 30),
                    new Caja(20, 50, 10)
                    // Agrega más cajas según sea necesario
                };

            //Console.WriteLine("Ancho x Largo x Alto");
            RecomendarCaja(productoUsuario, cajas);



        }

        private static void RecomendarCaja(Producto producto, List<Caja> cajas)
        {
            // Implementa la lógica para recomendar la caja más adecuada para el producto
            // (puedes basarte en criterios como el volumen, ajuste, etc.)

            double volUsuario = CalcularVolumen(producto.Largo, producto.Ancho, producto.Alto);

            Console.WriteLine("volumen de tu producto:  " + volUsuario);

            foreach (var item in cajas)
            {
                double resultado = CalcularVolumen(item.Ancho, item.Alto, item.Largo);
                Console.WriteLine("el tamaño de la caja: {0} volumen de: {1}", item.ToString(), resultado);

                double compVolumen = resultado / volUsuario;
                Console.WriteLine("en esta caja Cabe :" + (int)compVolumen);
                Console.WriteLine("\n");

            }


            // Aquí, por simplicidad, se recomendará la primera caja disponible
        }

        class Producto
        {
            public string Nombre { get; set; }
            public int Ancho { get; set; }
            public int Largo { get; set; }
            public int Alto { get; set; }

            public Producto(string nombre, int ancho, int largo, int alto)
            {
                Nombre = nombre;
                Ancho = ancho;
                Largo = largo;
                Alto = alto;
            }
        }


        class Caja
        {
            public int Ancho { get; set; }
            public int Largo { get; set; }
            public int Alto { get; set; }

            public Caja(int ancho, int largo, int alto)
            {
                Ancho = ancho;
                Largo = largo;
                Alto = alto;
            }

            public override string ToString()
            {
                return $"{Ancho}x{Largo}x{Alto}";
            }
        }


        struct Medidas
        {
            public double largoCm { get; set; }
            public double anchocm { get; set; }
            public double altocm { get; set; }
            public double objeto { get; set; }

        }


    }


}
