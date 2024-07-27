using System.Collections.Concurrent;

ObjectPool<X> pool = new ObjectPool<X>();
var x1 = pool.Get(() => new X());
x1.Count++;
//....
pool.Return(x1);

var x2 = pool.Get(() => new X());
x2.Count++;
pool.Return(x2);

var x3 = pool.Get(() => new X());
x3.Count++;
pool.Return(x3);

Console.WriteLine();

class ObjectPool<T> where T : class
{
    //Pool
    readonly ConcurrentBag<T> _instances;
    public ObjectPool()
    {
        _instances = new();
    }
    public ConcurrentBag<T> Instances { get => _instances; }
    public T Get(Func<T>? objectGenerator = null)
    {
        //Return the object of the type specified in the generic parameter from the pool.
        return _instances.TryTake(out T instance) ? instance : objectGenerator();
    }

    public void Return(T instance)
    {
        //Havuzdan ödünç alınan nesneyi geri iade etmek.
        _instances.Add(instance);
    }

}

class X
{
    public int Count { get; set; }
    public void Write()
        => Console.WriteLine(Count);

    public X()
        => Console.WriteLine("X created...");

    ~X()
        => Console.WriteLine("X disposed...");
}