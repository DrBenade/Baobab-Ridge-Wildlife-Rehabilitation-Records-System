namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Forms
{
    partial class Welcompage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcompage));
            pictureBox1 = new PictureBox();
            btnWelcomeLogin = new Button();
            lblWelcome = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(139, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(496, 430);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnWelcomeLogin
            // 
            btnWelcomeLogin.Location = new Point(336, 485);
            btnWelcomeLogin.Name = "btnWelcomeLogin";
            btnWelcomeLogin.Size = new Size(75, 23);
            btnWelcomeLogin.TabIndex = 1;
            btnWelcomeLogin.Text = "Login";
            btnWelcomeLogin.UseVisualStyleBackColor = true;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(336, 18);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(57, 15);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome";
            // 
            // Welcompage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 520);
            Controls.Add(lblWelcome);
            Controls.Add(btnWelcomeLogin);
            Controls.Add(pictureBox1);
            Name = "Welcompage";
            Text = "Welcompage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnWelcomeLogin;
        private Label lblWelcome;
    }
}