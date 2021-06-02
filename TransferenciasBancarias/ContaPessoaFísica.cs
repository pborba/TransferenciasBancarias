using System;
using System.Collections.Generic;
using System.Text;

namespace TransferenciasBancarias
{
    class ContaPessoaFisica : Conta
    {

        public ContaPessoaFisica(string nome, double saldo, double credito) : 
            base(nome, saldo, credito) {
        }

        override
        public string ToString()
        {
            StringBuilder strb = new StringBuilder();
            strb.Append($"{numero}");
            strb.Append(" | ");
            strb.Append($"Nome: {nomeCliente}");
            strb.Append(" | ");
            strb.Append("Pessoa Física");
            strb.Append(" | ");
            strb.Append($"Saldo: {saldo:0.00}");
            strb.Append(" | ");
            var creditUsed = -1 * creditoUtilizado;
            strb.Append($"Crédito usado: {creditUsed:0.00}");
            strb.Append(" | ");
            strb.Append($"Limite: {credito:0.00}");
            strb.Append(" | ");


            return strb.ToString();
        }
    }
}
