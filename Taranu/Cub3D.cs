using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TARANU_STEFAN-CATALIN
//GRUPA:3131A
//CALCULATAORE AN III
namespace Taranu
{
    class Cub3D
    { 
        private int[,] objVertices = new int[12,9];
        private Color[] ColorV2 = new Color[36];

        public void SetareCuloare()
        {
            ColorV2[0] = ColorV2[1] = ColorV2[2] = Color.FromArgb(255, 0, 0);
            ColorV2[3] = ColorV2[4] = ColorV2[5] = Color.FromArgb(255, 0, 0);
            ColorV2[6] = ColorV2[7] = ColorV2[8] = Color.FromArgb(0, 255, 0);
            ColorV2[9] = ColorV2[10] = ColorV2[11] = Color.FromArgb(0, 255, 0);
            ColorV2[12] = ColorV2[13] = ColorV2[14] = Color.FromArgb(255, 255, 0);
            ColorV2[15] = ColorV2[16] = ColorV2[17] = Color.FromArgb(255, 255, 0);
            ColorV2[18] = ColorV2[19] = ColorV2[20] = Color.FromArgb(255, 0, 255);
            ColorV2[21] = ColorV2[22] = ColorV2[23] = Color.FromArgb(255, 0, 255);
            ColorV2[24] = ColorV2[25] = ColorV2[26] = Color.FromArgb(255, 0, 0);
            ColorV2[27] = ColorV2[28] = ColorV2[29] = Color.FromArgb(255, 0, 0);
            ColorV2[30] = ColorV2[31] = ColorV2[32] = Color.FromArgb(255, 255, 0);
            ColorV2[33] = ColorV2[34] = ColorV2[35] = Color.FromArgb(255, 255, 0);
        }
        public void SchimbareCuloare(Randomizer r)
        {
            Color color1;
            for (int i = 0; i < 36; i++)
            {
                color1 = r.GenerateColor();
                ColorV2[i] = color1;
                Console.WriteLine(ColorV2[i] + "  ");
            }
        }
        public void AfisareCuloare()
        {
            Console.WriteLine("\nCuloare noua: \n"+ColorV2[0] + "\n"+ ColorV2[1]+"\n"+ColorV2[2]+"\n"+ColorV2[3]+"\n"+ColorV2[4]+"\n"+ColorV2[5]);
        }
        /*3. Folosiți fișiere text pentru stocarea vertexurilor (cu testare de eroare la
        deschiderea resurselor!). Folositi și fișiere low-poly de tip OBJ de pe Internet.*/
        public void CitireFisier()//citire cooordonate din fisier
        {
            using (StreamReader sr = new StreamReader("date.txt"))
            {
                int i = 0;
                string linieDinFisier;
                string[] lin = new string[9];
                while ((linieDinFisier = sr.ReadLine()) != null)
                {
                    lin = linieDinFisier.Split(',');
                    objVertices[i, 0] = Convert.ToInt32(lin[0]);
                    objVertices[i, 1] = Convert.ToInt32(lin[1]);
                    objVertices[i, 2] = Convert.ToInt32(lin[2]);
                    objVertices[i, 3] = Convert.ToInt32(lin[3]);
                    objVertices[i, 4] = Convert.ToInt32(lin[4]);
                    objVertices[i, 5] = Convert.ToInt32(lin[5]);
                    objVertices[i, 6] = Convert.ToInt32(lin[6]);
                    objVertices[i, 7] = Convert.ToInt32(lin[7]);
                    objVertices[i, 8] = Convert.ToInt32(lin[8]);
                    i++;
                }
                sr.Close();
            }
        }

        public void DCub()
        {
            CitireFisier();
            GL.Begin(PrimitiveType.Triangles);

            int j = 0;
            for (int i = 0; i < 12; i++)
            {
                GL.Color3(ColorV2[j]);
                GL.Vertex3(objVertices[i,0], objVertices[i,1], objVertices[i,2]);
                GL.Color3(ColorV2[j+1]);
                GL.Vertex3(objVertices[i,3], objVertices[i,4], objVertices[i,5]);
                GL.Color3(ColorV2[j+2]);
                GL.Vertex3(objVertices[i,6], objVertices[i,7], objVertices[i,8]);
                j += 3;
            }

            GL.End();      
        }
  
    }
}
