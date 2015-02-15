namespace ProjectLunarLander
{
    partial class frmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbG = new System.Windows.Forms.TrackBar();
            this.tbY = new System.Windows.Forms.TrackBar();
            this.tbX = new System.Windows.Forms.TrackBar();
            this.tbFuel = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbFuelMax = new System.Windows.Forms.ComboBox();
            this.lblG = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblFuel = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFuel)).BeginInit();
            this.SuspendLayout();
            // 
            // tbG
            // 
            this.tbG.Location = new System.Drawing.Point(13, 26);
            this.tbG.Maximum = 66;
            this.tbG.Name = "tbG";
            this.tbG.Size = new System.Drawing.Size(479, 45);
            this.tbG.TabIndex = 0;
            this.tbG.Scroll += new System.EventHandler(this.tbG_Scroll);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(13, 148);
            this.tbY.Maximum = 66;
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(479, 45);
            this.tbY.TabIndex = 1;
            this.tbY.Scroll += new System.EventHandler(this.tbY_Scroll);
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(13, 88);
            this.tbX.Maximum = 66;
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(479, 45);
            this.tbX.TabIndex = 2;
            this.tbX.Scroll += new System.EventHandler(this.tbX_Scroll);
            // 
            // tbFuel
            // 
            this.tbFuel.Location = new System.Drawing.Point(13, 211);
            this.tbFuel.Maximum = 20;
            this.tbFuel.Name = "tbFuel";
            this.tbFuel.Size = new System.Drawing.Size(479, 45);
            this.tbFuel.TabIndex = 3;
            this.tbFuel.Scroll += new System.EventHandler(this.tbFuel_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ajustement de la gravité";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ajustement de la poussée horizontale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ajustement de la poussée verticale";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ajustement du taux de consommation de carburant";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Capacité du réservoir de carburant";
            // 
            // cbFuelMax
            // 
            this.cbFuelMax.DisplayMember = "5000";
            this.cbFuelMax.FormattingEnabled = true;
            this.cbFuelMax.Items.AddRange(new object[] {
            "1000",
            "1500",
            "3000",
            "5000",
            "7500",
            "10000"});
            this.cbFuelMax.Location = new System.Drawing.Point(186, 265);
            this.cbFuelMax.Name = "cbFuelMax";
            this.cbFuelMax.Size = new System.Drawing.Size(135, 21);
            this.cbFuelMax.TabIndex = 9;
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Location = new System.Drawing.Point(498, 26);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(0, 13);
            this.lblG.TabIndex = 10;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(498, 88);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(0, 13);
            this.lblX.TabIndex = 11;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(498, 148);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(0, 13);
            this.lblY.TabIndex = 12;
            // 
            // lblFuel
            // 
            this.lblFuel.AutoSize = true;
            this.lblFuel.Location = new System.Drawing.Point(498, 211);
            this.lblFuel.Name = "lblFuel";
            this.lblFuel.Size = new System.Drawing.Size(0, 13);
            this.lblFuel.TabIndex = 13;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(416, 255);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(68, 31);
            this.btnValider.TabIndex = 14;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(333, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 31);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 294);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.lblFuel);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblG);
            this.Controls.Add(this.cbFuelMax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFuel);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbG);
            this.Name = "frmConfig";
            this.Text = "Config";
            ((System.ComponentModel.ISupportInitialize)(this.tbG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFuel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbG;
        private System.Windows.Forms.TrackBar tbY;
        private System.Windows.Forms.TrackBar tbX;
        private System.Windows.Forms.TrackBar tbFuel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbFuelMax;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblFuel;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnCancel;
    }
}