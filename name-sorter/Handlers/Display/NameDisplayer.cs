//Displaying names
public class NameDisplayer : INameDisplayer
{
    // Displays sorted names
    public void DisplaySortedNames(List<string> sortedNames)
    {
        try
        {

            Console.WriteLine("List of Names:");
            //Loop through names and displaying each one
            foreach (string name in sortedNames)
            {
                Console.WriteLine(name);
            }
        }
        //catch errors
        catch (Exception ex)
        {
            throw new Exception($"List display error: {ex.Message}");
        }
    }
}