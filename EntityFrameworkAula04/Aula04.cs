using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkAula04
{
    class Aula04
    {

        public static void ExecutarExercicio()
        {
            
            var estudante = new Estudante();
            estudante.Nome = "Aluno 01";
            estudante.DataNascimento = DateTime.Now;
            estudante.Nota = new Nota() { Descricao = "Nota A" };

            var salvarEstudante = SalvarEstudante(estudante);
            Console.WriteLine("Processamento na thread principal");

            salvarEstudante.Wait();

            Console.WriteLine("Processamento na thread principal finalizado");


        }

        public static async Task SalvarEstudante(Estudante e)
        {

            using (var context = new EscolaContext())
            {


                context.Alunos.Add(e);

                Console.WriteLine("Iniciando a persistência dos dados");

                int retorno = await context.SaveChangesAsync();

                Console.WriteLine("Finalizou a persistência dos dados");

            }


        }
        
        
    }
}
