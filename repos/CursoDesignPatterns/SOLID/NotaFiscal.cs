namespace SOLID.Desconto
{
    public class NotaFiscal : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {

        }
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public double ValorLiquido
        {
            get
            {
                return this.ValorBruto - this.Impostos;
            }

        }

        public NotaFiscal(double valorBruto, double impostos)
        {
            // TODO: Complete member initialization
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
        }   
    }
}