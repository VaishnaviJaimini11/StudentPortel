namespace StudentPortel.Models
{
    public class AddStudentsViewModel
    {
        public required string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Subscribed { get; set; }
    }
}
