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
            dgvPet.AutoGenerateColumns = true;
            dgvPet.Columns.Clear();

            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Animal ID", DataPropertyName = "AnimalID" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Species", DataPropertyName = "Species" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Age", DataPropertyName = "Age" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "RecoveryScore", DataPropertyName = "RecoveryScore" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Status", DataPropertyName = "Status" });
            dgvPet.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "HousingUnit", DataPropertyName = "HousinUnit" });

            dgvPet.ReadOnly = true;
            dgvPet.AllowUserToAddRows = false;
            dgvPet.AllowUserToDeleteRows = false;
            dgvPet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPet.MultiSelect = false;
            dgvPet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public void RefreshGrid()
        {
            try
            {
                animals = handler.LoadAnimals();
                dgvPet.DataSource = null;
                dgvPet.DataSource = animals;
                //lblOut.Text = $"{animals.Count} record(s) loaded. {reader.SkippedRecords} invalid record(s) skipped.";
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
