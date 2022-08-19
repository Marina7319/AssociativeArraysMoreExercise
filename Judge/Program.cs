using System;
using System.Collections.Generic;
using System.Linq;
namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentList = new Dictionary<string, List<string>>();
            var student = new Dictionary<string, int>();
            var participants = new List<string>();
            string input = Console.ReadLine();
            while (input != "no more time")
            {
                string[] inputLine = input.Split(" -> ");
                string discipline = inputLine[1];
                string name = inputLine[0];
                string students = string.Empty;
                int evaluation = int.Parse(inputLine[2]);
                students = $"{inputLine[0]} {int.Parse(inputLine[2])}";
                if (!studentList.ContainsKey(discipline))
                {
                    studentList.Add(discipline, new List<string>());
                }
                string sum = string.Empty;
                if (studentList.ContainsKey(discipline))
                {
                    foreach (var results in studentList)
                    {
                        if (results.Key == discipline)
                        {
                            foreach (var points in results.Value)
                            {
                                string[] pointsWithContests = points.Split(" ").ToArray();
                                if (pointsWithContests[0] == name)
                                {
                                    int pointsInString = int.Parse(pointsWithContests[1]);
                                    if (pointsInString < int.Parse(inputLine[2]))
                                    {
                                        sum = $"{name} {pointsInString}";
                                    }
                                    else
                                    {
                                        sum = $"{name} {int.Parse(inputLine[2])}";
                                    }
                                }
                            }
                        }
                    }
                }
                studentList[discipline].Add(students);
                studentList[discipline].Remove(sum);
                input = Console.ReadLine();
            }
            foreach (var participantInDiscipline in studentList)
            {
                Console.WriteLine($"{participantInDiscipline.Key}: {participantInDiscipline.Value.Count} participants");
                int participantsCounter = 0;
                foreach (var students in participantInDiscipline.Value.OrderByDescending(x => x.Split(" ")[1]).ThenBy(x => x.Split(" ")[0]))
                {
                    participantsCounter++;
                    string[] participant = students.Split(" ");
                    string nameParticipant = participant[0];
                    int evlParticipant = int.Parse(participant[1]);
                    Console.WriteLine($"{participantsCounter}. {participant[0]} <::> {participant[1]}");
                    participants.Add(students);
                }
            }
            Console.WriteLine("Individual standings:");
            foreach (var evaluations in participants)
            {
                string[] inputLine = evaluations.Split(" ");
                if (!student.ContainsKey(inputLine[0]))
                {
                    student.Add(inputLine[0], int.Parse(inputLine[1]));
                }
                else
                {
                    student[inputLine[0]] += int.Parse(inputLine[1]);
                }
            }
            int individualCounter = 0;
            foreach (var individualStandings in student.OrderByDescending(currEval => currEval.Value).ThenBy(currStudent => currStudent.Key))
            {
                individualCounter++;
                Console.WriteLine($"{individualCounter}. {individualStandings.Key} -> {individualStandings.Value}");
            }
        }
    }
}
