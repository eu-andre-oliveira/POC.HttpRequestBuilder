using Microsoft.AspNetCore.Mvc;
using POC.HttpRequestBuilder.Builder;

namespace POC.HttpRequestBuilder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            var req = RequestBuilder
                .Configure()
                .WithUri("https://data.directory.openbankingbrasil.org.br/participants")
                .WithHttpMethod(HttpMethod.Get)
                .AddPayload("payload json")
                .AddHeader("Chave-Idempotencia", "5PIXE556-1487-A2ZZ-9406-A1DE3Y9999P9")
                .AddHeader("Authorization", "Bearer eyJhbGciOiJQUzI1NiIsImtpZCI6IjU3M0I4M0Q5OEIwMjY0MzA4RUY2NzBBQjE4Qzc2ODk5MTMxQTEyQjUiLCJ4NXQiOiJWenVEMllzQ1pEQ085bkNyR01kb21STWFFclUiLCJ0eXAiOiJKV1QifQ.eyJ1bmlxdWVfbmFtZSI6Imxpc3RobWwiLCJqdGkiOiIyNjJhNDM0NGFkODg0YzE0OWMwMDYxNDFkYzQ4NmU2MiIsInVzZXJfaWQiOiIzYTA4NGQ2ZmNjZDA0ZjM1OGRlMWNiMzFkN2NjMzhhYSIsImlzcGJfcHNwIjoiMzQwODgwMjkiLCJpc3BiX3BzcF9pbmRpcmV0byI6IiIsImRpc3BsYXlfbmFtZSI6IiBsaXN0byIsImF1ZCI6WyJxcmNvZGVfYXBpIiwiZnJvbnRlbmQiLCJkaWN0X2FwaSIsImF1dGhfYXBpIiwic3BpX2FwaSJdLCJuYmYiOjE2NDk4NzI2NDUsImV4cCI6MTY0OTkwMTQ0NSwiaWF0IjoxNjQ5ODcyNjQ1LCJpc3MiOiJqZC5waS5hdXRoIn0.Tj8ZlbhVKxv4BRWwUDi-GKox3UkpqzNYXV0OmZFUOK9ZpC_BJ0smIAwctNhTy-QGgfW5TeLuQIRUKZu5-EgpMepf58G1h0KM1DiVD9hkYGcpxevL0NQQaTivRrDxP2NfRyDdFNgeHi8r7cG0z-uoSKy0ewU6QwyVBmDZVlpjW_Dls0qPKr9efbORqUW273wP3JmufQuNkZzSs0KWwTAYSvyZ4PhftCAmoQu12KnnbAH79AOr7HIG9eEe5n9jBogWSrX6StyMvYze3ShGRojNCbYtP5FrHrQeHJqzK5PCffnhL2E1Hn2GMsRAnVzog76jZqN2HwqeA02Z1VAPFBerGg")
                .AddParameter("application/json", "")
                .SendRequestAsync<List<WeatherForecast>>().Result;


            var reqSemHeader = RequestBuilder
                .Configure()
                .WithUri("https://data.directory.openbankingbrasil.org.br/participants")
                .WithHttpMethod(HttpMethod.Post)
                .AddPayload("payload json")
                .AddParameter("application/json", "")
                .SendRequestAsync<List<WeatherForecast>>().Result;


            var reqSemParameter = RequestBuilder
                .Configure()
                .WithUri("https://data.directory.openbankingbrasil.org.br/participants")
                .WithHttpMethod(HttpMethod.Post)
                .AddPayload("payload json")
                .SendRequestAsync<List<WeatherForecast>>().Result;

            var reqSemPayload = RequestBuilder
                .Configure()
                .WithUri("https://data.directory.openbankingbrasil.org.br/participants")
                .WithHttpMethod(HttpMethod.Post)
                .SendRequestAsync<List<WeatherForecast>>().Result;

            var reqParaColocarParametrosDepois = RequestBuilder
                .Configure()
                .WithUri("https://data.directory.openbankingbrasil.org.br/participants")
                .WithHttpMethod(HttpMethod.Post);

            //condição para colocar parametro
            bool codicaoParaParametro = true;
            bool codicaoParaParametro2 = false;
            if (codicaoParaParametro)
                reqParaColocarParametrosDepois.AddParameter("application/json", "");
            if (codicaoParaParametro2)
                reqParaColocarParametrosDepois.AddParameter("application/json", "");


            return req;
        }
    }
}