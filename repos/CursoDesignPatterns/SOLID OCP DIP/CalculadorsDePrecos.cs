namespace SOLID_OCP_DIP
{
    public class CalculadoraDePrecos
    {
        public double Calcula(ITabelaDesconto tabela, IServicoEntrega entrega)
        {
            //TabelaDePrecoPadrao tabela = new TabelaDePrecoPadrao();
            //Frete correios = new Frete();
            double desconto = tabela.DescontoPara(3000);
            double frete = entrega.Para("sao paulo");
            return Valor * (1 - desconto) + frete;
        }
    }
}