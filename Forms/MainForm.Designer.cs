namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    partial class DashBoard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// "disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            pictureBox1 = new PictureBox();
            pnlSearch = new Panel();
            cmbRecoveryScoreV = new ComboBox();
            btnSearchV = new Button();
            txtSearch = new TextBox();
            dtpToDateV = new DateTimePicker();
            dtpFromDate = new DateTimePicker();
            lblToDateV = new Label();
            label4 = new Label();
            lblRecoveryScoreV = new Label();
            label1 = new Label();
            txtAgeV = new TextBox();
            btnResetV = new Button();
            btnApplyV = new Button();
            label3 = new Label();
            btnGenerate = new Button();
            dgvPet = new DataGridView();
            lblAnimalIdA = new Label();
            label2 = new Label();
            lblSpecies = new Label();
            lblRecoveryScore = new Label();
            lblStatus = new Label();
            label6 = new Label();
            lblAgeA = new Label();
            txtPetID = new TextBox();
            txtAge = new TextBox();
            txtSpecies = new TextBox();
            txtPetName = new TextBox();
            btnSave = new Button();
            btnCancelA = new Button();
            cmbRecoveryScore = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            btnDelete = new Button();
            pnlController = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPet).BeginInit();
            pnlController.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(795, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(458, 416);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = SystemColors.ControlLight;
            pnlSearch.Controls.Add(cmbRecoveryScoreV);
            pnlSearch.Controls.Add(btnSearchV);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(dtpToDateV);
            pnlSearch.Controls.Add(dtpFromDate);
            pnlSearch.Controls.Add(lblToDateV);
            pnlSearch.Controls.Add(label4);
            pnlSearch.Controls.Add(lblRecoveryScoreV);
            pnlSearch.Controls.Add(label1);
            pnlSearch.Controls.Add(txtAgeV);
            pnlSearch.Controls.Add(btnResetV);
            pnlSearch.Controls.Add(btnApplyV);
            pnlSearch.Controls.Add(label3);
            pnlSearch.Location = new Point(795, 453);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(458, 277);
            pnlSearch.TabIndex = 38;
            // 
            // cmbRecoveryScoreV
            // 
            cmbRecoveryScoreV.FormattingEnabled = true;
            cmbRecoveryScoreV.Location = new Point(33, 120);
            cmbRecoveryScoreV.Name = "cmbRecoveryScoreV";
            cmbRecoveryScoreV.Size = new Size(121, 23);
            cmbRecoveryScoreV.TabIndex = 15;
            // 
            // btnSearchV
            // 
            btnSearchV.Location = new Point(162, 41);
            btnSearchV.Name = "btnSearchV";
            btnSearchV.Size = new Size(75, 23);
            btnSearchV.TabIndex = 14;
            btnSearchV.Text = "Search";
            btnSearchV.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(28, 42);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(128, 23);
            txtSearch.TabIndex = 13;
            txtSearch.Text = "Search";
            // 
            // dtpToDateV
            // 
            dtpToDateV.Location = new Point(225, 188);
            dtpToDateV.Name = "dtpToDateV";
            dtpToDateV.Size = new Size(142, 23);
            dtpToDateV.TabIndex = 12;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Location = new Point(28, 188);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(142, 23);
            dtpFromDate.TabIndex = 11;
            // 
            // lblToDateV
            // 
            lblToDateV.AutoSize = true;
            lblToDateV.Location = new Point(225, 170);
            lblToDateV.Name = "lblToDateV";
            lblToDateV.Size = new Size(50, 15);
            lblToDateV.TabIndex = 10;
            lblToDateV.Text = "To Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 170);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 9;
            label4.Text = "From Date:";
            // 
            // lblRecoveryScoreV
            // 
            lblRecoveryScoreV.AutoSize = true;
            lblRecoveryScoreV.Location = new Point(28, 89);
            lblRecoveryScoreV.Name = "lblRecoveryScoreV";
            lblRecoveryScoreV.Size = new Size(87, 15);
            lblRecoveryScoreV.TabIndex = 8;
            lblRecoveryScoreV.Text = "Recovery Score";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(225, 93);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 7;
            label1.Text = "Age";
            // 
            // txtAgeV
            // 
            txtAgeV.Location = new Point(225, 114);
            txtAgeV.Name = "txtAgeV";
            txtAgeV.Size = new Size(100, 23);
            txtAgeV.TabIndex = 6;
            // 
            // btnResetV
            // 
            btnResetV.Location = new Point(225, 246);
            btnResetV.Name = "btnResetV";
            btnResetV.Size = new Size(75, 23);
            btnResetV.TabIndex = 5;
            btnResetV.Text = "Reset";
            btnResetV.UseVisualStyleBackColor = true;
            // 
            // btnApplyV
            // 
            btnApplyV.Location = new Point(101, 246);
            btnApplyV.Name = "btnApplyV";
            btnApplyV.Size = new Size(75, 23);
            btnApplyV.TabIndex = 3;
            btnApplyV.Text = "Apply";
            btnApplyV.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 10);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 0;
            label3.Text = "Search For Pets";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(12, 419);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(154, 23);
            btnGenerate.TabIndex = 40;
            btnGenerate.Text = "Generate Summary";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // dgvPet
            // 
            dgvPet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPet.Location = new Point(12, 453);
            dgvPet.Name = "dgvPet";
            dgvPet.Size = new Size(770, 277);
            dgvPet.TabIndex = 43;
            // 
            // lblAnimalIdA
            // 
            lblAnimalIdA.AutoSize = true;
            lblAnimalIdA.Location = new Point(15, 13);
            lblAnimalIdA.Name = "lblAnimalIdA";
            lblAnimalIdA.Size = new Size(59, 15);
            lblAnimalIdA.TabIndex = 21;
            lblAnimalIdA.Text = "Animal ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 62);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 22;
            label2.Text = "Pet Name";
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(15, 113);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(46, 15);
            lblSpecies.TabIndex = 23;
            lblSpecies.Text = "Species";
            // 
            // lblRecoveryScore
            // 
            lblRecoveryScore.AutoSize = true;
            lblRecoveryScore.Location = new Point(15, 216);
            lblRecoveryScore.Name = "lblRecoveryScore";
            lblRecoveryScore.Size = new Size(87, 15);
            lblRecoveryScore.TabIndex = 24;
            lblRecoveryScore.Text = "Recovery Score";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(15, 261);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 25;
            lblStatus.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 306);
            label6.Name = "label6";
            label6.Size = new Size(77, 15);
            label6.TabIndex = 26;
            label6.Text = "Housing Unit";
            // 
            // lblAgeA
            // 
            lblAgeA.AutoSize = true;
            lblAgeA.Location = new Point(15, 160);
            lblAgeA.Name = "lblAgeA";
            lblAgeA.Size = new Size(28, 15);
            lblAgeA.TabIndex = 27;
            lblAgeA.Text = "Age";
            // 
            // txtPetID
            // 
            txtPetID.Location = new Point(134, 13);
            txtPetID.Name = "txtPetID";
            txtPetID.Size = new Size(100, 23);
            txtPetID.TabIndex = 28;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(134, 153);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(100, 23);
            txtAge.TabIndex = 29;
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(134, 105);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(100, 23);
            txtSpecies.TabIndex = 30;
            // 
            // txtPetName
            // 
            txtPetName.Location = new Point(134, 62);
            txtPetName.Name = "txtPetName";
            txtPetName.Size = new Size(100, 23);
            txtPetName.TabIndex = 31;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(117, 355);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(102, 23);
            btnSave.TabIndex = 32;
            btnSave.Text = "Save changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancelA
            // 
            btnCancelA.BackColor = Color.IndianRed;
            btnCancelA.Location = new Point(241, 355);
            btnCancelA.Name = "btnCancelA";
            btnCancelA.Size = new Size(75, 23);
            btnCancelA.TabIndex = 33;
            btnCancelA.Text = "Cancel";
            btnCancelA.UseVisualStyleBackColor = false;
            // 
            // cmbRecoveryScore
            // 
            cmbRecoveryScore.FormattingEnabled = true;
            cmbRecoveryScore.Location = new Point(134, 213);
            cmbRecoveryScore.Name = "cmbRecoveryScore";
            cmbRecoveryScore.Size = new Size(121, 23);
            cmbRecoveryScore.TabIndex = 34;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(134, 253);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 35;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(134, 298);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 36;
            // 
            // button1
            // 
            button1.Location = new Point(15, 355);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 39;
            button1.Text = "Add Pet";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(340, 355);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(102, 23);
            btnDelete.TabIndex = 41;
            btnDelete.Text = "Delete Pet";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // pnlController
            // 
            pnlController.BackColor = SystemColors.ControlLight;
            pnlController.Controls.Add(txtSpecies);
            pnlController.Controls.Add(lblAnimalIdA);
            pnlController.Controls.Add(btnDelete);
            pnlController.Controls.Add(label2);
            pnlController.Controls.Add(lblSpecies);
            pnlController.Controls.Add(button1);
            pnlController.Controls.Add(lblRecoveryScore);
            pnlController.Controls.Add(lblStatus);
            pnlController.Controls.Add(textBox2);
            pnlController.Controls.Add(label6);
            pnlController.Controls.Add(textBox1);
            pnlController.Controls.Add(lblAgeA);
            pnlController.Controls.Add(cmbRecoveryScore);
            pnlController.Controls.Add(txtPetID);
            pnlController.Controls.Add(btnCancelA);
            pnlController.Controls.Add(txtAge);
            pnlController.Controls.Add(btnSave);
            pnlController.Controls.Add(txtPetName);
            pnlController.Location = new Point(12, 12);
            pnlController.Name = "pnlController";
            pnlController.Size = new Size(451, 392);
            pnlController.TabIndex = 44;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(pnlController);
            Controls.Add(dgvPet);
            Controls.Add(btnGenerate);
            Controls.Add(pnlSearch);
            Controls.Add(pictureBox1);
            Margin = new Padding(2);
            Name = "DashBoard";
            Text = "DashBoard";
            Load += DashBoard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPet).EndInit();
            pnlController.ResumeLayout(false);
            pnlController.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Panel pnlSearch;
        private ComboBox cmbRecoveryScoreV;
        private Button btnSearchV;
        private TextBox txtSearch;
        private DateTimePicker dtpToDateV;
        private DateTimePicker dtpFromDate;
        private Label lblToDateV;
        private Label label4;
        private Label lblRecoveryScoreV;
        private Label label1;
        private TextBox txtAgeV;
        private Button btnResetV;
        private Button btnApplyV;
        private Label label3;
        private Button btnGenerate;
        private Label lblout;
        private DataGridView dgvPet;
        private Label lblAnimalIdA;
        private Label label2;
        private Label lblSpecies;
        private Label lblRecoveryScore;
        private Label lblStatus;
        private Label label6;
        private Label lblAgeA;
        private TextBox txtPetID;
        private TextBox txtAge;
        private TextBox txtSpecies;
        private TextBox txtPetName;
        private Button btnSave;
        private Button btnCancelA;
        private ComboBox cmbRecoveryScore;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button btnDelete;
        private Panel pnlController;
    }
}
