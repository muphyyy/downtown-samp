using System;
using SampSharp.Core;

namespace DowntownSAMP
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameModeBuilder()
            .Use<GameMode>()
            .Run();
        }
    }
}
