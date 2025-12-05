using Microsoft.AspNetCore.Mvc;
using Online_Glossery_Project_2025.Data;

namespace Online_Glossery_Project_2025.Controllers
{
    public class AddToCartController : Controller
    {
        private readonly DB db;
        public AddToCartController(DB db)
        {
            db = db;
        }
        
         
    }
}
