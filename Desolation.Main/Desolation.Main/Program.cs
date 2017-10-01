using Desolation.Basic.Parameters;
using Desolation.Basic.Parameters.Factories;

namespace Desolation.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var argumentsFactory = new DefaultArgumentsFactory();
            var argumentsParser = new ArgumentsParser(argumentsFactory);
            Parameters parameters = argumentsParser.Parse(args);
            
            Game game = new Game(parameters);
            game.Run();
        } 
    }
}
