using System;
using System.Collections.Generic;
using System.Linq;
namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var userContest = new Dictionary<string, List<string>>();
            var maxPoints = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] command = input.Split(":");
                var contest = command[0];
                var passwordForContest = command[1];
                contests.Add(contest, passwordForContest);
                input = Console.ReadLine();
            }
            string inputLine = Console.ReadLine();
            while (inputLine != "end of submissions")
            {
                string[] command = inputLine.Split("=>");
                var contest = command[0];
                var name = command[2];
                foreach (var item in contests)
                {
                    if (command[0] == item.Key && command[1] == item.Value)
                    {
                        string result = $"{command[0]}=>{command[3]}";
                        string sum = string.Empty;
                        if (!userContest.ContainsKey(name))
                        {
                            userContest.Add(name, new List<string>());
                        }
                        foreach (var results in userContest)
                        {
                            if (results.Key == name)
                            {
                                foreach (var points in results.Value)
                                {
                                    string[] pointsWithContests = points.Split("=>").ToArray();
                                    if (pointsWithContests[0] == contest)
                                    {
                                        int pointsInString = int.Parse(pointsWithContests[1]);
                                        if (pointsInString < int.Parse(command[3]))
                                        {
                                            sum = $"{pointsWithContests[0]}=>{pointsInString}";
                                        }
                                        else
                                        {
                                            sum = $"{pointsWithContests[0]}=>{int.Parse(command[3])}";
                                        }
                                    }
                                }
                            }
                        }
                        userContest[name].Add(result);
                        userContest[name].Remove(sum);
                    }
                }
                inputLine = Console.ReadLine();
            }
            int maxNum = int.MinValue;
            string userWithMaxPoints = string.Empty;
            string names = string.Empty;
            foreach (var users in userContest)
            {
                int sum = 0;
                foreach (var evaluationas in users.Value)
                {
                    string[] concattedWord = evaluationas.Split("=>");
                    int num = int.Parse(concattedWord[1]);
                    sum += num;
                }
                if (!maxPoints.ContainsKey(users.Key))
                {
                    maxPoints.Add(users.Key, sum);
                }
                foreach (var maxPointsStudent in maxPoints)
                {
                    int sumNums = 0;
                    sumNums += maxPointsStudent.Value;
                    int num = maxPointsStudent.Value;
                    if (num > maxNum)
                    {
                        maxNum = num;
                        userWithMaxPoints = maxPointsStudent.Key;
                    }
                }
            }
            Console.WriteLine($"Best candidate is {userWithMaxPoints} with total {maxNum} points.");
            Console.WriteLine("Ranking:");
            foreach (var users in userContest.OrderBy(currUser => currUser.Key))
            {
                Console.WriteLine(users.Key);
                foreach (var evaluationas in users.Value.OrderByDescending(x => x.Split("=>")[1]))
                {
                    string[] user = evaluationas.Split("=>");
                    Console.WriteLine($"#  {user[0]} -> {user[1]}");
                }
            }
        }
    }
}

