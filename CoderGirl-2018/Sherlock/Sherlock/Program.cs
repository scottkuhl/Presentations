using System;

namespace Sherlock
{
    public static class Program
    {
        public static void Main()
        {
            string press = { "a reporter from the Times", "a reporter from the Observer" };
            string family = {"Mycroft Holmes", "Mrs. Hudson" };
            string enemies = {"Professor Moriarty", "Charles "Augustus" Milverton", "John Woodley" };
            string loveInterests = {"Irene Adler" };
            string friends = {"Inspector Lestrade", "Dr. Watson" };

            Console.WriteLine(KnockKnock(press));
            Console.WriteLine(KnockKnock(family));
            Console.WriteLine(KnockKnock(enemies));
            Console.WriteLine(KnockKnock(loveInterests));
            Console.WriteLine(KnockKnock(friends));
        }

        private static string KnockKnock(string[] guests)
        {
            foreach (string guest in guests)
            {
                if (guest == "Dr Watson" || guest == "Inspector Lestrade")
                {
                    return "Enter";
                }
                else
                {
                    return "Go Away! (sound of violin music...)";
                }
            }
        }
    }
}
