namespace DDIAPI.Models;
public class Interaction {
    int id {get; set;}
    public int drug1ID {get; set;}
    public int drug2ID {get; set;}
    ICollection<Drug> drugs {get; set;}
    public int severityId {get; set;}
    Severity severity {get; set;}
    public int clinicalRecommendationId {get; set;}
    ClinicalRecommendation clinicalRecommendation {get; set;}
    string? Description {get; set;}
}