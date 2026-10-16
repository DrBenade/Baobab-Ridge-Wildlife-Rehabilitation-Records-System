using System;
using System.Collections.Generic;
using System.Text;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Models
{

    // Represents an animal record in the Baobab Ridge Wildlife Rehabilitation Centre.
    
    public class Animal
    {
        private string animalId;
        private string name;
        private string species;
        private int age;
        private int recoveryScore;
        private string status;
        private string housingUnit;

        // Empty constructor for object initialization.
         
        public Animal()
        {

        }

        public Animal(string animalId, string name, string species, int age, int recoveryScore, string status, string housingUnit)
        {
            AnimalId = animalId;
            Name = name;
            Species = species;
            Age = age;
            RecoveryScore = recoveryScore;
            Status = status;
            HousingUnit = housingUnit;
        }

        public string AnimalId { get => animalId; set => animalId = value; }
        public string Name { get => name; set => name = value; }
        public string Species { get => species; set => species = value; }
        public int Age { get => age; set => age = value; }
        public int RecoveryScore { get => recoveryScore; set => recoveryScore = value; }
        public string Status { get => status; set => status = value; }
        public string HousingUnit { get => housingUnit; set => housingUnit = value; }


        
        // Calculates and sets the animal's Status and Housing Unit based strictly on its Recovery Score.
        // This is the single classification method called by both Add and Update features.
        
        public void CalculateStatusAndHousing()
        {
            // Evaluate the recovery score within the predefined bands to determine classification
            if (RecoveryScore >= 0 && RecoveryScore <= 19)
            {
                Status = "Critical";
                HousingUnit = "Intensive Care Unit";
            }
            else if (RecoveryScore >= 20 && RecoveryScore <= 39)
            {
                Status = "Serious";
                HousingUnit = "High-Dependency Ward";
            }
            else if (RecoveryScore >= 40 && RecoveryScore <= 59)
            {
                Status = "Stable";
                HousingUnit = "Recovery Ward";
            }
            else if (RecoveryScore >= 60 && RecoveryScore <= 79)
            {
                Status = "Recovering";
                HousingUnit = "Outdoor Enclosure";
            }
            else if (RecoveryScore >= 80 && RecoveryScore <= 100)
            {
                Status = "Release-Ready";
                HousingUnit = "Pre-Release Camp";
            }
        }



        /// Formats the animal's data into a pipe-separated string for saving to the text file.
        /// A formatted string: ID | Name | Species | Age | Score | Status | Housing Unit</returns>
        /// 
        public string ToFileString()
        {
            // Constructs the exact format required for animals.txt
            return $"{AnimalId} | {Name} | {Species} | {Age} | {RecoveryScore} | {Status} | {HousingUnit}";
        }



    }
}
