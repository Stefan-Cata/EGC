using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

//TARANU_STEFAN-CATALIN
//GRUPA:3131A
//CALCULATAORE AN III
/*
 
1.Desenați axele de coordonate din aplicațiatemplate folosind un singur apel GL.Begin()
5.Creați un proiect elementar.
8.Creați o aplicație care la apăsarea unui set de taste va modificaculoarea unui triunghi (coordonatele acestuia vor fi încărcate dintr-un 
fișier text) între valorile minime și maxime, pentru fiecare canal de culoare. Ce efect va apare la utilizarea canalului de transparență?
Aplicația va permite modificarea unghiului camerei cu ajutorul mouse-ului.
9.Modificați aplicația pentru a manipula valorile RGB pentru fiecare
vertex ce definește un triunghi. Afișați valorile RGB în consolă.
 */
namespace Taranu
{
    class SimpleWindow : GameWindow
    {
        KeyboardState previousKeyboard;

        Color DEFAULT_BKG_COLOR = Color.LightBlue;
        private piramida pir1;
        private Culori c1;
        private const int XYZ_SIZE = 75;

        public SimpleWindow() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            pir1 = new piramida();
            c1 = new Culori();
            c1.CitireFisier("date.txt");
            DisplayHelp();
            c1.AfisareCuloriC();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(DEFAULT_BKG_COLOR);
            GL.Enable(EnableCap.DepthTest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // setare viewport
            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;

            //setare perspectiva
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            //setare camera
            Matrix4 lookat = Matrix4.LookAt(7, 7, 6 , 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMouse = Mouse.GetState();

            if (thisKeyboard[Key.Escape])
            {
                Exit();
            }

            if (thisKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                pir1.RestabilireCuloare();
            }
            if (thisKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                pir1.SchimbareCuloare(c1);
            }

            previousKeyboard = thisKeyboard;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {

            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            pir1.Desenare();//Desenare piramida
            Axe(); // Desenare axe
            this.SwapBuffers();
        }
        //1.Desenați axele de coordonate din aplicațiatemplate folosind un singur apel GL.Begin()
        private void Axe()
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(XYZ_SIZE, 0, 0);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0); ;
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();
        }
        private void DisplayHelp()
        {
            Console.WriteLine("\n      MENIU");
            Console.WriteLine(" H - meniul");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine(" R - resteaza scena la valori implicite");
            Console.WriteLine(" B - schimbare culoarea piramidei");
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
