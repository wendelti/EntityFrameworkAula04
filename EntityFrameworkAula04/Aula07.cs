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
    class Aula07
    {

        public class Logger
        {
            public static void Log(string mensagem)
            {
                Console.WriteLine(mensagem);
            }
        }

        public static void ExecutarExercicio()
        {


            using (var context = new EscolaContext())
            {

                context.Database.Log = Console.WriteLine;                

                var estudante = (from e in context.Alunos select e).FirstOrDefault();

                estudante.Nome = "Nome Alterado";

                context.SaveChanges();


            }

            

        }     

    }
}
