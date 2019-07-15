using System;
using CustomList;
namespace ChooseYourOwnAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            StoryTree myStory = new StoryTree("Apples and Bananas");

            myStory.AddLevel();

            myStory.AddNode(() =>
            {
                return UI.promptForOptions("Would You Like To go Left or Right",
                new CustomList<string>(new string[] { "Left", "Right" }));
            });
            myStory.AddLevel();

            myStory.AddNode(() =>
            {
                Console.WriteLine("Wrong Choice You Were Eaten By a Bear!");
                return -1;
            });

            
            myStory.AddNode(() =>
            {
                Console.WriteLine("You continue on the right path");
                Console.WriteLine("The path Splits 3 ways Each has a sign leading to Camelot, Babylon and Constantinople...");
                return UI.promptForOptions("Which Way do you choose to go?",
                    new CustomList<string>(new string[] { "Camelot", "Babylon", "Constantinople" })); 
            });

            myStory.Start();
        }
    }
}
