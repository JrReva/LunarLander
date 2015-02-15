namespace ProjectLunarLander
{
    partial class frmConsole
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsole));
            this.pboxEngin = new System.Windows.Forms.PictureBox();
            this.tmrFrame = new System.Windows.Forms.Timer(this.components);
            this.tmrExplosion = new System.Windows.Forms.Timer(this.components);
            this.tmrAtterissage = new System.Windows.Forms.Timer(this.components);
            this.lblPause = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblYmax = new System.Windows.Forms.Label();
            this.lblXmax = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblVy = new System.Windows.Forms.Label();
            this.lblVx = new System.Windows.Forms.Label();
            this.lblFuel = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuitter = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pboxEngin)).BeginInit();
            this.panel1.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pboxEngin
            // 
            this.pboxEngin.BackColor = System.Drawing.Color.Transparent;
            this.pboxEngin.Image = ((System.Drawing.Image)(resources.GetObject("pboxEngin.Image")));
            this.pboxEngin.Location = new System.Drawing.Point(287, 40);
            this.pboxEngin.Name = "pboxEngin";
            this.pboxEngin.Size = new System.Drawing.Size(150, 150);
            this.pboxEngin.TabIndex = 1;
            this.pboxEngin.TabStop = false;
            // 
            // tmrFrame
            // 
            this.tmrFrame.Interval = 20;
            this.tmrFrame.Tick += new System.EventHandler(this.tmrFrame_Tick);
            // 
            // tmrExplosion
            // 
            this.tmrExplosion.Interval = 150;
            this.tmrExplosion.Tick += new System.EventHandler(this.tmrExplosion_Tick);
            // 
            // tmrAtterissage
            // 
            this.tmrAtterissage.Interval = 150;
            this.tmrAtterissage.Tick += new System.EventHandler(this.tmrAtterissage_Tick);
            // 
            // lblPause
            // 
            this.lblPause.AutoSize = true;
            this.lblPause.BackColor = System.Drawing.Color.Transparent;
            this.lblPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPause.ForeColor = System.Drawing.Color.Yellow;
            this.lblPause.Location = new System.Drawing.Point(540, 100);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(157, 46);
            this.lblPause.TabIndex = 2;
            this.lblPause.Text = "PAUSE";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblYmax);
            this.panel1.Controls.Add(this.lblXmax);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Controls.Add(this.lblVy);
            this.panel1.Controls.Add(this.lblVx);
            this.panel1.Controls.Add(this.lblFuel);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 112);
            this.panel1.TabIndex = 3;
            // 
            // lblYmax
            // 
            this.lblYmax.AutoSize = true;
            this.lblYmax.ForeColor = System.Drawing.Color.Yellow;
            this.lblYmax.Location = new System.Drawing.Point(3, 91);
            this.lblYmax.Name = "lblYmax";
            this.lblYmax.Size = new System.Drawing.Size(0, 13);
            this.lblYmax.TabIndex = 5;
            // 
            // lblXmax
            // 
            this.lblXmax.AutoSize = true;
            this.lblXmax.ForeColor = System.Drawing.Color.Yellow;
            this.lblXmax.Location = new System.Drawing.Point(3, 74);
            this.lblXmax.Name = "lblXmax";
            this.lblXmax.Size = new System.Drawing.Size(0, 13);
            this.lblXmax.TabIndex = 4;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.ForeColor = System.Drawing.Color.Yellow;
            this.lblScore.Location = new System.Drawing.Point(3, 59);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 13);
            this.lblScore.TabIndex = 3;
            // 
            // lblVy
            // 
            this.lblVy.AutoSize = true;
            this.lblVy.ForeColor = System.Drawing.Color.Yellow;
            this.lblVy.Location = new System.Drawing.Point(3, 43);
            this.lblVy.Name = "lblVy";
            this.lblVy.Size = new System.Drawing.Size(0, 13);
            this.lblVy.TabIndex = 2;
            // 
            // lblVx
            // 
            this.lblVx.AutoSize = true;
            this.lblVx.ForeColor = System.Drawing.Color.Yellow;
            this.lblVx.Location = new System.Drawing.Point(3, 26);
            this.lblVx.Name = "lblVx";
            this.lblVx.Size = new System.Drawing.Size(0, 13);
            this.lblVx.TabIndex = 1;
            // 
            // lblFuel
            // 
            this.lblFuel.AutoSize = true;
            this.lblFuel.ForeColor = System.Drawing.Color.Yellow;
            this.lblFuel.Location = new System.Drawing.Point(3, 10);
            this.lblFuel.Name = "lblFuel";
            this.lblFuel.Size = new System.Drawing.Size(0, 13);
            this.lblFuel.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfiguration,
            this.menuAide,
            this.menuQuitter});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(744, 24);
            this.menu.TabIndex = 4;
            this.menu.Text = "Menu";
            // 
            // menuConfiguration
            // 
            this.menuConfiguration.Name = "menuConfiguration";
            this.menuConfiguration.Size = new System.Drawing.Size(84, 20);
            this.menuConfiguration.Text = "Configuration";
            this.menuConfiguration.Click += new System.EventHandler(this.menuConfiguration_Click);
            // 
            // menuAide
            // 
            this.menuAide.Name = "menuAide";
            this.menuAide.Size = new System.Drawing.Size(40, 20);
            this.menuAide.Text = "Aide";
            this.menuAide.Click += new System.EventHandler(this.menuAide_Click);
            // 
            // menuQuitter
            // 
            this.menuQuitter.Name = "menuQuitter";
            this.menuQuitter.Size = new System.Drawing.Size(53, 20);
            this.menuQuitter.Text = "Quitter";
            this.menuQuitter.Click += new System.EventHandler(this.menuQuitter_Click);
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(744, 518);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPause);
            this.Controls.Add(this.pboxEngin);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(750, 550);
            this.Name = "frmConsole";
            this.Text = "Project Lunar Lander";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmConsole_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsole_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pboxEngin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxEngin;
        private System.Windows.Forms.Timer tmrFrame;
        private System.Windows.Forms.Timer tmrExplosion;
        private System.Windows.Forms.Timer tmrAtterissage;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblVy;
        private System.Windows.Forms.Label lblVx;
        private System.Windows.Forms.Label lblFuel;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblYmax;
        private System.Windows.Forms.Label lblXmax;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguration;
        private System.Windows.Forms.ToolStripMenuItem menuAide;
        private System.Windows.Forms.ToolStripMenuItem menuQuitter;

    }
}

