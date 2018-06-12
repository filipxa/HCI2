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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrRadnihMesta)).BeginInit();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(12, 20);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID";
            // 
            // labelBrRadnihMesta
            // 
            this.labelBrRadnihMesta.AutoSize = true;
            this.labelBrRadnihMesta.Location = new System.Drawing.Point(204, 23);
            this.labelBrRadnihMesta.Name = "labelBrRadnihMesta";
            this.labelBrRadnihMesta.Size = new System.Drawing.Size(88, 13);
            this.labelBrRadnihMesta.TabIndex = 1;
            this.labelBrRadnihMesta.Text = "Broj radnih mesta";
            // 
            // labelDodatnaOprema
            // 
            this.labelDodatnaOprema.AutoSize = true;
            this.labelDodatnaOprema.Location = new System.Drawing.Point(12, 74);
            this.labelDodatnaOprema.Name = "labelDodatnaOprema";
            this.labelDodatnaOprema.Size = new System.Drawing.Size(86, 13);
            this.labelDodatnaOprema.TabIndex = 2;
            this.labelDodatnaOprema.Text = "Dodatna oprema";
            // 
            // labelNeophodanSoftver
            // 
            this.labelNeophodanSoftver.AutoSize = true;
            this.labelNeophodanSoftver.Location = new System.Drawing.Point(204, 74);
            this.labelNeophodanSoftver.Name = "labelNeophodanSoftver";
            this.labelNeophodanSoftver.Size = new System.Drawing.Size(98, 13);
            this.labelNeophodanSoftver.TabIndex = 3;
            this.labelNeophodanSoftver.Text = "Neophodan softver";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(15, 39);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(162, 20);
            this.textBoxID.TabIndex = 4;
            // 
            // numericUpDownBrRadnihMesta
            // 
            this.numericUpDownBrRadnihMesta.Location = new System.Drawing.Point(207, 40);
            this.numericUpDownBrRadnihMesta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBrRadnihMesta.Name = "numericUpDownBrRadnihMesta";
            this.numericUpDownBrRadnihMesta.Size = new System.Drawing.Size(85, 20);
            this.numericUpDownBrRadnihMesta.TabIndex = 5;
            this.numericUpDownBrRadnihMesta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(15, 93);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(162, 184);
            this.checkedListBox1.TabIndex = 6;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(207, 93);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(168, 184);
            this.checkedListBox2.TabIndex = 7;
            // 
            // buttonPotvrdi
            // 
            this.buttonPotvrdi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonPotvrdi.Location = new System.Drawing.Point(300, 304);
            this.buttonPotvrdi.Name = "buttonPotvrdi";
            this.buttonPotvrdi.Size = new System.Drawing.Size(75, 23);
            this.buttonPotvrdi.TabIndex = 8;
            this.buttonPotvrdi.Text = "Potvrdi";
            this.buttonPotvrdi.UseVisualStyleBackColor = true;
            this.buttonPotvrdi.Click += new System.EventHandler(this.buttonPotvrdi_Click);
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOdustani.Location = new System.Drawing.Point(207, 304);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(75, 23);
            this.buttonOdustani.TabIndex = 9;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            // 
            // UcionicaFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 359);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UcionicaFilterForm";
            this.Text = "UcionicaFilterForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrRadnihMesta)).EndInit();
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
    }
}