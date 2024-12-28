namespace DDIAPI.Models
{
    public class HealthCareProvider
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Speciality { get; set; }
    }
}