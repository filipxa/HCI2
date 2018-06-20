namespace RacunarskiCentar
{
    partial class SmerFilterForm
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
            this.labelID = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.labelNaziv = new System.Windows.Forms.Label();
            this.buttonPotvrdi = new System.Windows.Forms.Button();
            this.buttonObrisi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonIzmena = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(13, 34);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID";
            this.toolTip1.SetToolTip(this.labelID, "Jedinstveno obelezje smera.");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 20);
            this.textBox1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox1, "Jedinstveno obelezje smera.");
            // 
            // textBoxIme
            // 
            this.textBoxIme.Location = new System.Drawing.Point(16, 100);
            this.textBoxIme.Name = "textBoxIme";
            this.textBoxIme.Size = new System.Drawing.Size(182, 20);
            this.textBoxIme.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxIme, "Naziv smera.");
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Location = new System.Drawing.Point(13, 84);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(34, 13);
            this.labelNaziv.TabIndex = 3;
            this.labelNaziv.Text = "Naziv";
            this.toolTip1.SetToolTip(this.labelNaziv, "Naziv smera.");
            // 
            // buttonPotvrdi
            // 
            this.buttonPotvrdi.Location = new System.Drawing.Point(100, 144);
            this.buttonPotvrdi.Name = "buttonPotvrdi";
            this.buttonPotvrdi.Size = new System.Drawing.Size(90, 23);
            this.buttonPotvrdi.TabIndex = 4;
            this.buttonPotvrdi.Text = "Dodaj smer";
            this.toolTip1.SetToolTip(this.buttonPotvrdi, "Dodaj smer.");
            this.buttonPotvrdi.UseVisualStyleBackColor = true;
            this.buttonPotvrdi.Click += new System.EventHandler(this.buttonPotvrdi_Click);
            // 
            // buttonObrisi
            // 
            this.buttonObrisi.Location = new System.Drawing.Point(19, 183);
            this.buttonObrisi.Name = "buttonObrisi";
            this.buttonObrisi.Size = new System.Drawing.Size(75, 23);
            this.buttonObrisi.TabIndex = 5;
            this.buttonObrisi.Text = "Obriši";
            this.toolTip1.SetToolTip(this.buttonObrisi, "Obrisi smer.");
            this.buttonObrisi.UseVisualStyleBackColor = true;
            this.buttonObrisi.Click += new System.EventHandler(this.buttonObrisi_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(205, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(446, 550);
            this.dataGridView1.TabIndex = 6;
            // 
            // buttonIzmena
            // 
            this.buttonIzmena.Location = new System.Drawing.Point(19, 144);
            this.buttonIzmena.Name = "buttonIzmena";
            this.buttonIzmena.Size = new System.Drawing.Size(75, 23);
            this.buttonIzmena.TabIndex = 7;
            this.buttonIzmena.Text = "Izmena";
            this.toolTip1.SetToolTip(this.buttonIzmena, "Izmeni smer.");
            this.buttonIzmena.UseVisualStyleBackColor = true;
            this.buttonIzmena.Click += new System.EventHandler(this.buttonIzmena_Click);
            // 
            // SmerFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 611);
            this.Controls.Add(this.buttonIzmena);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonObrisi);
            this.Controls.Add(this.buttonPotvrdi);
            this.Controls.Add(this.labelNaziv);
            this.Controls.Add(this.textBoxIme);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SmerFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smerovi";
            this.Load += new System.EventHandler(this.SmerFilterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxIme;
        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.Button buttonPotvrdi;
        private System.Windows.Forms.Button buttonObrisi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonIzmena;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}