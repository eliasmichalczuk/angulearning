using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //Imposto iss = new ISS();
            //Imposto icms = new ICMS();

            //Orcamento orcamento = new Orcamento(500.0);

            //CalculadorDeImpostos calculador = new CalculadorDeImpostos();
            //calculador.RealizaCalculo(orcamento, iss);

            //var conta = new Conta(500.0);

            //CalculadorDeDescontos calculador = new CalculadorDeDescontos();
            Orcamento orcamento = new Orcamento(500);
            //orcamento.AdicionaItem(new Item("Caneta", 500));
            //orcamento.AdicionaItem(new Item("Lapis", 500));


            //double desconto = calculador.Calcula(orcamento);
            //Console.WriteLine(desconto);

            //Imposto iss = new ISS(new ICMS());
            //double valor = iss.Calcula(orcamento);
            //Console.WriteLine(valor);

            //Orcamento reforma = new Orcamento(500);
            //Console.WriteLine(reforma.Valor);

            //reforma.AplicaDescontoExtra();
            //Console.WriteLine(reforma.Valor);

            //reforma.AplicaDescontoExtra();
            //Console.WriteLine(reforma.Valor);

            //reforma.Finaliza();
            //reforma.Aprova(); 



            /*
             IList<ItemDaNota> itens = // recupera os itens da nota
        double valorTotal = 0;
        foreach(ItemDaNota item in itens) 
        {
            valorTotal += item.Valor;
        }
        double impostos = valorTotal * 0.05;

        NotaFiscal nf = new NotaFiscal("razao social qualquer", "um cnpj", DateTime.Now, valorTotal, impostos, itens, "observacoes quaisquer aqui");
    
             */

            CriadorDeNotaFiscal criador = new CriadorDeNotaFiscal();
            criador
                .ParaEmpresa("d")
            .ComCnpj("33")
            .Com(new ItemDaNota("item 1", 100.0))
            .NaDataAtual()
            .ComObservacoes("dd");

            criador.AdicionaAcao(new EnviadorDeEmail());
            NotaFiscal nf = criador.Constroi();
            Console.ReadKey();
        }   
    }
}
