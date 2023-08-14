using CatGraph.Data;
using Microsoft.EntityFrameworkCore;

namespace CatGraph.Data.Types;

internal static class CatDataLoaders
{
    [DataLoader]
    public static async Task<IReadOnlyDictionary<int, Cat>> GetCatByIdAsync(
        IReadOnlyList<int> ids,
        CatContext context,
        CancellationToken cancellationToken)
        => await context.Cats
            .Where(t => ids.Contains(t.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
}
