using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkAula04
{
    class Aula09
    {

        public static void ExecutarExercicio()
        {


            //adicionarMultiplos();
            removerMultiplos();
            

        }

        public static void adicionarMultiplos()
        {
            using (var context = new EscolaContext())
            {

                IList<Estudante> novosAlunos = retornaNovosAlunos();
                context.Alunos.AddRange(novosAlunos);
                context.SaveChanges();
                Console.WriteLine("Alunos adicionados");

                listarAlunos();

            }
        }

        public static void removerMultiplos()
        {
            using (var context = new EscolaContext())
            {

                var listaAlunos = from e in context.Alunos where e.Nome.StartsWith("J") select e;
                context.Alunos.RemoveRange(listaAlunos);
                context.SaveChanges();
                Console.WriteLine("Alunos Removidos");

                listarAlunos();

            }
        }

        public static IList<Estudante> retornaNovosAlunos()
        {
            IList<Estudante> novos = new List<Estudante>();
            novos.Add(new Estudante()
            {
                Nome = "Joao"
            });
            novos.Add(new Estudante()
            {
                Nome = "Jose"
            });
            novos.Add(new Estudante()
            {
                Nome = "Paulo"
            });

            return novos;

        }

        public static void listarAlunos()
        {
            Console.WriteLine("Alunos Cadastrados:");

            using (var context = new EscolaContext())
            {
                var listaAlunos = retornaAlunos();

                foreach (var aluno in listaAlunos)
                {
                    Console.WriteLine(aluno.Nome);
                }

            }
        }

        public static IList<Estudante> retornaAlunos()
        {
            using (var context = new EscolaContext())
            {
                return (from e in context.Alunos select e).ToList();
            }
        }

    }
}
