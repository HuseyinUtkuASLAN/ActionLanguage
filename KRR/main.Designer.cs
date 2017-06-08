namespace KRR
{
    partial class main
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnDescription = new System.Windows.Forms.Button();
            this.btnSigniture = new System.Windows.Forms.Button();
            this.btnScenarios = new System.Windows.Forms.Button();
            this.btnSyntax = new System.Windows.Forms.Button();
            this.btnSemantics = new System.Windows.Forms.Button();
            this.btnQueries = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(12, 12);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(239, 96);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnDescription
            // 
            this.btnDescription.Location = new System.Drawing.Point(12, 114);
            this.btnDescription.Name = "btnDescription";
            this.btnDescription.Size = new System.Drawing.Size(111, 96);
            this.btnDescription.TabIndex = 1;
            this.btnDescription.Text = "Action Language Description";
            this.btnDescription.UseVisualStyleBackColor = true;
            this.btnDescription.Click += new System.EventHandler(this.btnDescription_Click);
            // 
            // btnSigniture
            // 
            this.btnSigniture.Location = new System.Drawing.Point(140, 114);
            this.btnSigniture.Name = "btnSigniture";
            this.btnSigniture.Size = new System.Drawing.Size(111, 96);
            this.btnSigniture.TabIndex = 2;
            this.btnSigniture.Text = "Signature";
            this.btnSigniture.UseVisualStyleBackColor = true;
            this.btnSigniture.Click += new System.EventHandler(this.btnSigniture_Click);
            // 
            // btnScenarios
            // 
            this.btnScenarios.Location = new System.Drawing.Point(12, 216);
            this.btnScenarios.Name = "btnScenarios";
            this.btnScenarios.Size = new System.Drawing.Size(111, 96);
            this.btnScenarios.TabIndex = 3;
            this.btnScenarios.Text = "Scenarios";
            this.btnScenarios.UseVisualStyleBackColor = true;
            this.btnScenarios.Click += new System.EventHandler(this.btnScenarios_Click);
            // 
            // btnSyntax
            // 
            this.btnSyntax.Location = new System.Drawing.Point(140, 216);
            this.btnSyntax.Name = "btnSyntax";
            this.btnSyntax.Size = new System.Drawing.Size(111, 96);
            this.btnSyntax.TabIndex = 4;
            this.btnSyntax.Text = "Syntax";
            this.btnSyntax.UseVisualStyleBackColor = true;
            this.btnSyntax.Click += new System.EventHandler(this.btnSyntax_Click);
            // 
            // btnSemantics
            // 
            this.btnSemantics.Location = new System.Drawing.Point(12, 318);
            this.btnSemantics.Name = "btnSemantics";
            this.btnSemantics.Size = new System.Drawing.Size(111, 96);
            this.btnSemantics.TabIndex = 5;
            this.btnSemantics.Text = "Semantics";
            this.btnSemantics.UseVisualStyleBackColor = true;
            this.btnSemantics.Click += new System.EventHandler(this.btnSemantics_Click);
            // 
            // btnQueries
            // 
            this.btnQueries.Location = new System.Drawing.Point(140, 318);
            this.btnQueries.Name = "btnQueries";
            this.btnQueries.Size = new System.Drawing.Size(111, 96);
            this.btnQueries.TabIndex = 6;
            this.btnQueries.Text = "Queries";
            this.btnQueries.UseVisualStyleBackColor = true;
            this.btnQueries.Click += new System.EventHandler(this.btnQueries_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 428);
            this.Controls.Add(this.btnSigniture);
            this.Controls.Add(this.btnQueries);
            this.Controls.Add(this.btnSyntax);
            this.Controls.Add(this.btnSemantics);
            this.Controls.Add(this.btnScenarios);
            this.Controls.Add(this.btnDescription);
            this.Controls.Add(this.btnPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KRR : AL";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnDescription;
        private System.Windows.Forms.Button btnSigniture;
        private System.Windows.Forms.Button btnScenarios;
        private System.Windows.Forms.Button btnSyntax;
        private System.Windows.Forms.Button btnSemantics;
        private System.Windows.Forms.Button btnQueries;
    }
}