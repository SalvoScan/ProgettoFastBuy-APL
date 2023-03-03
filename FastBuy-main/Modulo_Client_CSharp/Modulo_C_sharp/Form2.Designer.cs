
namespace Modulo_C_sharp
{
    partial class FormRegistrazione
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrazione));
            this.TopPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FastBuyLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailText = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.UsernameText = new System.Windows.Forms.TextBox();
            this.CognomeLabel = new System.Windows.Forms.Label();
            this.NomeLabel = new System.Windows.Forms.Label();
            this.LinkAccedi = new System.Windows.Forms.LinkLabel();
            this.CognomeText = new System.Windows.Forms.TextBox();
            this.B_Registrati = new System.Windows.Forms.Button();
            this.NomeText = new System.Windows.Forms.TextBox();
            this.TopPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.OrangeRed;
            this.TopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopPanel.Controls.Add(this.FastBuyLabel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1023, 40);
            this.TopPanel.TabIndex = 2;
            // 
            // FastBuyLabel
            // 
            this.FastBuyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FastBuyLabel.AutoSize = true;
            this.FastBuyLabel.BackColor = System.Drawing.Color.Transparent;
            this.FastBuyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FastBuyLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FastBuyLabel.Location = new System.Drawing.Point(3, 0);
            this.FastBuyLabel.Name = "FastBuyLabel";
            this.FastBuyLabel.Size = new System.Drawing.Size(105, 29);
            this.FastBuyLabel.TabIndex = 5;
            this.FastBuyLabel.Text = "Fast Buy";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Maroon;
            this.groupBox1.Controls.Add(this.EmailLabel);
            this.groupBox1.Controls.Add(this.EmailText);
            this.groupBox1.Controls.Add(this.PasswordLabel);
            this.groupBox1.Controls.Add(this.UsernameLabel);
            this.groupBox1.Controls.Add(this.PasswordText);
            this.groupBox1.Controls.Add(this.UsernameText);
            this.groupBox1.Controls.Add(this.CognomeLabel);
            this.groupBox1.Controls.Add(this.NomeLabel);
            this.groupBox1.Controls.Add(this.LinkAccedi);
            this.groupBox1.Controls.Add(this.CognomeText);
            this.groupBox1.Controls.Add(this.B_Registrati);
            this.groupBox1.Controls.Add(this.NomeText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox1.Location = new System.Drawing.Point(809, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 512);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrazione";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.BackColor = System.Drawing.Color.Transparent;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.EmailLabel.Location = new System.Drawing.Point(33, 308);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(57, 24);
            this.EmailLabel.TabIndex = 15;
            this.EmailLabel.Text = "Email";
            // 
            // EmailText
            // 
            this.EmailText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailText.Location = new System.Drawing.Point(34, 335);
            this.EmailText.Name = "EmailText";
            this.EmailText.Size = new System.Drawing.Size(162, 28);
            this.EmailText.TabIndex = 14;
            this.EmailText.TextChanged += new System.EventHandler(this.EmailText_TextChanged);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.PasswordLabel.Location = new System.Drawing.Point(33, 238);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(92, 24);
            this.PasswordLabel.TabIndex = 12;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.UsernameLabel.Location = new System.Drawing.Point(33, 170);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(97, 24);
            this.UsernameLabel.TabIndex = 11;
            this.UsernameLabel.Text = "Username";
            // 
            // PasswordText
            // 
            this.PasswordText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordText.Location = new System.Drawing.Point(34, 265);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(162, 28);
            this.PasswordText.TabIndex = 13;
            this.PasswordText.UseSystemPasswordChar = true;
            this.PasswordText.TextChanged += new System.EventHandler(this.PasswordText_TextChanged);
            // 
            // UsernameText
            // 
            this.UsernameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameText.Location = new System.Drawing.Point(34, 197);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(162, 28);
            this.UsernameText.TabIndex = 10;
            this.UsernameText.TextChanged += new System.EventHandler(this.UsernameText_TextChanged);
            // 
            // CognomeLabel
            // 
            this.CognomeLabel.AutoSize = true;
            this.CognomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.CognomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CognomeLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.CognomeLabel.Location = new System.Drawing.Point(33, 100);
            this.CognomeLabel.Name = "CognomeLabel";
            this.CognomeLabel.Size = new System.Drawing.Size(94, 24);
            this.CognomeLabel.TabIndex = 6;
            this.CognomeLabel.Text = "Cognome";
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.NomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.NomeLabel.Location = new System.Drawing.Point(33, 32);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(62, 24);
            this.NomeLabel.TabIndex = 5;
            this.NomeLabel.Text = "Nome";
            // 
            // LinkAccedi
            // 
            this.LinkAccedi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkAccedi.AutoSize = true;
            this.LinkAccedi.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LinkAccedi.Location = new System.Drawing.Point(31, 476);
            this.LinkAccedi.Name = "LinkAccedi";
            this.LinkAccedi.Size = new System.Drawing.Size(148, 17);
            this.LinkAccedi.TabIndex = 9;
            this.LinkAccedi.TabStop = true;
            this.LinkAccedi.Text = "Già registrato? Accedi";
            this.LinkAccedi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkAccedi_LinkClicked);
            // 
            // CognomeText
            // 
            this.CognomeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CognomeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CognomeText.Location = new System.Drawing.Point(34, 127);
            this.CognomeText.Name = "CognomeText";
            this.CognomeText.Size = new System.Drawing.Size(162, 28);
            this.CognomeText.TabIndex = 8;
            this.CognomeText.TextChanged += new System.EventHandler(this.CognomeText_TextChanged);
            // 
            // B_Registrati
            // 
            this.B_Registrati.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Registrati.BackColor = System.Drawing.Color.OrangeRed;
            this.B_Registrati.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Registrati.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.B_Registrati.Location = new System.Drawing.Point(67, 385);
            this.B_Registrati.Name = "B_Registrati";
            this.B_Registrati.Size = new System.Drawing.Size(85, 27);
            this.B_Registrati.TabIndex = 7;
            this.B_Registrati.Text = "Registrati";
            this.B_Registrati.UseVisualStyleBackColor = false;
            this.B_Registrati.Click += new System.EventHandler(this.B_Registrati_Click);
            // 
            // NomeText
            // 
            this.NomeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NomeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeText.Location = new System.Drawing.Point(34, 59);
            this.NomeText.Name = "NomeText";
            this.NomeText.Size = new System.Drawing.Size(162, 28);
            this.NomeText.TabIndex = 2;
            this.NomeText.TextChanged += new System.EventHandler(this.NomeText_TextChanged);
            // 
            // FormRegistrazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1023, 552);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TopPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormRegistrazione";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrati";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRegistrazione_Closed);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel TopPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NomeText;
        private System.Windows.Forms.Button B_Registrati;
        private System.Windows.Forms.TextBox CognomeText;
        private System.Windows.Forms.LinkLabel LinkAccedi;
        private System.Windows.Forms.Label FastBuyLabel;
        private System.Windows.Forms.Label NomeLabel;
        private System.Windows.Forms.Label CognomeLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.TextBox UsernameText;
    }
}