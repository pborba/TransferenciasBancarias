using System;
using System.Linq;
using System.Collections.Generic;

namespace TransferenciasBancarias
{
    class Banco
    {
        List<Conta> contas;

        public Banco() {
            contas = new List<Conta>();
        }

        public void imprimirMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("=================================");
            Console.WriteLine("Bem-vindo ao banco DIO");
            Console.WriteLine("1 - Listar todas as contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");
        }

        public void realizarSelecaoMenu(string opcao)
        {
            switch(opcao.ToUpper())
            {
                case "1":
                    listarTodasAsContas();
                    break;
                case "2":
                    inserirNovaConta();
                    break;
                case "3":
                    transferir();
                    break;
                case "4":
                    sacar();
                    break;
                case "5":
                    depositar();
                    break;
                case "C":
                    limparTela();
                    break;
                case "X":
                    sair();
                    break;
            }
        }

        private void listarTodasAsContas()
        {
            if(contas.Count <= 0)
            {
                Console.WriteLine("Sem contas");
            }

            for(int i=0; i< contas.Count; i++)
            {
                Console.WriteLine(contas[i].ToString());
            }

        }

        private void inserirNovaConta()
        {
            Console.WriteLine("Selecione o tipo de conta:");
            Console.WriteLine("1 - Pessoa física");
            Console.WriteLine("2 - Pessoa jurídica");
            while(true)
            {
                var opcao = Console.ReadLine().ToUpper();
                switch(opcao)
                {
                    case "1":
                        inserirNovaContaPessoaFisica();
                        return;
                    case "2":
                        inserirNovaContaPessoaJuridica();
                        return;
                    case "X":
                        return;
                }
            }
        }

        private void inserirNovaContaPessoaFisica()
        {
            Console.WriteLine("Digite o nome do titular:");
            var nome = Console.ReadLine();
            if (nome.Equals(""))
            {
                Console.WriteLine("Erro: Nome não pode ser vazio");
                return;
            }

            Console.WriteLine("Digite o saldo inicial:");
            var saldoInicial = Double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito:");
            var creditoInicial = Double.Parse(Console.ReadLine());

            if (creditoInicial < 0)
            {
                Console.WriteLine("Erro: crédito não pode ser vazio");
                return;
            }

            var conta = new ContaPessoaFisica(nome, saldoInicial, creditoInicial);
            contas.Add(conta);

            Console.WriteLine("Conta adicionada com sucesso.");
            Console.WriteLine(conta.ToString());
        }

        private void inserirNovaContaPessoaJuridica()
        {
            Console.WriteLine("Digite o nome do titular:");
            var nome = Console.ReadLine();
            if(nome.Equals(""))
            {
                Console.WriteLine("Erro: Nome não pode ser vazio");
                return;
            }

            Console.WriteLine("Digite o saldo inicial:");
            var saldoInicial = Double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito:");
            var creditoInicial = Double.Parse(Console.ReadLine());

            if (creditoInicial<0)
            {
                Console.WriteLine("Erro: crédito não pode ser vazio");
                return;
            }

            var conta = new ContaPessoaJuridica(nome, saldoInicial, creditoInicial);
            contas.Add(conta);

            Console.WriteLine("Conta adicionada com sucesso.");
            Console.WriteLine(conta.ToString());
        }

        private void transferir()
        {
            // Conta a sacar
            Console.WriteLine("Digite a conta a sacar:");
            var contaSacar = int.Parse(Console.ReadLine());

            if(contaSacar < 0 || contas.Count <= contaSacar)
            {
                Console.WriteLine("Conta inválida");
                return;
            }

            // Conta a depositar
            Console.WriteLine("Digite a conta a depositar:");
            var contaDepositar = int.Parse(Console.ReadLine());

            if (contaDepositar < 0 || contas.Count <= contaDepositar)
            {
                Console.WriteLine("Conta inválida");
                return;
            }

            // Valor
            Console.WriteLine("Digite o valor:");
            var valor = Double.Parse(Console.ReadLine());

            if (!contas[contaSacar].verificaSacar(valor))
            {
                Console.WriteLine("Valor não é válido");
                return;
            }

            contas[contaSacar].sacar(valor);
            contas[contaDepositar].depositar(valor);

            Console.WriteLine("Saldo atual:");
            Console.WriteLine(contas[contaSacar].ToString());
            Console.WriteLine(contas[contaDepositar].ToString());

        }

        private void sacar()
        {
            // Conta a sacar
            Console.WriteLine("Digite a conta a sacar:");
            var contaSacar = int.Parse(Console.ReadLine());

            if (contaSacar < 0 || contas.Count <= contaSacar)
            {
                Console.WriteLine("Conta inválida");
                return;
            }

            // Valor
            Console.WriteLine("Digite o valor:");
            var valor = Double.Parse(Console.ReadLine());

            if (!contas[contaSacar].verificaSacar(valor))
            {
                Console.WriteLine("Valor não é válido");
                return;
            }

            contas[contaSacar].sacar(valor);

            Console.WriteLine("Saldo atual");
            Console.WriteLine(contas[contaSacar].ToString());
        }

        private void depositar()
        {

            // Conta a depositar
            Console.WriteLine("Digite a conta a depositar:");
            var contaDepositar = int.Parse(Console.ReadLine());

            if (contaDepositar < 0 || contas.Count <= contaDepositar)
            {
                Console.WriteLine("Conta inválida");
                return;
            }

            // Valor
            Console.WriteLine("Digite o valor");
            var valor = Double.Parse(Console.ReadLine());

            if (!contas[contaDepositar].verificaDepositar(valor))
            {
                Console.WriteLine("Valor não é válido");
                return;
            }

            contas[contaDepositar].depositar(valor);

            Console.WriteLine("Saldo atual");
            Console.WriteLine(contas[contaDepositar].ToString());
        }

        private void limparTela()
        {
            Console.Clear();
        }

        private void sair()
        {
            Environment.Exit(0);
        }
    }
}
