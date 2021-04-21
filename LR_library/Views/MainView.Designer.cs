
namespace LR_library
{
    partial class MainView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRegister = new System.Windows.Forms.TabPage();
            this.linkLabelResetPassword = new System.Windows.Forms.LinkLabel();
            this.tabPageSign = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageRegister);
            this.tabControl1.Controls.Add(this.tabPageSign);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(421, 506);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageRegister
            // 
            this.tabPageRegister.AutoScroll = true;
            this.tabPageRegister.Controls.Add(this.linkLabelResetPassword);
            this.tabPageRegister.Location = new System.Drawing.Point(4, 27);
            this.tabPageRegister.Name = "tabPageRegister";
            this.tabPageRegister.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRegister.Size = new System.Drawing.Size(413, 475);
            this.tabPageRegister.TabIndex = 0;
            this.tabPageRegister.Text = "Зарегистрироваться";
            this.tabPageRegister.UseVisualStyleBackColor = true;
            // 
            // linkLabelResetPassword
            // 
            this.linkLabelResetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelResetPassword.AutoSize = true;
            this.linkLabelResetPassword.Location = new System.Drawing.Point(263, 454);
            this.linkLabelResetPassword.Name = "linkLabelResetPassword";
            this.linkLabelResetPassword.Size = new System.Drawing.Size(144, 18);
            this.linkLabelResetPassword.TabIndex = 0;
            this.linkLabelResetPassword.TabStop = true;
            this.linkLabelResetPassword.Text = "Забыли пароль?";
            this.linkLabelResetPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelResetPassword_LinkClicked);
            // 
            // tabPageSign
            // 
            this.tabPageSign.AutoScroll = true;
            this.tabPageSign.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageSign.Location = new System.Drawing.Point(4, 27);
            this.tabPageSign.Name = "tabPageSign";
            this.tabPageSign.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSign.Size = new System.Drawing.Size(413, 475);
            this.tabPageSign.TabIndex = 1;
            this.tabPageSign.Text = "Войти";
            this.tabPageSign.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 530);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRegister.ResumeLayout(false);
            this.tabPageRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRegister;
        private System.Windows.Forms.TabPage tabPageSign;
        private System.Windows.Forms.LinkLabel linkLabelResetPassword;
    }
}

