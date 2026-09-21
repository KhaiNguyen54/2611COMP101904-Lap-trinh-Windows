namespace Lab04_QuanLySanPham;

public class Repository<T> where T : class, IEntity
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        if (_items.Any(x => string.Equals(x.Id, item.Id, StringComparison.OrdinalIgnoreCase)))
            throw new DuplicateProductException(item.Id);

        _items.Add(item);
    }

    public void Remove(string id)
    {
        T? item = _items.FirstOrDefault(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));

        if (item == null)
            throw new ProductNotFoundException(id);

        _items.Remove(item);
    }

    public T? FindById(string id)
    {
        return _items.FirstOrDefault(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
    }

    public List<T> Find(Func<T, bool> predicate)
    {
        return _items.Where(predicate).ToList();
    }

    public List<T> GetAll()
    {
        return new List<T>(_items);
    }
}
