namespace RacunarskiCentar
{
    partial class SoftwareFilterForm
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
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelIme = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxProizvodjac = new System.Windows.Forms.TextBox();
            this.labelProizvodjac = new System.Windows.Forms.Label();
            this.textBoxCena = new System.Windows.Forms.TextBox();
            this.labelCena = new System.Windows.Forms.Label();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.buttonSacuvaj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxIme
            // 
            this.textBoxIme.Location = new System.Drawing.Point(30, 78);
            this.textBoxIme.Name = "textBoxIme";
            this.textBoxIme.Size = new System.Drawing.Size(220, 20);
            this.textBoxIme.TabIndex = 12;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(30, 34);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(220, 20);
            this.textBoxID.TabIndex = 11;
            // 
            // labelIme
            // 
            this.labelIme.AutoSize = true;
            this.labelIme.Location = new System.Drawing.Point(27, 62);
            this.labelIme.Name = "labelIme";
            this.labelIme.Size = new System.Drawing.Size(34, 13);
            this.labelIme.TabIndex = 10;
            this.labelIme.Text = "Naziv";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(27, 18);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 9;
            this.labelID.Text = "ID";
            // 
            // textBoxProizvodjac
            // 
            this.textBoxProizvodjac.Location = new System.Drawing.Point(30, 121);
            this.textBoxProizvodjac.Name = "textBoxProizvodjac";
            this.textBoxProizvodjac.Size = new System.Drawing.Size(220, 20);
            this.textBoxProizvodjac.TabIndex = 14;
            // 
            // labelProizvodjac
            // 
            this.labelProizvodjac.AutoSize = true;
            this.labelProizvodjac.Location = new System.Drawing.Point(27, 104);
            this.labelProizvodjac.Name = "labelProizvodjac";
            this.labelProizvodjac.Size = new System.Drawing.Size(62, 13);
            this.labelProizvodjac.TabIndex = 13;
            this.labelProizvodjac.Text = "Proizvodjac";
            // 
            // textBoxCena
            // 
            this.textBoxCena.Location = new System.Drawing.Point(32, 161);
            this.textBoxCena.Name = "textBoxCena";
            this.textBoxCena.Size = new System.Drawing.Size(220, 20);
            this.textBoxCena.TabIndex = 16;
            // 
            // labelCena
            // 
            this.labelCena.AutoSize = true;
            this.labelCena.Location = new System.Drawing.Point(29, 144);
            this.labelCena.Name = "labelCena";
            this.labelCena.Size = new System.Drawing.Size(32, 13);
            this.labelCena.TabIndex = 15;
            this.labelCena.Text = "Cena";
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonOdustani.Location = new System.Drawing.Point(32, 209);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(75, 23);
            this.buttonOdustani.TabIndex = 18;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            // 
            // buttonSacuvaj
            // 
            this.buttonSacuvaj.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSacuvaj.Location = new System.Drawing.Point(177, 209);
            this.buttonSacuvaj.Name = "buttonSacuvaj";
            this.buttonSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.buttonSacuvaj.TabIndex = 17;
            this.buttonSacuvaj.Text = "Sacuvaj";
            this.buttonSacuvaj.UseVisualStyleBackColor = true;
            this.buttonSacuvaj.Click += new System.EventHandler(this.buttonSacuvaj_Click);
            // 
            // SoftwareFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.buttonSacuvaj);
            this.Controls.Add(this.textBoxCena);
            this.Controls.Add(this.labelCena);
            this.Controls.Add(this.textBoxProizvodjac);
            this.Controls.Add(this.labelProizvodjac);
            this.Controls.Add(this.textBoxIme);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelIme);
            this.Controls.Add(this.labelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoftwareFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoftwareFilterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIme;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelIme;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxProizvodjac;
        private System.Windows.Forms.Label labelProizvodjac;
        private System.Windows.Forms.TextBox textBoxCena;
        private System.Windows.Forms.Label labelCena;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.Button buttonSacuvaj;
    }
}