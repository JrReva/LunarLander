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
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ProjectLunarLander
{
    using Properties;

    //=========================================================================
    // Classe de l'engin lunaire comprenant les images de son comportement 
    // visuel, le touches de contrôles associées et les calculs de simulation 
    // de l'attraction gravitationnelle.
    //=========================================================================
    public class Engin
    {
        public Rectangle bounds;

        public static int FUEL_PLEIN = 5000; //.................. Nombres le litres de carburant
        public int MODULE_JET = 37;   //.................. Nombres de pixels de la plume du réacteur
        public double CTRL_PUISSANCE = 2.25f; //.......... Nombres de pixels de la plume du réacteur
        public int PIXELS_METRE = 30; //.................. Constante pour de conversion à l'échelle

        public Image[] tblPilotage;     //...................... Images de l'engin en vol
        public Image[] tblAtterrisage;  //...................... Images de l'engin à l'atterrissage
        public Image[] tblExplosion;    //...................... Images de l'engin explosant

        Control ctrlConsole;   //............................... Référence sur la Form servant de console
        PictureBox pboxEngin;  //............................... Référence sur la PictureBox utilisée
        Timer timer;           //............................... Horloge responsable des déplacements

        public double x;       //............................... Coordonnée X
        public double y;       //............................... Coordonnée Y 
        public double xV;      //............................... Vitesse en X
        public double yV;      //............................... Vitesse en Y
        public double xSens;   //............................... Direction en X
        public double ySens;   //............................... Direction en Y
        public double T;       //............................... Intervalle de temps en secondes
        public static double gF = 0.33f;//............................... Force gravitationnelle (1 = 1g)
        public static double xF = 0.50f;//............................... Poussée en X (g)
        public static double yF = 0.60f;//............................... Poussée en Y (g)
        public double xD;      //............................... Distance parcourue en X (m)
        public double yD;      //............................... Distance parcourue en Y (m)
        public double pixelsMetre; //........................... Facteur de conversion (pixels/m)

        public static int consommation = 5;
        public double fuel;
        internal int cliche;

        public static double Xmax = 0.7f;
        public static double Ymax = 1.2f;

        internal bool moteurGauche = false;
        internal bool moteurDroit = false;
        internal bool moteurHaut = false;
        internal bool moteurBas = false;
        internal bool moteurBasMax = false;

        Random rnd = new Random( ( int )DateTime.Now.Ticks );

        private int expIndex = 0;
        private int attIndex = 0;

        //-----------------------------------------------------------------------
        // Constructeur : demande la référence de la form propriétaire ainsi
        // que la référence de la PictureBox qui représente l'engin
        //-----------------------------------------------------------------------
        public Engin( Control console, PictureBox engin, Timer timer )
        {
            // Conserver les références des objets pour les "recontacter"
            this.ctrlConsole = console; 
            this.pboxEngin = engin;
            this.timer = timer;

            ImagesCharger();
            ValeursInitialiser();

            this.pboxEngin.Image = tblPilotage[0];
        }

        //-----------------------------------------------------------------------
        // Affecter les images aux tableaux.  Note : les images doivent être 
        // préalabement ajouté aux ressources du projet, et l'ajout de 
        // l'instruction using Properties;
        //-----------------------------------------------------------------------
        private void ImagesCharger()
        {
            // Instancier et  initialiser le tableau images 
            // Doit être utilisé avec les événements Key pour le changement d'image
            tblPilotage = new Image[]
         {  Resources.GLM_SM,  Resources.GLM_G,   Resources.GLM_D, 
            Resources.GLM_H,   Resources.GLM_GH,  Resources.GLM_DH,  
            Resources.GLM_B,   Resources.GLM_GB,  Resources.GLM_DB,             
            Resources.GLM_BC,  Resources.GLM_GBC, Resources.GLM_DBC
         };

            // Instancier et  initialiser le tableau atterrissage
            // Doit être utilisé avec un timer pour le changement d'image
            tblAtterrisage = new Image[]
         {  Resources.GLM_AT1, Resources.GLM_AT2, Resources.GLM_AT3, 
            Resources.GLM_AT4, Resources.GLM_AT2, Resources.GLM_AT5
         };

            // Instancier et  initialiser le tableau explosion
            // Doit être utilisé avec un timer pour le changement d'image
            tblExplosion = new Image[]
         {  Resources.GLM_EX1, Resources.GLM_EX2, Resources.GLM_EX3, 
            Resources.GLM_EX4, Resources.GLM_EX6, Resources.GLM_EX7, 
            Resources.GLM_EX8, Resources.GLM_EX9
         };
        }


        //---------------------------------------------------------------------
        // Obtenir les moteurs activés par la console
        //---------------------------------------------------------------------
        public void MoteursActifs(
           bool Gauche, bool Droit, bool Haut,
           bool Bas, bool BasMax )
        {
            moteurGauche = Gauche;
            moteurDroit = Droit;
            moteurHaut = Haut;
            moteurBas = Bas;
            moteurBasMax = BasMax;
        }


        //---------------------------------------------------------------------
        // Affichage de l'image de l'engin qui correspond aux
        // moteurs actifs.  La variable combinaison utilise le
        // principe binaire où chaque bit représente l'état d'un
        // moteur (0 inactif, 1 actif)
        // Appelant : MoteursAllumer()
        //---------------------------------------------------------------------
        public void MoteursAfficher()
        {
            if (fuel == 0)
            {
                return;
            }

            cliche = 0;

            //gauche-droite-haut-bas

            if (moteurGauche)
                cliche += 1;
            if (moteurDroit)
                cliche += 2;
            if (moteurHaut)
                cliche += 3;
            if (moteurBas)
                cliche += 6;
            if (moteurBasMax)
                cliche += 3;

            pboxEngin.Image = tblPilotage[ cliche ];
        }


        //---------------------------------------------------------------------
        // Affectation de valeurs initiales à la contruction de l'engin.  
        // Les valeurs peuvent être modifiés par la suite.
        // Appelant : contructeur
        //---------------------------------------------------------------------
        private void ValeursInitialiser()
        {
            pixelsMetre = ( double )( pboxEngin.Height * PIXELS_METRE ) / 150f;

            // Récupérer la base du temps
            T = timer.Interval / 1000f;

            // Vitesses initiales à zéro
            xV = 0.0f;
            yV = 0.0f;

            // Récupérer les coordonnées de l'engin
            x = pboxEngin.Location.X;
            y = pboxEngin.Location.Y;

            fuel = FUEL_PLEIN;
        }


        //---------------------------------------------------------------------
        //
        //---------------------------------------------------------------------
        internal void Deplacer()
        {
            DirectionObtenir();
            DistanceCalculer();

            pboxEngin.Location = new Point((int)x, (int)y);
            this.bounds = pboxEngin.Bounds;
            this.bounds.Height = pboxEngin.Height - 38;

            if (fuel > 0)
            {
                fuel -= T * consommation * 100 * (Math.Abs(xSens * xF)) + (Math.Abs(ySens * yF));

                if (fuel <= 0)
                {
                    pboxEngin.Image = tblPilotage[0];
                    fuel = 0;
                }
            }
        }


        //---------------------------------------------------------------------
        //
        //---------------------------------------------------------------------
        private void DirectionObtenir()
        {
            xSens = 0;  // +1 moteur droit, 0 aucun, -1 moteur gauche
            ySens = 0;  // +1 moteur haut,  0 aucun, -1 moteurs bas 
            if (fuel != 0)
            {
                if (moteurHaut)
                    ySens++;
                if (moteurBas)
                    ySens--;
                if (moteurBasMax)
                    ySens--;
                if (moteurDroit)
                    xSens--;
                if (moteurGauche)
                    xSens++;
            }
        }


        //---------------------------------------------------------------------
        // Calcul du déplacement, et de la vitesse après que se soit écoulé 
        // un intervalle T de temps.  Détermination de la nouvelle coordonnée 
        // (x,y) de l'engin à l'écran.
        // Appelant : TrajectoireCalculer()
        //---------------------------------------------------------------------
        private void DistanceCalculer()
        {
            // On tient compte de quelle façon la force s'applique 
            // avec les sens X et Y. Dans le cas des forces Y et G, 
            // elles s'additionnent ou se soustraient dépendant de
            // la valeur ySens.
            //
            // Calculs simplifiés :
            // Vfinale = Vinitiale + A * T
            // D  = Vinitiale * T + A * T * T / 2

            // Calculer la distance parcourue depuis le dernier T
            // à partir d'une vitesse initiale et de la poussée
            xD = ( xV * T ) + ( ( gF * 9.8f ) * T * T / 2.0f * xSens );
            yD = ( yV * T ) + ( ( gF * 9.8f ) * T * T / 2.0f * 1.0f 
                + ( yF * 9.8f ) * T * T / 2.0f * ySens );

            // Calculer la nouvelle position en vertu de la distance 
            // parcourue lors du dernier T
            x += xD * pixelsMetre;
            y += yD * pixelsMetre;

            // Mettre à jour la nouvelle vitesse initiale pour le prochain T
            xV = xV + ( xF * 9.8f * T * xSens );
            yV = yV + ( yF * 9.8f * T * ySens + gF * 9.8 * T );
        }


        //---------------------------------------------------------------------
        // Modifier la position de l'engin pour la démo.
        //---------------------------------------------------------------------
        public void ModifierPosition( Point point )
        {
            x = point.X;
            y = point.Y;
        }

        public bool tmr_Explosion()
        {
            if (expIndex < tblExplosion.Length)
            {
                pboxEngin.Image = tblExplosion[expIndex];
                expIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool tmr_Atterissage()
        {
            if (attIndex < tblAtterrisage.Length)
            {
                pboxEngin.Image = tblAtterrisage[attIndex];
                attIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetFuelPourcent()
        {
            return fuel / FUEL_PLEIN;
        }
    }
}