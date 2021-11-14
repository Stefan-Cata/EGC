//TARANU_STEFAN-CATALIN
//GRUPA:3131A
//CALCULATAORE AN III
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
    class Program
    {
        static void Main(string[] args)
        {
            Window3D wnd = new Window3D();
            wnd.Run(30.0, 0.0);

        }
    }
}