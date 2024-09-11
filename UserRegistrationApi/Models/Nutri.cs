namespace UserRegistration.Models
{
    public class Nutri
    {
        public int Id { get; set; }
        public int Calo { get; set; }
        public string TimeCook { get; set; } // Sử dụng string thay vì TimeSpan
        public string Meal { get; set; }
        public string Imagenutri { get; set; }
        public bool Ready { get; set; }
        public string HowToCook { get; set; }
        public bool Favorite { get; set; }
    }
}
