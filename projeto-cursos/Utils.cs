using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_cursos
{
    static class Utils
    {
        public static int lerInt(string entrada, int min, string msgErro)
        {
            bool converteu = int.TryParse(entrada, out int intValido);
            while (!converteu || intValido < min)
            {
                Console.Write(msgErro);
                converteu = int.TryParse(Console.ReadLine(), out intValido);
            }
            return intValido;

        }

        public static double lerDouble(string entrada, int min, string msgErro)
        {

            bool converteu = double.TryParse(entrada, out double doubleValido);
            while (!converteu || doubleValido < min)
            {
                Console.WriteLine(msgErro);
                converteu = double.TryParse(Console.ReadLine(), out doubleValido);
            }
            return doubleValido;

        }

        public static void Titulo(string titulo)
        {
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine($" SISTEMA DE VENDAS - {titulo}");
            Console.WriteLine("============================================");
        }

        public static void MensagemErro(string texto)
        {
            Console.WriteLine();
            Console.WriteLine($" {texto}");
            Console.WriteLine(" [Pressione qualquer tecla...]");
            Console.ReadKey();
        }

        public static void MensagemSucesso(string texto)
        {
            Console.WriteLine();
            Console.WriteLine($" {texto}");
            Console.WriteLine(" [Pressione qualquer tecla...]");
            Console.ReadKey();
        }
    }
}