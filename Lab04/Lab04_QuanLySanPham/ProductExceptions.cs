namespace Lab04_QuanLySanPham;

public class DuplicateProductException : Exception
{
    public DuplicateProductException(string productId)
        : base($"Sản phẩm có mã '{productId}' đã tồn tại.")
    {
    }
}

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string productId)
        : base($"Không tìm thấy sản phẩm có mã '{productId}'.")
    {
    }
}
