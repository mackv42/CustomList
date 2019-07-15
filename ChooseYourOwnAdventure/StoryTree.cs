using System;
using System.Collections.Generic;
using System.Text;
using CustomList;

namespace ChooseYourOwnAdventure
{
    public class StoryNode
    {
        private Func<int> function;
        private int result;

        public StoryNode(Func<int> callback)
        {
            function = callback;
        }

        public int Run()
        {
            this.result = function();
            return result;
        }

        public int getResult()
        {
            return result;
        }
    }

    public class StoryTree
    {
        private CustomList<CustomList<StoryNode>> story;
        private string Title;
        private CustomList<int> choicesList;

        public StoryTree(string storyName)
        {
            this.story = new CustomList<CustomList<StoryNode>>();

            this.Title = storyName;

            this.AddLevel();
            story[0].Add( new StoryNode(() => {
                Console.WriteLine($"{storyName}");
                return 0;
            }));
        }

        public void AddLevel()
        {
            story.Add(new CustomList<StoryNode>());
        }

        public void AddNode(Func<int> function)
        {
            this.story[story.Count()-1].Add(new StoryNode(function));
        }

        public void Start()
        {
            int[] currentNode = new int[2]{ 0, 0 };
            int choice = 0;
            int tmp = 0;

            choicesList = new CustomList<int>();

            for (int i = 0; i<story.Count(); i++)
            {
                tmp = story[i][choice].Run();

                // Added capability to go up levels
                if (tmp < -1)
                {
                    if(i + tmp + 1 < 0)
                    {
                        i = 0;
                    }
                    i += tmp;
                    
                }

                if(tmp == -1)
                {
                    i-=2;
                    choice = choicesList[i];
                    continue;
                }

                choicesList.Add(tmp);
                choice = tmp;
            }
        }
    }
}
