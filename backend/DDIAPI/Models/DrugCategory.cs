namespace DDIAPI.Models;
public class DrugCategory {
    int Id {get; set;}
    string? CategoryName {get; set;}
    string? Description {get; set;}
    public ICollection<Drug> drugs {get;}
}