using IMINBackend.Services.Contract.Model;
using IMINBackend.Services.Model.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMINBackend.Services.Model.Association;

/// <summary> Represent a volunteer </summary>
public class Volunteer : BaseIdendifiedElement
{
    /// <summary> The id of the user </summary>
    [Required]
    public required string UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    /// <summary> The user for the voluntter </summary>
    public required User User { get; set; }

    /// <summary> The date of the last HelloAsso inscription </summary>
    [Required]
    public required DateTime LastInscriptionDate { get; set; }

    /// <summary> The date of the last distribution of the volunteer </summary>
    public DateTime? LastDistribution { get; set; }

    /// <summary> The pole memberships of the volunteer </summary>
    public IEnumerable<PoleMembership> PoleMemberships { get; set; } = [];
}
