using CatGraph.Data;
using CatGraph.Data.Types;

namespace CatGraph.Types;

[QueryType]
public static class Queries
{
    [NodeResolver]
    public static async Task<Cat?> GetUserById(
    int id,
    CatByIdDataLoader catById,
    CancellationToken cancellationToken)
    => await catById.LoadAsync(id, cancellationToken);

    public static IQueryable<Cat> GetCats(CatContext context)
         => context.Cats.OrderBy(t => t.Name);
}
