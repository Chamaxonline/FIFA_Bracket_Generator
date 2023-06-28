
using BracketGenerator;
using BracketGenerator.Enum;
using BracketGenerator.Model;
using BracketGenerator.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        var autoService = new AutomatedService();
        var commonService = new CommonService();

        // Seed the teams in the round of 16 bracket
        var final16Teams = new List<R16>();

        final16Teams.Add(commonService.SeedTeam("1A", "Netherlands"));
        final16Teams.Add(commonService.SeedTeam("2A", "Qatar"));
        final16Teams.Add(commonService.SeedTeam("1B", "England"));
        final16Teams.Add(commonService.SeedTeam("2B", "USA"));
        final16Teams.Add(commonService.SeedTeam("1C", "Argentina"));
        final16Teams.Add(commonService.SeedTeam("2C", "Mexico"));
        final16Teams.Add(commonService.SeedTeam("1D", "France"));
        final16Teams.Add(commonService.SeedTeam("2D", "Denmark"));
        final16Teams.Add(commonService.SeedTeam("1E", "Germany"));
        final16Teams.Add(commonService.SeedTeam("2E", "Japan"));
        final16Teams.Add(commonService.SeedTeam("1F", "Belgium"));
        final16Teams.Add(commonService.SeedTeam("2F", "Canada"));
        final16Teams.Add(commonService.SeedTeam("1G", "Brazil"));
        final16Teams.Add(commonService.SeedTeam("2G", "Cameroon"));
        final16Teams.Add(commonService.SeedTeam("1H", "Portugal"));
        final16Teams.Add(commonService.SeedTeam("2H", "Uruguay"));

        // Simulate the round of 16 matches and advance teams to the quarterfinals

        var quarterfinalsBracket = autoService.SimulateRound16(final16Teams, commonService.GetEnumDescription(RoundTypeEnum.Round16));
        var json = JsonSerializer.Serialize(quarterfinalsBracket);

        // Simulate the quarterfinal matches and advance teams to the semifinals
        var semifinalsBracket = autoService.OtherRound(quarterfinalsBracket, commonService.GetEnumDescription(RoundTypeEnum.Quarterfinals));

        // Simulate the semifinal matches and advance teams to the final
        var finalBracket = autoService.OtherRound(semifinalsBracket, commonService.GetEnumDescription(RoundTypeEnum.Semifinals));

        var finalWinner = autoService.FinalRound(finalBracket, commonService.GetEnumDescription(RoundTypeEnum.Final), true);

        string winner = finalWinner.Games.LastOrDefault().Winner;

        Console.WriteLine($"Tournament Winner : {winner} ");
        commonService.PathToVictory(finalWinner, winner);

    }
}