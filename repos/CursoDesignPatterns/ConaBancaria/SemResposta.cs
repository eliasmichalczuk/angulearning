namespace ConaBancaria
{
    internal class SemResposta : Resposta
    {
        public Resposta OutraResposta { get; set; }
        public SemResposta(Resposta outra)
        {
            OutraResposta = outra;
        }
        public void Responde(Requisicao req, Conta conta)
        {
            
        }
    }
}