using System.ComponentModel.DataAnnotations;

namespace Online_Glossery_Project_2025.Models
{
    public class SubCetegory
    {
        [Key]
        public int SubCetegoryID { get; set; }
        public string SubCetegoryName { get; set; }
        public int CetegoryID { get; set; }
    }
}
