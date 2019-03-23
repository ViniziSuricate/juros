using System;
using System.Net.Http;
using System.Web;
using System.Web.UI;

namespace Default
{

    public partial class Default : System.Web.UI.Page
    {
        public void button1Clicked(object sender, EventArgs args)
        {
            HttpClient client;
            Uri usuarioUri;

            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string parametros = "?valorinicial=" + txtValor.Text + "&meses=" + txtMeses.Text;

            //http://localhost/api/calculajuros?valorinicial=100&meses=5

            //System.Net.Http.HttpResponseMessage response = client.PostAsJsonAsync("JurosAPI/calculajuros", parametros);
            HttpResponseMessage response = client.GetAsync("api/calculajuros" + parametros).Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                usuarioUri = response.Headers.Location;

                var valorResposta = response.Content.ReadAsAsync<Decimal>().Result;

                button1.Text = "Recalcular Taxa";
                txtResultado.Text = valorResposta.ToString();
            }
            else
            {
                Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
            }
        }

        public void button2Clicked(object sender, EventArgs args)
        {
            HttpClient client;
            Uri usuarioUri;

            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/showmethecode").Result;

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                usuarioUri = response.Headers.Location;

                var valorResposta = response.Content.ReadAsAsync<Decimal>().Result;

                button1.Text = "";
                txtLink.Text = valorResposta.ToString();
            }
            else
            {
                Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
            }
        }
    }
}
