namespace Ogmios.Domain;

public class MirrorOptions
{
    /// <summary>
    /// A unique identifier sent with the request and expected to be mirrored by the server in the response.
    /// </summary>
    public string? Id { get; set; }
}