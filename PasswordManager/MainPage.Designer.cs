namespace PasswordManager
{
    partial class MainPage
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
            this.accountsInfo = new System.Windows.Forms.Button();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accountsInfo
            // 
            this.accountsInfo.Location = new System.Drawing.Point(21, 33);
            this.accountsInfo.Name = "accountsInfo";
            this.accountsInfo.Size = new System.Drawing.Size(171, 29);
            this.accountsInfo.TabIndex = 0;
            this.accountsInfo.Text = "Accounts Info";
            this.accountsInfo.UseVisualStyleBackColor = true;
            this.accountsInfo.Click += new System.EventHandler(this.accountsInfo_Click);
            // 
            // createAccountButton
            // 
            this.createAccountButton.Location = new System.Drawing.Point(219, 33);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Size = new System.Drawing.Size(188, 29);
            this.createAccountButton.TabIndex = 1;
            this.createAccountButton.Text = "Add New Account";
            this.createAccountButton.UseVisualStyleBackColor = true;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(451, 33);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(117, 29);
            this.aboutButton.TabIndex = 2;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(630, 33);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 29);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.createAccountButton);
            this.Controls.Add(this.accountsInfo);
            this.Name = "MainPage";
            this.Text = "Password Manager";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button accountsInfo;
        private System.Windows.Forms.Button createAccountButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button closeButton;
    }
}

