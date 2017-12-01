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
    class Aula06
    {

        public static void ExecutarExercicio()
        {


            var estudante = new Estudante();
            estudante.Nome = "Aluno 01";
            estudante.DataNascimento = DateTime.Now;
            estudante.Nota = new Nota() { Descricao = "Nota A" };

            var salvarEstudante = SalvarEstudante(estudante);
            Console.WriteLine("Save - Principal - Inicial");
            salvarEstudante.Wait();
            Console.WriteLine("Save - Principal - Final");


            var taskEstudante = RetornaEstudante();
            Console.WriteLine("Retorna  - Principal - Inicio");
            taskEstudante.Wait();
            Console.WriteLine("Retorna - Principal - Final");
            Estudante e = taskEstudante.Result;
            Console.WriteLine(e.Nome);

        }

        public static async Task<Estudante> RetornaEstudante()
        {

            using (var context = new EscolaContext())
            {
                
                Console.WriteLine("Retorno - Iniciando  - Async");

                var query = from e in context.Alunos select e;

                var retorno = await query.FirstOrDefaultAsync();

                Console.WriteLine("Retorno - Final - Async");

                return retorno;
            }


        }

        public static async Task SalvarEstudante(Estudante e)
        {

            using (var context = new EscolaContext())
            {


                context.Alunos.Add(e);

                Console.WriteLine("Save - Iniciando  - Async");

                int retorno = await context.SaveChangesAsync();

                Console.WriteLine("Save - Final - Async");

            }


        }



    }
}
