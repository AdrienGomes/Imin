using IMINBackend.Services.Contract.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMINBackend.Services.Model.Account;

/// <summary>
/// Describe an account within this application
/// </summary>
public class AccessAccount : BaseIdendifiedElement
{
    [Required]
    public required string UserId { get; set; } // Foreign Key

    /// <summary>
    /// The user of this account
    /// </summary>
    /// <remarks>This is the navigation property. See <see cref="UserId"/> for the actual foreign key</remarks>
    [ForeignKey("UserId")]
    public required User User { get; set; }

    /// <summary>
    /// User's email to connect to this account
    /// </summary>
    [Required]
    public required string Email { get; set; }

    /// <summary>
    /// First connection
    /// </summary>
    public DateTime? FirstConnection { get; set; }

    /// <summary>
    /// Last connection
    /// </summary>
    public DateTime? LastConnection { get; set; }

    /// <summary>
    /// True if the account is verified. This means it is ackonelge by an administrator
    /// </summary>
    [DefaultValue(false)]
    public bool IsVerified { get; set; } = false;
}
