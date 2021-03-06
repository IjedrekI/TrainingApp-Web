﻿using NUnit.Framework;
using System.Collections;

namespace TraningAppTests.Shared.CoachTestCases
{
    public class CoachTestCases
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("a@gmail.com", "login", "password", "firstName", "lastName", "qwertyqwerty");
                yield return new TestCaseData("Maciek@gmail.com", "Maciek", "A231@", "Maciek", "Maciek", "asdfghasdfgh");
                yield return new TestCaseData("Tomek@gmail.com", "!@#$!@#$", "!@#$!@#$", "!@#$!@#$#$%^&", "#$%^&(*(@#$%DFG", "zxcvbnzxcvbn");
            }
        }
    }
}
