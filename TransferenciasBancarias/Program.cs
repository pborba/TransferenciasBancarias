using System;

namespace TransferenciasBancarias
{
    class Program
    {
        static void Main(string[] args)
        {
            var banco = new Banco();
            while (true)
            {
                banco.imprimirMenu();
                var userInput = Console.ReadLine();
                banco.realizarSelecaoMenu(userInput);
            }
        }
    }
}
