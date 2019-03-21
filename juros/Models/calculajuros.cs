using System;

namespace juros.calculadora
{
    public class CalculadoraJuros
    {
        public decimal CalculaJuros(decimal valInicialDecimal, int prazoCalcMeses)
        {

            //exemplo de entrada da especificação
            ///calculajuros?valorinicial=100&meses=5 Resultado esperado: 105,10
            // https://localhost:5001/api/calculajuros?valorinicial=100&meses=5

            decimal valFinal = 0;
            double txJurosBase = 0.01;
            double wTempo = 0;
            double wJuros = 0;
            decimal wJurosAcc = 0;

            //formula base
            //Valor Final = Valor Inicial * (1 + juros) ^ Tempo

            wJuros = 1 + txJurosBase;
            wTempo = Convert.ToDouble(prazoCalcMeses);

            wJurosAcc = Convert.ToDecimal(Math.Pow( wJuros,wTempo));
            // calculo truncado em 2 casas decimais, não utilizado arredondamento padrão, conforme especificação
            valFinal = Math.Truncate(valInicialDecimal * wJurosAcc * 100)/100;
            return valFinal;

        }
    }
}
