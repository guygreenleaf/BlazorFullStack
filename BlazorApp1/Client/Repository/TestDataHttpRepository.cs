using BlazorApp1.Shared;
using System.Text.Json;


namespace BlazorApp1.Client.Repository
{
    public class TestDataHttpRepository : ITestDataHttpRepository
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;


        public TestDataHttpRepository(HttpClient client)
        {
            _httpClient = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};

        }

        public async Task<List<TestData>> GetTestData()
        {
            var response = await _httpClient.GetAsync("testData");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var testData = JsonSerializer.Deserialize<List<TestData>>(content, _options);

            return testData;
        }
    }
}
