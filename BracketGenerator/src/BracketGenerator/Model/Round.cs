using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Model
{
    public  class Round
    {
        public List<NextRoundBracket> NextRoundBracket { get; set; }
        public List<Game> Games { get; set; }
    }
}
