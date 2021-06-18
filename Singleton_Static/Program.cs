using System;

namespace Singleton_Static
{

    public class ClasseNormal
    {
        public int variavelClasseNormal;
    }
    public sealed class ClasseSingleton
    {
        static ClasseSingleton _instancia;
        public static ClasseSingleton Instancia
        {
            get { return _instancia ?? (_instancia = new ClasseSingleton()); }
        }
        private ClasseSingleton() { }
        public string Mensagem { get; set; }
    }
    static public class ClasseEstatica
    {
        private static readonly int variavelEstatica;
        // Construtor Static constructor é executado 
        // somente uma vez quando o tipo for usado.   
        static ClasseEstatica()
        {
            variavelEstatica = 1;
        }
        public static string ExibirValor()
        {
            return string.Format("O valor da variável estática é {0}", variavelEstatica);
        }
        public static string Mensagem { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Classe Normal uso e instanciação
            var ClasseNormal = new ClasseNormal { variavelClasseNormal = 26 };
            Console.WriteLine("Uso da classe Normal: " + ClasseNormal.variavelClasseNormal);
            
            //Uso da classe estática
            string valorRetornado = ClasseEstatica.ExibirValor();
            Console.WriteLine("Uso da classe Static: " + valorRetornado);
            
            //Uso da classe Singleton
            var variavelSingleton = ClasseSingleton.Instancia;
            variavelSingleton.Mensagem = "Macoratti .net";
            Console.WriteLine("Uso da classe Singleton : " + variavelSingleton.Mensagem);
            
            
            //Teste para ver se as instâncias de Singleton são iguais
            var outraVariavelSingleton = ClasseSingleton.Instancia;
            Console.WriteLine("Verifcando se as instâncias são as mesmas : " + variavelSingleton.Equals(outraVariavelSingleton));
            Console.Read();
        }
    }
}
