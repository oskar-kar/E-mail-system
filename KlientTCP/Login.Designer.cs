namespace KlientTCP
{
    partial class Login
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.messages_listBox = new System.Windows.Forms.ListBox();
            this.change_password_button = new System.Windows.Forms.Button();
            this.send_message_button = new System.Windows.Forms.Button();
            this.download_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtLogin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "dane logowania";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(55, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(130, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(55, 28);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(130, 20);
            this.txtLogin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "hasło:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "login:";
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.login_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.login_button.Location = new System.Drawing.Point(40, 136);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(184, 35);
            this.login_button.TabIndex = 3;
            this.login_button.Text = "zaloguj";
            this.login_button.UseVisualStyleBackColor = false;
            // 
            // messages_listBox
            // 
            this.messages_listBox.FormattingEnabled = true;
            this.messages_listBox.Location = new System.Drawing.Point(263, 13);
            this.messages_listBox.Name = "messages_listBox";
            this.messages_listBox.Size = new System.Drawing.Size(300, 342);
            this.messages_listBox.TabIndex = 4;
            // 
            // change_password_button
            // 
            this.change_password_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.change_password_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.change_password_button.Location = new System.Drawing.Point(40, 189);
            this.change_password_button.Name = "change_password_button";
            this.change_password_button.Size = new System.Drawing.Size(184, 35);
            this.change_password_button.TabIndex = 5;
            this.change_password_button.Text = "zmień hasło";
            this.change_password_button.UseVisualStyleBackColor = false;
            // 
            // send_message_button
            // 
            this.send_message_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.send_message_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.send_message_button.Location = new System.Drawing.Point(40, 304);
            this.send_message_button.Name = "send_message_button";
            this.send_message_button.Size = new System.Drawing.Size(184, 51);
            this.send_message_button.TabIndex = 6;
            this.send_message_button.Text = "napisz wiadomość";
            this.send_message_button.UseVisualStyleBackColor = false;
            this.send_message_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // download_button
            // 
            this.download_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.download_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.download_button.Location = new System.Drawing.Point(40, 246);
            this.download_button.Name = "download_button";
            this.download_button.Size = new System.Drawing.Size(184, 35);
            this.download_button.TabIndex = 7;
            this.download_button.Text = "pobierz wiadomości";
            this.download_button.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 375);
            this.Controls.Add(this.download_button);
            this.Controls.Add(this.send_message_button);
            this.Controls.Add(this.change_password_button);
            this.Controls.Add(this.messages_listBox);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.groupBox1);
            this.Name = "Login";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.ListBox messages_listBox;
        private System.Windows.Forms.Button change_password_button;
        private System.Windows.Forms.Button send_message_button;
        private System.Windows.Forms.Button download_button;
    }
}