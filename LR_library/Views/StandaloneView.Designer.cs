
namespace LR_library.Views
{
    partial class StandaloneView
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
            this.groupBoxForm = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // groupBoxForm
            // 
            this.groupBoxForm.AutoSize = true;
            this.groupBoxForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxForm.Location = new System.Drawing.Point(0, 0);
            this.groupBoxForm.Margin = new System.Windows.Forms.Padding(20);
            this.groupBoxForm.Name = "groupBoxForm";
            this.groupBoxForm.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxForm.Size = new System.Drawing.Size(361, 169);
            this.groupBoxForm.TabIndex = 0;
            this.groupBoxForm.TabStop = false;
            // 
            // StandaloneView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(361, 169);
            this.Controls.Add(this.groupBoxForm);
            this.Name = "StandaloneView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StandaloneView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StandaloneView_FormClosed);
            this.Load += new System.EventHandler(this.StandaloneView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxForm;
    }
}