
using BlazorApp1.Server.Data;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Controllers
{

    [ApiController]
    [Route("testData")]
    public class TestDataController : ControllerBase
    {

        private readonly DataContext _context;

        public TestDataController(DataContext context)
        {
            _context = context;

        }

        // GET /testData/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestData>>> GetTestData(int id)
        {
            var lister = await _context.TestTable.ToListAsync();

            return lister;
        }
    }
}
