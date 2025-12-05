namespace Online_Glossery_Project_2025.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Cost { get; set; }
        public byte[] Image { get; set; }

        public int CetegoryID { get; set; }
        public int SubCetegoryID { get; set; }
    }
}
