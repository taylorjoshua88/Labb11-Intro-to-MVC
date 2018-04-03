using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonOfTheYear.Models
{
    /// <summary>
    /// Represents a single Time Person of the Year record
    /// </summary>
    public class Person : IEquatable<Person>
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// Returns a list of Person objects from the CSV file found at
        /// ~/personOfTheYear.csv who received the Time's Person of the Year
        /// within the range of years specified by <paramref name="startYear"/>
        /// and <paramref name="endYear"/> (inclusive)
        /// </summary>
        /// <param name="startYear">The earliest year of results to include</param>
        /// <param name="endYear">The latest year of results to include</param>
        /// <returns>A list of Person objects from ~/personOfTheYear.csv who
        /// received Time's Person of the Year within the years specified in
        /// <paramref name="startYear"/> and <paramref name="endYear"/></returns>
        public static List<Person> GetPeopleFromCSV(int startYear, int endYear)
        {
            // Path to the person of the year CSV file (build action for CSV file set
            // to "Copy if Newer")
            string csvPath = Path.Combine(
                Environment.CurrentDirectory, @"wwwroot\personOfTheYear.csv");

            // Load all lines of the CSV file. Will throw exceptions if the file is not found
            // or if there is an I/O error!!!
            string[] csvLines = File.ReadAllLines(csvPath);

            // Create a list for all people in the CSV file with an initial capacity taken from the
            // number of lines in the CSV file to avoid internal array resizing inefficiencies
            // in List<Person> as people are added. Subtract one to account for the header row.
            List<Person> people = new List<Person>(csvLines.Length - 1);

            // Parse each line of the CSV file, skipping the header row
            for (int lineIdx = 1; lineIdx < csvLines.Length; lineIdx++)
            {
                // Naively split by commas, assuming that no whitespace precedes entries
                string[] columns = csvLines[lineIdx].Split(',');
                
                // Make sure there are enough columns to avoid index exceptions and provide
                // a more helpful exception to fix the source CSV file in case of missing data
                if (columns.Length < 9)
                {
                    throw new FormatException($"{csvPath} has too few columns on row {lineIdx + 1}");
                }

                // Add a new person using the columns of data from this row
                people.Add(new Person
                {
                    // Year is required for core functionality, so make sure this is provided
                    Year = Convert.ToInt32(columns[0]),
                    Honor = columns[1],
                    Name = columns[2],
                    Country = columns[3],
                    // Birth Year and Death Year aren't necessary for the operation of this
                    // application so fill with 0's if they are empty strings
                    Birth_Year = (columns[4].Length > 0) ? Convert.ToInt32(columns[4]) : 0,
                    DeathYear = (columns[5].Length > 0) ? Convert.ToInt32(columns[5]) : 0,
                    Title = columns[6],
                    Category = columns[7],
                    Context = columns[8]
                });
            }

            // Return a list of all people within the requested years (inclusive on start and end)
            return people.Where(p => (p.Year <= endYear && p.Year >= startYear)).ToList();
        }

        #region IEquatable<Person> Implementation for Unit Testing
        public bool Equals(Person other)
        {
            return Year == other.Year &&
                Honor == other.Honor &&
                Name == other.Name &&
                Country == other.Country &&
                Birth_Year == other.Birth_Year &&
                DeathYear == other.DeathYear &&
                Title == other.Title &&
                Category == other.Category &&
                Context == other.Context;
        }
        #endregion
    }
}
