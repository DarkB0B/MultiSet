using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using km.Collections.MultiZbior;

namespace multi
{
    public class MultiSet<T> : IMultiSet<T>
    {
        private Dictionary<T, int> mset = new Dictionary<T, int>();
        public MultiSet() { }

        public MultiSet(IEnumerable<T> sequence)
        {
            foreach (var el in sequence)
            {
                this.Add(el);
            }
        }
        public int Count
        {
            get
            {
                int cnt = 0;
                foreach (var (item, multiplicity) in mset)
                {
                    for (int i = 0; i < multiplicity; i++)
                        cnt++;
                }
                return cnt;
            }
        }
        public int this[T item] => mset[item];
        public bool IsEmpty => Count == 0;
        public bool IsReadOnly => false;

        public IEqualityComparer<T> Comparer => throw new NotImplementedException();

        public IMultiSet<T> Add(T item, int numberOfItems = 1)
        {
            for (int i = 0; i < numberOfItems; i++)
                this.Add(item);
            return this;
        }
        
        public void Add(T item)
        {
            if (!mset.ContainsKey(item))
            {
                mset.Add(item, 1);
            }
            else
            {
                mset[item]++;
            }
        }

        public IReadOnlyDictionary<T, int> AsDictionary()
        {
            throw new NotImplementedException();
        }

        public IReadOnlySet<T> AsSet()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IMultiSet<T> ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IMultiSet<T> IntersectWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool MultiSetEquals(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public IMultiSet<T> Remove(T item, int numberOfItems = 1)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (!mset.ContainsKey(item))
                return false;
            if (mset[item] > 1)
            {
                mset[item]--;
                return true;
            }
            else
            {
                mset.Remove(item);
                return true;
            }
        }

        public IMultiSet<T> RemoveAll(T item)
        {
            throw new NotImplementedException();
        }

        public IMultiSet<T> SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public IMultiSet<T> UnionWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
