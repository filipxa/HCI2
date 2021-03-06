﻿namespace RacunarskiCentar
{
    partial class PredmetForm
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
            this.labelNaziv = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxNaziv = new System.Windows.Forms.TextBox();
            this.labelOpis = new System.Windows.Forms.Label();
            this.labelBrojLjudi = new System.Windows.Forms.Label();
            this.labelDuzinaTermina = new System.Windows.Forms.Label();
            this.labelBrojTermina = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSacuvaj = new System.Windows.Forms.Button();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.numericUpDownBrojLjudi = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDuzinaTermina = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBrojTermina = new System.Windows.Forms.NumericUpDown();
            this.labelSmer = new System.Windows.Forms.Label();
            this.comboBoxSmer = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.richTextBoxOpis = new System.Windows.Forms.RichTextBox();
            this.checkedListBoxSoftvera = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrojLjudi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuzinaTermina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrojTermina)).BeginInit();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(24, 24);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID";
            this.toolTip1.SetToolTip(this.labelID, "Jedinstveno obelezje predemta.");
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Location = new System.Drawing.Point(192, 24);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(81, 13);
            this.labelNaziv.TabIndex = 1;
            this.labelNaziv.Text = "Naziv predmeta";
            this.toolTip1.SetToolTip(this.labelNaziv, "Naziv predmeta.");
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(27, 41);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(146, 20);
            this.textBoxID.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBoxID, "Jedinstveno obelezje predemta.");
            this.textBoxID.Validated += new System.EventHandler(this.textBoxID_Validated);
            // 
            // textBoxNaziv
            // 
            this.textBoxNaziv.Location = new System.Drawing.Point(195, 40);
            this.textBoxNaziv.Name = "textBoxNaziv";
            this.textBoxNaziv.Size = new System.Drawing.Size(146, 20);
            this.textBoxNaziv.TabIndex = 4;
            this.toolTip1.SetToolTip(this.textBoxNaziv, "Naziv predmeta.");
            // 
            // labelOpis
            // 
            this.labelOpis.AutoSize = true;
            this.labelOpis.Location = new System.Drawing.Point(28, 174);
            this.labelOpis.Name = "labelOpis";
            this.labelOpis.Size = new System.Drawing.Size(75, 13);
            this.labelOpis.TabIndex = 5;
            this.labelOpis.Text = "Opis predmeta";
            // 
            // labelBrojLjudi
            // 
            this.labelBrojLjudi.AutoSize = true;
            this.labelBrojLjudi.Location = new System.Drawing.Point(192, 122);
            this.labelBrojLjudi.Name = "labelBrojLjudi";
            this.labelBrojLjudi.Size = new System.Drawing.Size(46, 13);
            this.labelBrojLjudi.TabIndex = 6;
            this.labelBrojLjudi.Text = "Broj ljudi";
            // 
            // labelDuzinaTermina
            // 
            this.labelDuzinaTermina.AutoSize = true;
            this.labelDuzinaTermina.Location = new System.Drawing.Point(192, 74);
            this.labelDuzinaTermina.Name = "labelDuzinaTermina";
            this.labelDuzinaTermina.Size = new System.Drawing.Size(164, 13);
            this.labelDuzinaTermina.TabIndex = 8;
            this.labelDuzinaTermina.Text = "Minimalan broj časova po terminu";
            // 
            // labelBrojTermina
            // 
            this.labelBrojTermina.AutoSize = true;
            this.labelBrojTermina.Location = new System.Drawing.Point(24, 124);
            this.labelBrojTermina.Name = "labelBrojTermina";
            this.labelBrojTermina.Size = new System.Drawing.Size(62, 13);
            this.labelBrojTermina.TabIndex = 10;
            this.labelBrojTermina.Text = "Broj termina";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(27, 236);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(146, 169);
            this.checkedListBox1.TabIndex = 12;
            this.toolTip1.SetToolTip(this.checkedListBox1, "Lista neophodne opreme na predmetu.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Neophodna oprema";
            // 
            // buttonSacuvaj
            // 
            this.buttonSacuvaj.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSacuvaj.Location = new System.Drawing.Point(280, 424);
            this.buttonSacuvaj.Name = "buttonSacuvaj";
            this.buttonSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.buttonSacuvaj.TabIndex = 15;
            this.buttonSacuvaj.Text = "Sacuvaj";
            this.toolTip1.SetToolTip(this.buttonSacuvaj, "Sacuvaj podatke i zatvori.");
            this.buttonSacuvaj.UseVisualStyleBackColor = true;
            this.buttonSacuvaj.Click += new System.EventHandler(this.buttonSacuvaj_Click);
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOdustani.Location = new System.Drawing.Point(181, 424);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(75, 23);
            this.buttonOdustani.TabIndex = 16;
            this.buttonOdustani.Text = "Odustani";
            this.toolTip1.SetToolTip(this.buttonOdustani, "Zatvori formu bez cuvanja.");
            this.buttonOdustani.UseVisualStyleBackColor = true;
            // 
            // numericUpDownBrojLjudi
            // 
            this.numericUpDownBrojLjudi.Location = new System.Drawing.Point(195, 141);
            this.numericUpDownBrojLjudi.Name = "numericUpDownBrojLjudi";
            this.numericUpDownBrojLjudi.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownBrojLjudi.TabIndex = 17;
            this.toolTip1.SetToolTip(this.numericUpDownBrojLjudi, "Broj ljudi koji slusa predmet.");
            this.numericUpDownBrojLjudi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownDuzinaTermina
            // 
            this.numericUpDownDuzinaTermina.Location = new System.Drawing.Point(195, 95);
            this.numericUpDownDuzinaTermina.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownDuzinaTermina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDuzinaTermina.Name = "numericUpDownDuzinaTermina";
            this.numericUpDownDuzinaTermina.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownDuzinaTermina.TabIndex = 18;
            this.numericUpDownDuzinaTermina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownBrojTermina
            // 
            this.numericUpDownBrojTermina.Location = new System.Drawing.Point(27, 145);
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
            this.numericUpDownBrojTermina.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownBrojTermina.TabIndex = 19;
            this.numericUpDownBrojTermina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelSmer
            // 
            this.labelSmer.AutoSize = true;
            this.labelSmer.Location = new System.Drawing.Point(24, 74);
            this.labelSmer.Name = "labelSmer";
            this.labelSmer.Size = new System.Drawing.Size(31, 13);
            this.labelSmer.TabIndex = 20;
            this.labelSmer.Text = "Smer";
            this.toolTip1.SetToolTip(this.labelSmer, "Smer.");
            // 
            // comboBoxSmer
            // 
            this.comboBoxSmer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSmer.FormattingEnabled = true;
            this.comboBoxSmer.Location = new System.Drawing.Point(27, 95);
            this.comboBoxSmer.Name = "comboBoxSmer";
            this.comboBoxSmer.Size = new System.Drawing.Size(146, 21);
            this.comboBoxSmer.TabIndex = 21;
            this.toolTip1.SetToolTip(this.comboBoxSmer, "Spisak smerova.");
            // 
            // richTextBoxOpis
            // 
            this.richTextBoxOpis.Location = new System.Drawing.Point(27, 190);
            this.richTextBoxOpis.Name = "richTextBoxOpis";
            this.richTextBoxOpis.Size = new System.Drawing.Size(146, 20);
            this.richTextBoxOpis.TabIndex = 14;
            this.richTextBoxOpis.Text = "";
            this.toolTip1.SetToolTip(this.richTextBoxOpis, "Detaljniji opis predmeta.");
            // 
            // checkedListBoxSoftvera
            // 
            this.checkedListBoxSoftvera.FormattingEnabled = true;
            this.checkedListBoxSoftvera.Location = new System.Drawing.Point(195, 236);
            this.checkedListBoxSoftvera.Name = "checkedListBoxSoftvera";
            this.checkedListBoxSoftvera.Size = new System.Drawing.Size(146, 169);
            this.checkedListBoxSoftvera.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Neophodan softver";
            // 
            // PredmetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 459);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBoxSoftvera);
            this.Controls.Add(this.comboBoxSmer);
            this.Controls.Add(this.labelSmer);
            this.Controls.Add(this.numericUpDownBrojTermina);
            this.Controls.Add(this.numericUpDownDuzinaTermina);
            this.Controls.Add(this.numericUpDownBrojLjudi);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.buttonSacuvaj);
            this.Controls.Add(this.richTextBoxOpis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.labelBrojTermina);
            this.Controls.Add(this.labelDuzinaTermina);
            this.Controls.Add(this.labelBrojLjudi);
            this.Controls.Add(this.labelOpis);
            this.Controls.Add(this.textBoxNaziv);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelNaziv);
            this.Controls.Add(this.labelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PredmetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Predmet";
            this.Load += new System.EventHandler(this.PredmetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrojLjudi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuzinaTermina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrojTermina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxNaziv;
        private System.Windows.Forms.Label labelOpis;
        private System.Windows.Forms.Label labelBrojLjudi;
        private System.Windows.Forms.Label labelDuzinaTermina;
        private System.Windows.Forms.Label labelBrojTermina;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSacuvaj;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.NumericUpDown numericUpDownBrojLjudi;
        private System.Windows.Forms.NumericUpDown numericUpDownDuzinaTermina;
        private System.Windows.Forms.NumericUpDown numericUpDownBrojTermina;
        private System.Windows.Forms.Label labelSmer;
        private System.Windows.Forms.ComboBox comboBoxSmer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RichTextBox richTextBoxOpis;
        private System.Windows.Forms.CheckedListBox checkedListBoxSoftvera;
        private System.Windows.Forms.Label label2;
    }
}