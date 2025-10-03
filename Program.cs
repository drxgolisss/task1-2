using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

class Program
{
    static void Main()
    {
        var gameSettings = GameWindowSettings.Default;
        var nativeSettings = new NativeWindowSettings()
        {
            Size = new Vector2i(800, 600),
            Title = "Git Tutorial - Task 2"
        };

        using (var window = new CubeWindow(gameSettings, nativeSettings))
        {
            window.Run();
        }
    }
}