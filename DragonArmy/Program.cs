using System;
using System.Collections.Generic;
using System.Linq;
namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var dragonsArmy = new Dictionary<string, List<string>>();
            for (int i = 0; i < N; i++)
            {
                string[] dragon = Console.ReadLine().Split(" ").ToArray();
                string color = dragon[0];
                string name = dragon[1];
                string dragonNameDamageHealthArmor = $"{dragon[1]} {dragon[2]} {dragon[3]} {dragon[4]}";
                if (!dragonsArmy.ContainsKey(color))
                {
                    dragonsArmy.Add(color, new List<string>());
                }
                string dragonSecond = string.Empty;
                if (dragonsArmy.ContainsKey(color))
                {
                    foreach (var dragons in dragonsArmy)
                    {
                        if (dragons.Key == color)
                        {
                            foreach (var points in dragons.Value)
                            {
                                string[] pointsWithContests = points.Split(" ").ToArray();
                                if (pointsWithContests[0] == name)
                                {
                                    dragonSecond = $"{pointsWithContests[0]} {pointsWithContests[1]} {pointsWithContests[2]} {pointsWithContests[3]}";
                                }
                            }
                        }
                    }
                }
                dragonsArmy[color].Remove(dragonSecond);
                dragonsArmy[color].Add(dragonNameDamageHealthArmor);
            }
            foreach (var dragonArmy in dragonsArmy)
            {
                Console.Write($"{dragonArmy.Key}::");
                int dragonCounter = 0;
                double damageSum = 0.0;
                double healthSum = 0.0;
                double armorSum = 0.0;
                string result = string.Empty;
                foreach (var valueDragonArmy in dragonArmy.Value)
                {
                    dragonCounter++;
                    string[] sum = valueDragonArmy.Split(" ");
                    double health = 0.0;
                    double damage = 0.0;
                    double armor = 0.0;
                    if (sum[2] == "null")
                    {
                        health = 250;
                    }
                    else
                    {
                        health = double.Parse(sum[2]);
                    }
                    if (sum[1] == "null")
                    {
                        damage = 45;
                    }
                    else
                    {
                        damage = double.Parse(sum[1]);
                    }
                    if (sum[3] == "null")
                    {
                        armor = 10;
                    }
                    else
                    {
                        armor = double.Parse(sum[3]);
                    }
                    healthSum += health;
                    damageSum += damage;
                    armorSum += armor;
                }
                Console.WriteLine($"({(damageSum / dragonCounter):f2}/{(healthSum / dragonCounter):f2}/{(armorSum / dragonCounter):f2})");
                foreach (var valueDragonArmy in dragonArmy.Value.OrderBy(x => x.Split(" ")[0]))
                {
                    double health = 0.0;
                    double damage = 0.0;
                    double armor = 0.0;
                    string[] sum = valueDragonArmy.Split(" ");
                    if (sum[2] == "null")
                    {
                        health = 250;
                    }
                    else
                    {
                        health = double.Parse(sum[2]);
                    }
                    if (sum[1] == "null")
                    {
                        damage = 45;
                    }
                    else
                    {
                        damage = double.Parse(sum[1]);
                    }
                    if (sum[3] == "null")
                    {
                        armor = 10;
                    }
                    else
                    {
                        armor = double.Parse(sum[3]);
                    }
                    result = $"-{sum[0]} -> damage: {damage}, health: {health}, armor: {armor}";
                    Console.WriteLine(result);
                }
            }
        }
    }
}
