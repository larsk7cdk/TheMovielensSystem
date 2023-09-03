namespace Movielens.Contracts.Entities;

/// <summary>
///     Movie entity compared to the MongoDB structure
/// </summary>
public class MovieEntity
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string[] Genres { get; init; }
}