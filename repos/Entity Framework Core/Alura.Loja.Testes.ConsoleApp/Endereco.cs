﻿namespace Alura.Loja.Testes.ConsoleApp
{
    public class Endereco
    {
        //public int EnderecoId { get; set; }
        //posso definir chave primaria em outro lugar
        public int Numero { get; internal set; }
        public string Logradouro { get; internal set; }
        public string Complemento { get; internal set; }
        public string Bairro { get; internal set; }
        public string Cidade { get; internal set; }
        public Cliente Cliente { get; internal set; }
    }
}