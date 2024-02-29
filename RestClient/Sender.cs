using RestMessages;
using System.Net.Http.Json;
using System.Text.Json;

namespace RestClient
{
    public class Sender : IDisposable
    {
        private HttpClient _httpClient;
        private HelloRequest _defaultRequest;

        public Sender()
        {
            _httpClient = new HttpClient();
            _defaultRequest = new HelloRequest() { Name = "default" };
        }

        public async Task<string> Post()
        {
            var request = new HelloRequest()
            {
                Name = "John Doe"
            };
            var content = JsonContent.Create(request);
            var response = await _httpClient.PostAsync("http://localhost:5082/greet", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<HelloResponse>(responseString)!.Message;
        }

        public async Task<string> PostDefault()
        {
            var content = JsonContent.Create(_defaultRequest);
            var response = await _httpClient.PostAsync("http://localhost:5082/greet", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<HelloResponse>(responseString)!.Message;
        }

        public async Task<string> Get()
        {
            var response = await _httpClient.GetAsync("http://localhost:5082/greet");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostComplex()
        {
            var request = new ComplexRequest()
            {
                IntField = 1,
                StringField = "hello",
                SubField = new ComplexRequestSubcontent()
                {
                    SubField = 2
                }
            };

            var content = JsonContent.Create(request);
            var response = await _httpClient.PostAsync("http://localhost:5082/greet_complex", content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SimpleResponse>(responseString)!.Message;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
