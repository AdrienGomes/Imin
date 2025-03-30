using IMINBackend.Services.Contract.Model;
using IMINBackend.Services.Model.Association;
using System.ComponentModel.DataAnnotations;

namespace IMINBackend.Services.Model.Account;

/// <summary> Describe a user of this application </summary>
public class User : BaseIdendifiedElement
{
    /// <summary> User's first name </summary>
    [Required]
    public required string FirstName { get; set; }

    /// <summary> User's last name </summary>
    [Required]
    public required string LastName { get; set; }

    /// <summary> User's birth date </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary> User's profil picture </summary>
    public byte[]? ProfilePicture { get; set; }

    /// <summary> The volunteer the user is associated with </summary>
    /// <remarks>No need to store foreign kee, has the relation is owned by the <see cref="Volunteer.UserId"/> property</remarks>
    public Volunteer? Volunteer { get; set; }
}
