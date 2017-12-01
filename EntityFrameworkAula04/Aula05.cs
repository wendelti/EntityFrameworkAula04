using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkAula04
{
    class Aula05
    {

        public static void ExecutarExercicio()
        {
            

            var taskEstudante = RetornaEstudante();
            Console.WriteLine("Inicio - Principal");

            taskEstudante.Wait();

            Console.WriteLine("Final - Principal");

            Estudante e = taskEstudante.Result;

            Console.WriteLine(e.Nome);

        }

        public static async Task<Estudante> RetornaEstudante()
        {

            using (var context = new EscolaContext())
            {
                
                Console.WriteLine("Iniciando  - Async");

                var query = from e in context.Alunos select e;

                var retorno = await query.FirstOrDefaultAsync();

                Console.WriteLine("Final - Async");

                return retorno;
            }


        }
        
        
    }
}
