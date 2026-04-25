using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HttpClientSample.Models;


namespace HttpClientSample
{
    
    public class RestApiQueries
    {
        private HttpClient _client;

        public RestApiQueries()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
