
namespace Modulo_C_sharp
{
    partial class FormSceltaCategoria
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

        #region Codice generato da Progettazione Windows Form

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSceltaCategoria));
            this.TopPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FastBuyLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.B_VisualizzaOrdini = new System.Windows.Forms.Button();
            this.TabProdotti = new System.Windows.Forms.TableLayoutPanel();
            this.QuantitaLabel = new System.Windows.Forms.Label();
            this.NumQuantita = new System.Windows.Forms.NumericUpDown();
            this.B_VisualizzaCarrello = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumQuantita)).BeginInit();
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Maroon;
            this.groupBox1.Controls.Add(this.B_VisualizzaOrdini);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1023, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleziona una categoria";
            // 
            // B_VisualizzaOrdini
            // 
            this.B_VisualizzaOrdini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_VisualizzaOrdini.BackColor = System.Drawing.Color.OrangeRed;
            this.B_VisualizzaOrdini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_VisualizzaOrdini.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.B_VisualizzaOrdini.Location = new System.Drawing.Point(886, 36);
            this.B_VisualizzaOrdini.Name = "B_VisualizzaOrdini";
            this.B_VisualizzaOrdini.Size = new System.Drawing.Size(125, 27);
            this.B_VisualizzaOrdini.TabIndex = 7;
            this.B_VisualizzaOrdini.Text = "Visualizza ordini";
            this.B_VisualizzaOrdini.UseVisualStyleBackColor = false;
            this.B_VisualizzaOrdini.Click += new System.EventHandler(this.B_VisualizzaOrdini_Click);
            // 
            // TabProdotti
            // 
            this.TabProdotti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabProdotti.AutoSize = true;
            this.TabProdotti.BackColor = System.Drawing.Color.Maroon;
            this.TabProdotti.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TabProdotti.ColumnCount = 4;
            this.TabProdotti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TabProdotti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TabProdotti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TabProdotti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TabProdotti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.ForeColor = System.Drawing.Color.OrangeRed;
            this.TabProdotti.Location = new System.Drawing.Point(0, 146);
            this.TabProdotti.Name = "TabProdotti";
            this.TabProdotti.RowCount = 14;
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabProdotti.Size = new System.Drawing.Size(1023, 295);
            this.TabProdotti.TabIndex = 4;
            // 
            // QuantitaLabel
            // 
            this.QuantitaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.QuantitaLabel.AutoSize = true;
            this.QuantitaLabel.BackColor = System.Drawing.Color.Maroon;
            this.QuantitaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantitaLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.QuantitaLabel.Location = new System.Drawing.Point(11, 468);
            this.QuantitaLabel.Name = "QuantitaLabel";
            this.QuantitaLabel.Size = new System.Drawing.Size(230, 18);
            this.QuantitaLabel.TabIndex = 5;
            this.QuantitaLabel.Text = "Quantità del prodotto desiderata:  ";
            // 
            // NumQuantita
            // 
            this.NumQuantita.BackColor = System.Drawing.Color.Maroon;
            this.NumQuantita.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumQuantita.ForeColor = System.Drawing.Color.OrangeRed;
            this.NumQuantita.Location = new System.Drawing.Point(266, 468);
            this.NumQuantita.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumQuantita.Name = "NumQuantita";
            this.NumQuantita.Size = new System.Drawing.Size(80, 18);
            this.NumQuantita.TabIndex = 6;
            this.NumQuantita.ValueChanged += new System.EventHandler(this.NumQuantita_ValueChanged);
            // 
            // B_VisualizzaCarrello
            // 
            this.B_VisualizzaCarrello.BackColor = System.Drawing.Color.OrangeRed;
            this.B_VisualizzaCarrello.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_VisualizzaCarrello.ForeColor = System.Drawing.Color.Black;
            this.B_VisualizzaCarrello.Location = new System.Drawing.Point(821, 462);
            this.B_VisualizzaCarrello.Name = "B_VisualizzaCarrello";
            this.B_VisualizzaCarrello.Size = new System.Drawing.Size(142, 27);
            this.B_VisualizzaCarrello.TabIndex = 7;
            this.B_VisualizzaCarrello.Text = "Visualizza carrello";
            this.B_VisualizzaCarrello.UseVisualStyleBackColor = false;
            this.B_VisualizzaCarrello.Click += new System.EventHandler(this.B_VisualizzaCarrello_Click);
            // 
            // FormSceltaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1023, 493);
            this.Controls.Add(this.B_VisualizzaCarrello);
            this.Controls.Add(this.NumQuantita);
            this.Controls.Add(this.QuantitaLabel);
            this.Controls.Add(this.TabProdotti);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TopPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSceltaCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scelta categoria";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSceltaCategoria_Closed);
            this.Load += new System.EventHandler(this.FormSceltaCategoria_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumQuantita)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel TopPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_VisualizzaOrdini;
        private System.Windows.Forms.Label FastBuyLabel;
        private System.Windows.Forms.TableLayoutPanel TabProdotti;
        private System.Windows.Forms.Label QuantitaLabel;
        private System.Windows.Forms.NumericUpDown NumQuantita;
        private System.Windows.Forms.Button B_VisualizzaCarrello;
    }
}
