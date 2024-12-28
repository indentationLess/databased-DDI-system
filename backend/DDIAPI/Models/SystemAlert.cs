using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDIAPI.Models;
public class SystemAlert {
    public int id {get; set;}
    [ForeignKey("Interaction")]

    // public int interactionID {get; set;}
    // public Interaction interaction {get; set;}
    [DataType(DataType.Date)]
    public DateTime dateCreated {get; set;}
    public string? message {get; set;}
}