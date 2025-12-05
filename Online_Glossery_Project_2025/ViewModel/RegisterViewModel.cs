using System.ComponentModel.DataAnnotations;

namespace Online_Glossery_Project_2025.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Plese Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Plese Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Plese Enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Plese Enter Phone Number")]
        public long? Phone { get; set; }
        [Required(ErrorMessage = "Plese Select Role")]
        public bool Islogin { get; set; }

        public bool IsActive { get; set; }
    }
}
