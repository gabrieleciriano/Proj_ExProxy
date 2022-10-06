using System;
using System.Threading;

namespace Proj_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**Exemplo de utilização de proxy através de uma maquininha de pagamento**");
            Console.WriteLine("\nExemplificando o processamento dos dados SEM PROXY...");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("\n");
           


            for (int i = 1; i <= 3; i++)
            {
                //Objeto da classe Subject
                Pagamento pagamento = new Pagamento();

                //Imprimindo o objeto com a chamada do metodo consultar de sua classe
                Console.WriteLine(pagamento.Pagar());

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            //Agora, fazendo a mesma coisa utilizando o objeto da classe proxy
            Console.WriteLine("Usando proxy para controlar a criação e repare na economia no transporte de dados...");
            Console.WriteLine("------------------------------------------------------------------------------------");


            Console.WriteLine();

            //Criando uma variavel do tipo interface
            IPagamento proxy;
            //essa variavel recebe a instancia de um novo objeto da classe ProxyUsuario que se torna o objeto proxy
            proxy = new ProxyUsuario();


            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine(proxy.Pagar());
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
    //ISubject
    public interface IPagamento
    {
        //Request()
        String Pagar();
    }

    //Subject
    //Classe Subject que possui o objeto real
    public class Pagamento
    {
        public Pagamento()
        {
            Console.WriteLine("Executando pagamento...");


            Thread.Sleep(2000);
        }

        //Request()
        public String Pagar()
        {
            Thread.Sleep(500);
            return String.Format("Paguei!");
        }
    }
    //Proxy
    public class ProxyUsuario : IPagamento
    {
        //ISubject
        //Normalmente ao criar um atributo do tipo da classe subject (Pagamento) é privado!
        private Pagamento _pgto; //possui um atributo da classe Usuario que seria o Subject

        //Request
        //Cria-se o msm metodo presente na classe subject (Pagamento) porém é neste metodo onde devem ser feitas as
        //verificações e condições do que deseja executar
        public String Pagar()
        {
            if (this._pgto == null)
                this._pgto = new Pagamento();

            return _pgto.Pagar();
        }
    }
}