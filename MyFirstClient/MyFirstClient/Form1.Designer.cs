namespace MyFirstClient
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnUpload = new System.Windows.Forms.Button();
            this.BtnDownExe = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.TxtShell = new System.Windows.Forms.TextBox();
            this.TxtCommand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblCo = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BtnDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnUpload
            // 
            this.BtnUpload.Font = new System.Drawing.Font("Segoe Print", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUpload.Location = new System.Drawing.Point(8, 1);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(75, 47);
            this.BtnUpload.TabIndex = 0;
            this.BtnUpload.Text = "UPLOAD";
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // BtnDownExe
            // 
            this.BtnDownExe.Font = new System.Drawing.Font("Segoe Print", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDownExe.Location = new System.Drawing.Point(8, 159);
            this.BtnDownExe.Name = "BtnDownExe";
            this.BtnDownExe.Size = new System.Drawing.Size(75, 47);
            this.BtnDownExe.TabIndex = 1;
            this.BtnDownExe.Text = "DL/EXE";
            this.BtnDownExe.UseVisualStyleBackColor = true;
            this.BtnDownExe.Click += new System.EventHandler(this.BtnDownExe_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Font = new System.Drawing.Font("Segoe Print", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.Location = new System.Drawing.Point(8, 320);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 47);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "EXIT";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // TxtShell
            // 
            this.TxtShell.BackColor = System.Drawing.SystemColors.MenuText;
            this.TxtShell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtShell.ForeColor = System.Drawing.Color.LimeGreen;
            this.TxtShell.Location = new System.Drawing.Point(89, 1);
            this.TxtShell.Multiline = true;
            this.TxtShell.Name = "TxtShell";
            this.TxtShell.ReadOnly = true;
            this.TxtShell.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtShell.Size = new System.Drawing.Size(711, 366);
            this.TxtShell.TabIndex = 3;
            // 
            // TxtCommand
            // 
            this.TxtCommand.Location = new System.Drawing.Point(89, 373);
            this.TxtCommand.Name = "TxtCommand";
            this.TxtCommand.Size = new System.Drawing.Size(711, 20);
            this.TxtCommand.TabIndex = 4;
            this.TxtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCommand_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "CMD/";
            // 
            // LblCo
            // 
            this.LblCo.AutoSize = true;
            this.LblCo.Location = new System.Drawing.Point(95, 417);
            this.LblCo.Name = "LblCo";
            this.LblCo.Size = new System.Drawing.Size(35, 13);
            this.LblCo.TabIndex = 7;
            this.LblCo.Text = "label2";
            // 
            // BtnDownload
            // 
            this.BtnDownload.Font = new System.Drawing.Font("Segoe Print", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDownload.Location = new System.Drawing.Point(8, 76);
            this.BtnDownload.Name = "BtnDownload";
            this.BtnDownload.Size = new System.Drawing.Size(75, 56);
            this.BtnDownload.TabIndex = 8;
            this.BtnDownload.Text = "DOWNLOAD";
            this.BtnDownload.UseVisualStyleBackColor = true;
            this.BtnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 447);
            this.Controls.Add(this.BtnDownload);
            this.Controls.Add(this.LblCo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCommand);
            this.Controls.Add(this.TxtShell);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnDownExe);
            this.Controls.Add(this.BtnUpload);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Button BtnDownExe;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.TextBox TxtShell;
        private System.Windows.Forms.TextBox TxtCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblCo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button BtnDownload;
    }
}

