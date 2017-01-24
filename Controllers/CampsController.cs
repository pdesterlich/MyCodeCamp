using Microsoft.AspNetCore.Mvc;

namespace MyCodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController: Controller
    {
        public IActionResult Get()
        {
            return Ok(new {Name = "Phelipe", FavouriteColor = "Blue"});
        }
    }
}