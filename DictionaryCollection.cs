namespace CollectionTester;

public class DictionaryCollection<T> : BaseCollection<T>
{
    private Dictionary<int, T> _dictionary = new();
    private int _currentIndex = 0;

    protected override void FillCollectionInternal(string[] input, Func<string, T> func)
    {
        foreach (var line in input)
        {
            _dictionary[_currentIndex++] = func(line);
        }
    }

    protected override void SortCollectionInternal(Func<T, T> comparer)
    {
        var SortEnumerable = _dictionary.OrderBy(kvp => comparer(kvp.Value));
        _dictionary = SortEnumerable.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    protected override void PrintCollectionInternal(TextWriter writer)
    {
        foreach (var kvp in _dictionary)
        {
            writer.WriteLine(kvp.Value);
        }
    }

    public override T FirstObject()
    {
        return _dictionary.Values.First();
    }

    public override T LastObject()
    {
        return _dictionary.Values.Last();
    }

    public override int Count()
    {
        return _dictionary.Count;
    }
}
