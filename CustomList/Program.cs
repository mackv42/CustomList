using System;

namespace CustomList
{

    class animal

    {

        public string color;
        private int numLegs;
        private string sound;
        public string name;

        public animal(string name, string sound)
        {
            this.sound = sound;
            this.name = name;
        }

        /*
        public void this[](animal a1, animal a2)
        {
            set{
                a1.color = a2.color;
                a1.sound = a2.sound;
                a1.name = a2.name;
            }
        }*/


    public void makeSound()
        {
            Console.WriteLine($"The {name} says {sound}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CustomList<animal> list = new CustomList<animal>(new animal[]{ new animal("dog", "woof"), new animal("doge", "bork"), new animal("pig", "squueeeel") });
            CustomList<animal> list2 = new CustomList<animal>(new animal[] { new animal("wombat", "reee"), new animal("seel", "oorf"), new animal("mouse", "eee") });
            CustomList<animal> animalsZipped = CustomList<animal>.Zip(list, list2);

            CustomList<int> c = new CustomList<int>();

            CustomList<int> a = new CustomList<int>();
            a.Add(10);
            a.Add(20);
            a.Add(30);
            a.Add(40);
            a.Add(45);

            //a.Remove(0);
            //a.Remove(a.Count()-1);
            Console.Write(a.Count());
            CustomList<int> b = new CustomList<int>(new int[] { 10, 20, 30});
            Console.Write(a.Equals(b));

            CustomList<int> d = CustomList<int>.Zip(a, b);
            Console.WriteLine();

            a.Add(b);

            (a).Map((x) => {
                Console.WriteLine(x);
            });

           
        }
    }
}
