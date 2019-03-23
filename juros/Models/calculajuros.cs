using System;

namespace juros.calculadora
{
    public class CalculadoraJuros
    {
        public decimal CalculaJuros(decimal valInicialDecimal, int prazoCalcMeses)
        {

            // consistencias lógicas
            // considerando retorno -999999999 como valor inválido para cálculo
            if (valInicialDecimal == 0)
                //Faltam parâmetros de Entrada, Entrar Valor Inicial e Meses para Calculo de Juros
                return 0;
            else
            if (prazoCalcMeses < 0)
                //meses negativos representam valores não lógico para tratamento de valores financeiro
                return -999999998;
            else
            if (valInicialDecimal < 0)
                //valores negativos representam valores não lógico para tratamento de valores financeiro
                return -999999997;

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

            try
            {
                wJurosAcc = Convert.ToDecimal(Math.Pow(wJuros, wTempo));
            }
            catch (Exception e)
            {
                //calculo excede o tamanho do campo decimal
                System.Console.WriteLine("Error Code -999999991: " + e.Message);
                valFinal = -999999991;
                return valFinal;
            }


            // calculo truncado em 2 casas decimais, não utilizado arredondamento padrão, conforme especificação
            try
            {
                valFinal = Math.Truncate(valInicialDecimal * wJurosAcc * 100) / 100;
            }
            catch (Exception e)
            {
                //calculo excede o tamanho do campo decimal
                System.Console.WriteLine("Error Code -999999990: " + e.Message);
                valFinal = -999999990;
                return valFinal;

            }

            return valFinal;

        }
    }
}
