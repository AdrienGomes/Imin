using IMINBackend.Services.Contract.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMINBackend.Services.Model.Association;

/// <summary> Represent a distribution enlistement for a volunteer</summary>
public class DistributionEnlistement : BaseIdendifiedElement
{
    [Required]
    /// <summary> The id of the distribution </summary>
    public required string DistributionId { get; set; }

    [ForeignKey(nameof(DistributionId))]
    /// <summary> The distribution </summary>
    public required Distribution Distribution { get; set; }

    [Required]
    /// <summary> The id of the volunteer </summary>
    public required string VolunteerId { get; set; }

    [ForeignKey(nameof(VolunteerId))]
    /// <summary> The volunteer </summary>
    public required Volunteer Volunteer { get; set; }

    [Required]
    /// <summary> The id of the pole </summary>
    public required string PoleId { get; set; }

    [ForeignKey(nameof(PoleId))]
    /// <summary> The pole for the enlistement </summary>
    public required Pole Pole { get; set; }

    [EnumDataType(typeof(PoleVolunteerStatus))]
    [Column(TypeName = "varchar(30)")]
    [DefaultValue(PoleVolunteerStatus.Member)]
    /// <summary> The status of the enlistement </summary>
    public PoleVolunteerStatus PoleEnlistementStatus { get; set; } = PoleVolunteerStatus.Member;
}
