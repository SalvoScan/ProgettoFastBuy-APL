
namespace Modulo_C_sharp
{
    partial class FormTracciamentoOrdine
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
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTracciamentoOrdine));
            this.TopPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FastBuyLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.B_TornaIndietro = new System.Windows.Forms.Button();
            this.B_AggiornaTracciamentoOrdine = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.FastBuyLabel.TabIndex = 4;
            this.FastBuyLabel.Text = "Fast Buy";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(110, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(816, 390);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // B_TornaIndietro
            // 
            this.B_TornaIndietro.BackColor = System.Drawing.Color.OrangeRed;
            this.B_TornaIndietro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_TornaIndietro.ForeColor = System.Drawing.Color.Black;
            this.B_TornaIndietro.Location = new System.Drawing.Point(110, 454);
            this.B_TornaIndietro.Name = "B_TornaIndietro";
            this.B_TornaIndietro.Size = new System.Drawing.Size(142, 27);
            this.B_TornaIndietro.TabIndex = 9;
            this.B_TornaIndietro.Text = "Torna indietro";
            this.B_TornaIndietro.UseVisualStyleBackColor = false;
            this.B_TornaIndietro.Click += new System.EventHandler(this.B_TornaIndietro_Click);
            // 
            // B_AggiornaTracciamentoOrdine
            // 
            this.B_AggiornaTracciamentoOrdine.BackColor = System.Drawing.Color.OrangeRed;
            this.B_AggiornaTracciamentoOrdine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_AggiornaTracciamentoOrdine.ForeColor = System.Drawing.Color.Black;
            this.B_AggiornaTracciamentoOrdine.Location = new System.Drawing.Point(702, 454);
            this.B_AggiornaTracciamentoOrdine.Name = "B_AggiornaTracciamentoOrdine";
            this.B_AggiornaTracciamentoOrdine.Size = new System.Drawing.Size(224, 27);
            this.B_AggiornaTracciamentoOrdine.TabIndex = 10;
            this.B_AggiornaTracciamentoOrdine.Text = "Aggiorna tracciamento ordine";
            this.B_AggiornaTracciamentoOrdine.UseVisualStyleBackColor = false;
            this.B_AggiornaTracciamentoOrdine.Click += new System.EventHandler(this.B_AggiornaTracciamentoOrdine_Click);
            // 
            // FormTracciamentoOrdine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1023, 493);
            this.Controls.Add(this.B_AggiornaTracciamentoOrdine);
            this.Controls.Add(this.B_TornaIndietro);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TopPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormTracciamentoOrdine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tracciamento ordine";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTracciamentoOrdine_Closed);
            this.Load += new System.EventHandler(this.FormTracciamentoOrdine_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel TopPanel;
        private System.Windows.Forms.Label FastBuyLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button B_TornaIndietro;
        private System.Windows.Forms.Button B_AggiornaTracciamentoOrdine;
    }
}
