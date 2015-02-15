/* <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
 *           - Projet Lunar Lander -
 *               Codé par J-R
 *            Jean-René Minville
 *              Classe: Ground
 *           Dernière modification
 *              4 Février 2010
 * >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProjectLunarLander
{
    class Ground
    {
        /// <summary>
        /// La form
        /// </summary>
        private Control control;
        /// <summary>
        /// La toile sur laquelle on dessine
        /// </summary>
        private Rectangle toile;

        /// <summary>
        /// La couleur du sol
        /// </summary>
        private SolidBrush pinceau = new SolidBrush(Color.Gray);

        /// <summary>
        /// La liste des points du sol
        /// </summary>
        private List<Point> listePoints;
        /// <summary>
        /// Un tableau contenant les points du sol
        /// </summary>
        private Point[] tableauPoints;
        /// <summary>
        /// Le contour du sol
        /// </summary>
        private GraphicsPath contour;
        /// <summary>
        /// La classe region du sol
        /// </summary>
        private Region region;

        /// <summary>
        /// La distance de X entre chaque points
        /// </summary>
        private int distanceX = 10;

        /// <summary>
        /// De combien maxi la montagne peut être appique
        /// </summary>
        private int stepMax = 15;
        /// <summary>
        /// De combien mini la montagne peut être appique
        /// </summary>
        private int stepMin = 1;

        /// <summary>
        /// Combien de haut (en pourcentage) doit être réservé pour le ciel
        /// </summary>
        private float limiteHaut = 0.4f;
        /// <summary>
        /// Combien de bas (en pourcentage) doit être réservé pour le sol
        /// </summary>
        private float limiteBas = 0.2f;

        /// <summary>
        /// Combien à gauche (en pourcentage) doit être réservé pour l'extérieur
        /// </summary>
        private float limiteGauche = 0.1f;
        /// <summary>
        /// Combien à droite (en pourcentage) doit être réservé pour l'extérieur
        /// </summary>
        private float limiteDroite = 0.1f;

        /// <summary>
        /// Combien de fois maximum une montagne peut monter
        /// </summary>
        private int maxMontain = 36;
        /// <summary>
        /// Combien de fois minimum une montagne peut monter
        /// </summary>
        private int minMontain = 12;

        /// <summary>
        /// La largeur que doit prendre la piste
        /// </summary>
        private int largeurPiste = 165;
        /// <summary>
        /// Le rectangle représentant la piste
        /// </summary>
        private Rectangle piste;

        /// <summary>
        /// Classe Random...
        /// </summary>
        private static Random rnd = new Random((int)DateTime.Now.Ticks);

        public Ground(Control control, int level)
        {
            // Arrange les couleurs, les limites et les sauts
            // de points selon le niveau du background
            int color = 200 / (level + 1);

            pinceau = new SolidBrush(Color.FromArgb(color, color, color));
            limiteHaut -= 0.1f * level;
            limiteBas += 0.1f * level;
            distanceX *= level + 1;
            maxMontain /= level + 1;
            minMontain /= level + 1;

            this.control = control;

            toile = control.ClientRectangle;
            listePoints = new List<Point>();
            int limiteLargeur = control.Width;

            // On définit les limites du sol

            int minX = (int)(limiteLargeur * limiteGauche);
            int maxX = (int)(limiteLargeur - limiteLargeur * limiteDroite);
            int yMax = (int)(control.Height * limiteHaut);
            int yMin = (int)(control.Height - control.Height * limiteBas);

            // On tire au hasard le début du sol
            int hauteur = rnd.Next(yMax, yMin);

            // On choisit l'emplacement de la piste
            int pisteX = rnd.Next(minX, maxX - largeurPiste);

            // Si c'est un des background derrière
            // on envoye la piste en dehors pour pas le voir
            if (level != 0)
                pisteX = int.MaxValue;

            int multiplicator = -1;
            
            
            int index = 0;
            listePoints.Add(new Point(index, hauteur));
            int montain = rnd.Next(minMontain, maxMontain);
            int pisteY = 0;
            bool pisteOk = false;

            // On récupère la résolution de l'écran pour s'en
            // servir comme limite
            int limiteX = Screen.FromControl(control).Bounds.Width;
            int limiteY = Screen.FromControl(control).Bounds.Height;

            // Tant qu'on a pas atteint 2500, grandeur assez grande pour
            // le fullscreen sur pas mal tous les ordis
            while (index <= limiteX)
            {
                // Si on est rendu à faire la piste
                if (index >= pisteX && !pisteOk)
                {
                    pisteX = index;
                    index += largeurPiste;
                    listePoints.Add(new Point(index, hauteur));
                    pisteY = hauteur;
                    pisteOk = true;

                    // Puis on change la direction, comme le conseille Roberto
                    multiplicator *= -1;
                    montain = rnd.Next(minMontain, maxMontain);
                }
                else
                {
                    montain--;
                    index += distanceX;
                    // On calcule au hasard la nouvelle hauteur qu'aurait le sol
                    int newHauteur = hauteur + (rnd.Next(stepMin, stepMax) * multiplicator);

                    // Et on vérifie s'il est toujours dans les limites
                    if (newHauteur > yMin || newHauteur < yMax || montain <= 0)
                    {
                        // S'il ne l'est pas, on change de direction
                        multiplicator *= -1;
                        montain = rnd.Next(minMontain, maxMontain);
                    }
                    else
                    {
                        hauteur = newHauteur;
                        listePoints.Add(new Point(index, hauteur));
                    }
                }
            }

            // On rajoute les coins
            listePoints.Add(new Point(limiteX, hauteur));
            listePoints.Add(new Point(limiteX, limiteY));
            listePoints.Add(new Point(0, limiteY));

            // On le change en tableau
            tableauPoints = new Point[listePoints.Count];
            listePoints.CopyTo(tableauPoints);

            contour = new GraphicsPath();
            contour.AddLines(tableauPoints);

            region = new Region(contour);

            piste = new Rectangle(new Point(pisteX, pisteY - 3), new Size(largeurPiste, 20));
        }

        public SolidBrush Pinceau
        {
            get { return pinceau; }
        }

        public Region Region
        {
            get { return region; }
        }

        public Rectangle Piste
        {
            get { return piste; }
        }
    }
}