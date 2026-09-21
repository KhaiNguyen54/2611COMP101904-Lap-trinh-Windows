namespace Lab04_QuanLySanPham;

public class Product : IEntity
{
    public string MaSP { get; }
    public string TenSP { get; }
    public decimal Price { get; }
    public int Quantity { get; }
    public string Id => MaSP;

    public Product(string maSP, string tenSP, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(maSP))
            throw new ArgumentException("Mã sản phẩm không được rỗng.");

        if (string.IsNullOrWhiteSpace(tenSP))
            throw new ArgumentException("Tên sản phẩm không được rỗng.");

        if (price < 0)
            throw new ArgumentException("Đơn giá không được âm.");

        if (quantity < 0)
            throw new ArgumentException("Số lượng không được âm.");

        MaSP = maSP.Trim();
        TenSP = tenSP.Trim();
        Price = price;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Mã: {MaSP}, Tên: {TenSP}, Đơn giá: {Price:N0}, Số lượng: {Quantity}";
    }
}
