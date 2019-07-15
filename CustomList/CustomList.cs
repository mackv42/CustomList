using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomList 
{
    public class CustomList<T> : IEnumerable<T>
    {
        private int count;
        private T[] items;

        public CustomList() {
            count = 0;
        }

        public bool Equals(CustomList<T> a)
        {

            if (a.Count() != this.Count())
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                if (!a[i].Equals(this[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public CustomList(int length)
        {
            count = length;
            items = new T[length];
        }

        public CustomList(T[] arr)
        {
            int i = 0;
            try
            {
                while (1 == 1)
                {
                    T nan;
                    nan = arr[i];
                    i++;
                }
            } catch (IndexOutOfRangeException E)
            {
                this.resize(i);
                for (int n = 0; n < count; n++)
                {
                    this.items[n] = arr[n];
                }
            }
        }

        public int Count()
        {
            return count;
        }

        public void copyArr(CustomList<T> arr1, CustomList<T> arr2)
        {
            for (int i = 0; i < arr1.Count(); i++)
            {
                arr1[i] = arr2[i];
            }

        }

        private void resize(int n)
        {
            T[] arr2 = new T[n];

            if (n < 0)
            {
                count = -1;
                this.items = null;
            }

            if (n <= this.Count())
            {
                for (int i = 0; i < n; i++)
                {
                    arr2[i] = items[i];
                }

                count = n;
                return;
            }

            for (int i = 0; i < count; i++)
            {
                arr2[i] = items[i];
            }

            this.items = arr2;
            count = n;
        }

        public void Add(T item)
        {
            this.resize(count + 1);
            items[count - 1] = item;
        }

        public void Add(CustomList<T> add) {
            if (add.Count() == 0)
            {
                return;
            }

            int oldcount = this.count;
            this.resize(count + add.count);

            for (int i = 0; i < add.count; i++)
            {
                items[i + oldcount] = add[i];
            }
        }

        public static CustomList<T> operator +(CustomList<T> a, CustomList<T> b)
        {
            CustomList<T> ret = new CustomList<T>(a.Count() + b.Count());
            for (int i = 0; i < a.Count(); i++)
            {
                ret[i] = a[i];
            }

            for (int i = 0; i < b.Count(); i++)
            {
                ret[i + a.Count()] = b[i];
            }
            return ret;
        }

        public CustomList<T>[] Split(int index)
        {
            int count2 = count - index;
            CustomList<T> first = new CustomList<T>(index);
            CustomList<T> second = new CustomList<T>(count2);
            copyArr(first, this);

            for (int i = 0; i < count2; i++)
            {
                second[i] = items[i + index];
            }

            return new CustomList<T>[2] { first, second };
        }


        //this doesn't work
        public CustomList<T> Splice(int p1, int p2)
        {
            int count2 = p2 - p1;
            CustomList<T> ret = new CustomList<T>(count2 + 1);

            for (int i = p1; i < p2; i++)
            {
                ret[i] = this[i];
            }

            //sret.count = count2;
            return ret;
        }


        public void Remove2(int index)
        {
            index += 1;
            CustomList<T> first = this.Split(index)[0];
            CustomList<T> second = this.Split(index)[1];

            this.resize(count - 1);
            if (first.items == null)
            {
                copyArr(this, second);
                return;
            }

            first.resize(first.count - 1);

            copyArr(this, first + second);
        }


        public void Remove(int index)
        {
            //index += 1;
            CustomList<T> newarr = new CustomList<T>(count - 1);

            int indexer = 0;
            for (int i = 0; i < count; i++)
            {
                if (i == index)
                {
                    indexer = index + 1;
                    break;
                }

                newarr[i] = this[i];
            }

            for (int i = indexer; i < count; i++)
            {
                newarr[i - 1] = this[i];
            }

            this.resize(count - 1);

            copyArr(this, newarr);
        }

        public void Map(Action<T> f)
        {
            for (int i = 0; i < this.Count(); i++)
            {
                f(items[i]);
            }
        }

        public CustomList<T> Filter(Func<T, bool> f)
        {
            CustomList<T> ret = new CustomList<T>();
            for (int i = 0; i < count; i++) {
                if (f(items[i]))
                {
                    ret.Add(items[i]);
                }
            }

            return ret;
        }

        public static CustomList<T> operator -(CustomList<T> a, CustomList<T> b)
        {
            CustomList<T> ret = new CustomList<T>(a.Count());

            for (int i = 0; i < a.Count(); i++)
            {
                ret[i] = a[i];
            }

            for (int i = 0; i < b.Count(); i++)
            {
                ret = ret.Filter((x) =>
                {
                    if (x.Equals(b[i]))
                    {
                        return false;
                    }

                    return true;
                });
            }
            return ret;
        }

        public static CustomList<T> Zip(CustomList<T> a, CustomList<T> b)
        {
            if (a.count == 0)
            {
                if (b.Count() != 0)
                {
                    return b;
                }

                return new CustomList<T>();
            }

            if (b.count == 0)
            {
                return a;
            }

            CustomList<T> ret = new CustomList<T>(a.Count() + b.Count());

            for (int i = 0; i < a.Count() * 2; i += 2)
            {
                ret[i] = a[i / 2];
            }

            for (int i = 0; i < b.Count() * 2; i += 2)
            {
                ret[i + 1] = b[i / 2];
            }

            return ret;
        }
        
        public int Find( T item )
        {
                for (int i = 0; i < count; i++)
                {
                    if (items[i].Equals(item))
                    {
                        return i;
                    }
                }

            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i=0; i<count; i++)
            {
                yield return items[i]; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int i] {
            get
            {
                try
                {
                    return items[i];
                } catch(IndexOutOfRangeException E)
                {
                    return default(T);
                }
            }

            set
            {
                try
                {
                  items[i] = value;
                } catch(IndexOutOfRangeException E)
                {

                }
            }
        }
    }
}