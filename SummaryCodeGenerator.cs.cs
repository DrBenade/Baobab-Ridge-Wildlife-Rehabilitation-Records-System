using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Models;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System.Data

    /// Handles the generation of the summary report for all animals in the system.
    public class SummaryGenerator
    {
        private const string SummaryFilePath = "summary.txt";

        /// Calculates statistics from the animals list and exports them to summary.txt.
        public void GenerateAndExportSummary(out int totalAnimals, out string avgAge, out string avgScore,
            out int critical, out int serious, out int stable, out int recovering, out int releaseReady)
        {
            FileHandler fileHandler = new FileHandler();
            List<Animal> animals = fileHandler.LoadAnimals(out _);

            totalAnimals = animals.Count;
            critical = 0; serious = 0; stable = 0; recovering = 0; releaseReady = 0;

            if (totalAnimals == 0)
            {
                avgAge = "N/A";
                avgScore = "N/A";
            }
            else
            {
                double ageSum = 0;
                double scoreSum = 0;

                foreach (Animal a in animals)
                {
                    ageSum += a.Age;
                    scoreSum += a.RecoveryScore;

                    switch (a.Status)
                    {
                        case "Critical": critical++; break;
                        case "Serious": serious++; break;
                        case "Stable": stable++; break;
                        case "Recovering": recovering++; break;
                        case "Release-Ready": releaseReady++; break;
                    }
                }

                avgAge = (ageSum / totalAnimals).ToString("0.00", CultureInfo.InvariantCulture);
                avgScore = (scoreSum / totalAnimals).ToString("0.00", CultureInfo.InvariantCulture);
            }

            ExportSummaryToFile(totalAnimals, avgAge, avgScore, critical, serious, stable, recovering, releaseReady);
        }

        private void ExportSummaryToFile(int total, string avgAge, string avgScore,
            int critical, int serious, int stable, int recovering, int releaseReady)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                
                string[] lines = {
                    "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE",
                    "ANIMAL SUMMARY REPORT",
                    $"Generated: {timestamp}",
                    "",
                    $"Total animals:        {total}",
                    $"Average age (years):  {avgAge}",
                    $"Average recovery score: {avgScore}",
                    "",
                    "Animals per status:",
                    $"  Critical:      {critical}",
                    $"  Serious:       {serious}",
                    $"  Stable:        {stable}",
                    $"  Recovering:    {recovering}",
                    $"  Release-Ready: {releaseReady}"
                };

                File.WriteAllLines(SummaryFilePath, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File writing error.\n{ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}