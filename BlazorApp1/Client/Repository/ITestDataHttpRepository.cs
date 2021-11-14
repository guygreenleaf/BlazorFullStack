using BlazorApp1.Shared;

namespace BlazorApp1.Client.Repository
{
    public interface ITestDataHttpRepository
    {
        Task<List<TestData>> GetTestData();
    }
}
