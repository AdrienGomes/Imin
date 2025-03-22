using IMINBackend.Services.Contract.Model;
using System.ComponentModel.DataAnnotations;

namespace IMINBackend.Services.Model.Account;

/// <summary>
/// Describe a user of this application
/// </summary>
public class User : BaseIdendifiedElement
{
    /// <summary>
    /// User's first name
    /// </summary>
    [Required]
    public required string FirstName { get; set; }

    /// <summary>
    /// User's last name
    /// </summary>
    [Required]
    public required string LastName { get; set; }

    /// <summary>
    /// User's birth date
    /// </summary>
    [Required]
    public required DateTime BirthDate { get; set; }
}
