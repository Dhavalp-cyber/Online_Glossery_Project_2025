using System.ComponentModel.DataAnnotations;

namespace Online_Glossery_Project_2025.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Plaese Enter Valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Plese Enter Password")]
        public string Password { get; set; }
    }
}
