using System;
using Desolation.Graphics.Window;
using Desolation.General.ArgumentsParser;
using Desolation.General.Config;

namespace Desolation.Main
{
    public class Game
    {
        private readonly Config _config;
        private readonly Parameters _parameters;
        private MainWindow _window;

        public event EventHandler MainLoop;
        public bool ShouldExit { get; set; }

        public Game(Parameters parameters)
        {
            _parameters = parameters;
            _config = Config.LoadConfig(parameters.CustomConfig?.ConfigFileName);
            _config.ApplyParameters(_parameters);
        }

        public void Run()
        {
            _window = new MainWindow(_config.WindowSettings.Width, _config.WindowSettings.Height);
            _window.Closed += (sender, args) => { ShouldExit = true; }; 
            _window.Run();

            while (!ShouldExit)
            {
                MainLoop?.Invoke(this, new EventArgs());
            }
        }
    }
}
