﻿namespace KRR
{
    partial class frmFormula
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
            this.rtbFormula = new System.Windows.Forms.RichTextBox();
            this.pnlCauses1 = new System.Windows.Forms.Panel();
            this.cmbCauses1 = new System.Windows.Forms.ComboBox();
            this.chkCauses1 = new System.Windows.Forms.CheckBox();
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.pnlCauses0 = new System.Windows.Forms.Panel();
            this.cmbCauses0 = new System.Windows.Forms.ComboBox();
            this.chkCauses0 = new System.Windows.Forms.CheckBox();
            this.btnAdd0 = new System.Windows.Forms.Button();
            this.btnOr = new System.Windows.Forms.Button();
            this.btnAddFormula = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbCausesAgents = new System.Windows.Forms.ComboBox();
            this.cmbCausesActions = new System.Windows.Forms.ComboBox();
            this.chkCondition = new System.Windows.Forms.CheckBox();
            this.cmbCondition = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.pnlCauses1.SuspendLayout();
            this.pnlCauses0.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbCondition);
            this.panel1.Controls.Add(this.chkCondition);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cmbCausesAgents);
            this.panel1.Controls.Add(this.cmbCausesActions);
            this.panel1.Controls.Add(this.rtbFormula);
            this.panel1.Controls.Add(this.pnlCauses1);
            this.panel1.Controls.Add(this.pnlCauses0);
            this.panel1.Controls.Add(this.btnOr);
            this.panel1.Controls.Add(this.btnAddFormula);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 197);
            this.panel1.TabIndex = 0;
            // 
            // rtbFormula
            // 
            this.rtbFormula.Location = new System.Drawing.Point(24, 117);
            this.rtbFormula.Name = "rtbFormula";
            this.rtbFormula.ReadOnly = true;
            this.rtbFormula.Size = new System.Drawing.Size(485, 30);
            this.rtbFormula.TabIndex = 8;
            this.rtbFormula.Text = "";
            // 
            // pnlCauses1
            // 
            this.pnlCauses1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCauses1.Controls.Add(this.cmbCauses1);
            this.pnlCauses1.Controls.Add(this.chkCauses1);
            this.pnlCauses1.Controls.Add(this.btnAdd1);
            this.pnlCauses1.Enabled = false;
            this.pnlCauses1.Location = new System.Drawing.Point(291, 47);
            this.pnlCauses1.Name = "pnlCauses1";
            this.pnlCauses1.Size = new System.Drawing.Size(193, 53);
            this.pnlCauses1.TabIndex = 7;
            // 
            // cmbCauses1
            // 
            this.cmbCauses1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCauses1.FormattingEnabled = true;
            this.cmbCauses1.Location = new System.Drawing.Point(27, 14);
            this.cmbCauses1.Name = "cmbCauses1";
            this.cmbCauses1.Size = new System.Drawing.Size(121, 24);
            this.cmbCauses1.TabIndex = 4;
            // 
            // chkCauses1
            // 
            this.chkCauses1.AutoSize = true;
            this.chkCauses1.Location = new System.Drawing.Point(3, 18);
            this.chkCauses1.Name = "chkCauses1";
            this.chkCauses1.Size = new System.Drawing.Size(18, 17);
            this.chkCauses1.TabIndex = 6;
            this.chkCauses1.UseVisualStyleBackColor = true;
            // 
            // btnAdd1
            // 
            this.btnAdd1.Location = new System.Drawing.Point(154, 10);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(32, 30);
            this.btnAdd1.TabIndex = 5;
            this.btnAdd1.Text = "+";
            this.btnAdd1.UseVisualStyleBackColor = true;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // pnlCauses0
            // 
            this.pnlCauses0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCauses0.Controls.Add(this.cmbCauses0);
            this.pnlCauses0.Controls.Add(this.chkCauses0);
            this.pnlCauses0.Controls.Add(this.btnAdd0);
            this.pnlCauses0.Location = new System.Drawing.Point(54, 47);
            this.pnlCauses0.Name = "pnlCauses0";
            this.pnlCauses0.Size = new System.Drawing.Size(193, 53);
            this.pnlCauses0.TabIndex = 7;
            // 
            // cmbCauses0
            // 
            this.cmbCauses0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCauses0.FormattingEnabled = true;
            this.cmbCauses0.Location = new System.Drawing.Point(27, 14);
            this.cmbCauses0.Name = "cmbCauses0";
            this.cmbCauses0.Size = new System.Drawing.Size(121, 24);
            this.cmbCauses0.TabIndex = 4;
            // 
            // chkCauses0
            // 
            this.chkCauses0.AutoSize = true;
            this.chkCauses0.Location = new System.Drawing.Point(3, 18);
            this.chkCauses0.Name = "chkCauses0";
            this.chkCauses0.Size = new System.Drawing.Size(18, 17);
            this.chkCauses0.TabIndex = 6;
            this.chkCauses0.UseVisualStyleBackColor = true;
            // 
            // btnAdd0
            // 
            this.btnAdd0.Location = new System.Drawing.Point(154, 10);
            this.btnAdd0.Name = "btnAdd0";
            this.btnAdd0.Size = new System.Drawing.Size(32, 30);
            this.btnAdd0.TabIndex = 5;
            this.btnAdd0.Text = "+";
            this.btnAdd0.UseVisualStyleBackColor = true;
            this.btnAdd0.Click += new System.EventHandler(this.btnAdd0_Click);
            // 
            // btnOr
            // 
            this.btnOr.Location = new System.Drawing.Point(253, 58);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(32, 30);
            this.btnOr.TabIndex = 5;
            this.btnOr.Text = "V";
            this.btnOr.UseVisualStyleBackColor = true;
            this.btnOr.Click += new System.EventHandler(this.btnOr_Click);
            // 
            // btnAddFormula
            // 
            this.btnAddFormula.Location = new System.Drawing.Point(528, 117);
            this.btnAddFormula.Name = "btnAddFormula";
            this.btnAddFormula.Size = new System.Drawing.Size(75, 71);
            this.btnAddFormula.TabIndex = 1;
            this.btnAddFormula.Text = "Add Formula";
            this.btnAddFormula.UseVisualStyleBackColor = true;
            this.btnAddFormula.Click += new System.EventHandler(this.btnAddFormula_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(253, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 17);
            this.label13.TabIndex = 10;
            this.label13.Text = "by";
            // 
            // cmbCausesAgents
            // 
            this.cmbCausesAgents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCausesAgents.FormattingEnabled = true;
            this.cmbCausesAgents.Location = new System.Drawing.Point(282, 3);
            this.cmbCausesAgents.Name = "cmbCausesAgents";
            this.cmbCausesAgents.Size = new System.Drawing.Size(121, 24);
            this.cmbCausesAgents.TabIndex = 11;
            // 
            // cmbCausesActions
            // 
            this.cmbCausesActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCausesActions.FormattingEnabled = true;
            this.cmbCausesActions.Location = new System.Drawing.Point(126, 3);
            this.cmbCausesActions.Name = "cmbCausesActions";
            this.cmbCausesActions.Size = new System.Drawing.Size(121, 24);
            this.cmbCausesActions.TabIndex = 9;
            // 
            // chkCondition
            // 
            this.chkCondition.AutoSize = true;
            this.chkCondition.Location = new System.Drawing.Point(185, 157);
            this.chkCondition.Name = "chkCondition";
            this.chkCondition.Size = new System.Drawing.Size(18, 17);
            this.chkCondition.TabIndex = 6;
            this.chkCondition.UseVisualStyleBackColor = true;
            // 
            // cmbCondition
            // 
            this.cmbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondition.FormattingEnabled = true;
            this.cmbCondition.Location = new System.Drawing.Point(209, 153);
            this.cmbCondition.Name = "cmbCondition";
            this.cmbCondition.Size = new System.Drawing.Size(121, 24);
            this.cmbCondition.TabIndex = 4;
            // 
            // frmFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 221);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmFormula";
            this.Text = "Formula";
            this.Load += new System.EventHandler(this.frmFormula_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCauses1.ResumeLayout(false);
            this.pnlCauses1.PerformLayout();
            this.pnlCauses0.ResumeLayout(false);
            this.pnlCauses0.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddFormula;
        private System.Windows.Forms.RichTextBox rtbFormula;
        private System.Windows.Forms.Panel pnlCauses0;
        private System.Windows.Forms.ComboBox cmbCauses0;
        private System.Windows.Forms.CheckBox chkCauses0;
        private System.Windows.Forms.Button btnOr;
        private System.Windows.Forms.Panel pnlCauses1;
        private System.Windows.Forms.ComboBox cmbCauses1;
        private System.Windows.Forms.CheckBox chkCauses1;
        private System.Windows.Forms.Button btnAdd1;
        private System.Windows.Forms.Button btnAdd0;
        private System.Windows.Forms.ComboBox cmbCondition;
        private System.Windows.Forms.CheckBox chkCondition;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbCausesAgents;
        private System.Windows.Forms.ComboBox cmbCausesActions;
    }
}