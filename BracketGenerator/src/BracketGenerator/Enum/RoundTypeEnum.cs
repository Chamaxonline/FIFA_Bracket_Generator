using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Enum
{
    public  enum RoundTypeEnum
    {
        [Description("Round of 16")]
        Round16 = 0,

        [Description("Quarterfinals")]
        Quarterfinals = 1,

        [Description("Semifinals")]
        Semifinals = 2,

        [Description("Final")]
        Final = 3,
        
    }
}
