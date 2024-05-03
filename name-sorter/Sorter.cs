namespace NameSorter
{
    // Sorter class responsible for sorting names
    public class Sorter
    {
        // Dependencies  
        private readonly INameLoader _nameLoader;
        private readonly INameSorter _nameSorter;
        private readonly INameWriter _nameWriter;
        private readonly INameDisplayer _nameDisplayer;

        // Constructor inject dependencies
        public Sorter(INameLoader nameLoader, INameSorter nameSorter, INameWriter nameWriter, INameDisplayer nameDisplayer)
        {
            _nameLoader = nameLoader;
            _nameSorter = nameSorter;
            _nameWriter = nameWriter;
            _nameDisplayer = nameDisplayer;
        }

        // Main method to run the sorting process
        public void Run(string[] args)
        {
            try
            {
                //   command line arguments
                var arguments = ParseArguments(args);

                //  no valid file is detected check
                if (arguments == null)
                {
                    Console.WriteLine("No valid file detected");
                    return;
                }

                //  input file name from args
                var inputFileName = arguments.InputFileName;

                // set output file name
                var outputFileName = "sorted_names.txt";

                // load names from file
                var names = _nameLoader.LoadNamesFromFile(inputFileName);

                 
                var sortedNames = _nameSorter.SortNames(names);

                // Write to file
                _nameWriter.WriteNamesToFile(outputFileName, sortedNames);

                // Display in cmd
                _nameDisplayer.DisplaySortedNames(sortedNames);

                //Success message
                Console.WriteLine("Names sorted successfully, sorted names saved in sorted_names.txt");
            }
            // Unexpected exceptions
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Parsing args
        private Arguments? ParseArguments(string[] args)
        {
            try
            {
                // Check for one argument only
                if (args.Length != 1)
                {
                    return null;
                }

                // Returning arguments 
                return new Arguments { InputFileName = args[0] };
            }
            // Invalid arguments  
            catch (Exception ex)
            {
                throw new Exception($"Invalid arguments:{ex.Message}");
            }
        }

         
        static void Main(string[] args)
        {
            // Creating a new Sorter instance 
            var sorter = new Sorter(new NameLoad(), new NameSort(), new NameWriter(), new NameDisplayer());

             
            sorter.Run(args);
        }
    }
}
