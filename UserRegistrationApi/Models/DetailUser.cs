namespace UserRegistration.Models
{
    public class DetailUser
    {
        public int ID { get; set; }
        public string Gender { get; set; }
        public string MucTieu { get; set; } // Mục tiêu
        public int Age { get; set; }
        public float Height { get; set; } // Chiều cao (có thể dùng kiểu double hoặc float tùy thuộc vào độ chính xác cần thiết)
        public float Weight { get; set; } // Cân nặng (cũng có thể dùng double hoặc float)
        public string Level { get; set; }
        public string Fullname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Image { get; set; }
    }
}
