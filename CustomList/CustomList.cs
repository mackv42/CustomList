using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    class CustomList<T>
    {
        public delegate void Del(T message);
        private int count;
        private T[] arr;

        public CustomList() {
            count = 0;
        }

        public CustomList(int length)
        {
            count = length;
            arr = new T[length];
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
            } catch(IndexOutOfRangeException E)
            {
                this.resize(i);
                for(int n=0; n<count; n++)
                {
                    this.arr[n] = arr[n];
                }
            }
        }

        public int Count()
        {
            return count;
        }

        private void resize(int n)
        {
            T[] arr2 = new T[count + n];

            for (int i = 0; i < count; i++)
            {
                arr2[i] = arr[i];
            }

            this.arr = arr2;
            count += n;
        }

        public void Add(T item)
        {
            this.resize(1);
            arr[count - 1] = item;
        }

        public void Add(CustomList<T> add) {
            this.resize(add.Count());
            for (int i = add.Count(); i < count; i++)
            {
                arr[i] = add[i - add.Count()];
            }
        }

        public void Map(Action<T> f )
        {
            for(int i=0; i<this.Count(); i++)
            {
               f(arr[i]);
            }
        }

        public CustomList<T> Filter(Func<T, bool> f)
        {
            CustomList<T> ret = new CustomList<T>();
            for (int i = 0; i < count; i++) { 
                if (f(arr[i]))
                {
                    ret.Add(arr[i]);
                }
            }

            return ret;
        }

        public static CustomList<T> operator+ (CustomList<T> a, CustomList<T> b)
        {
            CustomList<T> r = new CustomList<T>(a.Count() + b.Count());
            for(int i=0; i<a.Count(); i++)
            {
                r[i] = a[i];
            }

            for(int i=0; i<b.Count(); i++) {
                r[i + a.Count()] = b[i];
            }
            return r;
        }

        public static CustomList<T> Zip(CustomList<T> a, CustomList<T> b)
        {
            CustomList<T> ret = new CustomList<T>(a.Count()+b.Count());
            for(int i=0; i < a.Count()*2; i+=2)
            {
                ret[i] = a[i/2];
            }
            
            for(int i=0; i<b.Count()*2; i += 2)
            {
                ret[i + 1] = b[i/2];
            }

            return ret;
        }

        public T this[int i] {
            get
            {
                return arr[i];
            }

            set
            {
                arr[i] = value;
            }
        }
    }
}
