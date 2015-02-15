/* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
 *           - Projet Lunar Lander -
 *               Codé par J-R
 *            Jean-René Minville
 *              Classe: Form1
 *           Dernière modification
 *              19 février 2010
 * >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectLunarLander
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
            initialiser();
        }

        /// <summary>
        /// Méthode initialisant les barres et
        /// les labels
        /// </summary>
        public void initialiser()
        {
            tbG.Value = (int)(Engin.gF * 100);
            lblG.Text = "" + (double)tbG.Value / 100 + "g";

            tbX.Value = (int)(Engin.xF * 100);
            lblX.Text = "" + (double)tbX.Value / 100 + "g";

            tbY.Value = (int)(Engin.yF * 100);
            lblY.Text = "" + (double)tbY.Value / 100 + "g";

            tbFuel.Value = Engin.consommation;
            lblFuel.Text = "" + tbFuel.Value * 5 + "%";

            cbFuelMax.Text = "" + Engin.FUEL_PLEIN;
        }

        /// <summary>
        /// Méthode actualisant le label lblG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbG_Scroll(object sender, EventArgs e)
        {
            lblG.Text = "" + (double)tbG.Value / 100 + "g";
        }

        /// <summary>
        /// Méthode actualisant le label lblX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbX_Scroll(object sender, EventArgs e)
        {
            lblX.Text = "" + (double)tbX.Value / 100 + "g";
        }

        /// <summary>
        /// Méthode actualisant le label lblY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbY_Scroll(object sender, EventArgs e)
        {
            lblY.Text = "" + (double)tbY.Value / 100 + "g";
        }

        /// <summary>
        /// Méthode actualisant le label lblFuel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbFuel_Scroll(object sender, EventArgs e)
        {
            lblFuel.Text = "" + tbFuel.Value * 5 + "%";
        }

        /// <summary>
        /// Méthode appelée lors du clic sur le bouton quitter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Méthode pour valider les changements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValider_Click(object sender, EventArgs e)
        {
            Engin.gF = (double)tbG.Value / 100;
            Engin.xF = (double)tbX.Value / 100;
            Engin.yF = (double)tbY.Value / 100;
            Engin.consommation = tbFuel.Value;
            Engin.FUEL_PLEIN = Convert.ToInt32(cbFuelMax.Text);
            this.Close();
        }
    }
}
