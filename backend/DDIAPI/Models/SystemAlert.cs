using System.ComponentModel.DataAnnotations;

namespace DDIAPI.Models;
public class SystemAlert {
    int id {get; set;}
    int interactionID {get; set;}
    public Interaction interaction {get; set;}
    [DataType(DataType.Date)]
    public DateTime dateCreated {get; set;}
    string? message {get; set;}
}