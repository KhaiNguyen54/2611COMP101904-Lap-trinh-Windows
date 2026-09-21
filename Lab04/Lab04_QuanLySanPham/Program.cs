namespace Lab04_QuanLySanPham;

class Program
{
    private static readonly ProductService productService = new();

    static void Main(string[] args)
    {
        productService.ProductChanged += (_, e) => Console.WriteLine($"[Event] {e.Message}");

        int luaChon = -1;

        while (luaChon != 0)
        {
            Console.WriteLine();
            Console.WriteLine("===== PRODUCT MANAGER =====");
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim theo ma");
            Console.WriteLine("4. Tim theo ten");
            Console.WriteLine("5. Loc theo khoang gia");
            Console.WriteLine("6. Xoa san pham");
            Console.WriteLine("7. Tinh tong gia tri kho");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon: ");

            if (!int.TryParse(Console.ReadLine(), out luaChon))
            {
                Console.WriteLine("Loi: Vui long nhap so hop le.");
                continue;
            }

            try
            {
                switch (luaChon)
                {
                    case 1:
                        AddProductUI();
                        break;
                    case 2:
                        DisplayProducts(productService.GetAll());
                        break;
                    case 3:
                        SearchByIdUI();
                        break;
                    case 4:
                        SearchByNameUI();
                        break;
                    case 5:
                        FilterByPriceRangeUI();
                        break;
                    case 6:
                        RemoveProductUI();
                        break;
                    case 7:
                        CalculateTotalInventoryUI();
                        break;
                    case 0:
                        Console.WriteLine("Dang thoat chuong trinh...");
                        break;
                    default:
                        Console.WriteLine("Loi: Chuc nang khong ton tai.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
        }
    }

    static void AddProductUI()
    {
        string maSP = ReadNonEmptyText("Nhap ma san pham: ");
        string tenSP = ReadNonEmptyText("Nhap ten san pham: ");
        decimal price = ReadDecimal("Nhap don gia: ");
        int quantity = ReadInt("Nhap so luong: ");

        Product product = new Product(maSP, tenSP, price, quantity);
        productService.AddProduct(product);
        Console.WriteLine("Them san pham thanh cong.");
    }

    static void DisplayProducts(IEnumerable<Product> products)
    {
        List<Product> productList = products.ToList();

        if (productList.Count == 0)
        {
            Console.WriteLine("Danh sach san pham dang trong.");
            return;
        }

        Console.WriteLine("--- Danh sach san pham ---");
        foreach (Product product in productList)
        {
            Console.WriteLine(product);
        }
    }

    static void SearchByIdUI()
    {
        string productId = ReadNonEmptyText("Nhap ma san pham can tim: ");
        Product? product = productService.FindById(productId);

        if (product == null)
        {
            Console.WriteLine("Khong tim thay san pham.");
            return;
        }

        Console.WriteLine("--- Ket qua tim theo ma ---");
        Console.WriteLine(product);
    }

    static void SearchByNameUI()
    {
        string keyword = ReadNonEmptyText("Nhap tu khoa ten san pham: ");
        List<Product> results = productService.FindByName(keyword);
        DisplayProducts(results);
    }

    static void FilterByPriceRangeUI()
    {
        decimal minPrice = ReadDecimal("Nhap gia thap nhat: ");
        decimal maxPrice = ReadDecimal("Nhap gia cao nhat: ");

        if (minPrice > maxPrice)
        {
            Console.WriteLine("Loi: Gia thap nhat khong duoc lon hon gia cao nhat.");
            return;
        }

        Func<Product, bool> filter = p => p.Price >= minPrice && p.Price <= maxPrice;
        List<Product> results = productService.Filter(filter);
        DisplayProducts(results);
    }

    static void RemoveProductUI()
    {
        string productId = ReadNonEmptyText("Nhap ma san pham can xoa: ");
        productService.RemoveProduct(productId);
        Console.WriteLine("Xoa san pham thanh cong.");
    }

    static void CalculateTotalInventoryUI()
    {
        decimal total = productService.CalculateTotalInventoryValue();
        Console.WriteLine($"Tong gia tri kho: {total:N0} VND");
    }

    static string ReadNonEmptyText(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.WriteLine("Loi: Khong duoc de trong.");
        }
    }

    static decimal ReadDecimal(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal result) && result >= 0)
                return result;

            Console.WriteLine("Loi: Vui long nhap so thuc khong am.");
        }
    }

    static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int result) && result >= 0)
                return result;

            Console.WriteLine("Loi: Vui long nhap so nguyen khong am.");
        }
    }
}
