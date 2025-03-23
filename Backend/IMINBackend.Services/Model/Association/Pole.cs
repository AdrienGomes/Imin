using IMINBackend.Services.Contract.Model;
using System.ComponentModel.DataAnnotations;

namespace IMINBackend.Services.Model.Association;

/// <summary> Represent a pole of volunteers </summary>
public class Pole : BaseIdendifiedElement
{
    /// <summary> The label of the pole </summary>
    [Required]
    public required string Label { get; set; }

    /// <summary> The color of the pole (the hexadecimal value) </summary>
    /// <remarks> An example of color wwould be : "#FF43A7"</remarks>
    [Required]
    public required string Color { get; set; }
}

/// <summary> Represent the status of a volunteer in a pole </summary>
public enum PoleStatus
{
    /// <summary> 0 : Member </summary>
    Member,

    /// <summary> 1 : Referent </summary>
    Referent,

    /// <summary> 2 : Manager </summary>
    Manager,
}