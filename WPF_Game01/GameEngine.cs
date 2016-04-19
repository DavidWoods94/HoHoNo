using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStartupDemo
{
    class GameEngine
    {
        //everything in GameEngine.cs except for this has been moved to G.cs
        internal static G gameEngine = new G();
    }
}
