// Implementation for loading names from a file
public class NameLoad : INameLoader
{
    // Loads names from a file
    public List<string> LoadNamesFromFile(string fileName)
    {
        try
        {
            // Reading from file and add  to list
            var names = new List<string>();

            //switched to streamreader for handling larger filesizes
            using (var reader = new StreamReader(fileName))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    names.Add(line);
                }
            }
            return names;
        }
        // Invalid arguments 
        catch (Exception ex)
        {
            throw new Exception($"Error loading names:{ex.Message}");
        }
    }
}