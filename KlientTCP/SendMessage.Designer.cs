namespace KlientTCP
{
    partial class SendMessage
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
            this.label1 = new System.Windows.Forms.Label();
            this.receiver_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.message_TextBox = new System.Windows.Forms.RichTextBox();
            this.send_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "adresat:";
            // 
            // receiver_textBox
            // 
            this.receiver_textBox.Location = new System.Drawing.Point(112, 19);
            this.receiver_textBox.Name = "receiver_textBox";
            this.receiver_textBox.Size = new System.Drawing.Size(342, 20);
            this.receiver_textBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "wiadomość:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // message_TextBox
            // 
            this.message_TextBox.Location = new System.Drawing.Point(112, 49);
            this.message_TextBox.Name = "message_TextBox";
            this.message_TextBox.Size = new System.Drawing.Size(342, 224);
            this.message_TextBox.TabIndex = 4;
            this.message_TextBox.Text = "";
            this.message_TextBox.TextChanged += new System.EventHandler(this.message_richTextBox_TextChanged);
            // 
            // send_button
            // 
            this.send_button.Location = new System.Drawing.Point(12, 161);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(94, 99);
            this.send_button.TabIndex = 5;
            this.send_button.Text = "wyślij";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // SendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 285);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.message_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.receiver_textBox);
            this.Controls.Add(this.label1);
            this.Name = "SendMessage";
            this.Text = "SendMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox receiver_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox message_TextBox;
        private System.Windows.Forms.Button send_button;
    }
}