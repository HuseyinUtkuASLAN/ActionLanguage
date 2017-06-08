namespace KRR
{
    partial class frmOutput
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbEntrence = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtbEntrence);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 271);
            this.panel1.TabIndex = 0;
            // 
            // rtbEntrence
            // 
            this.rtbEntrence.Location = new System.Drawing.Point(3, 3);
            this.rtbEntrence.Name = "rtbEntrence";
            this.rtbEntrence.ReadOnly = true;
            this.rtbEntrence.Size = new System.Drawing.Size(515, 265);
            this.rtbEntrence.TabIndex = 0;
            this.rtbEntrence.Text = "";
            // 
            // frmOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(545, 1045);
            this.Controls.Add(this.panel1);
            this.Name = "frmOutput";
            this.Text = "frmOutput";
            this.Load += new System.EventHandler(this.frmOutput_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmOutput_Paint);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbEntrence;
    }
}