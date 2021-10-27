using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taranu
{
    class piramida
    {
        private Color color1 = Color.FromArgb(255,0,0);
        private Color color2 = Color.FromArgb(0, 255, 0);
        private Color color3 = Color.FromArgb(255, 255, 0);
        private Color color4 = Color.FromArgb(255, 0, 255);
        private Color color5 = Color.FromArgb(240, 255, 240);
        public void Desenare()
        {

            GL.Begin(PrimitiveType.TriangleStrip);

            GL.Color3(color1); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(color1); GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Color3(color1); GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Color3(color2); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(color2); GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Color3(color2); GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Color3(color3); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(color3); GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Color3(color3); GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Color3(color4); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(color4); GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Color3(color4); GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Color3(color5); GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Color3(color5); GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Color3(color5); GL.Vertex3(1.0f, -1.0f, 1.0f);
       
            GL.End();
        }
        /*8.Creați o aplicație care la apăsarea unui set de taste va modificaculoarea unui triunghi(coordonatele acestuia vor fi încărcate dintr-un
        fișier text) între valorile minime și maxime, pentru fiecare canal de culoare.Ce efect va apare la utilizarea canalului de transparență?
        Aplicația va permite modificarea unghiului camerei cu ajutorul mouse-ului.*/
        public void SchimbareCuloare(Culori _c)
        {
            color1 = _c.SCuloare1();
            color2 = _c.SCuloare2();
            color3 = _c.SCuloare3();
            color4 = _c.SCuloare4();
            color5 = _c.SCuloare5();
        }
        /*8.Creați o aplicație care la apăsarea unui set de taste va modificaculoarea unui triunghi(coordonatele acestuia vor fi încărcate dintr-un
        fișier text) între valorile minime și maxime, pentru fiecare canal de culoare.Ce efect va apare la utilizarea canalului de transparență?
        Aplicația va permite modificarea unghiului camerei cu ajutorul mouse-ului.*/
        public void RestabilireCuloare()
        {
            color1 = Color.FromArgb(255, 0, 0);
            color2 = Color.FromArgb(0, 255, 0);
            color3 = Color.FromArgb(255, 255, 0);
            color4 = Color.FromArgb(255, 0, 255);
            color5 = Color.FromArgb(240, 255, 240);
        }
    }
}
