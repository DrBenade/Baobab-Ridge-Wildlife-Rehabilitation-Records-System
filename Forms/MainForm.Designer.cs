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
            pbxShelter = new PictureBox();
            pnlSearch = new Panel();
            btnSearchName = new Button();
            btnSearchSpecies = new Button();
            btnSearchAge = new Button();
            btnSearchRecovery = new Button();
            cmbSpeciesSearch = new ComboBox();
            txtSearchName = new TextBox();
            txtSearchAge = new TextBox();
            lblIDSearch = new Label();
            lblNameSearch = new Label();
            lblSpeciesSearch = new Label();
            cmbRecoveryScoreSearch = new ComboBox();
            btnSearchID = new Button();
            txtSearchID = new TextBox();
            lblSearchRecoveryScore = new Label();
            lblAgeSearch = new Label();
            btnResetSearch = new Button();
            lblSearchHeading = new Label();
            btnGenerateSummary = new Button();
            dgvPet = new DataGridView();
            lblAnimalID = new Label();
            lblPetName = new Label();
            lblSpecies = new Label();
            lblRecoveryScore = new Label();
            lblStatus = new Label();
            lblHousingUnit = new Label();
            lblAge = new Label();
            txtPetID = new TextBox();
            txtAge = new TextBox();
            txtSpecies = new TextBox();
            txtPetName = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            txtRecoveryScore = new TextBox();
            txtStatus = new TextBox();
            txtHousingUnit = new TextBox();
            btnAddPet = new Button();
            btnDelete = new Button();
            pnlController = new Panel();
            btnAutoFillID = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)pbxShelter).BeginInit();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPet).BeginInit();
            pnlController.SuspendLayout();
            SuspendLayout();
            // 
            // pbxShelter
            // 
            pbxShelter.Image = (Image)resources.GetObject("pbxShelter.Image");
            pbxShelter.Location = new Point(1250, 32);
            pbxShelter.Margin = new Padding(4, 5, 4, 5);
            pbxShelter.Name = "pbxShelter";
            pbxShelter.Size = new Size(719, 637);
            pbxShelter.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxShelter.TabIndex = 1;
            pbxShelter.TabStop = false;
            pbxShelter.Click += pbxShelter_Click;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = SystemColors.ControlLight;
            pnlSearch.Controls.Add(btnExit);
            pnlSearch.Controls.Add(btnSearchName);
            pnlSearch.Controls.Add(btnSearchSpecies);
            pnlSearch.Controls.Add(btnSearchAge);
            pnlSearch.Controls.Add(btnSearchRecovery);
            pnlSearch.Controls.Add(cmbSpeciesSearch);
            pnlSearch.Controls.Add(txtSearchName);
            pnlSearch.Controls.Add(txtSearchAge);
            pnlSearch.Controls.Add(lblIDSearch);
            pnlSearch.Controls.Add(lblNameSearch);
            pnlSearch.Controls.Add(lblSpeciesSearch);
            pnlSearch.Controls.Add(cmbRecoveryScoreSearch);
            pnlSearch.Controls.Add(btnSearchID);
            pnlSearch.Controls.Add(txtSearchID);
            pnlSearch.Controls.Add(lblSearchRecoveryScore);
            pnlSearch.Controls.Add(lblAgeSearch);
            pnlSearch.Controls.Add(btnResetSearch);
            pnlSearch.Controls.Add(lblSearchHeading);
            pnlSearch.Location = new Point(1250, 695);
            pnlSearch.Margin = new Padding(4, 5, 4, 5);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(719, 468);
            pnlSearch.TabIndex = 38;
            // 
            // btnSearchName
            // 
            btnSearchName.Font = new Font("Cambria", 11F);
            btnSearchName.Location = new Point(578, 130);
            btnSearchName.Margin = new Padding(4, 5, 4, 5);
            btnSearchName.Name = "btnSearchName";
            btnSearchName.Size = new Size(118, 35);
            btnSearchName.TabIndex = 26;
            btnSearchName.Text = "Search";
            btnSearchName.UseVisualStyleBackColor = true;
            btnSearchName.Click += btnSearchName_Click;
            // 
            // btnSearchSpecies
            // 
            btnSearchSpecies.Font = new Font("Cambria", 11F);
            btnSearchSpecies.Location = new Point(578, 183);
            btnSearchSpecies.Margin = new Padding(4, 5, 4, 5);
            btnSearchSpecies.Name = "btnSearchSpecies";
            btnSearchSpecies.Size = new Size(118, 35);
            btnSearchSpecies.TabIndex = 25;
            btnSearchSpecies.Text = "Search";
            btnSearchSpecies.UseVisualStyleBackColor = true;
            btnSearchSpecies.Click += btnSearchSpecies_Click;
            // 
            // btnSearchAge
            // 
            btnSearchAge.Font = new Font("Cambria", 11F);
            btnSearchAge.Location = new Point(578, 234);
            btnSearchAge.Margin = new Padding(4, 5, 4, 5);
            btnSearchAge.Name = "btnSearchAge";
            btnSearchAge.Size = new Size(118, 35);
            btnSearchAge.TabIndex = 24;
            btnSearchAge.Text = "Search";
            btnSearchAge.UseVisualStyleBackColor = true;
            btnSearchAge.Click += btnSearchAge_Click;
            // 
            // btnSearchRecovery
            // 
            btnSearchRecovery.Font = new Font("Cambria", 11F);
            btnSearchRecovery.Location = new Point(578, 286);
            btnSearchRecovery.Margin = new Padding(4, 5, 4, 5);
            btnSearchRecovery.Name = "btnSearchRecovery";
            btnSearchRecovery.Size = new Size(118, 35);
            btnSearchRecovery.TabIndex = 23;
            btnSearchRecovery.Text = "Search";
            btnSearchRecovery.UseVisualStyleBackColor = true;
            btnSearchRecovery.Click += btnSearchRecovery_Click;
            // 
            // cmbSpeciesSearch
            // 
            cmbSpeciesSearch.Font = new Font("Cambria", 11F);
            cmbSpeciesSearch.FormattingEnabled = true;
            cmbSpeciesSearch.Location = new Point(253, 180);
            cmbSpeciesSearch.Margin = new Padding(4, 5, 4, 5);
            cmbSpeciesSearch.Name = "cmbSpeciesSearch";
            cmbSpeciesSearch.Size = new Size(307, 34);
            cmbSpeciesSearch.TabIndex = 22;
            // 
            // txtSearchName
            // 
            txtSearchName.Font = new Font("Cambria", 11F);
            txtSearchName.Location = new Point(253, 130);
            txtSearchName.Margin = new Padding(4, 5, 4, 5);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(307, 33);
            txtSearchName.TabIndex = 21;
            // 
            // txtSearchAge
            // 
            txtSearchAge.Font = new Font("Cambria", 11F);
            txtSearchAge.Location = new Point(253, 235);
            txtSearchAge.Margin = new Padding(4, 5, 4, 5);
            txtSearchAge.Name = "txtSearchAge";
            txtSearchAge.Size = new Size(307, 33);
            txtSearchAge.TabIndex = 20;
            // 
            // lblIDSearch
            // 
            lblIDSearch.AutoSize = true;
            lblIDSearch.Font = new Font("Cambria", 11F);
            lblIDSearch.Location = new Point(44, 80);
            lblIDSearch.Margin = new Padding(4, 0, 4, 0);
            lblIDSearch.Name = "lblIDSearch";
            lblIDSearch.Size = new Size(69, 26);
            lblIDSearch.TabIndex = 19;
            lblIDSearch.Text = "By ID:";
            // 
            // lblNameSearch
            // 
            lblNameSearch.AutoSize = true;
            lblNameSearch.Font = new Font("Cambria", 11F);
            lblNameSearch.Location = new Point(44, 133);
            lblNameSearch.Margin = new Padding(4, 0, 4, 0);
            lblNameSearch.Name = "lblNameSearch";
            lblNameSearch.Size = new Size(102, 26);
            lblNameSearch.TabIndex = 18;
            lblNameSearch.Text = "By Name:";
            // 
            // lblSpeciesSearch
            // 
            lblSpeciesSearch.AutoSize = true;
            lblSpeciesSearch.Font = new Font("Cambria", 11F);
            lblSpeciesSearch.Location = new Point(44, 187);
            lblSpeciesSearch.Margin = new Padding(4, 0, 4, 0);
            lblSpeciesSearch.Name = "lblSpeciesSearch";
            lblSpeciesSearch.Size = new Size(117, 26);
            lblSpeciesSearch.TabIndex = 17;
            lblSpeciesSearch.Text = "By Species:";
            // 
            // cmbRecoveryScoreSearch
            // 
            cmbRecoveryScoreSearch.Font = new Font("Cambria", 11F);
            cmbRecoveryScoreSearch.FormattingEnabled = true;
            cmbRecoveryScoreSearch.Items.AddRange(new object[] { "0-19", "20-39", "40-59", "60-79", "80-100" });
            cmbRecoveryScoreSearch.Location = new Point(253, 287);
            cmbRecoveryScoreSearch.Margin = new Padding(4, 5, 4, 5);
            cmbRecoveryScoreSearch.Name = "cmbRecoveryScoreSearch";
            cmbRecoveryScoreSearch.Size = new Size(307, 34);
            cmbRecoveryScoreSearch.TabIndex = 15;
            // 
            // btnSearchID
            // 
            btnSearchID.Font = new Font("Cambria", 11F);
            btnSearchID.Location = new Point(578, 76);
            btnSearchID.Margin = new Padding(4, 5, 4, 5);
            btnSearchID.Name = "btnSearchID";
            btnSearchID.Size = new Size(118, 35);
            btnSearchID.TabIndex = 14;
            btnSearchID.Text = "Search";
            btnSearchID.UseVisualStyleBackColor = true;
            btnSearchID.Click += btnSearchID_Click;
            // 
            // txtSearchID
            // 
            txtSearchID.Font = new Font("Cambria", 11F);
            txtSearchID.Location = new Point(253, 77);
            txtSearchID.Margin = new Padding(4, 5, 4, 5);
            txtSearchID.Name = "txtSearchID";
            txtSearchID.Size = new Size(307, 33);
            txtSearchID.TabIndex = 13;
            // 
            // lblSearchRecoveryScore
            // 
            lblSearchRecoveryScore.AutoSize = true;
            lblSearchRecoveryScore.Font = new Font("Cambria", 11F);
            lblSearchRecoveryScore.Location = new Point(44, 290);
            lblSearchRecoveryScore.Margin = new Padding(4, 0, 4, 0);
            lblSearchRecoveryScore.Name = "lblSearchRecoveryScore";
            lblSearchRecoveryScore.Size = new Size(194, 26);
            lblSearchRecoveryScore.TabIndex = 8;
            lblSearchRecoveryScore.Text = "By Recovery Score:";
            // 
            // lblAgeSearch
            // 
            lblAgeSearch.AutoSize = true;
            lblAgeSearch.Font = new Font("Cambria", 11F);
            lblAgeSearch.Location = new Point(44, 238);
            lblAgeSearch.Margin = new Padding(4, 0, 4, 0);
            lblAgeSearch.Name = "lblAgeSearch";
            lblAgeSearch.Size = new Size(83, 26);
            lblAgeSearch.TabIndex = 7;
            lblAgeSearch.Text = "By Age:";
            // 
            // btnResetSearch
            // 
            btnResetSearch.Font = new Font("Cambria", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResetSearch.Location = new Point(44, 369);
            btnResetSearch.Margin = new Padding(4, 5, 4, 5);
            btnResetSearch.Name = "btnResetSearch";
            btnResetSearch.Size = new Size(275, 54);
            btnResetSearch.TabIndex = 5;
            btnResetSearch.Text = "Reset Output";
            btnResetSearch.UseVisualStyleBackColor = true;
            btnResetSearch.Click += btnResetSearch_Click;
            // 
            // lblSearchHeading
            // 
            lblSearchHeading.AutoSize = true;
            lblSearchHeading.Font = new Font("Cambria", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearchHeading.Location = new Point(44, 25);
            lblSearchHeading.Margin = new Padding(4, 0, 4, 0);
            lblSearchHeading.Name = "lblSearchHeading";
            lblSearchHeading.Size = new Size(219, 33);
            lblSearchHeading.TabIndex = 0;
            lblSearchHeading.Text = "Search For Pets:";
            // 
            // btnGenerateSummary
            // 
            btnGenerateSummary.Location = new Point(19, 642);
            btnGenerateSummary.Margin = new Padding(4, 5, 4, 5);
            btnGenerateSummary.Name = "btnGenerateSummary";
            btnGenerateSummary.Size = new Size(242, 35);
            btnGenerateSummary.TabIndex = 40;
            btnGenerateSummary.Text = "Generate Summary";
            btnGenerateSummary.UseVisualStyleBackColor = true;
            btnGenerateSummary.Click += btnGenerateSummary_Click;
            // 
            // dgvPet
            // 
            dgvPet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPet.Location = new Point(19, 695);
            dgvPet.Margin = new Padding(4, 5, 4, 5);
            dgvPet.Name = "dgvPet";
            dgvPet.RowHeadersWidth = 62;
            dgvPet.Size = new Size(1210, 468);
            dgvPet.TabIndex = 43;
            dgvPet.CellClick += dgvPet_CellClick;
            // 
            // lblAnimalID
            // 
            lblAnimalID.AutoSize = true;
            lblAnimalID.Location = new Point(21, 23);
            lblAnimalID.Margin = new Padding(4, 0, 4, 0);
            lblAnimalID.Name = "lblAnimalID";
            lblAnimalID.Size = new Size(99, 23);
            lblAnimalID.TabIndex = 21;
            lblAnimalID.Text = "Animal ID:";
            // 
            // lblPetName
            // 
            lblPetName.AutoSize = true;
            lblPetName.Location = new Point(23, 94);
            lblPetName.Margin = new Padding(4, 0, 4, 0);
            lblPetName.Name = "lblPetName";
            lblPetName.Size = new Size(98, 23);
            lblPetName.TabIndex = 22;
            lblPetName.Text = "Pet Name:";
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(23, 173);
            lblSpecies.Margin = new Padding(4, 0, 4, 0);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(80, 23);
            lblSpecies.TabIndex = 23;
            lblSpecies.Text = "Species:";
            // 
            // lblRecoveryScore
            // 
            lblRecoveryScore.AutoSize = true;
            lblRecoveryScore.Location = new Point(23, 331);
            lblRecoveryScore.Margin = new Padding(4, 0, 4, 0);
            lblRecoveryScore.Name = "lblRecoveryScore";
            lblRecoveryScore.Size = new Size(147, 23);
            lblRecoveryScore.TabIndex = 24;
            lblRecoveryScore.Text = "Recovery Score:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(23, 400);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(69, 23);
            lblStatus.TabIndex = 25;
            lblStatus.Text = "Status:";
            // 
            // lblHousingUnit
            // 
            lblHousingUnit.AutoSize = true;
            lblHousingUnit.Location = new Point(23, 469);
            lblHousingUnit.Margin = new Padding(4, 0, 4, 0);
            lblHousingUnit.Name = "lblHousingUnit";
            lblHousingUnit.Size = new Size(128, 23);
            lblHousingUnit.TabIndex = 26;
            lblHousingUnit.Text = "Housing Unit:";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(23, 246);
            lblAge.Margin = new Padding(4, 0, 4, 0);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(47, 23);
            lblAge.TabIndex = 27;
            lblAge.Text = "Age:";
            // 
            // txtPetID
            // 
            txtPetID.Location = new Point(210, 21);
            txtPetID.Margin = new Padding(4, 5, 4, 5);
            txtPetID.Name = "txtPetID";
            txtPetID.Size = new Size(286, 31);
            txtPetID.TabIndex = 28;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(210, 235);
            txtAge.Margin = new Padding(4, 5, 4, 5);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(286, 31);
            txtAge.TabIndex = 29;
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(210, 161);
            txtSpecies.Margin = new Padding(4, 5, 4, 5);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(286, 31);
            txtSpecies.TabIndex = 30;
            // 
            // txtPetName
            // 
            txtPetName.Location = new Point(210, 94);
            txtPetName.Margin = new Padding(4, 5, 4, 5);
            txtPetName.Name = "txtPetName";
            txtPetName.Size = new Size(286, 31);
            txtPetName.TabIndex = 31;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(184, 545);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(161, 35);
            btnSave.TabIndex = 32;
            btnSave.Text = "Save changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Location = new Point(378, 545);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(118, 35);
            btnCancel.TabIndex = 33;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtRecoveryScore
            // 
            txtRecoveryScore.Location = new Point(210, 327);
            txtRecoveryScore.Margin = new Padding(4, 5, 4, 5);
            txtRecoveryScore.Name = "txtRecoveryScore";
            txtRecoveryScore.Size = new Size(286, 31);
            txtRecoveryScore.TabIndex = 34;
            // 
            // txtStatus
            // 
            txtStatus.Enabled = false;
            txtStatus.Location = new Point(210, 389);
            txtStatus.Margin = new Padding(4, 5, 4, 5);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(286, 31);
            txtStatus.TabIndex = 35;
            // 
            // txtHousingUnit
            // 
            txtHousingUnit.Enabled = false;
            txtHousingUnit.Location = new Point(210, 458);
            txtHousingUnit.Margin = new Padding(4, 5, 4, 5);
            txtHousingUnit.Name = "txtHousingUnit";
            txtHousingUnit.Size = new Size(286, 31);
            txtHousingUnit.TabIndex = 36;
            // 
            // btnAddPet
            // 
            btnAddPet.Location = new Point(23, 545);
            btnAddPet.Margin = new Padding(4, 5, 4, 5);
            btnAddPet.Name = "btnAddPet";
            btnAddPet.Size = new Size(118, 35);
            btnAddPet.TabIndex = 39;
            btnAddPet.Text = "Add Pet";
            btnAddPet.UseVisualStyleBackColor = true;
            btnAddPet.Click += btnAddPet_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(535, 545);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(161, 35);
            btnDelete.TabIndex = 41;
            btnDelete.Text = "Delete Pet";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // pnlController
            // 
            pnlController.BackColor = SystemColors.ControlLight;
            pnlController.Controls.Add(btnAutoFillID);
            pnlController.Controls.Add(txtSpecies);
            pnlController.Controls.Add(lblAnimalID);
            pnlController.Controls.Add(btnDelete);
            pnlController.Controls.Add(lblPetName);
            pnlController.Controls.Add(lblSpecies);
            pnlController.Controls.Add(btnAddPet);
            pnlController.Controls.Add(lblRecoveryScore);
            pnlController.Controls.Add(lblStatus);
            pnlController.Controls.Add(txtHousingUnit);
            pnlController.Controls.Add(lblHousingUnit);
            pnlController.Controls.Add(txtStatus);
            pnlController.Controls.Add(lblAge);
            pnlController.Controls.Add(txtRecoveryScore);
            pnlController.Controls.Add(txtPetID);
            pnlController.Controls.Add(btnCancel);
            pnlController.Controls.Add(txtAge);
            pnlController.Controls.Add(btnSave);
            pnlController.Controls.Add(txtPetName);
            pnlController.Location = new Point(19, 18);
            pnlController.Margin = new Padding(4, 5, 4, 5);
            pnlController.Name = "pnlController";
            pnlController.Size = new Size(708, 600);
            pnlController.TabIndex = 44;
            // 
            // btnAutoFillID
            // 
            btnAutoFillID.Location = new Point(535, 17);
            btnAutoFillID.Margin = new Padding(4, 5, 4, 5);
            btnAutoFillID.Name = "btnAutoFillID";
            btnAutoFillID.Size = new Size(148, 35);
            btnAutoFillID.TabIndex = 42;
            btnAutoFillID.Text = "Auto Fill ID";
            btnAutoFillID.UseVisualStyleBackColor = true;
            btnAutoFillID.Click += btnAutoFillID_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Cambria", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(418, 369);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(278, 54);
            btnExit.TabIndex = 27;
            btnExit.Text = "Exit Application";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2153, 1211);
            Controls.Add(pnlController);
            Controls.Add(dgvPet);
            Controls.Add(btnGenerateSummary);
            Controls.Add(pnlSearch);
            Controls.Add(pbxShelter);
            Font = new Font("Cambria", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DashBoard";
            Text = "DashBoard";
            Load += DashBoard_Load;
            ((System.ComponentModel.ISupportInitialize)pbxShelter).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPet).EndInit();
            pnlController.ResumeLayout(false);
            pnlController.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pbxShelter;
        private Panel pnlSearch;
        private ComboBox cmbRecoveryScoreSearch;
        private Button btnSearchID;
        private TextBox txtSearch;
        private Label lblSearchRecoveryScore;
        private Label lblAgeSearch;
        private TextBox txtAgeV;
        private Button btnResetSearch;
        private Button btnApplySearch;
        private Label lblSearchHeading;
        private Button btnGenerateSummary;
        private Label lblout;
        private DataGridView dgvPet;
        private Label lblAnimalID;
        private Label lblPetName;
        private Label lblSpecies;
        private Label lblRecoveryScore;
        private Label lblStatus;
        private Label lblHousingUnit;
        private Label lblAge;
        private TextBox txtPetID;
        private TextBox txtAge;
        private TextBox txtSpecies;
        private TextBox txtPetName;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtRecoveryScore;
        private TextBox txtStatus;
        private TextBox txtHousingUnit;
        private Button btnAddPet;
        private Button btnDelete;
        private Panel pnlController;
        private Button btnAutoFillID;
        private Label lblIDSearch;
        private Label lblNameSearch;
        private Label lblSpeciesSearch;
        private Button btnSearchName;
        private Button btnSearchSpecies;
        private Button btnSearchAge;
        private Button btnSearchRecovery;
        private ComboBox cmbSpeciesSearch;
        private TextBox txtSearchID;
        private TextBox txtSearchName;
        private TextBox txtSearchAge;
        private Label label1;
        private Button btnExit;
    }
}
