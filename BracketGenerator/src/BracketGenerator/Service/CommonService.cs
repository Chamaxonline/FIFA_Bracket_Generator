using BracketGenerator.Enum;
using BracketGenerator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Service
{
    public class CommonService
    {
        public R16 SeedTeam(string seed, string team)
        {
            var r16 = new R16
            {
                Seed = seed,
                Team = team,
            };
            return r16;
        }

        public void PathToVictory(Round round, string winner)
        {
            Console.WriteLine();
            Console.WriteLine("Path to Victory for " + winner + ":");
            Console.WriteLine();

            foreach (var game in round.Games)
            {
                if (game.Team1 == winner || game.Team2 == winner)
                {
                    Console.WriteLine($" {game.Round} : {game.Team1} VS {game.Team2} ==>  {winner}");
                }
            }
        }

        public string GetEnumDescription(RoundTypeEnum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

            return attribute.Description;
        }
    }
}
