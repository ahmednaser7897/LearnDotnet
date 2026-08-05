namespace CsharpFundamentals.CsharpOop;

internal static class GenericsAndConstraints
{
    public static void Run()
    {
        Console.WriteLine("\n========== Generics and Constraints ==========");

        Repository<User, int> repository = new(user => user.Id);
        repository.Add(new User(1, "Hana"));
        repository.Add(new User(2, "Youssef"));

        User? user = repository.Find(2);
        Console.WriteLine($"Found: {user?.Name}");

        AuditedEntity entity = Factory.Create<AuditedEntity>();
        Console.WriteLine($"Factory created: {entity.GetType().Name}");

        IEnumerable<string> names = new List<string> { "A", "B" }; // Covariant conversion.
        IComparer<string> comparer = Comparer<object>.Create((x, y) =>
            string.Compare(x?.ToString(), y?.ToString(), StringComparison.Ordinal));
        Console.WriteLine($"Covariant values: {string.Join(", ", names)}");
        Console.WriteLine($"Contravariant comparer result: {comparer.Compare("A", "B")}");
    }

    private interface IEntity<TKey> where TKey : notnull
    {
        TKey Id { get; }
    }

    private sealed record User(int Id, string Name) : IEntity<int>;

    private sealed class Repository<TEntity, TKey>
        where TEntity : class
        where TKey : notnull
    {
        private readonly Dictionary<TKey, TEntity> _items = [];
        private readonly Func<TEntity, TKey> _keySelector;

        public Repository(Func<TEntity, TKey> keySelector)
        {
            _keySelector = keySelector;
        }

        public void Add(TEntity entity) => _items.Add(_keySelector(entity), entity);

        public TEntity? Find(TKey id) => _items.GetValueOrDefault(id);
    }

    private sealed class AuditedEntity
    {
        public DateTime CreatedAtUtc { get; } = DateTime.UtcNow;
    }

    private static class Factory
    {
        // new() means T must be non-abstract and have a public parameterless constructor.
        public static T Create<T>() where T : class, new() => new T();
    }
}

