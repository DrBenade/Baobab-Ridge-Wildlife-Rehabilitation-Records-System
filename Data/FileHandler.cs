using System;
using System.Collections.Generic;
using System.Text;

//
using System.IO;
using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Models;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Data
{

    // Handles all file reading and writing operations for the animals.txt file.
    // Wraps operations in error handling to prevent application crashes during file locks or missing files.

    public class FileHandler
    {
        // The file is stored in the same folder as the running .exe
        private const string FilePath = "animals.txt";

       
        // Loads all valid animals from the text file. Skips malformed lines and tracks the skipped count.

        // <param name="skippedLines">Outputs the number of lines that failed validation during load.
        // Returns a list of valid Animal objects.

        public List<Animal> LoadAnimals(out int skippedLines)
        {
            List<Animal> animals = new List<Animal>();
            skippedLines = 0;

            // Feature 2.5: If animals.txt does not exist, create an empty one and show an empty grid without an error
            if (!File.Exists(FilePath))
            {
                try
                {
                    File.Create(FilePath).Close();
                }
                catch (Exception ex)
                {
                    ShowFriendlyError("missing file or folder", ex);
                }
                return animals; // Returns empty list, grid will load empty
            }

            try
            {
                string[] lines = File.ReadAllLines(FilePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');

                    // A line that is malformed (wrong number of fields) must be skipped
                    if (parts.Length != 7)
                    {
                        skippedLines++;
                        continue;
                    }

                    // Validate numeric age and score
                    if (!int.TryParse(parts[3].Trim(), out int age) ||
                        !int.TryParse(parts[4].Trim(), out int score))
                    {
                        skippedLines++;
                        continue;
                    }

                    // Validate ID format (WR- followed by exactly 4 digits)
                    string id = parts[0].Trim().ToUpper();
                    if (!id.StartsWith("WR-") || id.Length != 7 || !int.TryParse(id.Substring(3), out _))
                    {
                        skippedLines++;
                        continue;
                    }

                    // Create the animal object
                    Animal animal = new Animal
                    {
                        AnimalId = id,
                        Name = parts[1].Trim(),
                        Species = parts[2].Trim(),
                        Age = age,
                        RecoveryScore = score
                    };

                    // Recalculate status and housing to ensure absolute data integrity matching the score
                    animal.CalculateStatusAndHousing();
                    animals.Add(animal);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                ShowFriendlyError("permission problems", ex);
            }
            catch (IOException ex)
            {
                ShowFriendlyError("file that is in use by another program", ex);
            }
            catch (Exception ex)
            {
                ShowFriendlyError("unexpected file read error", ex);
            }

            return animals;
        }


        // Appends a single newly added animal to the bottom of the text file.

        // The validated animal object to append.
        // True if save was successful, false otherwise.
        public bool AppendAnimal(Animal animal)
        {
            try
            {
                File.AppendAllText(FilePath, animal.ToFileString() + Environment.NewLine);
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                ShowFriendlyError("permission problems", ex);
                return false;
            }
            catch (IOException ex)
            {
                ShowFriendlyError("file that is in use by another program", ex);
                return false;
            }
            catch (Exception ex)
            {
                ShowFriendlyError("unexpected file write error", ex);
                return false;
            }
        }


        // Rewrites the entire file with the provided list of animals. Used for Update and Delete features.

        // The complete, updated list of animals.
        // True if save was successful, false otherwise.
        public bool RewriteAllAnimals(List<Animal> animals)
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (Animal animal in animals)
                {
                    lines.Add(animal.ToFileString());
                }

                File.WriteAllLines(FilePath, lines);
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                ShowFriendlyError("permission problems", ex);
                return false;
            }
            catch (IOException ex)
            {
                ShowFriendlyError("file that is in use by another program", ex);
                return false;
            }
            catch (Exception ex)
            {
                ShowFriendlyError("unexpected file write error", ex);
                return false;
            }
        }


        // Displays a friendly error message to the user instead of a stack trace.

        private void ShowFriendlyError(string errorType, Exception ex)
        {
            string message = $"A file error occurred ({errorType}).\n\nPlease check that the 'animals.txt' file is not open in another program or set to read-only.";
            MessageBox.Show(message, "File Access Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}