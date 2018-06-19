namespace RacunarskiCentar
{
    partial class UcionicaForm
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
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelOpis = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelBrMesta = new System.Windows.Forms.Label();
            this.buttonSacuvaj = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(12, 25);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(120, 20);
            this.textBoxID.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxID, "Jedinstveno obelezje ucionice.");
            this.textBoxID.Validated += new System.EventHandler(this.textBoxID_Validated);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(138, 25);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.numericUpDown1, "Broj mesta u ucionici.");
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Validated += new System.EventHandler(this.numericUpDown1_Validated);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 52);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 169);
            this.checkedListBox1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.checkedListBox1, "Lista opreme u ucionici.");
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(138, 52);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(120, 169);
            this.checkedListBox2.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 258);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(246, 96);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.toolTip1.SetToolTip(this.richTextBox1, "Detaljniji opis ucionice.");
            // 
            // labelOpis
            // 
            this.labelOpis.AutoSize = true;
            this.labelOpis.Location = new System.Drawing.Point(13, 239);
            this.labelOpis.Name = "labelOpis";
            this.labelOpis.Size = new System.Drawing.Size(28, 13);
            this.labelOpis.TabIndex = 4;
            this.labelOpis.Text = "Opis";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(13, 9);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(18, 13);
            this.labelID.TabIndex = 4;
            this.labelID.Text = "ID";
            this.toolTip1.SetToolTip(this.labelID, "Jedinstveno obelezje ucionice.");
            // 
            // labelBrMesta
            // 
            this.labelBrMesta.AutoSize = true;
            this.labelBrMesta.Location = new System.Drawing.Point(135, 9);
            this.labelBrMesta.Name = "labelBrMesta";
            this.labelBrMesta.Size = new System.Drawing.Size(51, 13);
            this.labelBrMesta.TabIndex = 4;
            this.labelBrMesta.Text = "Br. mesta";
            this.toolTip1.SetToolTip(this.labelBrMesta, "Broj mesta u ucionici.");
            // 
            // buttonSacuvaj
            // 
            this.buttonSacuvaj.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSacuvaj.Location = new System.Drawing.Point(183, 360);
            this.buttonSacuvaj.Name = "buttonSacuvaj";
            this.buttonSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.buttonSacuvaj.TabIndex = 5;
            this.buttonSacuvaj.Text = "Sacuvaj";
            this.toolTip1.SetToolTip(this.buttonSacuvaj, "Sacuvaj.");
            this.buttonSacuvaj.UseVisualStyleBackColor = true;
            this.buttonSacuvaj.Click += new System.EventHandler(this.buttonSacuvaj_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(12, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Odustani";
            this.toolTip1.SetToolTip(this.button1, "Odustani.");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // UcionicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 403);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSacuvaj);
            this.Controls.Add(this.labelBrMesta);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelOpis);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBoxID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UcionicaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Učionica";
            this.Load += new System.EventHandler(this.UcionicaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelOpis;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelBrMesta;
        private System.Windows.Forms.Button buttonSacuvaj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}