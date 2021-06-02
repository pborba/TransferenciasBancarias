using System;
using System.Collections.Generic;
using System.Text;

namespace TransferenciasBancarias
{
    class Conta
    {
        protected static int cont = 0;
        protected int numero;
        protected string nomeCliente;
        protected double saldo;
        protected double credito;
        protected double creditoUtilizado;

        public Conta(string nomeCliente, double saldo, double credito)
        {
            numero = cont;
            this.nomeCliente = nomeCliente;
            this.saldo = saldo;
            this.credito = credito;
            creditoUtilizado = 0;
            cont++;
        }

        public bool verificaDepositar(double valor)
        {
            if (valor < 0)
            {
                Console.WriteLine("Valor não pode ser negativo");
                return false;
            }

            return true;
        }

        public void depositar(double valor)
        {
            double valor_aux = valor;

            if(creditoUtilizado > 0)
            {
                if(valor<=creditoUtilizado)
                {
                    creditoUtilizado += valor;
                } else
                {
                    valor_aux -= creditoUtilizado;
                    saldo += valor_aux;
                    creditoUtilizado = 0;
                }
            } else
            {
                saldo += valor;
            }
        }

        public bool verificaSacar(double valor)
        {

            if (valor < 0)
            {
                Console.WriteLine("Valor não pode ser negativo");
                return false;
            }

            if (saldo + credito - creditoUtilizado < valor)
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            return true;
        }

        public void sacar(double valor)
        {

            if (valor > saldo)
            {
                creditoUtilizado += valor - saldo;
                saldo = 0;
            }
            else
            {
                saldo -= valor;
            }
        }
    }
}
