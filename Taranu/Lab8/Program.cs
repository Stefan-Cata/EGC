using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//TARANU_STEFAN-CATALIN
//GRUPA:3131A
//CALCULATOARE AN III
/*
 3. Plasați o a doua sursă de lumină în cadru. Aceasta poate fi închisă/pornită 
individual (la apăsarea unui buton). Sursa de lumină adițională va fi 
poziționată deasupra cubului generat și va putea fi deplasată folosind (a) 6 
taste (3 axe spațiale) și (b) mouse-ul (2 axe spațiale). Implementarea va utiliza 
metode specifice POO (clase). Controalele pentru manipularea sursei/surselor 
de lumină vor fi funcționale doar dacă iluminarea este activă... 
4. Implementați modificările specificate în secțiunea ToDo din constructorul 
formularului principal.
 */
namespace Lab8 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
