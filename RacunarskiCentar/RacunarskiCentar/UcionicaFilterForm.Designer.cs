namespace RacunarskiCentar
{
    partial class UcionicaFilterForm
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
            this.labelBrRadnihMesta = new System.Windows.Forms.Label();
            this.labelDodatnaOprema = new System.Windows.Forms.Label();
            this.labelNeophodanSoftver = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.numericUpDownBrRadnihMesta = new System.Windows.Forms.NumericUpDown();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.buttonPotvrdi = new System.Windows.Forms.Button();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonIzmeni = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrRadnihMesta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(11, 30);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID";
            this.toolTip1.SetToolTip(this.labelID, "Jedinstveno obelezje ucionice");
            // 
            // labelBrRadnihMesta
            // 
            this.labelBrRadnihMesta.AutoSize = true;
            this.labelBrRadnihMesta.Location = new System.Drawing.Point(203, 33);
            this.labelBrRadnihMesta.Name = "labelBrRadnihMesta";
            this.labelBrRadnihMesta.Size = new System.Drawing.Size(88, 13);
            this.labelBrRadnihMesta.TabIndex = 1;
            this.labelBrRadnihMesta.Text = "Broj radnih mesta";
            // 
            // labelDodatnaOprema
            // 
            this.labelDodatnaOprema.AutoSize = true;
            this.labelDodatnaOprema.Location = new System.Drawing.Point(11, 84);
            this.labelDodatnaOprema.Name = "labelDodatnaOprema";
            this.labelDodatnaOprema.Size = new System.Drawing.Size(86, 13);
            this.labelDodatnaOprema.TabIndex = 2;
            this.labelDodatnaOprema.Text = "Dodatna oprema";
            // 
            // labelNeophodanSoftver
            // 
            this.labelNeophodanSoftver.AutoSize = true;
            this.labelNeophodanSoftver.Location = new System.Drawing.Point(203, 84);
            this.labelNeophodanSoftver.Name = "labelNeophodanSoftver";
            this.labelNeophodanSoftver.Size = new System.Drawing.Size(98, 13);
            this.labelNeophodanSoftver.TabIndex = 3;
            this.labelNeophodanSoftver.Text = "Neophodan softver";
            this.toolTip1.SetToolTip(this.labelNeophodanSoftver, "Neophodan softver u ucionici.");
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(14, 49);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(162, 20);
            this.textBoxID.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBoxID, "Jedinstveno obelezje ucionice");
            // 
            // numericUpDownBrRadnihMesta
            // 
            this.numericUpDownBrRadnihMesta.Location = new System.Drawing.Point(206, 50);
            this.numericUpDownBrRadnihMesta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBrRadnihMesta.Name = "numericUpDownBrRadnihMesta";
            this.numericUpDownBrRadnihMesta.Size = new System.Drawing.Size(85, 20);
            this.numericUpDownBrRadnihMesta.TabIndex = 5;
            this.toolTip1.SetToolTip(this.numericUpDownBrRadnihMesta, "Broj radnih mesta.");
            this.numericUpDownBrRadnihMesta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(14, 103);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(162, 184);
            this.checkedListBox1.TabIndex = 6;
            this.toolTip1.SetToolTip(this.checkedListBox1, "Lista opreme u ucionici.");
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(206, 103);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(168, 184);
            this.checkedListBox2.TabIndex = 7;
            this.toolTip1.SetToolTip(this.checkedListBox2, "Neophodan softver u ucionici.");
            // 
            // buttonPotvrdi
            // 
            this.buttonPotvrdi.Location = new System.Drawing.Point(249, 314);
            this.buttonPotvrdi.Name = "buttonPotvrdi";
            this.buttonPotvrdi.Size = new System.Drawing.Size(90, 23);
            this.buttonPotvrdi.TabIndex = 8;
            this.buttonPotvrdi.Text = "Dodaj učionicu";
            this.toolTip1.SetToolTip(this.buttonPotvrdi, "Dodaj ucionicu.");
            this.buttonPotvrdi.UseVisualStyleBackColor = true;
            this.buttonPotvrdi.Click += new System.EventHandler(this.buttonPotvrdi_Click);
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.Location = new System.Drawing.Point(149, 314);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(90, 23);
            this.buttonOdustani.TabIndex = 9;
            this.buttonOdustani.Text = "Obriši";
            this.toolTip1.SetToolTip(this.buttonOdustani, "Obrisi ucionicu.");
            this.buttonOdustani.UseVisualStyleBackColor = true;
            this.buttonOdustani.Click += new System.EventHandler(this.buttonObrisi_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(380, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(329, 575);
            this.dataGridView1.TabIndex = 10;
            // 
            // buttonIzmeni
            // 
            this.buttonIzmeni.Location = new System.Drawing.Point(21, 313);
            this.buttonIzmeni.Name = "buttonIzmeni";
            this.buttonIzmeni.Size = new System.Drawing.Size(75, 23);
            this.buttonIzmeni.TabIndex = 11;
            this.buttonIzmeni.Text = "Izmeni";
            this.toolTip1.SetToolTip(this.buttonIzmeni, "Izmeni ucionicu.");
            this.buttonIzmeni.UseVisualStyleBackColor = true;
            this.buttonIzmeni.Click += new System.EventHandler(this.buttonIzmeni_Click);
            // 
            // UcionicaFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 637);
            this.Controls.Add(this.buttonIzmeni);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.buttonPotvrdi);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.numericUpDownBrRadnihMesta);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelNeophodanSoftver);
            this.Controls.Add(this.labelDodatnaOprema);
            this.Controls.Add(this.labelBrRadnihMesta);
            this.Controls.Add(this.labelID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UcionicaFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Učionice";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrRadnihMesta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelBrRadnihMesta;
        private System.Windows.Forms.Label labelDodatnaOprema;
        private System.Windows.Forms.Label labelNeophodanSoftver;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.NumericUpDown numericUpDownBrRadnihMesta;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button buttonPotvrdi;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonIzmeni;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}