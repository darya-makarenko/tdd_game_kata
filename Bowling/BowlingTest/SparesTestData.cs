using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingTest
{
    public class SparesTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 1, 2, 8 };
                yield return new object[] { 3, 4, 6 };
                yield return new object[] { 4, 7, 3 };
                yield return new object[] { 6, 1, 9 };
                yield return new object[] { 8, 5, 5 };
                yield return new object[] { 9, 3, 7 };
            }
        }

    }
}
