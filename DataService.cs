namespace EditCellTemplateRemoteOperations;

public class DataService
{
    private readonly List<ProductDto> _products;

    public DataService()
    {
        _products = (
            from i in Enumerable.Range(0, 1000)
            select new ProductDto
            {
                Id = i,
                Name = "Product " + i
            }
        ).ToList();
    }

    public List<ProductDto> GetData() => _products;
}

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}