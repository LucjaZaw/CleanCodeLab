using CleanCodeLab.Classes;
using CleanCodeLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabTests.Classes
{
    public class MockObjects
    {
        public class MockUI : IUI
        {
            public void DisplayOutput(string message)
            {
                //Ignore output, does nothing
            }

            public string GetUserInput()
            {
                return "Jag retunrerar alltid denna sträng just nu!";
            }
        }
        public class MockRandom : ICustomRandom
        {
            private string _numbers;
            private int _index = 0;
            public MockRandom(string numbers)
            {
                _numbers = numbers;
            }
            public int NextNumber(int maxValue)
            {
                char digit = _numbers.ElementAt(_index % _numbers.Length);
                int.TryParse(digit.ToString(), out int result);
                _index++;
                return result;
            }
        }
    }
}
