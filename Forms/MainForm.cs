using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Models;
using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Data;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    public partial class DashBoard : Form
    {
        FileHandler handler = new FileHandler();
        List<Animal> animals = new List<Animal>();
        public DashBoard()
        {
            InitializeComponent();
        }
        public void SetUpGrid()
        {
            dgvPet.AutoGenerateColumns = false;   // we define the 7 columns ourselves
            dgvPet.Columns.Clear();
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Animal ID", DataPropertyName = "AnimalId" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Species", DataPropertyName = "Species" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Age", DataPropertyName = "Age" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Recovery Score", DataPropertyName = "RecoveryScore" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Housing Unit", DataPropertyName = "HousingUnit" });

            dgvPet.ReadOnly = true;
            dgvPet.AllowUserToAddRows = false;
            dgvPet.AllowUserToDeleteRows = false;
            dgvPet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void RefreshGrid()
        {
            try
            {
                animals = handler.LoadAnimals(out int skippedlines);
                MessageBox.Show(
                 "Path: " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt") +
                 "\nExists: " + File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt")) +
                 "\nLoaded: " + animals.Count +
                 "\nSkipped: " + skippedlines);
                dgvPet.DataSource = null;
                dgvPet.DataSource = animals;
              
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            SetUpGrid();
            RefreshGrid();
        }
    }
}
