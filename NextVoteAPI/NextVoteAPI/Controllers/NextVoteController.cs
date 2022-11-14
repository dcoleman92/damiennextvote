using Microsoft.AspNetCore.Mvc; 

namespace NextVoteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NextVoteController : ControllerBase
    {

        private readonly ILogger<NextVoteController> _logger;

        public NextVoteController(ILogger<NextVoteController> logger)
        {
            _logger = logger;
        }
        [Route("inventory")]
        [HttpGet]
        public ActionResult<Inventory> GetInventory()
        {
            Inventory inventory = new Inventory();

            List<Item> itemList = new List<Item>()
            {
                new Item {Description = "Chair", Count = 18 },
                new Item { Description = "Table", Count = 3 },
                new Item { Description = "Clock", Count = 5 },
                new Item { Description = "Cooler", Count = 2 },
                new Item { Description = "Pen", Count = 20 },
                new Item { Description = "Eraser", Count = 4 },
                new Item { Description = "Scissor", Count = 5 }
            };

            inventory.ItemList = itemList;

            return inventory;
        }

        [Route("time")]
        [HttpGet]
        public ActionResult<int> GetTime()
        {
            int time = 1;
            return time;
        }

    }
}