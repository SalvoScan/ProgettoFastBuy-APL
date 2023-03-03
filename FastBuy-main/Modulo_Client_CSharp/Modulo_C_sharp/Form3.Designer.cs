
namespace Modulo_C_sharp
{
    partial class FormInserimentoProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInserimentoProd));
            this.TopPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FastBuyLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QuantitaLabel = new System.Windows.Forms.Label();
            this.QuantitaText = new System.Windows.Forms.TextBox();
            this.PrezzoLabel = new System.Windows.Forms.Label();
            this.NomeLabel = new System.Windows.Forms.Label();
            this.PrezzoText = new System.Windows.Forms.TextBox();
            this.NomeText = new System.Windows.Forms.TextBox();
            this.CategoriaLabel = new System.Windows.Forms.Label();
            this.CodiceLabel = new System.Windows.Forms.Label();
            this.CategoriaText = new System.Windows.Forms.TextBox();
            this.B_Inserisci = new System.Windows.Forms.Button();
            this.CodiceText = new System.Windows.Forms.TextBox();
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
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Maroon;
            this.groupBox1.Controls.Add(this.QuantitaLabel);
            this.groupBox1.Controls.Add(this.QuantitaText);
            this.groupBox1.Controls.Add(this.PrezzoLabel);
            this.groupBox1.Controls.Add(this.NomeLabel);
            this.groupBox1.Controls.Add(this.PrezzoText);
            this.groupBox1.Controls.Add(this.NomeText);
            this.groupBox1.Controls.Add(this.CategoriaLabel);
            this.groupBox1.Controls.Add(this.CodiceLabel);
            this.groupBox1.Controls.Add(this.CategoriaText);
            this.groupBox1.Controls.Add(this.B_Inserisci);
            this.groupBox1.Controls.Add(this.CodiceText);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox1.Location = new System.Drawing.Point(247, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 438);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inserimento prodotto";
            // 
            // QuantitaLabel
            // 
            this.QuantitaLabel.AutoSize = true;
            this.QuantitaLabel.BackColor = System.Drawing.Color.Transparent;
            this.QuantitaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantitaLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.QuantitaLabel.Location = new System.Drawing.Point(33, 308);
            this.QuantitaLabel.Name = "QuantitaLabel";
            this.QuantitaLabel.Size = new System.Drawing.Size(79, 24);
            this.QuantitaLabel.TabIndex = 15;
            this.QuantitaLabel.Text = "Quantità";
            // 
            // QuantitaText
            // 
            this.QuantitaText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.QuantitaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantitaText.Location = new System.Drawing.Point(37, 335);
            this.QuantitaText.Name = "QuantitaText";
            this.QuantitaText.Size = new System.Drawing.Size(244, 28);
            this.QuantitaText.TabIndex = 14;
            this.QuantitaText.TextChanged += new System.EventHandler(this.QuantitaText_TextChanged);
            // 
            // PrezzoLabel
            // 
            this.PrezzoLabel.AutoSize = true;
            this.PrezzoLabel.BackColor = System.Drawing.Color.Transparent;
            this.PrezzoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrezzoLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.PrezzoLabel.Location = new System.Drawing.Point(33, 238);
            this.PrezzoLabel.Name = "PrezzoLabel";
            this.PrezzoLabel.Size = new System.Drawing.Size(68, 24);
            this.PrezzoLabel.TabIndex = 12;
            this.PrezzoLabel.Text = "Prezzo";
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.NomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.NomeLabel.Location = new System.Drawing.Point(33, 170);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(136, 24);
            this.NomeLabel.TabIndex = 11;
            this.NomeLabel.Text = "Nome prodotto";
            // 
            // PrezzoText
            // 
            this.PrezzoText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PrezzoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrezzoText.Location = new System.Drawing.Point(37, 265);
            this.PrezzoText.Name = "PrezzoText";
            this.PrezzoText.Size = new System.Drawing.Size(244, 28);
            this.PrezzoText.TabIndex = 13;
            this.PrezzoText.TextChanged += new System.EventHandler(this.PrezzoText_TextChanged);
            // 
            // NomeText
            // 
            this.NomeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NomeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeText.Location = new System.Drawing.Point(37, 197);
            this.NomeText.Name = "NomeText";
            this.NomeText.Size = new System.Drawing.Size(244, 28);
            this.NomeText.TabIndex = 10;
            this.NomeText.TextChanged += new System.EventHandler(this.NomeText_TextChanged);
            // 
            // CategoriaLabel
            // 
            this.CategoriaLabel.AutoSize = true;
            this.CategoriaLabel.BackColor = System.Drawing.Color.Transparent;
            this.CategoriaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoriaLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.CategoriaLabel.Location = new System.Drawing.Point(33, 100);
            this.CategoriaLabel.Name = "CategoriaLabel";
            this.CategoriaLabel.Size = new System.Drawing.Size(90, 24);
            this.CategoriaLabel.TabIndex = 6;
            this.CategoriaLabel.Text = "Categoria";
            // 
            // CodiceLabel
            // 
            this.CodiceLabel.AutoSize = true;
            this.CodiceLabel.BackColor = System.Drawing.Color.Transparent;
            this.CodiceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodiceLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.CodiceLabel.Location = new System.Drawing.Point(33, 32);
            this.CodiceLabel.Name = "CodiceLabel";
            this.CodiceLabel.Size = new System.Drawing.Size(144, 24);
            this.CodiceLabel.TabIndex = 5;
            this.CodiceLabel.Text = "Codice prodotto";
            // 
            // CategoriaText
            // 
            this.CategoriaText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CategoriaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoriaText.Location = new System.Drawing.Point(37, 127);
            this.CategoriaText.Name = "CategoriaText";
            this.CategoriaText.Size = new System.Drawing.Size(244, 28);
            this.CategoriaText.TabIndex = 8;
            this.CategoriaText.TextChanged += new System.EventHandler(this.CategoriaText_TextChanged);
            // 
            // B_Inserisci
            // 
            this.B_Inserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Inserisci.BackColor = System.Drawing.Color.OrangeRed;
            this.B_Inserisci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Inserisci.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.B_Inserisci.Location = new System.Drawing.Point(346, 388);
            this.B_Inserisci.Name = "B_Inserisci";
            this.B_Inserisci.Size = new System.Drawing.Size(85, 27);
            this.B_Inserisci.TabIndex = 7;
            this.B_Inserisci.Text = "Inserisci";
            this.B_Inserisci.UseVisualStyleBackColor = false;
            this.B_Inserisci.Click += new System.EventHandler(this.B_Inserisci_Click);
            // 
            // CodiceText
            // 
            this.CodiceText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CodiceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodiceText.Location = new System.Drawing.Point(37, 59);
            this.CodiceText.Name = "CodiceText";
            this.CodiceText.Size = new System.Drawing.Size(244, 28);
            this.CodiceText.TabIndex = 2;
            this.CodiceText.TextChanged += new System.EventHandler(this.CodiceText_TextChanged);
            // 
            // FormInserimentoProd
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
            this.Name = "FormInserimentoProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserimento prodotto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormInserimentoProd_Closed);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel TopPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CodiceText;
        private System.Windows.Forms.Button B_Inserisci;
        private System.Windows.Forms.TextBox CategoriaText;
        private System.Windows.Forms.Label FastBuyLabel;
        private System.Windows.Forms.Label CodiceLabel;
        private System.Windows.Forms.Label CategoriaLabel;
        private System.Windows.Forms.Label QuantitaLabel;
        private System.Windows.Forms.TextBox QuantitaText;
        private System.Windows.Forms.Label PrezzoLabel;
        private System.Windows.Forms.Label NomeLabel;
        private System.Windows.Forms.TextBox PrezzoText;
        private System.Windows.Forms.TextBox NomeText;
    }
}