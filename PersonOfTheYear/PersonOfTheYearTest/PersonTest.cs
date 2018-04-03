using System;
using Xunit;
using PersonOfTheYear;
using PersonOfTheYear.Models;
using System.Collections.Generic;

namespace PersonOfTheYearTest
{
    public class PersonTest
    {
        // Performs three tests using PersonTestData at yielded indexes
        // NOTE: Test will fail if CSV file is modified!
        [Theory]
        [ClassData(typeof(PersonTestData))]
        public void GetPeopleFromCSVTest(Person expectedPerson, int csvIndex)
        {
            // Arrange & Act
            List<Person> actualPeople = Person.GetPeopleFromCSV(int.MinValue, int.MaxValue);

            // Assert
            Assert.Equal(expectedPerson, actualPeople[csvIndex]);
        }

        // TODO: Add theory for year ranges based on quantity
    }
}
