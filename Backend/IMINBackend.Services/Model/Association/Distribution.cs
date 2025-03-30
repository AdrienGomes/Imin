using IMINBackend.Services.Contract.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMINBackend.Services.Model.Association;

/// <summary> Represent a distribution of volunteers </summary>
public class Distribution : BaseIdendifiedElement
{
    /// <summary> The description of the distribution </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary> The Date of the distribution </summary>
    [Required]
    public required DateTime Date { get; set; }

    [EnumDataType(typeof(DistributionState))]
    [Column(TypeName = "varchar(30)")]
    [Required]
    /// <summary> The state of the distribution </summary>
    public required DistributionState State { get; set; }

    [Required]
    /// <summary> The id of the Publisher </summary>
    public required string PublisherId { get; set; }

    [ForeignKey(nameof(PublisherId))]
    /// <summary> The volunteer responsible for handling the distribution publication </summary>
    public required Volunteer Publisher { get; set; }

    [Required]
    /// <summary> The poles of the distribution </summary>
    public required IEnumerable<PoleDistributionEnlistement> Poles { get; set; }

    [Required]
    /// <summary> The enlistements of the distribution </summary>
    public required IEnumerable<DistributionEnlistement> DistributionEnlistements { get; set; }
}

/// <summary> Represent the state of a distribution </summary>
public enum DistributionState
{
    /// <summary> 0 : Planned </summary>
    Planned,
    /// <summary> 1 : InProgress </summary>
    InProgress,
    /// <summary> 2 : Done </summary>
    Done,
    /// <summary> 3 : Cancelled </summary>
    Cancelled,
}