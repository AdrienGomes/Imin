namespace IMINBackend.Contracts.Services;

/// <summary>
/// Service for bootstrap
/// </summary>
public interface IAppBootstrapService
{
    /// <summary>
    /// Do the bootstrap protocol
    /// </summary>
    Task DoAsync();
}