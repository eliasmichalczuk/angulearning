using System;

public class Funcionario
{
    public Cargo Cargo { get; private set; }

    public double SalarioBase { get; private set; }

    public Funcionario(Cargo cargo, double salarioBase)
    {
        this.Cargo = cargo;
        this.SalarioBase = salarioBase;
    }

    public double Calcula(Funcionario funcionario)
    {
        return funcionario.CalculaSalario();
    }
    public double CalculaSalario()
    {
        return Cargo.Regra.Calcula(this);
    }
}