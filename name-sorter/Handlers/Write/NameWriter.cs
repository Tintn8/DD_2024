//Writing names  
public class NameWriter : INameWriter
{
    // Writes a list of names to a file
    public void WriteNamesToFile(string fileName, List<string> names)
    {
        try
        {
            //write names to the file
            File.WriteAllLines(fileName, names);
        }
        //catch errors
        catch (Exception ex)
        {
            throw new Exception($"Error writing to file: {ex.Message}");
        }
    }
}