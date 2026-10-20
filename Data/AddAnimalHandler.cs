using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Data
{
    public class AddAnimalHandler
    {

        // Handles input validation, classification, and persistence for adding a new animal record.

        private readonly FileHandler _fileHandler;

        // Initializes a new instance of the AddAnimalHandler class.
        // The file handler used for reading and appending records.

        public AddAnimalHandler(FileHandler fileHandler)
        {
            _fileHandler = fileHandler ?? new FileHandler();
        }

        // Validates user inputs from the form, calculates classification, appends the record to animals.txt,
        // shows the confirmation message, clears the inputs, and triggers a grid refresh.

        // True if the animal was validated and saved successfully; otherwise, false.
        public bool AddNewAnimal(
            TextBox txtAnimalId,
            TextBox txtName,
            TextBox txtSpecies,
            TextBox txtAge,
            TextBox txtRecoveryScore,
            List<Animal> existingAnimals
            )
        {
            // Ensure we have a valid list to check ID uniqueness against
            List<Animal> currentRecords = existingAnimals ?? _fileHandler.LoadAnimals(out _);

            // Step 1: Validate all fields (isEditMode = false checks ID uniqueness)
            if (!ValidateInputs(
                txtAnimalId,
                txtName,
                txtSpecies,
                txtAge,
                txtRecoveryScore,
                currentRecords,
                isEditMode: false,
                out Animal validatedAnimal))
            {
                // Validation failed; specific error message was shown and cursor focus was returned to the field
                return false;
            }

            // Step 2: Calculate Status and Housing Unit using the single classification method
            validatedAnimal.CalculateStatusAndHousing();

            // Step 3: Append the single new line to animals.txt, leaving existing lines untouched
            bool isSaved = _fileHandler.AppendAnimal(validatedAnimal);
            if (!isSaved)
            {
                return false;
            }

            // Step 4: Sync the in-memory list so the grid has the new data
            currentRecords.Add(validatedAnimal);

            // Step 5: Show confirmation message with the calculated Status and Housing Unit
            MessageBox.Show(
                $"Animal '{validatedAnimal.Name}' ({validatedAnimal.AnimalId}) has been added successfully.\n\n" +
                $"Status: {validatedAnimal.Status}\n" +
                $"Housing Unit: {validatedAnimal.HousingUnit}",
                "Animal Added",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Step 6: Clear input boxes and prepare the form for the next animal
            ClearInputBoxes(txtAnimalId, txtName, txtSpecies, txtAge, txtRecoveryScore);

            return true;
        }
        

        // Trims and validates all input fields.
        // Can be reused by both Add (isEditMode = false) and Update (isEditMode = true).
       
        // True if all fields are valid; otherwise, false.
        public bool ValidateInputs(
            TextBox txtAnimalId,
            TextBox txtName,
            TextBox txtSpecies,
            TextBox txtAge,
            TextBox txtRecoveryScore,
            List<Animal> existingAnimals,
            bool isEditMode,
            out Animal validatedAnimal)
        {
            validatedAnimal = null;

            // Trim all user inputs before validating as required by Section 3
            string rawId = txtAnimalId.Text.Trim().ToUpperInvariant();
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();
            string ageText = txtAge.Text.Trim();
            string scoreText = txtRecoveryScore.Text.Trim();

            // 1. Validate Animal ID: Required, "WR-" followed by exactly 4 digits, converted to uppercase
            if (string.IsNullOrEmpty(rawId) || !IsValidAnimalIdFormat(rawId))
            {
                ShowValidationError("Animal ID is required and must be the letters WR- followed by exactly 4 digits (for example, WR-0007).", txtAnimalId);
                return false;
            }

            // Check Animal ID uniqueness only when adding a new animal
            if (!isEditMode && existingAnimals != null)
            {
                bool idExists = existingAnimals.Any(a => string.Equals(a.AnimalId, rawId, StringComparison.OrdinalIgnoreCase));
                if (idExists)
                {
                    ShowValidationError($"Animal ID '{rawId}' already exists. Animal ID must be unique.", txtAnimalId);
                    return false;
                }
            }

            // 2. Validate Name: Required, 1-30 characters, must not contain the pipe character '|'
            if (string.IsNullOrEmpty(name) || name.Length < 1 || name.Length > 30)
            {
                ShowValidationError("Name is required and must be between 1 and 30 characters.", txtName);
                return false;
            }

            if (name.Contains('|'))
            {
                ShowValidationError("Name must not contain the pipe character (|).", txtName);
                return false;
            }

            // 3. Validate Species: Required, 1-30 characters, must not contain the pipe character '|'
            if (string.IsNullOrEmpty(species) || species.Length < 1 || species.Length > 30)
            {
                ShowValidationError("Species is required and must be between 1 and 30 characters.", txtSpecies);
                return false;
            }

            if (species.Contains('|'))
            {
                ShowValidationError("Species must not contain the pipe character (|).", txtSpecies);
                return false;
            }

            // 4. Validate Age: Required, whole number from 0 to 100 (rejects decimals and text)
            if (!TryParseWholeNumberInRange(ageText, 0, 100, out int age))
            {
                ShowValidationError("Age must be a whole number between 0 and 100.", txtAge);
                return false;
            }

            // 5. Validate Recovery Score: Required, whole number from 0 to 100 (rejects decimals and text)
            if (!TryParseWholeNumberInRange(scoreText, 0, 100, out int recoveryScore))
            {
                ShowValidationError("Recovery Score must be a whole number between 0 and 100.", txtRecoveryScore);
                return false;
            }

            // Update the ID TextBox to reflect the normalized uppercase ID
            txtAnimalId.Text = rawId;

            // Construct the validated Animal instance
            validatedAnimal = new Animal
            {
                AnimalId = rawId,
                Name = name,
                Species = species,
                Age = age,
                RecoveryScore = recoveryScore
            };

            return true;
        }


        // Checks that the Animal ID strictly starts with "WR-" followed by exactly 4 numeric digits.

        // True if the format matches WR-XXXX; otherwise, false.
        private bool IsValidAnimalIdFormat(string animalId)
        {
            if (animalId.Length != 7 || !animalId.StartsWith("WR-"))
            {
                return false;
            }

            // Verify that the last 4 characters are strictly digits (0-9) and not signs (+ or -)
            string digitPart = animalId.Substring(3, 4);
            return digitPart.All(char.IsDigit);
        }


        // Strictly parses a whole integer within the specified range, rejecting decimals, letters, and plus/minus signs.


        // True if valid whole number within range; otherwise, false.
        private bool TryParseWholeNumberInRange(string input, int min, int max, out int result)
        {
            result = 0;

            if (string.IsNullOrEmpty(input) || !input.All(char.IsDigit))
            {
                return false;
            }

            return int.TryParse(input, out result) && result >= min && result <= max;
        }


        // Displays a validation error message naming the problematic field and returns the cursor to that control.

       
        private void ShowValidationError(string message, TextBox targetControl)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            targetControl.Focus();
            targetControl.SelectAll();
        }


        // Clears all animal input TextBoxes and places the cursor back in the Animal ID box.

        public void ClearInputBoxes(
            TextBox txtAnimalId,
            TextBox txtName,
            TextBox txtSpecies,
            TextBox txtAge,
            TextBox txtRecoveryScore)
        {
            txtAnimalId.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtRecoveryScore.Clear();
            txtAnimalId.Focus();
        }




        // Generates the next available Animal ID by finding the highest existing ID number and incrementing it by 1
        // Will return a formatted string representing the next available ID (e.g., "WR-0021").
        public string GenerateNextAnimalId(List<Animal> existingAnimals)
        {
            List<Animal> currentRecords = existingAnimals ?? _fileHandler.LoadAnimals(out _);

            // If there are no records, start at WR-0001
            if (currentRecords == null || currentRecords.Count == 0)
            {
                return "WR-0001";
            }

            int maxIdNumber = 0;

            foreach (Animal animal in currentRecords)
            {
                // Verify the ID matches the expected format before attempting to parse
                if (!string.IsNullOrEmpty(animal.AnimalId) &&
                    animal.AnimalId.Length == 7 &&
                    animal.AnimalId.StartsWith("WR-", StringComparison.OrdinalIgnoreCase))
                {
                    // Extract the last 4 characters and parse to an integer
                    if (int.TryParse(animal.AnimalId.Substring(3), out int currentNumber))
                    {
                        if (currentNumber > maxIdNumber)
                        {
                            maxIdNumber = currentNumber;
                        }
                    }
                }
            }

            // Increment the highest found number
            int nextIdNumber = maxIdNumber + 1;

            // Return formatted as WR- followed by exactly 4 digits (e.g., 21 becomes WR-0021)
            return $"WR-{nextIdNumber:D4}";
        }
    }
}