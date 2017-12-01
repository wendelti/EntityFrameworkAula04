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
    class Aula08
    {

        public class Interceptador : IDbCommandInterceptor
        {
            public void LogInterceptacao(string metodo, bool ehAsync, string sql)
            {
                Console.WriteLine("Metodo chamado: " + metodo );
                Console.WriteLine("Async: " + ehAsync);
                Console.WriteLine("Sql:" + sql);
            }

            public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
            {
                LogInterceptacao("NonQueryExecuted", interceptionContext.IsAsync, command.CommandText);
            }

            public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
            {
                LogInterceptacao("NonQueryExecuting", interceptionContext.IsAsync, command.CommandText);
            }

            public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
            {
                LogInterceptacao("ReaderExecuted", interceptionContext.IsAsync, command.CommandText);
            }

            public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
            {
                LogInterceptacao("ReaderExecuting", interceptionContext.IsAsync, command.CommandText);
            }

            public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
            {
                LogInterceptacao("ScalarExecuted", interceptionContext.IsAsync, command.CommandText);
            }

            public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
            {
                LogInterceptacao("ScalarExecuting", interceptionContext.IsAsync, command.CommandText);
            }
        }



        public static void ExecutarExercicio()
        {


            using (var context = new EscolaContext())
            {
         
                var estudante = (from e in context.Alunos select e).FirstOrDefault();

                estudante.Nome = "Nome Alterado";

                context.SaveChanges();


            }

            

        }     

    }
}
