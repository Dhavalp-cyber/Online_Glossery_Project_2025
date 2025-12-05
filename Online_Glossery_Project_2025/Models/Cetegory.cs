using System.ComponentModel.DataAnnotations;

namespace Online_Glossery_Project_2025.Models
{
    public class Cetegory
    {
        [Key]
        public int CetegoryID { get; set; }
        public string CetegoryName { get; set; }
    }
}
