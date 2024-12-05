using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinderChallenge
{
    public static class MockData
    {
        public static string[] Matrix = new[]
        {
            "ABCDEDAB",
            "EFGJVSAN",
            "IJKLGVAB",
            "MNSOFTWA",
            "BTASKSEF",
            "BTADEVKF",
            "BWBESSEF",
            "BWBVSSEF",
        };

        public static string[] WordStream = new[]
        {
            "ABCD",
            "ABCD",
            "ABCD",
            "DEV",
            "SOFT",
            "TASK",
            "SOFTWARE",
            "BACKEND"
        };
    }
}
