using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace NextVoteApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountdownEndController : ControllerBase
    {

        private readonly ILogger<CountdownEndController> _logger;

        public CountdownEndController(ILogger<CountdownEndController> logger)
        {
            _logger = logger;
        }

        [Route("countdownEnd")]
        [HttpPost]
        public async Task<ActionResult> Write(Inventory inv)
        {
            Inventory inventory = new Inventory();

            inventory = inv;

            using StreamWriter file = new("Inventory.txt");
            file.WriteLine("Description - Count");
            foreach (Item i in inventory.ItemList)
            {
                await file.WriteLineAsync(i.Description + " - " + i.Count.ToString());
            }

            return Ok();

        }

    }


}