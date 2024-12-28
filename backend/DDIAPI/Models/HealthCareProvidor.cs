namespace DDIAPI.Models
{
    public class HealthCareProvider
    {
        public int Id { get; set; }
        // public int PatientId { get; set; }
        // public Patient Patient { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Speciality { get; set; }
    }
}