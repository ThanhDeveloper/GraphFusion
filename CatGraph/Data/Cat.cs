using System.ComponentModel.DataAnnotations;

namespace CatGraph.Data;

public class Cat
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
}
