using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using juros.calculadora;



namespace juros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : Controller
    {
        //exemplo de entrada da especificação
        // api.../calculajuros?valorinicial=100&meses=5 Resultado esperado: 105,10
        // padrao da url de teste https://localhost:5001/api/calculajuros?valorinicial=100&meses=5

        // GET api/calculajuros
        public decimal Get(decimal valorinicial, int meses)
        {
            if (valorinicial == 0 && meses == 0)
                //string sem parametros de entrada
                return -999999999;
            else
            if (valorinicial.ToString() == "" || meses.ToString() == "")
                //Faltam parâmetros de Entrada, Entrar Valor Inicial e Meses para Calculo de Juros
                return -999999999;
            else
            {
                CalculadoraJuros calc = new CalculadoraJuros();
                return calc.CalculaJuros(valorinicial, meses);
            }
        }
    }
}