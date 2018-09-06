using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(Roteamento);
        }

        public Task Roteamento(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
           {
               {"/Livros/ParaLer", LivrosParaLer },
               {"/Livros/Lendo", LivrosLendo },
               {"/Livros/Lidos", LivrosLidos }
           };

            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                System.Console.WriteLine("mano");

                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context);//invoke recebe context e executa um request delegate 
                //return context.Response.WriteAsync(caminhosAtendidos[context.Request.Path]);
            }


            context.Response.StatusCode = 404;
            //o endereco responsavel pela resposta
            return context.Response.WriteAsync("Caminho inexistente");
        }

        public Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString());

        }
        public Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());

        }
        public Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());

        }
    }

    //Escolha a alternativa com a melhor definição para Request Pipeline.
    //    Termo usado pelo ASP.NET Core para representar o fluxo 
    //        que uma requisição HTTP percorre dentro de sua aplicação 
    //        até que a resposta seja entregue ao cliente.
    //Isso aí! O código que escrevemos nesse pipeline é chamado
    //        Middleware.Veja essa definição na documentação da Microsoft.


    //    Veja a declaração do delegate RequestDelegate, disponível na API do ASP.NET Core.

    //public delegate Task RequestDelegate(HttpContext context);
    //    Escolha, dentre as assinaturas de métodos abaixo, o único que pode ser 
    //        considerado um RequestDelegate.
    //        private Task MeuRequestDelegate(HttpContext context);

    //    Isso aí! Se ficou em dúvida quanto ao modificador de acesso private, 
    //        saiba que o compilador ignora os modificadores na avaliação de um delegate


    //    Selecione o tipo que encapsula todas as informações 
    //        necessárias sobre o contexto de uma requisição web.
    //Alternativa correta
    //HttpContext
    //Isso aí! Um objeto desta classe é passado como 
    //        argumento de entrada do delegate RequestDelegate 
    //        para escrever as respostas das requisiçõe

//    Nessa aula vimos que a classe Startup é usada para realizar 
//        a inicialização do nosso servidor, mais especificamente no método Configure().

//Você sabia que é possível configurar diferentes ambientes usando 
//        métodos Configure diferentes? Por convenção, o ASP.NET Core permite 
//            que você configure o ambiente de desenvolvimento através de um
//            método ConfigureDevelopment(). O mesmo pode ser feito para o 
//            ambiente de produção com ConfigureProduction() e o de testes com ConfigureStaging().

//E mais: é possível criar classes específicas para cada ambiente. 
//            Como? Usando os nomes StartupDevelopment, StartupStaging e StartupProduction.Legal né?
}