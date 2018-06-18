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
            this.components = new System.ComponentModel.Container();
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelIme = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxProizvodjac = new System.Windows.Forms.TextBox();
            this.labelProizvodjac = new System.Windows.Forms.Label();
            this.labelCena = new System.Windows.Forms.Label();
            this.buttonOrisi = new System.Windows.Forms.Button();
            this.buttonSacuvaj = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonIzmena = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxIme
            // 
            this.textBoxIme.Location = new System.Drawing.Point(30, 98);
            this.textBoxIme.Name = "textBoxIme";
            this.textBoxIme.Size = new System.Drawing.Size(220, 20);
            this.textBoxIme.TabIndex = 12;
            this.toolTip1.SetToolTip(this.textBoxIme, "Naziv softvera.");
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(30, 54);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(220, 20);
            this.textBoxID.TabIndex = 11;
            this.toolTip1.SetToolTip(this.textBoxID, "Jedinstveno obelezje softvera.");
            // 
            // labelIme
            // 
            this.labelIme.AutoSize = true;
            this.labelIme.Location = new System.Drawing.Point(27, 82);
            this.labelIme.Name = "labelIme";
            this.labelIme.Size = new System.Drawing.Size(37, 13);
            this.labelIme.TabIndex = 10;
            this.labelIme.Text = "Naziv:";
            this.toolTip1.SetToolTip(this.labelIme, "Naziv softvera.");
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(27, 38);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 13);
            this.labelID.TabIndex = 9;
            this.labelID.Text = "ID:";
            this.toolTip1.SetToolTip(this.labelID, "Jedinstveno obelezje softvera.");
            // 
            // textBoxProizvodjac
            // 
            this.textBoxProizvodjac.Location = new System.Drawing.Point(30, 141);
            this.textBoxProizvodjac.Name = "textBoxProizvodjac";
            this.textBoxProizvodjac.Size = new System.Drawing.Size(220, 20);
            this.textBoxProizvodjac.TabIndex = 14;
            this.toolTip1.SetToolTip(this.textBoxProizvodjac, "Proizvodjac softvera.");
            // 
            // labelProizvodjac
            // 
            this.labelProizvodjac.AutoSize = true;
            this.labelProizvodjac.Location = new System.Drawing.Point(27, 124);
            this.labelProizvodjac.Name = "labelProizvodjac";
            this.labelProizvodjac.Size = new System.Drawing.Size(65, 13);
            this.labelProizvodjac.TabIndex = 13;
            this.labelProizvodjac.Text = "Proizvodjac:";
            this.toolTip1.SetToolTip(this.labelProizvodjac, "Proizvodjac softvera.");
            // 
            // labelCena
            // 
            this.labelCena.AutoSize = true;
            this.labelCena.Location = new System.Drawing.Point(29, 164);
            this.labelCena.Name = "labelCena";
            this.labelCena.Size = new System.Drawing.Size(77, 13);
            this.labelCena.TabIndex = 15;
            this.labelCena.Text = "Cena veca od:";
            // 
            // buttonOrisi
            // 
            this.buttonOrisi.Location = new System.Drawing.Point(32, 256);
            this.buttonOrisi.Name = "buttonOrisi";
            this.buttonOrisi.Size = new System.Drawing.Size(75, 23);
            this.buttonOrisi.TabIndex = 18;
            this.buttonOrisi.Text = "Obrisi";
            this.toolTip1.SetToolTip(this.buttonOrisi, "Obrisi softver.");
            this.buttonOrisi.UseVisualStyleBackColor = true;
            this.buttonOrisi.Click += new System.EventHandler(this.buttonOrisi_Click);
            // 
            // buttonSacuvaj
            // 
            this.buttonSacuvaj.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSacuvaj.Location = new System.Drawing.Point(30, 216);
            this.buttonSacuvaj.Name = "buttonSacuvaj";
            this.buttonSacuvaj.Size = new System.Drawing.Size(90, 23);
            this.buttonSacuvaj.TabIndex = 17;
            this.buttonSacuvaj.Text = "Dodaj softver";
            this.toolTip1.SetToolTip(this.buttonSacuvaj, "Dodaj softver.");
            this.buttonSacuvaj.UseVisualStyleBackColor = true;
            this.buttonSacuvaj.Click += new System.EventHandler(this.buttonSacuvaj_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(258, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(725, 596);
            this.dataGridView1.TabIndex = 19;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(30, 180);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(220, 20);
            this.numericUpDown1.TabIndex = 20;
            // 
            // buttonIzmena
            // 
            this.buttonIzmena.Location = new System.Drawing.Point(132, 216);
            this.buttonIzmena.Name = "buttonIzmena";
            this.buttonIzmena.Size = new System.Drawing.Size(75, 23);
            this.buttonIzmena.TabIndex = 21;
            this.buttonIzmena.Text = "Izmena";
            this.toolTip1.SetToolTip(this.buttonIzmena, "Izmeni softver.");
            this.buttonIzmena.UseVisualStyleBackColor = true;
            this.buttonIzmena.Click += new System.EventHandler(this.buttonIzmena_Click);
            // 
            // SoftwareFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 648);
            this.Controls.Add(this.buttonIzmena);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonOrisi);
            this.Controls.Add(this.buttonSacuvaj);
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
            this.Text = "Softveri obrada";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.Label labelCena;
        private System.Windows.Forms.Button buttonOrisi;
        private System.Windows.Forms.Button buttonSacuvaj;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonIzmena;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}