using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

class CubeWindow : GameWindow
{
    private double Time = 0.0;
    private Cube CubeA, CubeB;
    private Shader Shader;
    private Matrix4 View, Projection;
    private Matrix4 ModelA, ModelB;
    private readonly float rotationSpeed = 50.0f;

    public CubeWindow(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws) { }

    protected override void OnLoad()
    {
        base.OnLoad();

        GL.ClearColor(0.1f, 0.2f, 0.3f, 1.0f);
        GL.Enable(EnableCap.DepthTest);

        Shader = new Shader("resources/shaders/cube.vert", "resources/shaders/cube.frag");
        CubeA = new Cube(new Vector3(0.5f, 0.5f, 1f), Shader);
        CubeB = new Cube(new Vector3(1.0f, 0.0f, 0f), Shader);
        View = Matrix4.LookAt(new Vector3(1.5f, 1.5f, 2f), Vector3.Zero, Vector3.UnitY); 
        Projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100f);
        ModelA = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(25.0f)) * 
            Matrix4.CreateTranslation(0, 0, 0);
        ModelB = Matrix4.CreateScale(0.5f) *
            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(45.0f)) *
            Matrix4.CreateTranslation(0.5f, 0.5f, -1.0f);
    }
    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        Time += args.Time;
        base.OnUpdateFrame(args);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        // TODO 2.2 (Uncomment the line below)
        ModelA = Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)(Time * rotationSpeed))) * Matrix4.CreateTranslation(0, 0, 0);
        CubeA.Render(ModelA, View, Projection);

        // TODO 2.4 (Uncomment the line below)
        // CubeB.Render(ModelB, View, Projection);

        SwapBuffers();
    }
}