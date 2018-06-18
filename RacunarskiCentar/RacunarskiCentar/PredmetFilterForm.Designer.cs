namespace RacunarskiCentar
{
    partial class PredmetFilterForm
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
            this.numericUpDownBrojTermina = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDuzinaTermina = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBrojLjudi = new System.Windows.Forms.NumericUpDown();
            this.labelBrojTermina = new System.Windows.Forms.Label();
            this.labelDuzinaTermina = new System.Windows.Forms.Label();
            this.labelBrojLjudi = new System.Windows.Forms.Label();
            this.textBoxNaziv = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.labelNaziv = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonPotvrdi = new System.Windows.Forms.Button();
            this.buttonObrisi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxSmer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Izmeni = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrojTermina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuzinaTermina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrojLjudi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownBrojTermina
            // 
            this.numericUpDownBrojTermina.Location = new System.Drawing.Point(18, 251);
            this.numericUpDownBrojTermina.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownBrojTermina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBrojTermina.Name = "numericUpDownBrojTermina";
            this.numericUpDownBrojTermina.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownBrojTermina.TabIndex = 31;
            this.numericUpDownBrojTermina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownDuzinaTermina
            // 
            this.numericUpDownDuzinaTermina.Location = new System.Drawing.Point(18, 212);
            this.numericUpDownDuzinaTermina.Maximum = new decimal(new int[] {
            270,
            0,
            0,
            0});
            this.numericUpDownDuzinaTermina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDuzinaTermina.Name = "numericUpDownDuzinaTermina";
            this.numericUpDownDuzinaTermina.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownDuzinaTermina.TabIndex = 30;
            this.numericUpDownDuzinaTermina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownBrojLjudi
            // 
            this.numericUpDownBrojLjudi.Location = new System.Drawing.Point(18, 173);
            this.numericUpDownBrojLjudi.Name = "numericUpDownBrojLjudi";
            this.numericUpDownBrojLjudi.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownBrojLjudi.TabIndex = 29;
            this.toolTip1.SetToolTip(this.numericUpDownBrojLjudi, "Broj ljudi koji prisustvuje predavanju.");
            this.numericUpDownBrojLjudi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelBrojTermina
            // 
            this.labelBrojTermina.AutoSize = true;
            this.labelBrojTermina.Location = new System.Drawing.Point(15, 235);
            this.labelBrojTermina.Name = "labelBrojTermina";
            this.labelBrojTermina.Size = new System.Drawing.Size(62, 13);
            this.labelBrojTermina.TabIndex = 28;
            this.labelBrojTermina.Text = "Broj termina";
            // 
            // labelDuzinaTermina
            // 
            this.labelDuzinaTermina.AutoSize = true;
            this.labelDuzinaTermina.Location = new System.Drawing.Point(15, 196);
            this.labelDuzinaTermina.Name = "labelDuzinaTermina";
            this.labelDuzinaTermina.Size = new System.Drawing.Size(165, 13);
            this.labelDuzinaTermina.TabIndex = 27;
            this.labelDuzinaTermina.Text = "Duzina jednog termina u minutima";
            // 
            // labelBrojLjudi
            // 
            this.labelBrojLjudi.AutoSize = true;
            this.labelBrojLjudi.Location = new System.Drawing.Point(15, 157);
            this.labelBrojLjudi.Name = "labelBrojLjudi";
            this.labelBrojLjudi.Size = new System.Drawing.Size(46, 13);
            this.labelBrojLjudi.TabIndex = 26;
            this.labelBrojLjudi.Text = "Broj ljudi";
            // 
            // textBoxNaziv
            // 
            this.textBoxNaziv.Location = new System.Drawing.Point(18, 95);
            this.textBoxNaziv.Name = "textBoxNaziv";
            this.textBoxNaziv.Size = new System.Drawing.Size(156, 20);
            this.textBoxNaziv.TabIndex = 25;
            this.toolTip1.SetToolTip(this.textBoxNaziv, "Naziv predmeta.");
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(18, 56);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(156, 20);
            this.textBoxID.TabIndex = 24;
            this.toolTip1.SetToolTip(this.textBoxID, "Jedinstveno obelezje predmeta.");
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Location = new System.Drawing.Point(15, 79);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(81, 13);
            this.labelNaziv.TabIndex = 23;
            this.labelNaziv.Text = "Naziv predmeta";
            this.toolTip1.SetToolTip(this.labelNaziv, "Naziv predmeta.");
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(15, 39);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 22;
            this.labelID.Text = "ID";
            this.toolTip1.SetToolTip(this.labelID, "Jedinstveno obelezje predmeta.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Neophodna oprema";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(197, 56);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(174, 229);
            this.checkedListBox1.TabIndex = 32;
            this.toolTip1.SetToolTip(this.checkedListBox1, "Lista neophodne opreme na predmetu.");
            // 
            // buttonPotvrdi
            // 
            this.buttonPotvrdi.Location = new System.Drawing.Point(281, 314);
            this.buttonPotvrdi.Name = "buttonPotvrdi";
            this.buttonPotvrdi.Size = new System.Drawing.Size(90, 23);
            this.buttonPotvrdi.TabIndex = 22;
            this.buttonPotvrdi.Text = "Dodaj predemt";
            this.toolTip1.SetToolTip(this.buttonPotvrdi, "Dodaj predmet.");
            this.buttonPotvrdi.UseVisualStyleBackColor = true;
            this.buttonPotvrdi.Click += new System.EventHandler(this.buttonPotvrdi_Click);
            // 
            // buttonObrisi
            // 
            this.buttonObrisi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonObrisi.Location = new System.Drawing.Point(197, 314);
            this.buttonObrisi.Name = "buttonObrisi";
            this.buttonObrisi.Size = new System.Drawing.Size(75, 23);
            this.buttonObrisi.TabIndex = 34;
            this.buttonObrisi.Text = "Obrisi";
            this.toolTip1.SetToolTip(this.buttonObrisi, "Obrisi.");
            this.buttonObrisi.UseVisualStyleBackColor = true;
            this.buttonObrisi.Click += new System.EventHandler(this.buttonObrisi_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(377, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(742, 561);
            this.dataGridView1.TabIndex = 35;
            // 
            // textBoxSmer
            // 
            this.textBoxSmer.Location = new System.Drawing.Point(18, 134);
            this.textBoxSmer.Name = "textBoxSmer";
            this.textBoxSmer.Size = new System.Drawing.Size(156, 20);
            this.textBoxSmer.TabIndex = 36;
            this.toolTip1.SetToolTip(this.textBoxSmer, "Jedinstveno obelezje smera.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Smer ID";
            // 
            // Izmeni
            // 
            this.Izmeni.Location = new System.Drawing.Point(110, 314);
            this.Izmeni.Name = "Izmeni";
            this.Izmeni.Size = new System.Drawing.Size(75, 23);
            this.Izmeni.TabIndex = 38;
            this.Izmeni.Text = "Izmeni";
            this.toolTip1.SetToolTip(this.Izmeni, "Izmeni.");
            this.Izmeni.UseVisualStyleBackColor = true;
            this.Izmeni.Click += new System.EventHandler(this.Izmeni_Click);
            // 
            // PredmetFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 614);
            this.Controls.Add(this.Izmeni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSmer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonObrisi);
            this.Controls.Add(this.buttonPotvrdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.numericUpDownBrojTermina);
            this.Controls.Add(this.numericUpDownDuzinaTermina);
            this.Controls.Add(this.numericUpDownBrojLjudi);
            this.Controls.Add(this.labelBrojTermina);
            this.Controls.Add(this.labelDuzinaTermina);
            this.Controls.Add(this.labelBrojLjudi);
            this.Controls.Add(this.textBoxNaziv);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelNaziv);
            this.Controls.Add(this.labelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PredmetFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Predmeti obrada";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrojTermina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuzinaTermina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrojLjudi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDownBrojTermina;
        private System.Windows.Forms.NumericUpDown numericUpDownDuzinaTermina;
        private System.Windows.Forms.NumericUpDown numericUpDownBrojLjudi;
        private System.Windows.Forms.Label labelBrojTermina;
        private System.Windows.Forms.Label labelDuzinaTermina;
        private System.Windows.Forms.Label labelBrojLjudi;
        private System.Windows.Forms.TextBox textBoxNaziv;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonPotvrdi;
        private System.Windows.Forms.Button buttonObrisi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxSmer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Izmeni;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}