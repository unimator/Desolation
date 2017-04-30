using Desolation.General.ArgumentsParser;

namespace Desolation.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Parameters parameters = ArgumentsParser.Parse(args);
            
            Game game = new Game(parameters);
            game.Run();
        } 
    }
}
