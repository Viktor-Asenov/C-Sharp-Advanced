using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V___Logger
{
    class Vlogger
    {
        public List<string> Followers = new List<string>();

        public List<string> Following = new List<string>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            var vloggersDict = new Dictionary<string, Vlogger>();

            while (command != "Statistics")
            {
                string[] currentCommand = command.Split();
                string vloggername = currentCommand[0];
                string action = currentCommand[1];

                if (action == "joined")
                {
                    if (!vloggersDict.ContainsKey(vloggername))
                    {
                        vloggersDict[vloggername] = new Vlogger();
                    }
                }
                else if (action == "followed")
                {
                    string followedVloggerName = currentCommand[2];

                    if (vloggersDict.ContainsKey(vloggername) && vloggersDict.ContainsKey(followedVloggerName))
                    {
                        if (vloggername != followedVloggerName
                            && !vloggersDict[vloggername].Following.Contains(followedVloggerName)
                            && !vloggersDict[followedVloggerName].Followers.Contains(vloggername))
                        {
                            vloggersDict[followedVloggerName].Followers.Add(vloggername);
                            vloggersDict[vloggername].Following.Add(followedVloggerName);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            var sorted = vloggersDict
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"The V-Logger has a total of {sorted.Count} vloggers in its logs.");

            string mostFamous = string.Empty;
            int maxFollowers = 0;
            int following = 0;
            var followers = new List<string>();

            foreach (var vlogger in sorted)
            {
                foreach (var follower in vlogger.Value.Followers)
                {
                    int currentVloggerFollowers = vlogger.Value.Followers.Count;
                    int currentVloggerFollowings = vlogger.Value.Following.Count;

                    if (currentVloggerFollowers > maxFollowers)
                    {
                        maxFollowers = currentVloggerFollowers;                        
                        mostFamous = vlogger.Key;
                        followers = vlogger.Value.Followers;
                        following = currentVloggerFollowings;
                    }
                }
            }

            int counter = 1;

            foreach (var vlogger in sorted)
            {
                if (counter == 1)
                {
                    Console.WriteLine($"{counter}. {mostFamous} : {maxFollowers} followers, {following} following");

                    var sortedFollowers = followers.OrderBy(x => x);

                    foreach (var follower in sortedFollowers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                else
                {
                    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
                }

                counter++;
            }          

        }        
    }
}
