using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Data
{

    // Handles all file reading and writing operations for the animals.txt file.
    // Wraps operations in error handling to prevent application crashes during file locks or missing files.
    
    public class FileHandler
    {
        //        // The file is stored in the same folder as the running .exe
        //        private readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");
        //        public int SkippedLines { get; set; }

        //        // Loads all valid animals from the text file. Skips malformed lines and tracks the skipped count.

        //        // <param name="skippedLines">Outputs the number of lines that failed validation during load.
        //        // Returns a list of valid Animal objects.

        private static readonly string FilePath =
               Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");
       // private  Animal Animal { get; set; }

        /// <summary>Loads all valid animals; counts malformed lines in skippedLines.</summary>
        public  List<Animal> LoadAnimals(out int skippedLines)
        {
            Animal animal = new Animal();
            var animals = new List<Animal>();
            skippedLines = 0;

            if (!File.Exists(FilePath)) return animals;

            try
            {
                foreach (string line in File.ReadAllLines(FilePath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] p = line.Split('|');
                    if (p.Length != 7 ||
                        !Regex.IsMatch(p[0].Trim(), @"^WR-\d{4}$") ||
                        !int.TryParse(p[3].Trim(), out int age) || age < 0 || age > 100 ||
                        !int.TryParse(p[4].Trim(), out int score) || score < 0 || score > 100)
                    {
                        skippedLines++;
                        continue;
                    }


                    animals.Add(new Animal
                    {
                        AnimalId = p[0].Trim(),
                        Name = p[1].Trim(),
                        Species = p[2].Trim(),
                        Age = age,
                        RecoveryScore = score,
                        Status = p[5].Trim(),
                        HousingUnit = p[6].Trim()
                    });

                    // Recalculate status and housing to ensure absolute data integrity matching the score
                    
                    animal.CalculateStatusAndHousing();
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

        private bool IsValidAnimalID(string animalID)
        {
            if (animalID == null || animalID.Length != 7)
            {
                return false;
            }

            if (!animalID.StartsWith("WR-"))
            {
                return false;

            }
            else
            {
                for (int i = 3; i < animalID.Length; i++)
                {
                    if (!char.IsDigit(animalID[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

       
        }
    }
