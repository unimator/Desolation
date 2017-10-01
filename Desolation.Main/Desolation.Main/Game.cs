using System;
using Desolation.Graphics.Window;
using Desolation.Basic.Config;
using Desolation.Basic.Config.Options;
using Desolation.Basic.Logger;
using Desolation.Basic.Parameters;
using Desolation.Basic.Parameters.Types;

namespace Desolation.Main
{
    public class Game
    {
        private readonly Config _config;
        private readonly Parameters _parameters;
        private MainWindow _window;

        public event EventHandler OnStart;
        public event EventHandler MainLoop;
        public event EventHandler OnExit;

        public bool ShouldExit { get; set; }

        public Game(Parameters parameters)
        {
            _parameters = parameters;
            var customConfig = parameters.ParametersSet.Get<CustomConfigParameter>();

            var configFileName = !string.IsNullOrEmpty(customConfig?.ConfigFileName) 
                ? customConfig.ConfigFileName 
                : ConfigInitializer.ConfigFileName;

            try
            {
                _config = customConfig != null 
                    ? ConfigInitializer.LoadConfig(configFileName) 
                    : ConfigInitializer.LoadDefaultConfig();
            }
            catch (Exception)
            {
                Logger.LogMessage("Config file not found");
                _config = new Config();
            }
            
            foreach (var parameter in _parameters.ParametersSet)
            {
                parameter.TryApplyOnConfig(_config);
            }

            OnExit += (sender, args) => { ConfigPersistenceManager.SaveToFile(_config, configFileName); };
        }

        public void Run()
        {
            OnStart?.Invoke(this, EventArgs.Empty);

            var windowSettings = _config.WindowSettings;
            if(windowSettings == null)
                throw new Exception("Window settings option is null");

            _window = new MainWindow(windowSettings.Width, windowSettings.Height);
            _window.Closed += (sender, args) => { ShouldExit = true; }; 
            _window.Run();

            var eventArgs = new EventArgs();

            while (!ShouldExit)
            {
                MainLoop?.Invoke(this, eventArgs);
            }

            OnExit?.Invoke(this, EventArgs.Empty);
        }
    }
}
