namespace Catalog.Application.Responses;
public record ProductTypeResponse
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}