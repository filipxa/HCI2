namespace RacunarskiCentar
{
    partial class Form1
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.toolboxPanel = new System.Windows.Forms.Panel();
            this.test = new System.Windows.Forms.Button();
            this.toolboxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.AllowDrop = true;
            this.MainPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainPanel.Location = new System.Drawing.Point(273, -1);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(997, 791);
            this.MainPanel.TabIndex = 4;
            // 
            // toolboxPanel
            // 
            this.toolboxPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolboxPanel.Controls.Add(this.test);
            this.toolboxPanel.Location = new System.Drawing.Point(-3, -1);
            this.toolboxPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolboxPanel.Name = "toolboxPanel";
            this.toolboxPanel.Size = new System.Drawing.Size(268, 791);
            this.toolboxPanel.TabIndex = 5;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(43, 456);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(75, 23);
            this.test.TabIndex = 0;
            this.test.Text = "test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1271, 790);
            this.Controls.Add(this.toolboxPanel);
            this.Controls.Add(this.MainPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolboxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel toolboxPanel;
        private System.Windows.Forms.Button test;
    }
}

