using System;
using System.Reflection;

namespace RomanNumerals
{
    public static class AboutInfo
    {
        /// <summary>
        ///     Not to be confused with Package Version or Assembly File Version.
        /// </summary>
        public static string AssemblyVersion
        {
            get
            {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;
                return v.Major + "." + v.Minor + "." + v.Build;
            }
        }

        public static string ReleaseDate => "22 July 2021.";
    }
}