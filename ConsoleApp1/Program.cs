using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime;
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
                "1. cm \n" +
                "2. mts");

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


        private static double convertirAcm(double nConvertir)
        {
            //Console.WriteLine("recibo "+nConvertir);
            double cm = nConvertir * 100;
            return cm;
        }

        private static double convertirAmts(double nConvertir)
        {
            //Console.WriteLine("recibo "+nConvertir);
            double mts = nConvertir / 100;
            return mts;
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
                Console.WriteLine("Caben {0} cajas del mismo tamaño",(int)resultado);



            }

        }


        private static void opcionCm()
        {
            double largoCm = 0;
            double anchocm = 0;
            double altocm = 0;
            double objeto = 0;

            Console.WriteLine("largo en cm");
            largoCm = double.Parse(Console.ReadLine());

            Console.WriteLine("ancho en cm");
            anchocm = double.Parse(Console.ReadLine());

            Console.WriteLine("alto en cm");
            altocm = double.Parse(Console.ReadLine());

            Console.WriteLine("Caja de las mismas medidas o esfera");
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


            Console.WriteLine("caben {0} esferas dentro del contenedor " , (int)resultadoEsfera);

            //return resultado;

        }
    }
}
