using Newtonsoft.Json;
using POC.HttpRequestBuilder.Builder.Interfaces;
using RestSharp;
using System.Net.Http.Headers;

namespace POC.HttpRequestBuilder.Builder
{
    public class RequestBuilder :
        IRequestBuilder,
        IRequestBuilderUri,
        IRequestBuilderMethod,
        IRequestBuilderPayload,
        IRequestBuilderHeader,
        IRequestBuilderParameter
    {
        public const string HttpName = "OPENBANKING";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public List<string>? Parameters { get; private set; } = new(); // melhorar para especificar tipos diferentes como query 
        public List<string>? Headers { get; private set; } = new();
        public HttpMethod HttpMethodRequest { get; private set; }
        public string Uri { get; private set; }
        public string? Payload { get; private set; }
        public string? Authorization { get; private set; }

        private RequestBuilder()
        {
            //_httpClient = _httpClientFactory.CreateClient(HttpName);
            _httpClient = new HttpClient();
        }
        public static IRequestBuilder Configure()
        {


            //Aqui deve entrar a logica de gerar o httpClient e realizar o request

            return new RequestBuilder();
        }

        public IRequestBuilderMethod WithHttpMethod(HttpMethod httpMethod)
        {
            HttpMethodRequest = httpMethod;
            return this;
        }

        public IRequestBuilderUri WithUri(string uri)
        {
            Uri = uri;
            return this;
        }

        public IRequestBuilderPayload AddPayload(string payload)
        {
            Payload = payload;
            return this;
        }

        public IRequestBuilderParameter AddParameter(string parameter, string value)
        {
            Parameters.Add($"{parameter }|{value}");
            return this;
        }

        public IRequestBuilderHeader AddHeader(string headerName, string value)
        {
            Headers.Add($"{headerName }|{value}");
            return this;
        }

        public async Task<T> SendRequestAsync<T>()
        {
            try
            {
                var url = $"{Uri}";

                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethodRequest, new Uri(url));

                if (Authorization != string.Empty)
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Authorization);

                foreach (var header in Headers)
                {
                    var dados = header.Split('|');
                    httpRequest.Headers.Add(dados[0], dados[1]);
                }

                foreach (var param in Parameters)
                {
                    var dados = param.Split('|');
                    //implementar logica de parametros
                }

                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequest);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<T>(content);
                    return result;
                }
                return default(T);
            }
            catch (Exception)
            {

                return default(T);
            }
        }
    }
}
