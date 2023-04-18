
namespace ScreenToTextApp
{
    partial class ScreenForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CloseAppBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CloseAppBtn
            // 
            this.CloseAppBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CloseAppBtn.FlatAppearance.BorderSize = 0;
            this.CloseAppBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.CloseAppBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseAppBtn.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CloseAppBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CloseAppBtn.Location = new System.Drawing.Point(364, 9);
            this.CloseAppBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloseAppBtn.Name = "CloseAppBtn";
            this.CloseAppBtn.Size = new System.Drawing.Size(45, 45);
            this.CloseAppBtn.TabIndex = 0;
            this.CloseAppBtn.Text = "X";
            this.CloseAppBtn.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CloseAppBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseAppBtn;
    }
}

