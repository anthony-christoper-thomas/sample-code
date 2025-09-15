// See https://aka.ms/new-console-template for more information

namespace ConsoleApp1
{
    internal static class ProgramHelpers

    {

        public static string CommaSeparateCharacters(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                result += input[i];
                if (i < input.Length - 1)
                {
                    result += ",";
                }
            }
            return result;
        }
    }
}