using System;

namespace RomanNumerals
{
    public static class AboutInfo
    {
        /// <summary>
        /// Not to be confused with Package Version or Assembly File Version.
        /// </summary>
        public static string AssemblyVersion
        {
            get
            {
                Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                return v.Major + "." + v.Minor + "." + v.Build + "." + v.Revision;
            }
        }

        public static string ReleaseDate => "11 September 2019";
    }
}