using ConsoleApp1;
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            string result = "";
            Console.WriteLine("Enter the string:");
            string input = Console.ReadLine();
            if (input != null)
                result = ProgramHelpers.CommaSeparateCharacters(input: input);

            Console.WriteLine($"Comma-separated string: {result}");
        }
        catch (Exception ex)
        {
            Console.Write(ex.ToString());
        }
    }
}
