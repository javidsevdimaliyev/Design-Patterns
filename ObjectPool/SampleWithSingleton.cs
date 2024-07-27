using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    internal class SampleWithSingleton
    {
        public void Test()
        {
            ObjectPool<X> pool = ObjectPool<X>.GetInstance;
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
        }

        //Objectpool Design Pattern with singleton design pattern
        class ObjectPool<T> where T : class
        {
            //Pool
            readonly ConcurrentBag<T> _instances;
            ObjectPool()
                => _instances = new();

            static ObjectPool<T> _objectPool;
            static ObjectPool() => _objectPool = new ObjectPool<T>();
            static public ObjectPool<T> GetInstance { get => _objectPool; }

            public ConcurrentBag<T> Instances { get => _instances; }
            public T Get(Func<T>? objectGenerator = null)
            {
                //Havuzdan generic parametrede bildirilen türdeki nesneyi geri döndürmek.
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
    }
}
