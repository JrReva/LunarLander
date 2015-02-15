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
    public partial class frmConsole : Form
    {
        /// <summary>
        /// Objet contenant l'engin
        /// </summary>
        Engin engin;
        /// <summary>
        /// Variables gardant en mémoire les touches appuyés
        /// </summary>
        private bool gauche, droite, haut, bas, ctrl;
        /// <summary>
        /// Classe du sol
        /// </summary>
        private Ground ground;
        /// <summary>
        /// Classe du premier background
        /// </summary>
        private Ground background1;
        /// <summary>
        /// Classe du deuxième background
        /// </summary>
        private Ground background2;
        /// <summary>
        /// Classe du troisième background
        /// </summary>
        private Ground background3;
        /// <summary>
        /// Le score du joueur
        /// </summary>
        private int pointage = 0;
        /// <summary>
        /// Le compteur avant de refresher le tableau de bord
        /// </summary>
        private int redrawCounter = 10;
        /// <summary>
        /// Le rectangle affichant le carburant restant
        /// </summary>
        private Rectangle carburant;

        public frmConsole()
        {
            // Lors de la création de la form, on appèle la méthode
            // De création du background et du sol
            InitializeComponent();

            // On affiche le Xmax et le Ymax (car elle ne change pas)
            lblXmax.Text = "Xmax: " + Math.Round(Engin.Xmax, 2) + " m/s";
            lblYmax.Text = "Ymax: " + Math.Round(Engin.Ymax, 2) + " m/s";
            // Et on débute la partie
            newGame();
        }

        /// <summary>
        /// Méthode débutant une nouvelle partie
        /// </summary>
        public void newGame()
        {
            // On arrête tous les timers pour faire sur
            tmrAtterissage.Enabled = false;
            tmrExplosion.Enabled = false;

            // On réactive le menu de configuration
            menuConfiguration.Enabled = true;

            // On crée un nouveau background
            CreateBackground();
            this.Refresh();

            // On remet l'engin en haut et on en crée un nouveau
            pboxEngin.Location = new Point(250, 40);
            engin = new Engin(this, pboxEngin, tmrFrame);
            gauche = droite = haut = bas = ctrl = false;

            // On affiche le pause
            lblPause.Visible = true;
        }

        /// <summary>
        /// Méthode pour créer les classes de background et du sol
        /// </summary>
        public void CreateBackground()
        {
            this.ground = new Ground(this, 0);
            this.background1 = new Ground(this, 1);
            this.background2 = new Ground(this, 2);
            this.background3 = new Ground(this, 3);
        }

        /// <summary>
        /// Méthode appelée lorsque la form est redessinée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // On récupère l'objet Graphics

            // On descine les background en partant de celui le plus loin
            g.FillRegion(this.background3.Pinceau, this.background3.Region);
            g.FillRegion(this.background2.Pinceau, this.background2.Region);
            g.FillRegion(this.background1.Pinceau, this.background1.Region);

            // Puis le sol
            g.FillRegion(this.ground.Pinceau, this.ground.Region);

            // Et finalement le rectangle du carburant
            g.FillRectangle(new SolidBrush(Color.Red), this.carburant);
        }

        /// <summary>
        /// Méthode qui fait la gestion de l'utilité de la spacebar
        /// </summary>
        public void SpaceBar()
        {
            // On désactive le menu de configuration au cas où
            // il vien de commencer une partie
            menuConfiguration.Enabled = false;

            // On modifie la valeur du timer et du pause
            tmrFrame.Enabled = !tmrFrame.Enabled;
            lblPause.Visible = !tmrFrame.Enabled;
            return;
        }

        /// <summary>
        /// Méthode affichant le messagebox pour
        /// demander de commencer une nouvelle partie
        /// </summary>
        private void JouerEncore()
        {
            switch (MessageBox.Show("Désirez-vous commencer une autre partie?", "Nouvelle partie", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    newGame();
                    break;
                case DialogResult.No:
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Méthode gérant les touches entrées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsole_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    bas = false;
                    haut = true;
                    break;
                case Keys.Down:
                    haut = false;
                    bas = true;
                    break;
                case Keys.Left:
                    droite = false;
                    gauche = true;
                    break;
                case Keys.Right:
                    gauche = false;
                    droite = true;
                    break;
                case Keys.Space:
                    SpaceBar();
                    break;
            }

            if (e.Control && bas)
                ctrl = true;
            else
                ctrl = false;
        }

        /// <summary>
        /// Méthode gérant les touches relâchées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConsole_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    haut = false;
                    break;
                case Keys.Down:
                    bas = false;
                    ctrl = false;
                    break;
                case Keys.Left:
                    gauche = false;
                    break;
                case Keys.Right:
                    droite = false;
                    break;
            }

            if (!e.Control)
                ctrl = false;
        }

        /// <summary>
        /// Méthode du timer qui s'effectue à chaque x ms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrFrame_Tick(object sender, EventArgs e)
        {
            // On envoit les moteurs actifs à l'engin
            engin.MoteursActifs(
                gauche,
                droite,
                haut,
                bas,
                ctrl);

            // On lui dit de se déplacer
            engin.Deplacer();

            // S'il sort en dehors du jeu
            if (!this.ClientRectangle.IntersectsWith(engin.bounds))
            {
                pointage -= (int) engin.fuel;
                tmrFrame.Stop();
                JouerEncore();
                return;
            }

            // S'il touche au sol
            if (ground.Region.IsVisible(engin.bounds))
            {
                pointage -= (int) engin.fuel + 1000;
                tmrFrame.Stop();
                tmrExplosion.Start();
                JouerEncore();
                return;
            }

            // S'il touche à la piste
            if (engin.bounds.Width == 
                Rectangle.Intersect(ground.Piste, engin.bounds).Width)
            {
                // S'il va pas trop vite
                if (engin.xV < Engin.Xmax && engin.yV < Engin.Ymax)
                {
                    pointage += (int) engin.fuel;
                    tmrFrame.Stop();
                    tmrAtterissage.Start();
                    JouerEncore();
                    return;
                }
                else
                {
                    pointage -= (int) engin.fuel + 1000;
                    tmrFrame.Stop();
                    tmrExplosion.Start();
                    JouerEncore();
                    return;
                }
            }
            
            // On affiche les moteurs
            engin.MoteursAfficher();

            // Si ça fait 10 fois, on réécrit les infos
            if (redrawCounter == 0)
            {
                lblFuel.Text = "Carburant restant: "+(int)engin.fuel+" L";
                lblScore.Text = "Pointage: " + pointage;
                lblVx.Text = "Vx: " + Math.Round(engin.xV, 2) + " m/s";
                lblVy.Text = "Vy: " + Math.Round(engin.yV, 2) + " m/s";

                redrawCounter = 10;

                this.Invalidate(carburant);
                carburant = new Rectangle(new Point(550, 50), new Size((int)(engin.GetFuelPourcent() * 150), 30));
            }
            redrawCounter--;
        }

        /// <summary>
        /// Méthode pour le timer d'explosion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrExplosion_Tick(object sender, EventArgs e)
        {
            if (!engin.tmr_Explosion())
                tmrExplosion.Stop();
        }

        /// <summary>
        /// Méthode pour le timer d'atterissage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrAtterissage_Tick(object sender, EventArgs e)
        {
            if (!engin.tmr_Atterissage())
                tmrAtterissage.Stop();
        }

        /// <summary>
        /// Méthode affichant un messagebox pour quitter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuQuitter_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Voulez-vous vraiment quitter?", "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Méthode affichant l'aide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAide_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Les touches de clavier sont les suivantes : \n\n"+
                "Flèche à gauche 		 fusée d'appoint de gauche\n"+
                "Flèche à droite 		 fusée d'appoint de droite\n"+
                "Flèche vers le haut 		 fusées d'appoint du haut\n"+
                "Flèche vers le bas 		 réacteur poussée réduite\n"+
                "CTRL + flèche vers le bas 	 réacteur pleine poussée\n", "Aide");
        }

        /// <summary>
        /// Méthode ouvrant le menu de configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuConfiguration_Click(object sender, EventArgs e)
        {
            frmConfig config = new frmConfig();
            AddOwnedForm(config);
            config.ShowDialog();
        }
    }
}