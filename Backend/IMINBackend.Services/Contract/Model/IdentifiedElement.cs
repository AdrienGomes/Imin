using System.ComponentModel.DataAnnotations;

namespace IMINBackend.Services.Contract.Model;

/// <summary>
/// Represent an element identifiable by a guid
/// </summary>
interface IIdentifiedElement
{
    /// <summary>
    /// The Guid of the element
    /// </summary>
    public string Id { get; set; }
}

/// <summary>
/// Base class for 
/// </summary>
public class BaseIdendifiedElement : IIdentifiedElement
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
