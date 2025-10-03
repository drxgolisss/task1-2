using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

class Shader
{
    public int ProgramID {
        get;
        private set;
    }
    public Shader(string vertPath, string fragPath)
    {
        ProgramID = CreateShaderProgram(vertPath, fragPath);
    }
    private int CreateShaderProgram(string vertPath, string fragPath)
    {
        string vertexCode = File.ReadAllText(vertPath);
        string fragmentCode = File.ReadAllText(fragPath);

        int vertex = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertex, vertexCode);
        GL.CompileShader(vertex);

        int fragment = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragment, fragmentCode);
        GL.CompileShader(fragment);

        int program = GL.CreateProgram();
        GL.AttachShader(program, vertex);
        GL.AttachShader(program, fragment);
        GL.LinkProgram(program);

        GL.DeleteShader(vertex);
        GL.DeleteShader(fragment);

        return program;
    }

    public void SetVector3(string name, Vector3 value)
    {
        int loc = GL.GetUniformLocation(ProgramID, name);
        GL.Uniform3(loc, value);
    }

    public void SetMatrix4(string name, Matrix4 matrix)
    {
        int loc = GL.GetUniformLocation(ProgramID, name);
        GL.UniformMatrix4(loc, false, ref matrix);
    }
}
