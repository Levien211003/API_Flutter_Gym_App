namespace UserRegistrationApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public decimal? Height { get; set; }  // Thay đổi từ float? thành decimal?
        public decimal? Weight { get; set; }
        public string? Gender { get; set; }
        public string? MucTieu { get; set; }
        public string? Fullname { get; set; }
        public string? Nickname { get; set; }
        public string? MobileNumber { get; set; }
        public string? Image { get; set; }
        public string? Level { get; set; }
    }

}
