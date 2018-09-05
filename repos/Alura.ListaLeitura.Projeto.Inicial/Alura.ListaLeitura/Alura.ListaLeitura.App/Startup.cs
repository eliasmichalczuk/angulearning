using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(LivrosParaLer);
        }

        public Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString());

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
}