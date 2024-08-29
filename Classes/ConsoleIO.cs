using CleanCodeLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Classes
{
    public class ConsoleIO : IUI
    {
        public ConsoleIO()
        {
            Debug.WriteLine("Created instance of IO");
        }
        public void DisplayOutput(string message)
        {
            Console.WriteLine(message);
        }
        public string GetUserInput()
        {
           return Console.ReadLine();
        }
    }
}
