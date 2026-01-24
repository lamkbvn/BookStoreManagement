using Microsoft.AspNetCore.Mvc;

namespace WebBanHang.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        public CategoryController() { }

        [HttpGet]
        public string GetALl()
        {
            return "Hello world";
        }
    }
}
