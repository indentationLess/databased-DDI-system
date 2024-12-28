namespace DDIAPI.Models;
public class Drug {
    public int Id {get; set;}
    public string? DrugName {get; set;}
    public string? GenericDrugName {get; set;}
    public string? BrandName {get; set;}
    public string? DosageForm {get; set;}
    public string? Strength {get; set;}
    public  int DrugCategoryId {get; set;}
    public DrugCategory drugCategory {get; set;}
}