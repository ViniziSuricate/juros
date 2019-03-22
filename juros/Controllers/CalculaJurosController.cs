using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using juros.calculadora;



namespace calculajuros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : Controller
    {
        //exemplo de entrada da especificação
        // api.../calculajuros?valorinicial=100&meses=5 Resultado esperado: 105,10
        // padrao da url de teste https://localhost:5001/api/calculajuros?valorinicial=100&meses=5

        // GET api/calculajuros
        public ActionResult<IEnumerable<string>> Get(string valorinicial, string meses)
        {

            if (string.IsNullOrEmpty(valorinicial) || string.IsNullOrEmpty(meses))
                return new string[] { "Faltam parâmetros de Entrada", "Entrar Valor Inicial e Meses para Calculo de Juros" };
            else
            {
                CalculadoraJuros calc = new CalculadoraJuros();
                return new string[] {  calc.CalculaJuros(Convert.ToDecimal(valorinicial), Convert.ToInt16(meses)).ToString() };
            }
        }
    }
}