namespace name_sorter
{
     //logic is broken into functions to provide better reusability for later implementations
    public class Program
    {
        // Start of program
        static void Main(string[] args)
        {
            // Check if a file is provided
            if (args.Length != 1)
            {
                Console.WriteLine("No Textfile Detected");
                return;
            }

            // Get the input   
            string inputFileName = args[0];
            // Set output filename
            string outputFileName = "sorted_names.txt";

            try
            {
                // Read the names from the input
                List<string> names = ReadNamesFromFile(inputFileName);

                // Sort the names
                List<string> sortName = SortNames(names);

                // Write the sorted names to the output file
                WriteNamesToFile(outputFileName, sortName);

                // Display the sorted names
                Console.WriteLine("List of Names:");

                              foreach (string name in sortName)
                                         {
                                            Console.WriteLine(name);
                                         }

                // Display success message
                Console.WriteLine("Names sorted successfully, sorted names saved in Text file");
            }
           
            catch (Exception ex)
            {
                // Display error message 
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Read names from a file and return them as a list of strings
        public static List<string> ReadNamesFromFile(string fileName)
        {
            try
            {
                return File.ReadAllLines(fileName).ToList();
            }
            catch (Exception ex)
            {
                // Throw an exception with an error message if file reading fails
                throw new Exception($"Error reading the file: {ex.Message}");
            }
        }

        // Sorts a list of names alphabetically 
        public static List<string> SortNames(List<string> names)
        {
            // Split names into parts, order by last name, then by given names, and join back
            return names
                .Select(name => name.Split(' '))

                .OrderBy(nameParts => nameParts.Last())

                .ThenBy(nameParts => string.Join(' ', nameParts.Take(nameParts.Length - 1)))

                .Select(nameParts => string.Join(' ', nameParts))

                .ToList();
            // Chose list instead of array due to familiarity. The list was chosen due to the unkown amount of items. 
        }


        // Write a list of names to a file
        public static void WriteNamesToFile(string fileName, List<string> names)
        {
            try
            {
                File.WriteAllLines(fileName, names);
            }
            catch (Exception ex)
            {
                // Throw an exception with an error message if file writing fails
                throw new Exception($"Error writing to file: {ex.Message}");
            }
        }
    }
}
