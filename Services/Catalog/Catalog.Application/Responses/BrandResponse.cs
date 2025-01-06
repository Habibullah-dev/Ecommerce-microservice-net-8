namespace Catalog.Application.Responses;
public record BrandResponse
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}