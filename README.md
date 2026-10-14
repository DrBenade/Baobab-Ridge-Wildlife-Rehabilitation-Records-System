# Baobab Ridge Wildlife Rehabilitation Records System

## Team Members
* Ryan Desmond Benade - 604302
* Daniel Gabriel De Villiers - 604930
* Benjamin Genis - 603837
* Muzi Manaka - 603311

## How to Build and Run
1. Clone the repository to your local machine.
2. Open the `.sln` solution file using Visual Studio. Ensure you have the .NET 8.0 SDK (or newer) installed.
3. Build the solution (`Ctrl + Shift + B`). The project is configured to automatically copy the starter `animals.txt` file to the output directory beside the `.exe` file.
4. Run the application (`F5` or "Start").

## Features
* **Feature 1 - Add a new animal:** Validates user input (ID format, string lengths, numeric constraints), calculates the animal's Status and Housing Unit based on the Recovery Score, and securely appends the new record to the data file.
* **Feature 2 - View all animals:** Automatically loads valid records from `animals.txt` on startup and displays them in a read-only DataGridView. Skips malformed lines safely without crashing.
* **Feature 3 - Update an animal:** Allows users to load an existing record via grid selection or exact ID search. Re-validates edits, recalculates the status/housing unit, and accurately rewrites only the modified record in the text file.
* **Feature 4 - Delete an animal:** Removes a selected record from the data file following a prompt confirmation, leaving all other records untouched.
* **Feature 5 - Generate a summary report:** Calculates the total animal count, average age, average recovery score, and individual status counts, displaying them on the UI and exporting them to `summary.txt`.

## File Formats
**1. animals.txt**
* **Encoding:** UTF-8 plain text.
* **Structure:** One animal record per line. No header line and no blank lines.
* **Format:** Seven fields separated by the pipe character `|` in the exact following order: 
  `Animal ID | Name | Species | Age | Recovery Score | Status | Housing Unit`

**2. summary.txt**
* **Encoding:** Plain text generated at runtime. Overwritten on each generation, never appended.
* **Structure:** A specifically formatted multi-line report detailing total counts, averages (forced to two decimal places using a full stop `.` separator), and a count for all five statuses.
* **Format:** Includes a generation timestamp in the exact `yyyy-MM-dd HH:mm` layout.

## Known Limitations
* None currently (Initial Commit).