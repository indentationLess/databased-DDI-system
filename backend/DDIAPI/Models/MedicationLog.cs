using System.ComponentModel.DataAnnotations;

namespace DDIAPI.Models;
public class MedicationLogs {
    int id {get; set;}
    int drugID {get; set;}
    public Drug drug {get; set;}
    string? dosage {get; set;}
    [DataType(DataType.Date)]
    public DateTime startDate {get; set;}
    public DateTime endDate {get; set;}
    string? Notes {get; set;}
}