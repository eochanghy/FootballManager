
namespace ProjectPRN_ManagerSoccer
{
    partial class SubPlayer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.ptImage = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.Label();
            this.btnSwap = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panel1.Controls.Add(this.ptImage);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 116);
            this.panel1.TabIndex = 0;
            // 
            // ptImage
            // 
            this.ptImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptImage.Location = new System.Drawing.Point(10, 14);
            this.ptImage.Name = "ptImage";
            this.ptImage.Size = new System.Drawing.Size(95, 88);
            this.ptImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptImage.TabIndex = 0;
            this.ptImage.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtName.Location = new System.Drawing.Point(137, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(75, 24);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "Rooney";
            // 
            // btnSwap
            // 
            this.btnSwap.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnSwap.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwap.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSwap.Location = new System.Drawing.Point(141, 55);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(71, 35);
            this.btnSwap.TabIndex = 2;
            this.btnSwap.Text = "SWAP";
            this.btnSwap.UseVisualStyleBackColor = false;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCancel.Location = new System.Drawing.Point(218, 55);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // SubPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.panel1);
            this.Name = "SubPlayer";
            this.Size = new System.Drawing.Size(325, 116);
            this.Load += new System.EventHandler(this.SubPlayer_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox ptImage;
        public System.Windows.Forms.Label txtName;
        public System.Windows.Forms.Button btnSwap;
        public System.Windows.Forms.Button btnCancel;
    }
}
