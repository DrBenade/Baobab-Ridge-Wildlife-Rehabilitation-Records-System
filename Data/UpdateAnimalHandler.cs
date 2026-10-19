using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Data
{

    /// Handles loading, validating, recalculating, and saving changes for updating an existing animal record.

    public class UpdateAnimalHandler
    {
        private readonly FileHandler _fileHandler;
        private readonly AddAnimalHandler _addAnimalHandler;

        // Initializes a new instance of the UpdateAnimalHandler class.
        public UpdateAnimalHandler(FileHandler fileHandler, AddAnimalHandler addAnimalHandler)
        {
            _fileHandler = fileHandler ?? new FileHandler();
            _addAnimalHandler = addAnimalHandler ?? new AddAnimalHandler(_fileHandler);
        }


        // Loads the selected row from the DataGridView into the input boxes and switches the form to Edit Mode.

        public void LoadFromGridSelection(
            DataGridView dgvAnimals,
            List<Animal> existingAnimals,
            TextBox txtAnimalId,
            TextBox txtName,
            TextBox txtSpecies,
            TextBox txtAge,
            TextBox txtRecoveryScore,
            Button btnAdd,
            Button btnSaveChanges)
        {
            // Prevent crashes if the grid is empty or no valid row is selected
            if (dgvAnimals == null || dgvAnimals.CurrentRow == null || dgvAnimals.CurrentRow.Index < 0)
            {
                return;
            }

            // Retrieve the Animal object either directly from DataBoundItem or by matching the ID column cell
            Animal selectedAnimal = dgvAnimals.CurrentRow.DataBoundItem as Animal;

            if (selectedAnimal == null && dgvAnimals.CurrentRow.Cells.Count > 0)
            {
                string cellId = dgvAnimals.CurrentRow.Cells[0].Value?.ToString()?.Trim();
                if (!string.IsNullOrEmpty(cellId) && existingAnimals != null)
                {
                    selectedAnimal = existingAnimals.FirstOrDefault(
                        a => string.Equals(a.AnimalId, cellId, StringComparison.OrdinalIgnoreCase));
                }
            }

            if (selectedAnimal != null)
            {
                PopulateFormAndSetEditMode(
                    selectedAnimal,
                    txtAnimalId,
                    txtName,
                    txtSpecies,
                    txtAge,
                    txtRecoveryScore,
                    btnAdd,
                    btnSaveChanges);
            }
        }

        // Searches for an animal by exact, case-insensitive Animal ID and loads it into the form if found.

        // True if the animal was found and loaded; otherwise, false.</returns>
        public bool LoadByIdSearch(
            TextBox txtSearchId,
            List<Animal> existingAnimals,
            TextBox txtAnimalId,
            TextBox txtName,
            TextBox txtSpecies,
            TextBox txtAge,
            TextBox txtRecoveryScore,
            Button btnAdd,
            Button btnSaveChanges,
            DataGridView dgvAnimals = null)
        {
            string searchId = txtSearchId.Text.Trim();

            if (string.IsNullOrEmpty(searchId))
            {
                MessageBox.Show("Please enter an Animal ID to search.", "Search Animal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchId.Focus();
                return false;
            }

            List<Animal> currentRecords = existingAnimals ?? _fileHandler.LoadAnimals(out _);

            // Exact match, not case-sensitive
            Animal matchedAnimal = currentRecords.FirstOrDefault(
                a => string.Equals(a.AnimalId, searchId, StringComparison.OrdinalIgnoreCase));

            // Feature 3.1: If the ID is not found, the user is told and nothing else changes
            if (matchedAnimal == null)
            {
                MessageBox.Show(
                    $"No animal record found with Animal ID '{searchId.ToUpperInvariant()}'.",
                    "Record Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            // Populate input boxes and switch form into Edit Mode
            PopulateFormAndSetEditMode(
                matchedAnimal,
                txtAnimalId,
                txtName,
                txtSpecies,
                txtAge,
                txtRecoveryScore,
                btnAdd,
                btnSaveChanges);

            // Optionally highlight the corresponding row in the grid for visual consistency
            if (dgvAnimals != null)
            {
                foreach (DataGridViewRow row in dgvAnimals.Rows)
                {
                    string rowId = (row.DataBoundItem as Animal)?.AnimalId ?? row.Cells[0].Value?.ToString();
                    if (string.Equals(rowId?.Trim(), matchedAnimal.AnimalId, StringComparison.OrdinalIgnoreCase))
                    {
                        row.Selected = true;
                        dgvAnimals.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }

            return true;
        }


        // Validates edited fields, recalculates Status and Housing Unit, rewrites animals.txt so only the
        // edited record changes, refreshes the grid, and returns the form to Add mode.

        // True if the update succeeded; otherwise, false.
        public bool SaveUpdatedAnimal(
            TextBox txtAnimalId,
            TextBox txtName,
            TextBox txtSpecies,
            TextBox txtAge,
            TextBox txtRecoveryScore,
            Button btnAdd,
            Button btnSaveChanges,
            List<Animal> existingAnimals,
            Action refreshGridCallback = null)
        {
            // Prevent unhandled exception if Save Changes is clicked with nothing loaded
            if (!txtAnimalId.ReadOnly || string.IsNullOrWhiteSpace(txtAnimalId.Text))
            {
                MessageBox.Show(
                    "No animal is currently loaded for editing. Please select a row in the grid or search for an Animal ID first.",
                    "No Record Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            List<Animal> currentRecords = existingAnimals ?? _fileHandler.LoadAnimals(out _);

            // Locate the index of the existing record in the list so order is preserved
            string targetId = txtAnimalId.Text.Trim().ToUpperInvariant();
            int recordIndex = currentRecords.FindIndex(
                a => string.Equals(a.AnimalId, targetId, StringComparison.OrdinalIgnoreCase));

            if (recordIndex == -1)
            {
                MessageBox.Show(
                    $"Could not locate Animal ID '{targetId}' in the current records.",
                    "Update Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            // Apply the same validation rules as Add, skipping ID uniqueness (isEditMode = true)
            if (!_addAnimalHandler.ValidateInputs(
                txtAnimalId,
                txtName,
                txtSpecies,
                txtAge,
                txtRecoveryScore,
                currentRecords,
                isEditMode: true,
                out Animal updatedAnimal))
            {
                return false;
            }

            // Recalculate status and housing unit from the score, even if the score is unchanged
            updatedAnimal.CalculateStatusAndHousing();

            // Replace only the edited record at its exact original position in the list
            currentRecords[recordIndex] = updatedAnimal;

            // Rewrite animals.txt so that only the edited record changes
            bool isSaved = _fileHandler.RewriteAllAnimals(currentRecords);
            if (!isSaved)
            {
                return false;
            }

            MessageBox.Show(
                $"Changes to '{updatedAnimal.Name}' ({updatedAnimal.AnimalId}) have been saved.\n\n" +
                $"Updated Status: {updatedAnimal.Status}\n" +
                $"Updated Housing Unit: {updatedAnimal.HousingUnit}",
                "Animal Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Return the form to Add mode with empty boxes and refresh the grid
            ExitEditModeAndClear(txtAnimalId, txtName, txtSpecies, txtAge, txtRecoveryScore, btnAdd, btnSaveChanges);
            refreshGridCallback?.Invoke();

            return true;
        }


        // Populates the input controls with the selected animal's data and locks the form into Edit Mode.
        public void PopulateFormAndSetEditMode(
                   Animal animal,
                   TextBox txtAnimalId,
                   TextBox txtName,
                   TextBox txtSpecies,
                   TextBox txtAge,
                   TextBox txtRecoveryScore,
                   Button btnAdd,
                   Button btnSaveChanges)
        {
            // Load record values into the shared input boxes
            txtAnimalId.Text = animal.AnimalId;
            txtName.Text = animal.Name;
            txtSpecies.Text = animal.Species;
            txtAge.Text = animal.Age.ToString();
            txtRecoveryScore.Text = animal.RecoveryScore.ToString();

            // Enter Edit Mode (ID box read-only, Add disabled, Save Changes enabled)
            txtAnimalId.ReadOnly = true;
            btnAdd.Enabled = false;
            btnSaveChanges.Enabled = true;
        }


        // Leaves Edit Mode, clears all input boxes, and restores the form to Add Mode.
        // Called by the Clear button and after a successful update or delete.

        public void ExitEditModeAndClear(
            TextBox txtAnimalId,
            TextBox txtName,
            TextBox txtSpecies,
            TextBox txtAge,
            TextBox txtRecoveryScore,
            Button btnAdd,
            Button btnSaveChanges,
            TextBox txtSearchId = null)
        {
            // Restore Add Mode state
            txtAnimalId.ReadOnly = false;
            btnAdd.Enabled = true;
            btnSaveChanges.Enabled = false;

            txtSearchId?.Clear();

            // Empty all input boxes and focus the ID box
            _addAnimalHandler.ClearInputBoxes(txtAnimalId, txtName, txtSpecies, txtAge, txtRecoveryScore);
        }
    }
}