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
//CALCULATOARE AN III
/*
1. Creați o aplicație care la apăsarea unui clic va genera un obiect ce se 
va deplasa în direcția “jos”. La contactul cu planul Oxz deplasarea
încetează. Pentru animație veti folosi un contor legat de valoarea de
update a metodei OnUpdateFrame(). Se va lucra în manieră OOP (pentru 
cameră inclusiv). 
2. Modificați aplicația pentru a manipula valorile camerei (permite mișcare și repoziționare 
la 2 locații predefinite, “aproape” și “departe”. 
3. Folosiți fișiere text pentru stocarea vertexurilor (cu testare de eroare la
deschiderea resurselor!). Folositi și fișiere low-poly de tip OBJ de pe 
Internet.*/
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
        int Ok = 0;
        private int transStep = 0;
        private int radStep = 0;
        private int attStep = 60;

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
            /*
            2.Modificați aplicația pentru a manipula valorile camerei(permite mișcare și repoziționare
            la 2 locații predefinite, “aproape” și “departe”. */
            if (thisKeyboard[Key.N])
            {
                cam.Departe();
            }
            if (thisKeyboard[Key.M])
            {
                cam.Aproape();
            }/*
            1.Creați o aplicație care la apăsarea unui clic va genera un obiect ce se
            va deplasa în direcția “jos”. La contactul cu planul Oxz deplasarea
            încetează.Pentru animație veti folosi un contor legat de valoarea de
            update a metodei OnUpdateFrame(). Se va lucra în manieră OOP(pentru
            cameră inclusiv). */
            if (thisKeyboard[Key.Up])
            {
                attStep++;
            }
            if ((currentMouse[MouseButton.Left] || Ok == 1) && attStep != 0)
            {
                 attStep--;
            }
            previousKeyboard = thisKeyboard;
            previousMouse = currentMouse;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            MouseState currentMouse = Mouse.GetState();
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            if (currentMouse[MouseButton.Left] || Ok == 1 && attStep != 0)
            {
                GL.PushMatrix();
                GL.Translate(transStep, attStep, radStep);

                cub1.DCub();
                GL.PopMatrix();

                Ok = 1;
            }
            else
            {
                attStep = 60;
                Ok = 0;
            }
            Axe();
            previousMouse = currentMouse;
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
            Console.WriteLine(" N - setare camera departe ");
            Console.WriteLine(" M - setare camera aproape ");
            Console.WriteLine(" Click stanga - creare obiect ");
        }
    }
}
