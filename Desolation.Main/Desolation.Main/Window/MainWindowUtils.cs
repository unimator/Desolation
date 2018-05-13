namespace Desolation.Main.Window
{
    public static class MainWindowUtils
    {
        private static MainWindow _mainWindow;

        public static void Initialize(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public static System.Drawing.Graphics GetGraphics()
        {
            return System.Drawing.Graphics.FromHwnd(_mainWindow.WindowInfo.Handle);
        }
    }
}