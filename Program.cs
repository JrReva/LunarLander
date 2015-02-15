/* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
 *           - Projet Lunar Lander -
 *               Codé par J-R
 *            Jean-René Minville
 *              Classe: Program
 *           Dernière modification
 *              27 Janvier 2010
 * >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjectLunarLander
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmConsole());
        }
    }
}
