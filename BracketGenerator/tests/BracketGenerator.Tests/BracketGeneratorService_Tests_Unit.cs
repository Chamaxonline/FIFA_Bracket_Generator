using BracketGenerator.Enum;
using BracketGenerator.Model;
using BracketGenerator.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BracketGenerator.Tests
{
    public class BracketGeneratorService_Tests_Unit
    {
        [Fact]
        public void Should_Be_Always_SeedTeam()
        {
            //given
            var service = new CommonService();
            string team = "England";
            string seed = "1A";
            var expected = new R16
            {
                Seed = seed,
                Team = team,
            };

            //when
            var actual = service.SeedTeam(seed, team);

            //then
            Assert.Equal(expected.Team, actual.Team);
            Assert.Equal(expected.Seed, actual.Seed);

        }
        [Fact]
        public void Should_Be_Always_Return_QuaterFinal_Teams()
        {
            //given
            var service = new AutomatedService();
            var commonService = new CommonService();
            var r16List = new List<R16>
            {
                new R16
                {
                    Seed =  "1A",
                    Team = "Netherlands"
                },
                 new R16
                {
                    Seed =  "2A",
                    Team = "Qatar"
                },
                  new R16
                {
                    Seed =  "1B",
                    Team = "England"
                },
                   new R16
                {
                    Seed =  "2B",
                    Team = "USA"
                },
                    new R16
                {
                    Seed =  "1C",
                    Team = "Argentina"
                },
                     new R16
                {
                    Seed =  "2C",
                    Team = "Mexico"
                },
                      new R16
                {
                    Seed =  "1D",
                    Team = "France"
                },
                       new R16
                {
                    Seed =  "2D",
                    Team = "Denmark"
                },
                        new R16
                {
                    Seed =  "1E",
                    Team = "Germany"
                },
                 new R16
                {
                    Seed =  "2E",
                    Team = "Japan"
                },
                  new R16
                {
                    Seed =  "1F",
                    Team = "Belgium"
                },
                   new R16
                {
                    Seed =  "2F",
                    Team = "Canada"
                },
                    new R16
                {
                    Seed =  "1G",
                    Team = "Brazil"
                },
                 new R16
                {
                    Seed =  "2G",
                    Team = "Cameroon"
                },
                  new R16
                {
                    Seed =  "1H",
                    Team = "Portugal"
                },
                   new R16
                {
                    Seed =  "2H",
                    Team = "Uruguay"
                },

            };

            //when
            var actual = service.SimulateRound16(r16List, commonService.GetEnumDescription(RoundTypeEnum.Round16));
            //then

            Assert.True(actual.NextRoundBracket.Count() == 8);
            Assert.True(actual.Games.Count() == 8);
        }

        [Fact]
        public void Should_Be_Always_Return_Semifinals_Teams()
        {
            //given
            var service = new AutomatedService();
            var commonService = new CommonService();
            var games = new List<Game>
           {
              new Game{
            MatchNo= 1,
            Team1 = "Netherlands",
            Team2 = "USA",
            Round = "Round of 16",

        },
         new Game{
            MatchNo=2,
            Team1 = "England",
            Team2 = "Qatar",
            Round = "Round of 16",

        },
        new Game{
            MatchNo = 3,
            Team1 ="Argentina",
            Team2 ="Denmark",
            Round = "Round of 16",
        },
         new Game{
            MatchNo= 4,
            Team1 = "France",
            Team2 = "Mexico",
            Round = "Round of 16",

        },
         new Game{
            MatchNo=5,
            Team1 = "Germany",
            Team2 = "Canada",
            Round = "Round of 16",

        },
        new Game{
            MatchNo = 6,
            Team1 ="Belgium",
            Team2 ="Japan",
            Round = "Round of 16",
        },
          new Game{
            MatchNo=7,
            Team1 = "Brazil",
            Team2 = "Uruguay",
            Round = "Round of 16",

        },
        new Game{
            MatchNo = 8,
            Team1 ="Portugal",
            Team2 ="Cameroon",
            Round = "Round of 16",
        },
           };

            var nextRoundBrackets = new List<NextRoundBracket>
            {
               new NextRoundBracket{
                   Team = "USA",
                IsScheduled = false
               },
               new NextRoundBracket{
                   Team = "England",
                IsScheduled = false
               },
               new NextRoundBracket{
                   Team = "Argentina",
                IsScheduled = false
               },
               new NextRoundBracket{
                   Team = "France",
                IsScheduled = false
               },
               new NextRoundBracket{
                   Team = "Germany",
                IsScheduled = false
               },
               new NextRoundBracket{
                   Team = "Belgium",
                IsScheduled = false
               },
                new NextRoundBracket{
                   Team = "Brazil",
                IsScheduled = false
               },
               new NextRoundBracket{
                   Team = "Portugal",
                IsScheduled = false
               }
            };

            var round = new Round
            {
                NextRoundBracket = nextRoundBrackets,
                Games = games
            };

            //when
            var actual = service.OtherRound(round, commonService.GetEnumDescription(RoundTypeEnum.Quarterfinals));
            //then

            Assert.True(actual.NextRoundBracket.Count() == 4);
            Assert.True(actual.Games.Count() == 12);
        }

        [Fact]
        public void Should_Be_Always_Return_final_Teams()
        {
            //given
            var service = new AutomatedService();
            var commonService = new CommonService();
            var games = new List<Game>
           {
              new Game{
            MatchNo= 1,
            Team1 = "Netherlands",
            Team2 = "USA",
            Round = "Round of 16",

        },
         new Game{
            MatchNo=2,
            Team1 = "England",
            Team2 = "Qatar",
            Round = "Round of 16",

        },
        new Game{
            MatchNo = 3,
            Team1 ="Argentina",
            Team2 ="Denmark",
            Round = "Round of 16",
        },
         new Game{
            MatchNo= 4,
            Team1 = "France",
            Team2 = "Mexico",
            Round = "Round of 16",

        },
         new Game{
            MatchNo=5,
            Team1 = "Germany",
            Team2 = "Canada",
            Round = "Round of 16",

        },
        new Game{
            MatchNo = 6,
            Team1 ="Belgium",
            Team2 ="Japan",
            Round = "Round of 16",
        },
          new Game{
            MatchNo=7,
            Team1 = "Brazil",
            Team2 = "Uruguay",
            Round = "Round of 16",

        },
        new Game{
            MatchNo = 8,
            Team1 ="Portugal",
            Team2 ="Cameroon",
            Round = "Round of 16",
        },
        new Game{
            MatchNo=9,
            Team1 = "Netherlands",
            Team2 = "England",
            Round = "Quarterfinals",

        },
        new Game{
            MatchNo = 10,
            Team1 ="Argentina",
            Team2 ="France",
            Round = "Quarterfinals",
        },
          new Game{
            MatchNo=11,
            Team1 = "Canada",
            Team2 = "Japan",
            Round = "Quarterfinals",

        },
        new Game{
            MatchNo = 12,
            Team1 ="Portugal",
            Team2 ="Cameroon",
            Round = "Quarterfinals",
        },
           };

            var nextRoundBrackets = new List<NextRoundBracket>
            {
               new NextRoundBracket{
                   Team = "Netherlands",
                IsScheduled = false
               },
               new NextRoundBracket{
                   Team = "Argentina",
                IsScheduled = false
               },
               new NextRoundBracket{
                   Team = "Japan",
                IsScheduled = false
               },
               new NextRoundBracket{
                   Team = "Uruguay",
                IsScheduled = false
               },
            };
            
            var round = new Round
            {
                 NextRoundBracket = nextRoundBrackets,
                Games = games
            };

            //when
            var actual = service.OtherRound(round, commonService.GetEnumDescription(RoundTypeEnum.Semifinals));
            //then

            Assert.True(actual.NextRoundBracket.Count() == 2);
            Assert.True(actual.Games.Count() == 14);
        }

        [Fact]
        public void Should_Be_Always_Return_winning_Team()
        {
            //given
            var service = new AutomatedService();
            var commonService = new CommonService();
            var games = new List<Game>
           {
              new Game{
            MatchNo= 1,
            Team1 = "Netherlands",
            Team2 = "USA",
            Round = "Round of 16",

        },
         new Game{
            MatchNo=2,
            Team1 = "England",
            Team2 = "Qatar",
            Round = "Round of 16",

        },
        new Game{
            MatchNo = 3,
            Team1 ="Argentina",
            Team2 ="Denmark",
            Round = "Round of 16",
        },
         new Game{
            MatchNo= 4,
            Team1 = "France",
            Team2 = "Mexico",
            Round = "Round of 16",

        },
         new Game{
            MatchNo=5,
            Team1 = "Germany",
            Team2 = "Canada",
            Round = "Round of 16",

        },
        new Game{
            MatchNo = 6,
            Team1 ="Belgium",
            Team2 ="Japan",
            Round = "Round of 16",
        },
          new Game{
            MatchNo=7,
            Team1 = "Brazil",
            Team2 = "Uruguay",
            Round = "Round of 16",

        },
        new Game{
            MatchNo = 8,
            Team1 ="Portugal",
            Team2 ="Cameroon",
            Round = "Round of 16",
        },
        new Game{
            MatchNo=9,
            Team1 = "Netherlands",
            Team2 = "England",
            Round = "Quarterfinals",

        },
        new Game{
            MatchNo = 10,
            Team1 ="Argentina",
            Team2 ="France",
            Round = "Quarterfinals",
        },
          new Game{
            MatchNo=11,
            Team1 = "Canada",
            Team2 = "Japan",
            Round = "Quarterfinals",

        },
        new Game{
            MatchNo = 12,
            Team1 ="Portugal",
            Team2 ="Cameroon",
            Round = "Quarterfinals",
        },
         new Game{
            MatchNo=11,
            Team1 = "England",
            Team2 = "France",
            Round = "Semifinals",

        },
        new Game{
            MatchNo = 12,
            Team1 ="Portugal",
            Team2 ="Japan",
            Round = "Semifinals",
        },
           };
            var nextRoundBrackets = new List<NextRoundBracket>
            {
               new NextRoundBracket{
                   Team = "France",
                IsScheduled = false
               },
               new NextRoundBracket{
                   Team = "Portugal",
                IsScheduled = false
               },
            };            

            var round = new Round
            {
                 NextRoundBracket = nextRoundBrackets,
                Games = games
            };

            //when
            var actual = service.FinalRound(round, commonService.GetEnumDescription(RoundTypeEnum.Final));
            //then

            Assert.True(actual.NextRoundBracket.Count == 0);
            Assert.True(actual.Games.Count() == 15);
        }
    }
}
