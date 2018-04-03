using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PersonOfTheYear;
using PersonOfTheYear.Models;

namespace PersonOfTheYearTest
{
    class PersonTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[2]
            {
                new Person()
                {
                    Year = 1927,
                    Honor = "Man of the Year",
                    Name = "Charles Lindbergh",
                    Country = "United States",
                    Birth_Year = 1902,
                    DeathYear = 1974,
                    Title = "US Air Mail Pilot",
                    Category = "",
                    Context = "First Solo Transatlantic Flight"
                },
                0
            };

            yield return new object[2]
            {
                new Person()
                {
                    Year = 1975,
                    Honor = "Women of the Year",
                    Name = "American Women",
                    Country = "United States",
                    Birth_Year = 0,
                    DeathYear = 0,
                    Title = "",
                    Category = "Politics",
                    Context = "Feminist Movement"
                },
                52
            };

            yield return new object[2]
            {
                new Person()
                {
                    Year = 2016,
                    Honor = "Person of the Year",
                    Name = "Donald Trump",
                    Country = "United States",
                    Birth_Year = 1946,
                    DeathYear = 0,
                    Title = "President of the United States",
                    Category = "Politics",
                    Context = "Presidential Election"
                },
                103
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
