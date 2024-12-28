namespace DDIAPI.Models;
public class DrugCategory {
    public int Id {get; set;}
    public string? CategoryName {get; set;}
    public string? Description {get; set;}
    public virtual ICollection<Drug> drugs {get;}
}