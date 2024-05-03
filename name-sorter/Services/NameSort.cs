// Implementation for sorting names
public class NameSort : INameSorter
{
    // Sorts a list of names alphabetically 
    public List<string> SortNames(List<string> names)
    {
        try
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

        // Invalid arguments 
        catch (Exception ex)
        {
            throw new Exception($"Error sorting List:{ex.Message}");
        }
    }
}