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
            this.labelID = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.labelNaziv = new System.Windows.Forms.Label();
            this.buttonPotvrdi = new System.Windows.Forms.Button();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(13, 22);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBoxIme
            // 
            this.textBoxIme.Location = new System.Drawing.Point(16, 88);
            this.textBoxIme.Name = "textBoxIme";
            this.textBoxIme.Size = new System.Drawing.Size(182, 20);
            this.textBoxIme.TabIndex = 2;
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Location = new System.Drawing.Point(13, 72);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(34, 13);
            this.labelNaziv.TabIndex = 3;
            this.labelNaziv.Text = "Naziv";
            // 
            // buttonPotvrdi
            // 
            this.buttonPotvrdi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonPotvrdi.Location = new System.Drawing.Point(123, 132);
            this.buttonPotvrdi.Name = "buttonPotvrdi";
            this.buttonPotvrdi.Size = new System.Drawing.Size(75, 23);
            this.buttonPotvrdi.TabIndex = 4;
            this.buttonPotvrdi.Text = "Potvrdi";
            this.buttonPotvrdi.UseVisualStyleBackColor = true;
            this.buttonPotvrdi.Click += new System.EventHandler(this.buttonPotvrdi_Click);
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonOdustani.Location = new System.Drawing.Point(16, 131);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(75, 23);
            this.buttonOdustani.TabIndex = 5;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            // 
            // SmerFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 181);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.buttonPotvrdi);
            this.Controls.Add(this.labelNaziv);
            this.Controls.Add(this.textBoxIme);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SmerFilterForm";
            this.Text = "SmerFilterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxIme;
        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.Button buttonPotvrdi;
        private System.Windows.Forms.Button buttonOdustani;
    }
}