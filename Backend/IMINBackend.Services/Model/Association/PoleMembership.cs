using IMINBackend.Services.Contract.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMINBackend.Services.Model.Association;

/// <summary> Represent a pole membership for a volunteer </summary>
public class PoleMembership : BaseIdendifiedElement
{
    [Required]
    /// <summary> The id of the pole </summary>
    public required string PoleId { get; set; }

    [ForeignKey(nameof(PoleId))]
    /// <summary> The pole </summary>
    public required Pole Pole { get; set; }

    [Required]
    /// <summary> The id of the volunteer </summary>
    public required string VolunteerId { get; set; }

    [ForeignKey(nameof(VolunteerId))]
    /// <summary> The volunteer </summary>
    public required Volunteer Volunteer { get; set; }

    [Required]
    /// <summary> The priority of the pole for the volunteer </summary>
    public required int Priority { get; set; }

    [EnumDataType(typeof(PoleVolunteerStatus))]
    [Column(TypeName = "varchar(30)")]
    public required PoleVolunteerStatus MembershipStatus { get; set; }
}
