using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Interfaces
{
    public interface IUI
    { 
        string GetUserInput();
        void DisplayOutput(string message);
    }
}
