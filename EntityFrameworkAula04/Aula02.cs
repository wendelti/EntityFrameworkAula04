using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkAula04
{
    class Aula02
    {

        public async static void ExecutarExercicio()
        {
            HttpClient cliente = new HttpClient();

            Task<string> endereco = cliente.GetStringAsync("https://viacep.com.br/ws/90560001/json/");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ExecutarExercicio " + i.ToString());
            }


            string resultado = await endereco;
            Console.WriteLine(resultado);

            Console.WriteLine("fim");
        }
        
        
    }
}
