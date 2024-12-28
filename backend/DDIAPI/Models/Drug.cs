namespace DDIAPI.Models;
public class Drug {
    int Id {get; set;}
    string? DrugName {get; set;}
    string? GenericDrugName {get; set;}
    string? BrandName {get; set;}
    string? DosageForm {get; set;}
    string? Strength {get; set;}
    public int DrugCategoryId {get; set;}
    public DrugCategory drugCategory {get; set;}
}