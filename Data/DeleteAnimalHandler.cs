using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Data
{
    /// <summary>
    /// Handles deleting animal records from the collection
    /// and updating animals.txt.
    /// </summary>
    public class DeleteAnimalHandler
    {
        private readonly FileHandler _fileHandler ;

        public DeleteAnimalHandler(FileHandler fileHandler)
        {
            _fileHandler = fileHandler ?? new FileHandler();
        
        
        }

        /// <summary>
        /// Deletes the selected animal after the confirmation.
        /// </summary>
        public bool DeleteAnimal(
            DataGridView dgvPet,
            List<Animal> animals)
        {
            //Feature 4.1- this will check if any of our rows are selected
            if (dgvPet.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an animal to delete.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            DataGridViewRow selectedRow =
                dgvPet.SelectedRows[0];

            string animalId =
             selectedRow.Cells[0].Value.ToString();

                string animalName =
                selectedRow.Cells[1].Value.ToString();

            // Feature4.2 -this is our confirmation prompt
            DialogResult result = MessageBox.Show(
                $"Delete {animalId} ({animalName})? This cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return false;
            }

            //Feature 4.3- Finding and removing the selected  animal
            Animal animalToDelete = animals.FirstOrDefault(a =>
                a.AnimalId.Equals(
                    animalId,
                       StringComparison.OrdinalIgnoreCase));

            if (animalToDelete == null)
            {
                return false;
            }

            animals.Remove(animalToDelete);

            //Feature 4.4- Rewriting animals.txt
             bool success =
                _fileHandler.RewriteAllAnimals(animals);

            if (success)
            {
                MessageBox.Show(
                    "Animal deleted successfully.",
                    "Deleted",
                 MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            return success;
        }
    }
}
