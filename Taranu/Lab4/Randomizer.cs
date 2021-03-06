using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TARANU_STEFAN-CATALIN
//GRUPA:3131A
//CALCULATOARE AN III
namespace Taranu
{
    //3. Implementați un mecanism de modificare a culorilor(randomizare sau
    //încărcare din paletă predefinită) pentru o clasă ce permite desenarea
    //unui cub în spațiul 3D*/
    class Randomizer
    {
        private Random r;
        public Randomizer()
        {
            r = new Random();
        }
        public Color GenerateColor()//creare culoare random
        {
            int genR = r.Next(0, 256);
            int genG = r.Next(0, 256);
            int genB = r.Next(0, 256);

            Color col = Color.FromArgb(genR, genG, genB);

            return col;
        }
    }
}
