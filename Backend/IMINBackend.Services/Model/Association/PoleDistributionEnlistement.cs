using IMINBackend.Services.Contract.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMINBackend.Services.Model.Association;

/// <summary> Represent a pole distribution enlistement </summary>
public class PoleDistributionEnlistement : BaseIdendifiedElement
{
    [Required]
    /// <summary> The id of the distribution </summary>
    public required string DistributionId { get; set; }

    [ForeignKey(nameof(DistributionId))]
    /// <summary> The distribution </summary>
    public required Distribution Distribution { get; set; }

    [Required]
    /// <summary> The id of the pole </summary>
    public required string PoleId { get; set; }

    [ForeignKey(nameof(PoleId))]
    /// <summary> The pole for the enlistement </summary>
    public required Pole Pole { get; set; }
}
