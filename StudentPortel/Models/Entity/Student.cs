namespace StudentPortel.Models.Entity
{
    public class Student
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Subscribed { get; set; }
    }
}
