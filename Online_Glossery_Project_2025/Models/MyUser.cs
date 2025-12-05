using System.ComponentModel.DataAnnotations;

namespace Online_Glossery_Project_2025.Models
{
    public class MyUser
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long? Phone { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
        public bool Islogin { get; set; }
    }
}
