using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TARANU_STEFAN-CATALIN
//GRUPA:3131A
//CALCULATAORE AN III
/*
1.Creați o aplicație care la apăsarea unui set de taste va modifica
culoarea unei fețe a unui cub 3D (coordonatele acestuia vor fi
încărcate dintr-un fișier text) între valorile minime și maxime, pentru
fiecare canal de culoare. Ce efect va apare la utilizarea canalului de
transparență?

2. Modificați aplicația pentru a manipula valorile RGB pentru fiecare
vertex ce definește un triunghi. Afișați valorile RGB în consolă.

3. Implementați un mecanism de modificare a culorilor (randomizare sau
încărcare din paletă predefinită) pentru o clasă ce permite desenarea
unui cub în spațiul 3D*/
namespace Taranu
{
    class Window3D : GameWindow
    {
        KeyboardState previousKeyboard;
        private MouseState previousMouse;
        private Cub3D cub1;
        private Randomizer rand;
        private Camera3D cam;
        private const int XYZ_SIZE = 75;

        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            cub1 = new Cub3D();
            rand = new Randomizer();
            DisplayHelp();
            cub1.SetareCuloare();
            cam = new Camera3D();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // setare background
            GL.ClearColor(Color.MidnightBlue);

            // setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // setare perspectiva
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 1024);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // setare camera
            cam.SetCamera();
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();
            if (thisKeyboard[Key.Escape])
            {
                Exit();
            }
            if (thisKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                cub1.SchimbareCuloare(rand);
                cub1.AfisareCuloare();
            }
            if (thisKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                Console.Clear();
                DisplayHelp();
            }
            if (thisKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                cub1.SetareCuloare();
                Console.Clear();
                DisplayHelp();
            }

            if (thisKeyboard[Key.W])
            {
                cam.MoveForward();
            }
            if (thisKeyboard[Key.S])
            {
                cam.MoveBackward();
            }
            if (thisKeyboard[Key.A])
            {
                cam.MoveLeft();
            }
            if (thisKeyboard[Key.D])
            {
                cam.MoveRight();
            }
            if (thisKeyboard[Key.Q])
            {
                cam.MoveUp();
            }
            if (thisKeyboard[Key.E])
            {
                cam.MoveDown();
            }       
            previousKeyboard = thisKeyboard;
            previousMouse = currentMouse;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            cub1.DCub();

            Axe();

            this.SwapBuffers();
        }

        private void Axe()//Desenare axe
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
            Console.WriteLine(" B - schimbare culoarea piramidei");
            Console.WriteLine(" R - resetare culoare ");
        }
    }
}
