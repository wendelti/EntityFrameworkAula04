using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkAula04
{
    class Aula01
    {

        public async static void ExecutarExercicio()
        {
            Task<bool> retorno = FuncaoAsync();

            ExecutaFor("ExecutarExercicio-PRE", 100);
            
            Console.WriteLine("fim");

            bool resultado = await retorno;
        }

        public static void ExecutaFor(string metodo, int sleep)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(metodo + " " + i.ToString());
                Thread.Sleep(sleep);
            }
        }

        public static async Task<bool> FuncaoAsync()
        {
            return await Task.Run(() =>
            {
                ExecutaFor("funcaoAsync", 200);
                return true;
            });
        }

    }
}
