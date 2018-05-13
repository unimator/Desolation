using System;
using System.Threading;
using System.Threading.Tasks;
using Desolation.Basic.Parameters;
using Desolation.Basic.Parameters.Factories;

namespace Desolation.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var argumentsFactory = new DefaultArgumentsFactory();
            var argumentsParser = new ArgumentsParser(argumentsFactory);
            var parameters = argumentsParser.Parse(args);
            
            var game = new Game(parameters);
            game.Run();
        } 
    }
}
