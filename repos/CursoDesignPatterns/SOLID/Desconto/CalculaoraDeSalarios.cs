namespace SOLID
{
    public class CalculadoraDeSalario
    {
        public double Calcula(Funcionario funcionario)
        {
            return funcionario.Cargo.Regra.Calcula(funcionario);
        } 
