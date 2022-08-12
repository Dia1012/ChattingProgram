
namespace Client
{
    partial class ClientChat
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
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.SendBox = new System.Windows.Forms.TextBox();
            this.Sender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ChatBox.Cursor = System.Windows.Forms.Cursors.No;
            this.ChatBox.Location = new System.Drawing.Point(12, 12);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ChatBox.Size = new System.Drawing.Size(776, 393);
            this.ChatBox.TabIndex = 0;
            // 
            // SendBox
            // 
            this.SendBox.Location = new System.Drawing.Point(12, 417);
            this.SendBox.Name = "SendBox";
            this.SendBox.Size = new System.Drawing.Size(685, 21);
            this.SendBox.TabIndex = 1;
            // 
            // Sender
            // 
            this.Sender.Location = new System.Drawing.Point(703, 415);
            this.Sender.Name = "Sender";
            this.Sender.Size = new System.Drawing.Size(85, 23);
            this.Sender.TabIndex = 2;
            this.Sender.Text = "Send!";
            this.Sender.UseVisualStyleBackColor = true;
            this.Sender.Click += new System.EventHandler(this.Sender_Click);
            // 
            // ClientChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Sender);
            this.Controls.Add(this.SendBox);
            this.Controls.Add(this.ChatBox);
            this.Name = "ClientChat";
            this.Text = "Chatting!";
            this.Load += new System.EventHandler(this.ClientChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.TextBox SendBox;
        private System.Windows.Forms.Button Sender;
    }
}