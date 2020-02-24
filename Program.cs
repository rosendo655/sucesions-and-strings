using System;
using System.Text;

namespace SucesionesYCadenas
{
    class Program
    {
        static void Main(string[] args)
        {
            int desde = 1, hasta = 6;
            string cadena = "esta es la cadena original";
            string subCadena1 = "cadena";
            string subCadena2 = "den";
            string subCadena3 = "cadeno";
            string subCadena4 = "a e";


            Console.WriteLine("Sucesiones:");

            Console.Write("2n:\t");
            Console.WriteLine(StringSucesion(DosN, desde, hasta));

            Console.Write("2^n:\t");
            Console.WriteLine(StringSucesion(DosALaN, desde, hasta));

            Console.Write("n^2:\t");
            Console.WriteLine(StringSucesion(NCuadrada, desde, hasta));

            Console.Write("n^3:\t");
            Console.WriteLine(StringSucesion(NCubica, desde, hasta));

            Console.Write("fib:\t");
            Console.WriteLine(StringSucesion(Fibonacci, desde, hasta));

            Console.Write("n/5:\t");
            Console.WriteLine(StringSucesion(EntreCinco, desde, hasta));

            Console.Write("1000/n:\t");
            Console.WriteLine(StringSucesion(MilEntreN, desde, hasta));

            Console.Write("|n-5|:\t");
            Console.WriteLine(StringSucesion(MenosCincoAbsoluto, desde, hasta));


            Console.WriteLine("\nSumatoria:");

            Console.Write("2n:\t");
            Console.WriteLine(Sumatoria(DosN, desde, hasta));

            Console.Write("2^n:\t");
            Console.WriteLine(Sumatoria(DosALaN, desde, hasta));

            Console.Write("n^2:\t");
            Console.WriteLine(Sumatoria(NCuadrada, desde, hasta));

            Console.Write("n^3:\t");
            Console.WriteLine(Sumatoria(NCubica, desde, hasta));

            Console.Write("fib:\t");
            Console.WriteLine(Sumatoria(Fibonacci, desde, hasta));

            Console.Write("n/5:\t");
            Console.WriteLine(Sumatoria(EntreCinco, desde, hasta));

            Console.Write("1000/n:\t");
            Console.WriteLine(Sumatoria(MilEntreN, desde, hasta));

            Console.Write("|n-5|:\t");
            Console.WriteLine(Sumatoria(MenosCincoAbsoluto, desde, hasta));


            Console.WriteLine("\nMultiplicatoria:");

            Console.Write("2n:\t");
            Console.WriteLine(Multiplicatoria(DosN, desde, hasta));

            Console.Write("2^n:\t");
            Console.WriteLine(Multiplicatoria(DosALaN, desde, hasta));

            Console.Write("n^2:\t");
            Console.WriteLine(Multiplicatoria(NCuadrada, desde, hasta));

            Console.Write("n^3:\t");
            Console.WriteLine(Multiplicatoria(NCubica, desde, hasta));

            Console.Write("fib:\t");
            Console.WriteLine(Multiplicatoria(Fibonacci, desde, hasta));

            Console.Write("n/5:\t");
            Console.WriteLine(Multiplicatoria(EntreCinco, desde, hasta));

            Console.Write("1000/n:\t");
            Console.WriteLine(Multiplicatoria(MilEntreN, desde, hasta));

            Console.Write("|n-5|:\t");
            Console.WriteLine(Multiplicatoria(MenosCincoAbsoluto, desde, hasta));


            Console.WriteLine("\nClasificacionSucesion:");

            Console.Write("2n:\t");
            Console.WriteLine(ClasificacionSucesion(DosN));

            Console.Write("2^n:\t");
            Console.WriteLine(ClasificacionSucesion(DosALaN));

            Console.Write("n^2:\t");
            Console.WriteLine(ClasificacionSucesion(NCuadrada));

            Console.Write("n^3:\t");
            Console.WriteLine(ClasificacionSucesion(NCubica));

            Console.Write("fib:\t");
            Console.WriteLine(ClasificacionSucesion(Fibonacci));

            Console.Write("n/5:\t");
            Console.WriteLine(ClasificacionSucesion(EntreCinco));

            Console.Write("1000/n:\t");
            Console.WriteLine(ClasificacionSucesion(MilEntreN));

            Console.Write("|n-5|:\t");
            Console.WriteLine(ClasificacionSucesion(MenosCincoAbsoluto));


            Console.WriteLine("\nCadenas:");

            CompararCadenas(cadena, subCadena1);
            Console.WriteLine();

            CompararCadenas(cadena, subCadena2);
            Console.WriteLine();

            CompararCadenas(cadena, subCadena3);
            Console.WriteLine();

            CompararCadenas(cadena, subCadena4);
        }

        static int DosN(int n) => 2 * n;

        static int DosALaN(int n) => (int)Math.Pow(2, n);

        static int NCuadrada(int n) => n * n;

        static int NCubica(int n) => n * n * n;

        static int EntreCinco(int n) => n/5;

        static int MilEntreN(int n) => 1000/n;

        static int MenosCincoAbsoluto(int n) => Math.Abs(n - 5);

        static int Fibonacci(int n)
        {
            if (n <= 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        //SUCESIONES
        static string StringSucesion<T>(Func<int, T> funcion, int desde, int hasta)
        {
            string str = "[";
            for (int i = desde; i <= hasta; i++)
            {
                str += $"{(desde == i ? "" : ",")}{funcion(i)}";
            }
            str += "]";
            return str;
        }

        static long Sumatoria(Func<int, int> funcion, int desde, int hasta)
        {
            long suma = 0;
            for (int i = desde; i <= hasta; i++)
            {
                suma += funcion(i);
            }
            return suma;
        }

        static long Multiplicatoria(Func<int, int> funcion, int desde, int hasta)
        {
            long mult = 1;
            for (int i = desde; i <= hasta; i++)
            {
                mult *= funcion(i);
            }
            return mult;
        }

        static TipoSucesion TipoSucesionFuncion(Func<int, int> funcion)
        {
            TipoSucesion tipo = TipoSucesion.CRECIENTE | TipoSucesion.DECRECIENTE | TipoSucesion.NO_CRECIENTE | TipoSucesion.NO_DECRECIENTE;

            int nPrevia;
            int nActual;

            nPrevia = funcion(1);
            for (int i = 2; i < 10; i++)
            {
                nActual = funcion(i);

                if (!(nPrevia < nActual))
                {
                    //No cumple con creciente
                    tipo &= ~TipoSucesion.CRECIENTE;
                }

                if (!(nPrevia > nActual))
                {
                    //No cumple con decreciente
                    tipo &= ~TipoSucesion.DECRECIENTE;
                }

                if (!(nPrevia <= nActual))
                {
                    //No cumple con no decreciente
                    tipo &= ~TipoSucesion.NO_DECRECIENTE;
                }

                if (!(nPrevia >= nActual))
                {
                    //No cumple con no creciente
                    tipo &= ~TipoSucesion.NO_CRECIENTE;
                }
                nPrevia = nActual;
            }
            return tipo;
        }

        static string ClasificacionSucesion(Func<int,int> funcion)
        {
            return TiposDeSucesion(TipoSucesionFuncion(funcion));
        }

        static string TiposDeSucesion(TipoSucesion tipo)
        {
            string str  = "";
            if(tipo == TipoSucesion.NINGUNO) str = "[NINGUNO]";
            else
            {
                if((tipo & TipoSucesion.CRECIENTE) == TipoSucesion.CRECIENTE) str +="[CRECIENTE]";
                if((tipo & TipoSucesion.NO_CRECIENTE) == TipoSucesion.NO_CRECIENTE) str +="[NO CRECIENTE]";
                if((tipo & TipoSucesion.DECRECIENTE) == TipoSucesion.DECRECIENTE) str +="[DECRECIENTE]";
                if((tipo & TipoSucesion.NO_DECRECIENTE) == TipoSucesion.NO_DECRECIENTE) str +="[NO DECRECIENTE]";
            }
            return str;
        }
        //CADENAS
        static string Concatenar(string str1, string str2) => str1 + str2;

        static bool Subcadena(string str1, string str2) => str1.Contains(str2);

        static string EsSubCadena(string str1, string str2) => SiNo(Subcadena(str1, str2));

        static string SiNo(bool cond) => cond ? "SI" : "NO";

        static void CompararCadenas(string str1, string str2)
        {
            Console.WriteLine($"Es \"{str1}\" subcadena de \"{str2}\" ?");
            Console.WriteLine(EsSubCadena(str1, str2));
            if (Subcadena(str1, str2))
            {
                Console.WriteLine("Primera ocurrencia");
                Console.WriteLine(str1);
                Console.WriteLine(new string(' ', str1.IndexOf(str2)) + "^");
            }
        }

        static char CharAt(string str, int pos)
        {
            return pos < str.Length ? str[pos] : ' ';
        }
    }
    
    [Flags]
    public enum TipoSucesion
    {
        NINGUNO = 0,
        CRECIENTE = 1,
        NO_CRECIENTE = 1 << 1,
        DECRECIENTE = 1 << 2,
        NO_DECRECIENTE = 1 << 3

    }
}
