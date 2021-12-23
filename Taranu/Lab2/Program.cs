using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

//TARANU_STEFAN-CATALIN
//GRUPA:3131A
//CALCULATOARE AN III
/*Implementați o versiune a aplicației în care controlul obiectului randat 
se face:
- prin apăsarea a 2 taste;
- prin mișcarea mouse-ului.*/
namespace Taranu
{
    class SimpleWindow : GameWindow
    {
        float angle = 0;
        float rotation_speed = 1.5f;
        float rot2 = 0.005f;
        public SimpleWindow() : base(800, 600)
        {
           
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Blue);
            GL.Enable(EnableCap.DepthTest);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            OpenTK.Matrix4 perspective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {

            base.OnRenderFrame(e);
           
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 lookat = Matrix4.LookAt(0, 5, 10, 0, 0, 2, 0, 5, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Key.W))
                angle += rotation_speed;
            if (input.IsKeyDown(Key.S))
                angle -= rotation_speed;

            MouseState mouse = Mouse.GetState();
            if (mouse.X > 0)
                angle += rot2 * mouse.X;
            if (mouse.X < 0)
                angle -= rot2 * -mouse.X;
            GL.Rotate(angle, 0.0f, 1.0f, 0.0f);
            Desenare();

            this.SwapBuffers();
        }
        private void Desenare()
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(Color.Red); GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Color3(Color.Red); GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Color3(Color.Green); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(Color.Green); GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Color3(Color.Green); GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Color3(Color.Yellow); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(Color.Yellow); GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Color3(Color.Yellow); GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Color3(Color.Purple); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(Color.Purple); GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Color3(Color.Purple); GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Color3(Color.White); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(Color.White); GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Color3(Color.White); GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.End();
        }
        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
