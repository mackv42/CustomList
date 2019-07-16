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

            

            CustomList<int> expected = new CustomList<int>(new int[] { 4, 5, 6, 7, 8, 9 });
            CustomList<IComparable> a = new CustomList<IComparable>(new IComparable[] { 7, 8, 9 });
            CustomList<int> b = new CustomList<int>(new int[] { 4, 5, 6 });


            foreach (var x in a.Sort(a))
            {
                Console.WriteLine(x);
            }
            //new StoryTree("Apples and Bananas").Start();
        }
    }
}
