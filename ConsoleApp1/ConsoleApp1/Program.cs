using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Instituicao a = new Instituicao();
            a.nome = "FURB";
            a.entidade = (Entidade)1;

            Console.WriteLine($"instituiaco:  {a.nome} + {a.entidade}");
        }
    }
    public class Instituicao 
    {
        public string nome { get; set; }
        public Entidade entidade { get; set; }

    }

}
public enum Entidade
{
    governamental = 1,
    naoGovernamental = 2,
}

