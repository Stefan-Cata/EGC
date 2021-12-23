using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TARANU_STEFAN-CATALIN
//GRUPA:3131A
//CALCULATOARE AN III
namespace Taranu
{
    class Culori
    {
        int[] vector = new int[15];
        string NumeFisier { get; set; }
        public void CitireFisier(string numeFisier)//Citire culori din fisier
        {

            using (StreamReader sr = new StreamReader(numeFisier))
            {
                int i = 0;
                string linieDinFisier;
                string[] lin = new string[3];
                while ((linieDinFisier = sr.ReadLine()) != null)
                {
                    lin = linieDinFisier.Split(',');
                    vector[i] = Convert.ToInt32(lin[0]);
                    vector[i + 1] = Convert.ToInt32(lin[1]);
                    vector[i + 2] = Convert.ToInt32(lin[2]);
                    i += 3;
                }
            }
        }
        //9.Modificați aplicația pentru a manipula valorile RGB pentru fiecarevertex ce definește un triunghi.Afișați valorile RGB în consolă.
        public Color SCuloare1()
        {
            Color col = Color.FromArgb(vector[0], vector[1], vector[2]);
            return col;
        }
        public Color SCuloare2()
        {
            Color col = Color.FromArgb(vector[3], vector[4], vector[5]);
            return col;
        }
        public Color SCuloare3()
        {
            Color col = Color.FromArgb(vector[6], vector[7], vector[8]);
            return col;
        }
        public Color SCuloare4()
        {
            Color col = Color.FromArgb(vector[9], vector[10], vector[11]);
            return col;
        }
        public Color SCuloare5()
        {
            Color col = Color.FromArgb(vector[12], vector[13], vector[14]);
            return col;
        }
        //9.Modificați aplicația pentru a manipula valorile RGB pentru fiecarevertex ce definește un triunghi.Afișați valorile RGB în consolă.
        public void AfisareCuloriC()//Afisare in consola a culorilor citite din fisier
        {
            Console.WriteLine("\n    CULORI DIN FISIER \n --------------------------------");
            for (int i = 0; i < 15; i += 3)
            {
                Console.WriteLine("R:" + vector[i] + ", G:" + vector[i + 1] + ", B:" + vector[i + 2]);
            }
        }
    }
}
