using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Model
{
    public  class Game
    {
        public int MatchNo { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Round { get; set; }
        public string Winner { get; set; }
        public bool IsScheduled { get; set; }

    }
}
