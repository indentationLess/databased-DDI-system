using System.ComponentModel.DataAnnotations;

namespace DDIAPI.Models;
public class MedicationLogs {
    public int id {get; set;}
    public int drugID {get; set;}
    public Drug drug {get; set;}
    public string? dosage {get; set;}
    [DataType(DataType.Date)]
    public DateTime startDate {get; set;}
    public DateTime endDate {get; set;}
    public string? Notes {get; set;}
}