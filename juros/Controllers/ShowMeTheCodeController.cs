using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace juros.Controllers
{
    [Route("api/[controller]")]
    public class ShowMeTheCodeController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            // Retorno com link do repositório git da api
            return new string ( "https://github.com/ViniziSuricate/juros" );
        }


    }
}
