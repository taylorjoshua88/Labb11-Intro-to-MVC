using Xunit;
using PersonOfTheYear.Models;
using System.Collections.Generic;

namespace PersonOfTheYearTest
{
    // NOTE: Tests will fail if CSV file is modified!
    public class PersonTest
    {
        // Performs three tests using PersonTestData at yielded indexes
        [Theory]
        [ClassData(typeof(PersonTestData))]
        public void GetPeopleFromCSVContentTest(Person expectedPerson, int csvIndex)
        {
            // Arrange & Act
            List<Person> actualPeople = Person.GetPeopleFromCSV(int.MinValue, int.MaxValue);

            // Assert
            Assert.Equal(expectedPerson, actualPeople[csvIndex]);
        }

        [Theory]
        [InlineData(1945, 1970, 28)]
        [InlineData(int.MinValue, int.MaxValue, 104)]
        [InlineData(1997, 1998, 3)] // 1998 had two persons of the year
        [InlineData(1927, 2015, 103)]
        public void GetPeopleFromCSVYearRangeTest(int minYear, int maxYear, int expectedRecordsCount)
        {
            // Arrange & Act
            List<Person> actualPeople = Person.GetPeopleFromCSV(minYear, maxYear);

            // Assert
            Assert.Equal(expectedRecordsCount, actualPeople.Count);
        }
    }
}
