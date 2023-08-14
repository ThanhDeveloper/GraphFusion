namespace CatGraph.Data
{
    public class DatabaseHelper
    {
        public static async Task SeedDatabaseAsync(WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var context = scope.ServiceProvider.GetRequiredService<CatContext>();
            if (await context.Database.EnsureCreatedAsync())
            {
                await context.Cats.AddRangeAsync(
                    new Cat
                    {
                        Name = "ding ding",

                    },
                    new Cat
                    {
                        Name = "dong dong",
                    });
                await context.SaveChangesAsync();
            }
        }
    }
}
