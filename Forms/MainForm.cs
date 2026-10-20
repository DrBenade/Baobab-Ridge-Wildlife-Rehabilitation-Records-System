using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Data;
using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Models;
using System.Xml.Linq;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{

    public partial class DashBoard : Form
    {
        private readonly FileHandler _fileHandler;
        private readonly AddAnimalHandler _addAnimalHandler;
        private readonly UpdateAnimalHandler _updateAnimalHandler;

        private readonly SearchHandler _searchHandler = new SearchHandler();

        private List<Animal> _currentAnimals;

        public DashBoard()
        {
            InitializeComponent();

            _fileHandler = new FileHandler();
            _addAnimalHandler = new AddAnimalHandler(_fileHandler);
            _updateAnimalHandler = new UpdateAnimalHandler(_fileHandler, _addAnimalHandler);
            _currentAnimals = new List<Animal>();
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
                _currentAnimals = _fileHandler.LoadAnimals(out int skippedLines);
                dgvPet.DataSource = null;
                dgvPet.DataSource = _currentAnimals;
                cmbSpeciesSearch.DataSource = null;
                cmbSpeciesSearch.DataSource = _searchHandler.GetUniqueSpecies(_currentAnimals);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbxShelter_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Calls the update handler to re-validate, recalculate, rewrite the file, and reset the form
            _updateAnimalHandler.SaveUpdatedAnimal(
                txtPetID,            // Animal ID text box
                txtPetName,          // Name text box
                txtSpecies,          // Species text box
                txtAge,              // Age text box
                txtRecoveryScore,    // Recovery Score text box 
                btnAddPet,           // Add Pet button
                btnSave,             // Save Changes button
                _currentAnimals,     // Currently loaded list of animals
                RefreshGrid          // Method that reloads the DataGridView
            );

            txtStatus.Text = "";
            txtHousingUnit.Text = "";
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            SetUpGrid();
            RefreshGrid();
            dgvPet.ClearSelection();
        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {

            // Capture the boolean result to ensure we only refresh on a successful save
            bool success = _addAnimalHandler.AddNewAnimal(
                txtPetID,
                txtPetName,
                txtSpecies,
                txtAge,
                txtRecoveryScore,
                _currentAnimals
            );

            // Only refresh the DataGridView if the animal was actually added
            if (success)
            {
                RefreshGrid();
            }

        }

        private void dgvPet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Ignore clicks on the column headers or empty rows
            if (e.RowIndex >= 0 && dgvPet.Rows[e.RowIndex].Cells[0].Value != null)
            {
                // Get the specific row that was clicked
                DataGridViewRow row = dgvPet.Rows[e.RowIndex];

                // 2. Create the Animal object using the grid view cell data
                // ID(0), Name(1), Species(2), Age(3), Score(4), Status(5), Housing(6)
                Animal selectedAnimal = new Animal
                {
                    AnimalId = row.Cells[0].Value.ToString(),
                    Name = row.Cells[1].Value.ToString(),
                    Species = row.Cells[2].Value.ToString(),
                    Age = int.Parse(row.Cells[3].Value.ToString()),
                    RecoveryScore = int.Parse(row.Cells[4].Value.ToString())
                };

                // 3. Populate the text boxes using the newly created Animal object
                txtPetID.Text = selectedAnimal.AnimalId;
                txtPetName.Text = selectedAnimal.Name;
                txtSpecies.Text = selectedAnimal.Species;
                txtAge.Text = selectedAnimal.Age.ToString();
                txtRecoveryScore.Text = selectedAnimal.RecoveryScore.ToString();

                txtStatus.Text = row.Cells[5].Value.ToString();
                txtHousingUnit.Text = row.Cells[6].Value.ToString();

                // 4. Lock the UI into Edit Mode 
                txtPetID.ReadOnly = true;     // ID cannot be changed during an update
                btnAddPet.Enabled = false;    // Disable the Add button
                btnSave.Enabled = true;       // Enable the Save Changes button

                btnAutoFillID.Enabled = false; // Disable the Auto-Fill ID button
            }
        }

        private void btnAutoFillID_Click(object sender, EventArgs e)
        {
            // Generate the next ID and automatically place it into the Animal ID text box
            txtPetID.Text = _addAnimalHandler.GenerateNextAnimalId(_currentAnimals);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 1. Unselect any highlighted rows in the DataGridView
            dgvPet.ClearSelection();

            // 2. Clear all input boxes and restore Add Mode (Enables Add, Disables Save)
            _updateAnimalHandler.ExitEditModeAndClear(
                txtPetID,            // Animal ID text box
                txtPetName,          // Name text box
                txtSpecies,          // Species text box
                txtAge,              // Age text box
                txtRecoveryScore,    // Recovery Score text box 
                btnAddPet,           // Add Pet button (will be enabled)
                btnSave,             // Save Changes button (will be disabled)
                txtSearch            // Search text box
            );

            // 3. Clear the calculated read-only fields
            txtStatus.Clear();
            txtHousingUnit.Clear();

            btnAutoFillID.Enabled = true; // Re-enable the Auto-Fill ID button

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Check if a row is currently selected in the grid 
            if (dgvPet.CurrentRow == null || dgvPet.CurrentRow.Index < 0 || dgvPet.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show(
                    "Please select an animal from the grid to delete.",
                    "No Row Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2. Retrieve the Animal ID and Name from the selected row
            string animalId = dgvPet.CurrentRow.Cells[0].Value.ToString();
            string name = dgvPet.CurrentRow.Cells[1].Value.ToString();

            // 3. Display the exact Yes/No confirmation prompt 
            DialogResult result = MessageBox.Show(
                $"Delete {animalId} ({name})? This cannot be undone.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // 4. If 'Yes' is clicked, process the deletion 
            if (result == DialogResult.Yes)
            {
                // Find and remove the target animal from the list
                Animal animalToDelete = _currentAnimals.FirstOrDefault(
                    a => string.Equals(a.AnimalId, animalId, StringComparison.OrdinalIgnoreCase));

                if (animalToDelete != null)
                {
                    _currentAnimals.Remove(animalToDelete);

                    // Overwrite animals.txt with the updated list
                    bool isSaved = _fileHandler.RewriteAllAnimals(_currentAnimals);

                    if (isSaved)
                    {
                        // Refresh the DataGridView to remove the deleted row
                        RefreshGrid();

                        // If the deleted animal is currently loaded in the input boxes, clear the form
                        if (string.Equals(txtPetID.Text.Trim(), animalId, StringComparison.OrdinalIgnoreCase))
                        {
                            // Call cancel event to reset the UI back to Add Mode
                            btnCancel_Click(null, null);
                        }
                    }
                }
            }
        }

        private void btnGenerateSummary_Click(object sender, EventArgs e)
        {
            // 1. Instantiate the generator from your Data folder
            SummaryGenerator summaryGen = new SummaryGenerator();

            // 2. Call the method to calculate all statistics and export them to summary.txt
            summaryGen.GenerateAndExportSummary(
                out int totalAnimals,
                out string avgAge,
                out string avgScore,
                out int critical,
                out int serious,
                out int stable,
                out int recovering,
                out int releaseReady
            );

            // 3. Format the report exactly as the rubric specifies to display on the form
            string reportMessage =
                $"BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE\n" +
                $"ANIMAL SUMMARY REPORT\n" +
                $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}\n\n" +
                $"Total animals:\t\t{totalAnimals}\n" +
                $"Average age (years):\t{avgAge}\n" +
                $"Average recovery score:\t{avgScore}\n\n" +
                $"Animals per status:\n" +
                $"  Critical:\t\t{critical}\n" +
                $"  Serious:\t\t{serious}\n" +
                $"  Stable:\t\t{stable}\n" +
                $"  Recovering:\t{recovering}\n" +
                $"  Release-Ready:\t{releaseReady}\n\n" +
                $"This report has also been successfully exported to 'summary.txt'.";

            // 4. Display the results directly to the user
            MessageBox.Show(reportMessage, "Summary Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearchID_Click(object sender, EventArgs e)
        {
            // Pass the text box value and full in-memory list
            List<Animal> filteredList = _searchHandler.SearchById(txtSearchID.Text, _currentAnimals);

            // Bind the filtered results to the grid
            dgvPet.DataSource = null;
            dgvPet.DataSource = filteredList;
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            // Pass the text box value 
            List<Animal> filteredList = _searchHandler.SearchByName(txtSearchName.Text, _currentAnimals);

            dgvPet.DataSource = null;
            dgvPet.DataSource = filteredList;

        }

        private void btnSearchSpecies_Click(object sender, EventArgs e)
        {
            // Pass the selected text from the ComboBox
            List<Animal> filteredList = _searchHandler.SearchBySpecies(cmbSpeciesSearch.Text, _currentAnimals);

            dgvPet.DataSource = null;
            dgvPet.DataSource = filteredList;
        }

        private void btnSearchAge_Click(object sender, EventArgs e)
        {
            // Pass the text box value for age
            List<Animal> filteredList = _searchHandler.SearchByAge(txtSearchAge.Text, _currentAnimals);

            dgvPet.DataSource = null;
            dgvPet.DataSource = filteredList;

            if (filteredList.Count == 0 && !string.IsNullOrWhiteSpace(txtSearchAge.Text))
            {
                MessageBox.Show("No animals found matching that age, or invalid number format entered.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearchRecovery_Click(object sender, EventArgs e)
        {
            // Pass the selected range from the ComboBox
            List<Animal> filteredList = _searchHandler.SearchByRecoveryScore(cmbRecoveryScoreSearch.Text, _currentAnimals);

            dgvPet.DataSource = null;
            dgvPet.DataSource = filteredList;
        }

        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            // 1. Clear all search inputs 
            txtSearchID.Clear();
            txtSearchName.Clear();
            txtSearchAge.Clear();

            // Set ComboBoxes back to an empty/unselected state
            cmbSpeciesSearch.SelectedIndex = -1;
            cmbRecoveryScoreSearch.SelectedIndex = -1;

            // 2. Restore the DataGridView to show the full, unfiltered list of animals
            dgvPet.DataSource = null;
            dgvPet.DataSource = _currentAnimals;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Safely closes the entire application
            Application.Exit();
        }
    }

}
