namespace RacunarskiCentar
{
    partial class BrisanjeForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonIzbrisi = new System.Windows.Forms.Button();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(36, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(244, 264);
            this.listBox1.TabIndex = 0;
            // 
            // buttonIzbrisi
            // 
            this.buttonIzbrisi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonIzbrisi.Location = new System.Drawing.Point(205, 327);
            this.buttonIzbrisi.Name = "buttonIzbrisi";
            this.buttonIzbrisi.Size = new System.Drawing.Size(75, 23);
            this.buttonIzbrisi.TabIndex = 1;
            this.buttonIzbrisi.Text = "Izbrisi";
            this.buttonIzbrisi.UseVisualStyleBackColor = true;
            this.buttonIzbrisi.Click += new System.EventHandler(this.buttonIzbrisi_Click);
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOdustani.Location = new System.Drawing.Point(36, 327);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(75, 23);
            this.buttonOdustani.TabIndex = 2;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            // 
            // BrisanjeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 381);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.buttonIzbrisi);
            this.Controls.Add(this.listBox1);
            this.Name = "BrisanjeForm";
            this.Text = "BrisanjeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonIzbrisi;
        private System.Windows.Forms.Button buttonOdustani;
    }
}