using System;
using System.Collections.Generic;
using System.Linq;
namespace SnowWhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var drawrds = new Dictionary<string, int>();
            string cmd = Console.ReadLine();
            while (cmd != "Once upon a time")
            {
                var tokens = cmd.Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);
                var dwarfName = tokens[0];
                var hatColor = tokens[1];
                var phisics = int.Parse(tokens[2]);
                var dwarfID = $"{dwarfName}:{hatColor}";
                if (!drawrds.ContainsKey(dwarfID))
                {
                    drawrds.Add(dwarfID, phisics);
                }
                else
                {
                    drawrds[dwarfID] = Math.Max(drawrds[dwarfID], phisics);
                }
                cmd = Console.ReadLine();
            }
            foreach (var KeyValuePair in drawrds.OrderByDescending(x => x.Value).ThenByDescending(currDwarf => drawrds.Where(hatColor => hatColor.Key.Split(":")[1] == currDwarf.Key.Split(":")[1]).Count()))
            {
                string[] hatColor = KeyValuePair.Key.Split(":");
                int physics = KeyValuePair.Value;
                Console.WriteLine($"({hatColor[1]}) {hatColor[0]} <-> {physics}");
            }
        }
    }
}
