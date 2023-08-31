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
        static void Main(string[] args)
        {


            int opcion = 0;
            bool entrada = false;


            Console.WriteLine("escribe que valor vas usar \n " +
                "1. calular por CM\n" +
                "2. Calcular por Mts\n" +
                "3. caja recomendada de tu producto");

            while (!entrada)
            {
                try
                {
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("opcion ingresar valores por centimetros");
                            opcionCm();
                            entrada = true;

                            break;

                        case 2:
                            Console.WriteLine("opcion ingresar valores por Metros");
                            metrosCubicos();
                            entrada = true;

                            break;
                        case 3:
                            Console.WriteLine("Recomendacion de tamaño cajas");
                            entrada = true;
                            recomendarCajas();

                            break;

                        case 0:
                            Console.WriteLine("error");
                            break;
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }




        }
 

        private static float calcularVolumen(float ancho, float largo, float alto)
        {
            float volumen = ancho * largo * alto;
            return volumen;
        }

        private static double calcularVolumenEsfera(double tamanoEsfera)
        {
            //sacar mitad del tamaño total
            double radio = tamanoEsfera / 2;
            double volumen = (4.0 / 3.0) * Math.PI * Math.Pow(radio, 3);
            //Console.WriteLine("el volumen esfera es " + volumen);
            return volumen;
        }

        static double convertirAmts(double nConvertir)
        {
            //Console.WriteLine("recibo "+nConvertir);
            double mts = nConvertir / 100;
            return mts;
        }

        private static double convertirAcm(double nConvertir)
        {
            //Console.WriteLine("recibo "+nConvertir);
            double cm = nConvertir * 100;
            return cm;
        }


        //metodos
        private static void metrosCubicos()
        {

            float alto = 0;
            float ancho = 0;
            float largo = 0;
            bool entrada = false;
            float volumenProducto = 0;


            while (!entrada)
            {
                try
                {
                    Console.WriteLine("intruduce el alto del contenedor M");
                    alto = float.Parse(Console.ReadLine());

                    Console.WriteLine("Introduce el largo contenedor m"); ;
                    largo = float.Parse(Console.ReadLine());

                    Console.WriteLine("Introduce el ancho del contenedor m"); ;
                    ancho = float.Parse(Console.ReadLine());

                    Console.WriteLine("escribe el volumen del producto");
                    volumenProducto = float.Parse(Console.ReadLine());

                    entrada = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("No es numero pa.");
                    //throw; para terminar eol programa de ejecucion 
                }

                double rVolumen = calcularVolumen(ancho, largo, alto);
                Console.WriteLine("el cvolumen del contedor es: {0} m3", rVolumen);

                //int convertidoCm = (int)convertirAcm(rVolumen);
                //Console.WriteLine("el volumen del contedor es: cm3  " + convertidoCm);

                double vProductocm = calcularVolumen(volumenProducto, volumenProducto, volumenProducto);
                Console.WriteLine("el volumen del producto es: m3  " + vProductocm);

                double resultado = rVolumen / vProductocm;
                Console.WriteLine("Caben {0} cajas del mismo tamaño", (int)resultado);



            }

        }


        private static void opcionCm()
        {
            double largoCm = 0;
            double anchocm = 0;
            double altocm = 0;
            double objeto = 0;

            Console.Write("largo cm : ");
            largoCm = double.Parse(Console.ReadLine());

            Console.Write("ancho en cm: ");
            anchocm = double.Parse(Console.ReadLine());

            Console.Write("alto en cm: ");
            altocm = double.Parse(Console.ReadLine());

            Console.Write("Caja de las mismas medidas o esfera:  ");
            objeto = double.Parse(Console.ReadLine());


            //double resultado = cuantoscaben(largoCm,anchocm, altocm,objeto);
            cuantosCabenVolumen(largoCm, anchocm, altocm, objeto);


        }

        private static void cuantosCabenVolumen(double largo, double ancho, double alto, double objeto)
        {
            double volumenCajaObjeto = calcularVolumen((float)objeto, (float)objeto, (float)objeto);

            double esfera = calcularVolumenEsfera(objeto);

            double volumenCaja = calcularVolumen((float)ancho, (float)largo, (float)alto);

            Console.WriteLine("volumen del contenedor: " + volumenCaja);

            Console.WriteLine("volumen caja objeto: " + volumenCajaObjeto);
            Console.WriteLine("Volumen esfera: " + esfera);



            double resultado = volumenCaja / volumenCajaObjeto;
            double resultadoEsfera = volumenCaja / esfera;


            Console.WriteLine("\nel total de cajas dentro del contenedor es {0} piezas", resultado);


            Console.WriteLine("caben {0} esferas dentro del contenedor ", (int)resultadoEsfera);

            //return resultado;

        }


        private static void recomendarCajas()
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

        private static Caja RecomendarCaja(Producto producto, List<Caja> cajas)
        {
            // Implementa la lógica para recomendar la caja más adecuada para el producto
            // (puedes basarte en criterios como el volumen, ajuste, etc.)

            double volUsuario = calcularVolumen(producto.Largo, producto.Ancho, producto.Alto);

            Console.WriteLine("volumen de tu producto:  " +volUsuario);

            foreach (var item in cajas)
            {
                double resultado = calcularVolumen(item.Ancho, item.Alto, item.Largo);
                Console.WriteLine("el tamaño de la caja: {0} volumen de: {1}", item.ToString(), resultado);

                double compVolumen = resultado / volUsuario;
                Console.WriteLine("en esta caja Cabe :" + (int)compVolumen);
                Console.WriteLine("\n");


            }


            return cajas[0];
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



    }


}
