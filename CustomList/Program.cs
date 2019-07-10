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

            Console.Write(list.Count());
            CustomList<int> c = new CustomList<int>();

            animalsZipped.Map((x) => {
                x.makeSound();
            });

            CustomList<int> a = new CustomList<int>();
            a.Add(10);
            a.Add(20);
            a.Add(30);
            a.Add(40);
            a.Add(45);

            CustomList<int> b = new CustomList<int>();

            b.Add(10);
            b.Add(25);
            b.Add(20);
            b.Add(15);
            int z = 1;
            int y = -1;

            CustomList<int> subtracted = a-b;

            subtracted.Map((x) =>
            {
                Console.WriteLine(x);
            });

            CustomList<animal> filteredList = new CustomList<animal>();
        }
    }
}
