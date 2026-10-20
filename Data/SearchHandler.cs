using System;
using System.Collections.Generic;
using System.Text;

using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Models;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Data
{

    /// Handles all filtering and search operations for the DataGridView.
    public class SearchHandler
    {
        // Filters the animal list by ID (supports partial, case-insensitive matching so "0002" finds "WR-0002").
        // Returns a filtered list of animals matching the ID.
        public List<Animal> SearchById(string idQuery, List<Animal> currentAnimals)
        {
            if (string.IsNullOrWhiteSpace(idQuery) || currentAnimals == null)
            {
                return currentAnimals ?? new List<Animal>();
            }

            string query = idQuery.Trim();

            // Filters the list returning any record where the ID contains the search string
            return currentAnimals.Where(a =>
                a.AnimalId.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        
        // Extracts a sorted, unique list of all species currently in the dataset to populate the ComboBox.

        // Returns a list of unique species names.
        public List<string> GetUniqueSpecies(List<Animal> currentAnimals)
        {
            if (currentAnimals == null || currentAnimals.Count == 0)
            {
                return new List<string>();
            }

            // Selects the species, removes duplicates (Distinct), and sorts them alphabetically
            return currentAnimals
                .Select(a => a.Species)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(s => s)
                .ToList();
        }

        // Filters the animal list by Name (supports partial, case-insensitive matching).

        // Returns A filtered list of animals matching the name.

        public List<Animal> SearchByName(string nameQuery, List<Animal> currentAnimals)
        {
            if (string.IsNullOrWhiteSpace(nameQuery) || currentAnimals == null)
            {
                return currentAnimals ?? new List<Animal>();
            }

            string query = nameQuery.Trim();

            // Filters the list returning any record where the Name contains the search string
            return currentAnimals.Where(a =>
                a.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        // Filters the animal list by Species (exact, case-insensitive matching based on ComboBox selection).

        // Returns A filtered list of animals matching the species.
        public List<Animal> SearchBySpecies(string speciesQuery, List<Animal> currentAnimals)
        {
            if (string.IsNullOrWhiteSpace(speciesQuery) || currentAnimals == null)
            {
                return currentAnimals ?? new List<Animal>();
            }

            string query = speciesQuery.Trim();

            // Filters the list returning exact matches for the selected species
            return currentAnimals.Where(a =>
                string.Equals(a.Species, query, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Filters the animal list by an exact Age.

        // Returns a filtered list of animals matching the age, or an empty list if input is invalid.
        public List<Animal> SearchByAge(string ageQuery, List<Animal> currentAnimals)
        {
            if (string.IsNullOrWhiteSpace(ageQuery) || currentAnimals == null)
            {
                return currentAnimals ?? new List<Animal>();
            }

            // Attempt to parse the user's input into an integer
            if (int.TryParse(ageQuery.Trim(), out int searchAge))
            {
                return currentAnimals.Where(a => a.Age == searchAge).ToList();
            }

            // If the user typed letters instead of a number, return no results
            return new List<Animal>();
        }

        
        // Filters the animal list by a Recovery Score range (e.g., "20-39").

        // Returns a filtered list of animals falling within the score range.

        public List<Animal> SearchByRecoveryScore(string rangeQuery, List<Animal> currentAnimals)
        {
            if (string.IsNullOrWhiteSpace(rangeQuery) || currentAnimals == null)
            {
                return currentAnimals ?? new List<Animal>();
            }

            // Split the ComboBox string (e.g., "20-39") into a minimum and maximum value
            string[] boundaries = rangeQuery.Split('-');
            if (boundaries.Length == 2 &&
                int.TryParse(boundaries[0].Trim(), out int minScore) &&
                int.TryParse(boundaries[1].Trim(), out int maxScore))
            {
                return currentAnimals.Where(a =>
                    a.RecoveryScore >= minScore && a.RecoveryScore <= maxScore).ToList();
            }

            return new List<Animal>();
        }
    }
}