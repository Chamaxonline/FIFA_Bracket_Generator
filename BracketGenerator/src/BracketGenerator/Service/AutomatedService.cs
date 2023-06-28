using BracketGenerator.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BracketGenerator.Service
{
    public class AutomatedService
    {
        public Round SimulateRound16(List<R16> bracket, string roundName)
        {
            Console.WriteLine(roundName + " Matches:");
            Console.WriteLine();

            var nextRoundBrackets = new List<NextRoundBracket>();
            List<Game> games = new List<Game>();
            Round round = new Round();
            int n = 0;

            for (char c = 'A'; c <= 'H'; c++)
            {
                var team1 = bracket.Find(x => x.Seed.EndsWith(c));
                char current = c;


                var team2 = new R16();

                if (n % 2 == 0)
                {
                    char next = current++;
                    team2 = bracket.FindLast(x => x.Seed.EndsWith(current));
                }
                else
                {
                    char next = current--;
                    team2 = bracket.FindLast(x => x.Seed.EndsWith(current));
                }
                n++;

                Console.WriteLine($"Match {n}: {team1.Team} vs {team2.Team}");


                // Simulate the match and determine the winning team
                string winner = SimulateMatch(team1.Team, team2.Team);

                var nextRound = new NextRoundBracket
                {
                    IsScheduled = false,
                    Team = winner
                };
                nextRoundBrackets.Add(nextRound);

                var game = new Game
                {
                    MatchNo = n,
                    Team1 = team1.Team,
                    Team2 = team2.Team,
                    Round = roundName,
                    Winner = winner,
                };
                games.Add(game);
            }
            round.NextRoundBracket = nextRoundBrackets;
            round.Games = games;

            Console.WriteLine();
            return round;
        }

        public Round OtherRound(Round round, string roundName)
        {
            Console.WriteLine(roundName + " Matches:");
            Console.WriteLine();

            var nextRoundBrackets = new List<NextRoundBracket>();
            List<Game> games = new List<Game>();
            int n = round.Games.Count + 1;

            for (int match = 0; match < round.NextRoundBracket.Count ; match++)
            {
                int slotIndex = match ;
                if (!round.NextRoundBracket[slotIndex].IsScheduled)
                {
                    string team1 = round.NextRoundBracket[slotIndex].Team;
                    string team2 = round.NextRoundBracket[slotIndex + 2].Team;

                    round.NextRoundBracket[slotIndex].IsScheduled = true;
                    round.NextRoundBracket[slotIndex + 2].IsScheduled = true;

                    Console.WriteLine($"Match {n}: {team1} vs {team2}");

                    // Simulate the match and determine the winning team
                    string winner = SimulateMatch(team1, team2);

                    // Store the winner in the next round bracket
                    var nextRound = new NextRoundBracket
                    {
                        IsScheduled = false,
                        Team = winner
                    };
                    nextRoundBrackets.Add(nextRound);

                    var game = new Game
                    {
                        MatchNo = n,
                        Team1 = team1,
                        Team2 = team2,
                        Round = roundName,
                        Winner = winner
                    };
                    games.Add(game);

                    n++;
                    

                    

                }
               

            }
            
            round.NextRoundBracket = nextRoundBrackets;
            round.Games.AddRange(games);

            Console.WriteLine();
            return round;
        }

        public Round FinalRound(Round round, string roundName, bool isFinal = false)
        {
            Console.WriteLine(roundName + (isFinal ? " Match" : " Matches:"));
            Console.WriteLine();

            var nextRoundBrackets = new List<NextRoundBracket>();
            List<Game> games = new List<Game>();
            int n = round.Games.Count + 1;

            for (int match = 0; match < round.NextRoundBracket.Count / 2; match++)
            {
                int slotIndex = match * 2;
                string team1 = round.NextRoundBracket[slotIndex].Team;
                string team2 = round.NextRoundBracket[slotIndex + 1].Team;

                Console.WriteLine($"Match {n}: {team1} vs {team2}");

                // Simulate the match and determine the winning team
                string winner = SimulateMatch(team1, team2);

                // Store the winner in the next round bracket
                // Store the winner in the next round bracket               

                var game = new Game
                {
                    MatchNo = n,
                    Team1 = team1,
                    Team2 = team2,
                    Round = roundName,
                    Winner = winner
                };
                games.Add(game);

                n++;
            }

            round.NextRoundBracket = nextRoundBrackets;
            round.Games.AddRange(games);

            Console.WriteLine();
            return round;
        }

        public string SimulateMatch(string team1, string team2)
        {
            var random = new Random().Next(0, 10);
            return random % 2 == 0 ? team1 : team2;
        }


    }
}
