using System.ComponentModel.DataAnnotations.Schema;

namespace DDIAPI.Models;
public class Drug {
    public int Id {get; set;}
    public string? DrugName {get; set;}
    public string? GenericDrugName {get; set;}
    public string? BrandName {get; set;}
    public string? DosageForm {get; set;}
    public string? Strength {get; set;}
    [ForeignKey("DrugCategoryId")]

    public  int DrugCategoryId {get; set;}
    // public ICollection<Interaction> InteractionsAsDrug1 { get; set; }
    // public ICollection<Interaction> InteractionsAsDrug2 { get; set; }
    public DrugCategory drugCategory {get; set;}

}