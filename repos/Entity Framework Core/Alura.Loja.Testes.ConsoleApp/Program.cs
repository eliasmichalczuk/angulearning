using Alura.Loja.Testes.ConsoleApp.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"endereco de entrega: {cliente.EnderecoDeEntrega.Logradouro}");

                var produto = contexto
                    .Produtos
                    //.Include(p => p.Compras)
                    .Where(p => p.Id == 9004)
                    .FirstOrDefault();


                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()//funciona todos metodos de extensao Iqueryable
                    .Where(c => c.Preco > 10)
                    .Load();

                Console.WriteLine($"compras do produto {produto.Nome}");
                foreach(var item in produto.Compras)
                {
                    Console.WriteLine(item);
                }


            }

                Console.ReadKey();
        }

        private static void ExibeProdutosPromocao()
        {
            using (var contexto2 = new LojaContext())
            {
                var serviceProvider = contexto2.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = contexto2
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();
                Console.WriteLine("\nMostrando os produtos da promocao\n");
                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {

                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = new Promocao();
                promocao.Descricao = "Queima Total janeiro 2017";
                promocao.DataInicio = new DateTime(2017, 1, 1);
                promocao.DataTermino = new DateTime(2017, 1, 31);

                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();
                foreach (var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                contexto.Promocoes.Add(promocao);
                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
            }
        }

        private static void MetodoUmParaUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulano";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 23,
                Logradouro = "Rua 34",
                Complemento = "Casa",
                Bairro = "Centro",
                Cidade = "Joinville"
            };
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());
                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }

        private static void MuitosParaMuitos()
        {
            //using (var contexto = new LojaContext())
            //{
            //    var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
            //    var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            //    loggerFactory.AddProvider(SqlLoggerProvider.Create());

            //    var produtos = contexto.Produtos.ToList();

            //    ExibeEntries(contexto.ChangeTracker.Entries());

            //    var novoProduto = new Produto
            //    {
            //        Nome = "Sabão em pó",
            //        Categoria = "Limpeza",
            //        Preco = 5.99;
            //}
            //contexto.Produtos.Add(novoProduto);

            //contexto.Produtos.Remove(novoProduto);

            //ExibeEntries(contexto.ChangeTracker.Entries());

            ////contexto.SaveChages();
            //var entry = contexto.Entry(novoProduto);
            //Console.WriteLine("\n\n"entry.Entity.ToString() + " - " + entry.State); //removido mas recuperado pelo contexto

            //ExibeEntries(contexto.ChangeTracker.Entries());

            //var paoFrances = new Produto();
            //paoFrances.Nome = "Pão Francês";
            //paoFrances.PrecoUnitario = 0.40;
            //paoFrances.Unidade = "Unidade";
            //paoFrances.Categoria = "Padaria";

            //var compra = new Compra();
            //compra.Quantidade = 6;
            //compra.Produto = paoFrances;
            //compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };


            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Pascoa feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                //contexto.Compra.Add(compra);
                //ExibeEntries(contexto.ChangeTracker.Entries());

                //contexto.SaveChanges();

                //contexto.Promocoes.Add(promocaoDePascoa);
                //ExibeEntries(contexto.ChangeTracker.Entries());
                var promocao = contexto.Promocoes.Find(1);
                contexto.Promocoes.Remove(promocao);
                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();

            }
        }
        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
            {
            Console.WriteLine("===================");
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }

        private static void AtualizarProduto()
        {
            GravarUsandoEntity();
            RecuperarProdutos();

            using (var repo = new LojaContext())
            {
                Produto produto = repo.Produtos.First();
                produto.Nome = "editado";
                repo.Produtos.Update(produto);
                repo.SaveChanges();
            }
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();
                foreach(var item in produtos)
                {
                    repo.Produtos.Remove(item);
                }
                repo.SaveChanges();
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new LojaContext())
            {
                IList<Produto> Produtos = repo.Produtos.ToList();
                foreach(var item in Produtos)
                {
                    Console.WriteLine(item.Nome);
                }
                Console.ReadLine();
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            //using (var contexto = new LojaContexto())
            //{
            //    contexto.Produtos.Add(p);
            //    contexto.SaveChanges();
            //}
        }

        //private static void GravarUsandoAdoNet()
        //{
        //    Produto p = new Produto();
        //    p.Nome = "Harry Potter e a Ordem da Fênix";
        //    p.Categoria = "Livros";
        //    p.Preco = 19.89;

        //    using (var repo = new ProdutoDAO())
        //    {
        //        repo.Adicionar(p);
        //    }
        //}
    }
}
