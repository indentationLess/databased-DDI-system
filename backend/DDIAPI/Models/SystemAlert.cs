using System.ComponentModel.DataAnnotations;

namespace DDIAPI.Models;
public class SystemAlert {
    public int id {get; set;}
    public int interactionID {get; set;}
    public Interaction interaction {get; set;}
    [DataType(DataType.Date)]
    public DateTime dateCreated {get; set;}
    public string? message {get; set;}
}