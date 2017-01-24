using Microsoft.AspNetCore.Mvc;

namespace MyCodeCamp.Controllers
{
    [Route("api/camps")]
    public class CampsController: Controller
    {
        public IActionResult Get()
        {
            return Ok(new {Name = "Phelipe", FavouriteColor = "Blue"});
        }
    }
}