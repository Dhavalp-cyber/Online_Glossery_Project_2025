using Microsoft.AspNetCore.Mvc;
using Online_Glossery_Project_2025.Data;

namespace Online_Glossery_Project_2025.Controllers
{
    public class ImageController : Controller
    {
        private readonly DB db;
        public ImageController(DB db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var images = db.images.ToList();
            return View(images);  
        }

        public IActionResult ImageUpload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImageUpload(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);
                    var imageData = memoryStream.ToArray();

                    var imageModel = new Models.Images
                    {
                        Name = imageFile.Name,
                        Image = imageData
                    };

                    db.images.Add(imageModel);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Please select a valid image file.");
            return View();
        }

        public IActionResult DisplayImage(int id)
        {
            var img = db.images.FirstOrDefault(x => x.Id == id);
            if (img == null)
                return NotFound();

            return File(img.Image, "image/jpeg");
        }
    }
}
