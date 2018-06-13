namespace RacunarskiCentar
{
    partial class SmerForm
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
            this.labelIme = new System.Windows.Forms.Label();
            this.labelDatumUvodjenja = new System.Windows.Forms.Label();
            this.labelOpis = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonSacuvaj = new System.Windows.Forms.Button();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.richTextBoxOpis = new System.Windows.Forms.RichTextBox();
            this.labelPredmeti = new System.Windows.Forms.Label();
            this.listBoxPredmeti = new System.Windows.Forms.ListBox();
            this.buttonDodajPredmet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(21, 20);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID";
            // 
            // labelIme
            // 
            this.labelIme.AutoSize = true;
            this.labelIme.Location = new System.Drawing.Point(21, 67);
            this.labelIme.Name = "labelIme";
            this.labelIme.Size = new System.Drawing.Size(24, 13);
            this.labelIme.TabIndex = 1;
            this.labelIme.Text = "Ime";
            // 
            // labelDatumUvodjenja
            // 
            this.labelDatumUvodjenja.AutoSize = true;
            this.labelDatumUvodjenja.Location = new System.Drawing.Point(21, 116);
            this.labelDatumUvodjenja.Name = "labelDatumUvodjenja";
            this.labelDatumUvodjenja.Size = new System.Drawing.Size(87, 13);
            this.labelDatumUvodjenja.TabIndex = 2;
            this.labelDatumUvodjenja.Text = "Datum uvodjenja";
            // 
            // labelOpis
            // 
            this.labelOpis.AutoSize = true;
            this.labelOpis.Location = new System.Drawing.Point(21, 165);
            this.labelOpis.Name = "labelOpis";
            this.labelOpis.Size = new System.Drawing.Size(28, 13);
            this.labelOpis.TabIndex = 3;
            this.labelOpis.Text = "Opis";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(24, 36);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(220, 20);
            this.textBoxID.TabIndex = 5;
            this.textBoxID.Validated += new System.EventHandler(this.textBoxID_Validated);
            // 
            // textBoxIme
            // 
            this.textBoxIme.Location = new System.Drawing.Point(24, 84);
            this.textBoxIme.Name = "textBoxIme";
            this.textBoxIme.Size = new System.Drawing.Size(220, 20);
            this.textBoxIme.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(24, 134);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(220, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // buttonSacuvaj
            // 
            this.buttonSacuvaj.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSacuvaj.Location = new System.Drawing.Point(425, 282);
            this.buttonSacuvaj.Name = "buttonSacuvaj";
            this.buttonSacuvaj.Size = new System.Drawing.Size(91, 53);
            this.buttonSacuvaj.TabIndex = 10;
            this.buttonSacuvaj.Text = "Sacuvaj";
            this.buttonSacuvaj.UseVisualStyleBackColor = true;
            this.buttonSacuvaj.Click += new System.EventHandler(this.buttonSacuvaj_Click);
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOdustani.Location = new System.Drawing.Point(298, 312);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(101, 23);
            this.buttonOdustani.TabIndex = 11;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            // 
            // richTextBoxOpis
            // 
            this.richTextBoxOpis.Location = new System.Drawing.Point(24, 182);
            this.richTextBoxOpis.Name = "richTextBoxOpis";
            this.richTextBoxOpis.Size = new System.Drawing.Size(220, 92);
            this.richTextBoxOpis.TabIndex = 14;
            this.richTextBoxOpis.Text = "";
            // 
            // labelPredmeti
            // 
            this.labelPredmeti.AutoSize = true;
            this.labelPredmeti.Location = new System.Drawing.Point(295, 20);
            this.labelPredmeti.Name = "labelPredmeti";
            this.labelPredmeti.Size = new System.Drawing.Size(48, 13);
            this.labelPredmeti.TabIndex = 4;
            this.labelPredmeti.Text = "Predmeti";
            // 
            // listBoxPredmeti
            // 
            this.listBoxPredmeti.FormattingEnabled = true;
            this.listBoxPredmeti.Location = new System.Drawing.Point(298, 36);
            this.listBoxPredmeti.Name = "listBoxPredmeti";
            this.listBoxPredmeti.Size = new System.Drawing.Size(218, 238);
            this.listBoxPredmeti.TabIndex = 13;
            // 
            // buttonDodajPredmet
            // 
            this.buttonDodajPredmet.Location = new System.Drawing.Point(298, 282);
            this.buttonDodajPredmet.Name = "buttonDodajPredmet";
            this.buttonDodajPredmet.Size = new System.Drawing.Size(101, 23);
            this.buttonDodajPredmet.TabIndex = 12;
            this.buttonDodajPredmet.Text = "Dodaj Predmet";
            this.buttonDodajPredmet.UseVisualStyleBackColor = true;
            this.buttonDodajPredmet.Click += new System.EventHandler(this.buttonDodajPredmet_Click);
            // 
            // SmerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 359);
            this.Controls.Add(this.richTextBoxOpis);
            this.Controls.Add(this.listBoxPredmeti);
            this.Controls.Add(this.buttonDodajPredmet);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.buttonSacuvaj);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBoxIme);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelPredmeti);
            this.Controls.Add(this.labelOpis);
            this.Controls.Add(this.labelDatumUvodjenja);
            this.Controls.Add(this.labelIme);
            this.Controls.Add(this.labelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SmerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelIme;
        private System.Windows.Forms.Label labelDatumUvodjenja;
        private System.Windows.Forms.Label labelOpis;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxIme;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonSacuvaj;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.RichTextBox richTextBoxOpis;
        private System.Windows.Forms.Label labelPredmeti;
        private System.Windows.Forms.ListBox listBoxPredmeti;
        private System.Windows.Forms.Button buttonDodajPredmet;
    }
}