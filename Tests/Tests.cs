using Moq;
using NameSorter;
using Xunit;
using System.Collections.Generic;

public class SorterTests
{
    [Fact]
    public void Run_WhenValidFileExists_SortsAndWritesToFile()
    {
        // Arrange
        var inputFileName = "input.txt";
        var outputFileName = "sorted_names.txt";

        // Generating 1000 names for testing
        var names = new List<string>();
        for (int i = 0; i < 1000; i++)
        {
            names.Add($"Name{i}");
        }

        // Creating mocks for dependencies
        var mockLoader = new Mock<INameLoader>();
        var mockSorter = new Mock<INameSorter>();
        var mockWriter = new Mock<INameWriter>();
        var mockDisplayer = new Mock<INameDisplayer>();
        var sorter = new Sorter(mockLoader.Object, mockSorter.Object, mockWriter.Object, mockDisplayer.Object);

        // Setting up mock behaviors
        mockLoader.Setup(l => l.LoadNamesFromFile(inputFileName)).Returns(names);
        mockSorter.Setup(s => s.SortNames(names)).Returns(names);

        // Act
        sorter.Run(new[] { inputFileName });

        // Assert
        mockLoader.Verify(l => l.LoadNamesFromFile(inputFileName), Times.Once);
        mockSorter.Verify(s => s.SortNames(names), Times.Once);
        mockWriter.Verify(w => w.WriteNamesToFile(outputFileName, names), Times.Once);
        mockDisplayer.Verify(d => d.DisplaySortedNames(names), Times.Once);
    }

    [Fact]
    public void Run_WhenValidFileExists_SortsNames()
    {
        // Arrange
        var mockLoader = new Mock<INameLoader>();
        var mockSorter = new Mock<INameSorter>();
        var mockWriter = new Mock<INameWriter>();
        var mockDisplayer = new Mock<INameDisplayer>();

        var sorter = new Sorter(mockLoader.Object, mockSorter.Object, mockWriter.Object, mockDisplayer.Object);
        var args = new[] { "valid_file.txt" };
        var namesFromFile = new List<string> { "John Doe", "Jane Smith", "Alice Johnson" };
        var sortedNames = new List<string> { "Alice Johnson", "Jane Smith", "John Doe" };

        // Setting up mock behaviors
        mockLoader.Setup(l => l.LoadNamesFromFile("valid_file.txt")).Returns(namesFromFile);
        mockSorter.Setup(s => s.SortNames(namesFromFile)).Returns(sortedNames);

        // Act
        sorter.Run(args);

        // Assert
        mockSorter.Verify(s => s.SortNames(namesFromFile), Times.Once);
    }
}
