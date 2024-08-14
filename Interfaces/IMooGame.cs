using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Interfaces
{
    public interface IMooGame
    {
        string GenerateRandomFourDigitNumber();
        string GetBullsAndCows(string gameGoal, string playersGuess);
    }
}
