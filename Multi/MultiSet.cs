using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using km.Collections.MultiZbior;

namespace multi
{
    public class MultiSet<T> : IMultiSet<T>
    {
        private Dictionary<T, int> mset = new Dictionary<T, int>();
        public MultiSet() { }
        private IEqualityComparer<T> comparer;
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

        public void IsSetReadonly()
        {
            if (this.IsReadOnly == true)
            {
                throw new NotSupportedException();
            }
        }

        public IEqualityComparer<T> Comparer => comparer;
        public MultiSet(IEqualityComparer<T> comparer) : this()
        {
            this.comparer = comparer;
        }
        public MultiSet(IEnumerable<T> sequence, IEqualityComparer<T> comparer) : this(sequence)
        {
            this.comparer = comparer;
        }

        public IMultiSet<T> Add(T item, int numberOfItems = 1)
        {
            IsSetReadonly();
            for (int i = 0; i < numberOfItems; i++)
                this.Add(item);
            return this;
        }
        
        public void Add(T item)
        {
            IsSetReadonly();
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
            return mset;
        }

        public IReadOnlySet<T> AsSet()
        {
            var set = new HashSet<T>();
            foreach (T el in mset.Keys)
            {
                set.Add(el);
            }
            return set;
        }

        public void Clear()
        {
            mset.Clear();
        }

        public bool Contains(T item)
        {
            if (mset.ContainsKey(item))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            List<T> temp = new List<T>();
            foreach (var x in this)
            {
                temp.Add(x);
            }
            temp.CopyTo(array, arrayIndex);
        }

        public IMultiSet<T> ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }
            IsSetReadonly();
            foreach (var otherEl in other)
            {
                if (!mset.ContainsKey(otherEl))
                    continue;
                RemoveAll(otherEl);
            }
            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var (item, multiplicity) in mset)
            {
                for (int i = 0; i < multiplicity; i++)
                    yield return item;
            }
        }

        public IMultiSet<T> IntersectWith(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }
            IsSetReadonly();
            var multiset = new MultiSet<T>(other);
            var enumerator = multiset.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (Contains(enumerator.Current))
                {
                    Remove(enumerator.Current, this[enumerator.Current] - multiset[enumerator.Current]);
                }
                else
                {
                    Remove(enumerator.Current);
                }
            }
            return this;
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }
            if (!IsSubsetOf(other))
                return false;
            var multiset = new MultiSet<T>(other);
            var enumerator = multiset.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (!Contains(enumerator.Current) || multiset[enumerator.Current] > this[enumerator.Current])
                    return true;
            }
            return false;
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }
            if (!IsSupersetOf(other))
                return false;
            var multiset = new MultiSet<T>(other);
            var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (!multiset.Contains(enumerator.Current) || this[enumerator.Current] > multiset[enumerator.Current])
                    return true;
            }
            return false;
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }
            var multiset = new MultiSet<T>(other);
            var enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (!multiset.Contains(enumerator.Current) || multiset[enumerator.Current] < this[enumerator.Current])
                    return false;
            }
            return true;
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other is null)
            {
                throw new ArgumentNullException();
            }
            var multiset = new MultiSet<T>(other);
            var enumerator = multiset.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (!Contains(enumerator.Current) || multiset[enumerator.Current] > this[enumerator.Current])
                    return false;
            }
            return true;
        }

        public bool MultiSetEquals(IEnumerable<T> other)
        {
            var multiset = new MultiSet<T>(other);
            foreach (T el in mset.Keys)
            {
                if (!multiset.Contains(el) || multiset[el] != this[el])
                    return false;
            }
            return true;
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            foreach (var el in other)
            {
                if (mset.ContainsKey(el))
                    return true;
            }
            return false;
        }

        public IMultiSet<T> Remove(T item, int numberOfItems = 1)
        {
            IsSetReadonly();
            if (mset[item] < numberOfItems)
                numberOfItems = mset[item];
            if (mset.ContainsKey(item))
            {
                for (int i = 0; i < numberOfItems; i++)
                    this.Remove(item);
            }
            return this;
        }

        public bool Remove(T item)
        {
            IsSetReadonly();
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
            IsSetReadonly();
            if (mset.ContainsKey(item))
                mset.Remove(item);
            return this;
        }

        public IMultiSet<T> SymmetricExceptWith(IEnumerable<T> other)
        {
            IsSetReadonly();
            if (other is null)
            {
                throw new ArgumentNullException();
            }

            var enumerable = other as T[] ?? other.ToArray();
            UnionWith(enumerable);
            foreach (var item in mset.Keys)
            {
                if (Contains(item) && !enumerable.Contains(item))
                {
                    Remove(item);
                }
            }

            return this;
        }

        public IMultiSet<T> UnionWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            IsSetReadonly();
            foreach (var el in other)
                this.Add(el);
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
