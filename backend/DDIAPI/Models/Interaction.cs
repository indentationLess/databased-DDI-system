namespace DDIAPI.Models;
public class Interaction {
    public int id {get; set;}
    public int drug1ID {get; set;}
    public int drug2ID {get; set;}
    public virtual ICollection<Drug> drugs {get; set;}
    public int severityId {get; set;}
    public Severity severity {get; set;}
    public int clinicalRecommendationId {get; set;}
    public ClinicalRecommendation clinicalRecommendation {get; set;}
    public string? Description {get; set;}
}