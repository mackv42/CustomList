using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    class CustomList<T>
    {
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
            T[] arr2 = new T[n];

            if(n < 0)
            {
                count = -1;
                this.arr = null;
            }

            if(n < count)
            {
                for (int i = 0; i < count-1; i++)
                {
                    arr2[i] = arr[i];
                }

                count--;
            }
            
            for (int i = 0; i < count; i++)
            {
                arr2[i] = arr[i];
            }

            this.arr = arr2;
            count = n;
        }

        public void Add(T item)
        {
            this.resize(count + 1);
            arr[count - 1] = item;
        }

        public void Add(CustomList<T> add) {
            this.resize(add.Count());
            for (int i = add.Count(); i < count; i++)
            {
                arr[i] = add[i - add.Count()];
            }
        }


        //THIS WORKS!
        public CustomList<T>[] Split(int index)
        {
            int count2 = count - index;
            CustomList<T> first = new CustomList<T>(index);
            CustomList<T> second = new CustomList<T>(count2);
            copyArr(first, this);
            //copyArr(second, this);
            
            for (int i = 0; i < count2; i++)
            {
                second[i] = arr[i+index];
            }

            return new CustomList<T>[2] { first, second };
        }


        //this doesn't work
        /*
        public CustomList<T> Splice(int p1, int p2)
        {
            int count2 = p2 - p1;
            CustomList<T> ret = new CustomList<T>(count2+1);

            for(int i=p1; i<p2; i++)
            {
                ret[i] = arr[i];
            }

            //sret.count = count2;
            return ret;
        }*/

        public void copyArr(CustomList<T> arr1, CustomList<T> arr2)
        {
            for(int i = 0; i<arr1.Count(); i++)
            {
                arr1.arr[i] = arr2.arr[i];
            }
        }


        //AYE
        public void Remove(int index)
        {
            index += 1;
            CustomList<T> first = this.Split(index)[0];
            CustomList<T> second = this.Split(index)[1];
            Console.Write(first.arr);
            
            this.resize(count - 1);
            if (first.arr == null)
            {
                copyArr(this, second);
                return;
            }

            first.resize(first.Count()-1);

            copyArr(this, first + second);
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

        public static CustomList<T> operator +(CustomList<T> a, CustomList<T> b)
        {
            CustomList<T> r = new CustomList<T>(a.Count() + b.Count());
            for (int i = 0; i < a.Count(); i++)
            {
                r[i] = a[i];
            }

            for (int i = 0; i < b.Count(); i++) {
                r[i + a.Count()] = b[i];
            }
            return r;
        }

        public static CustomList<T> operator -(CustomList<T> a, CustomList<T> b) 
        {
            CustomList<T> ret = new CustomList<T>(a.Count());

            for(int i=0; i<a.Count(); i++)
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
                try
                {
                    return arr[i];
                } catch(IndexOutOfRangeException E)
                {
                    return default(T);
                }
            }

            set
            {
                try
                {
                  arr[i] = value;
                } catch(IndexOutOfRangeException E)
                {

                }
            }
        }
    }
}
