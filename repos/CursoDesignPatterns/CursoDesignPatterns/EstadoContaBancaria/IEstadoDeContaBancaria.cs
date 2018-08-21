

namespace CursoDesignPatterns
{
    public interface IEstadoDeContaBancaria
    {
        void Deposito(Conta conta, double valor);
        void Saque(Conta conta, double valor);
    }
}