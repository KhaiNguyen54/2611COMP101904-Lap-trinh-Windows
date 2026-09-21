namespace Lab04_QuanLySanPham;

public class ProductChangeEventArgs : EventArgs
{
    public string Message { get; }

    public ProductChangeEventArgs(string message)
    {
        Message = message;
    }
}

public class ProductService
{
    private readonly Repository<Product> _repository = new();

    public event EventHandler<ProductChangeEventArgs>? ProductChanged;

    public void AddProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        _repository.Add(product);
        OnProductChanged($"Đã thêm sản phẩm {product.MaSP}.");
    }

    public void RemoveProduct(string productId)
    {
        if (string.IsNullOrWhiteSpace(productId))
            throw new ArgumentException("Mã sản phẩm không được rỗng.");

        _repository.Remove(productId);
        OnProductChanged($"Đã xóa sản phẩm {productId}.");
    }

    public Product? FindById(string productId)
    {
        return _repository.FindById(productId);
    }

    public List<Product> FindByName(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return GetAll();

        return _repository.Find(p => p.TenSP.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    public List<Product> Filter(Func<Product, bool> predicate)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        return _repository.Find(predicate);
    }

    public List<Product> GetAll()
    {
        return _repository.GetAll();
    }

    public decimal CalculateTotalInventoryValue()
    {
        return GetAll().Sum(p => p.Price * p.Quantity);
    }

    protected virtual void OnProductChanged(string message)
    {
        ProductChanged?.Invoke(this, new ProductChangeEventArgs(message));
    }
}
