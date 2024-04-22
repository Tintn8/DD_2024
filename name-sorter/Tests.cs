using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.IO;
using System.Linq;

namespace name_sorter.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private string? _testFilePath;

        [SetUp]
        public void Setup()
        {
            // Create a temporary test file with some names
            _testFilePath = Path.GetTempFileName();
            File.WriteAllLines(_testFilePath, new[] { "Jane Doe", "Joe Schmoe", "Db Cooper" });
        }

        [TearDown]
        public void TearDown()
        {
            // Delete the temporary test file
            File.Delete(_testFilePath);
        }

        [Test]
        public void ReadNamesFromFile_WhenValidFile_ReturnsNamesList()
        {
            // Arrange
            var expectedNames = new[] { "Jane Doe", "Joe Schmoe", "Db Cooper" };

            // Act
            var actualNames = Program.ReadNamesFromFile(_testFilePath);

            // Assert
            CollectionAssert.AreEqual(expectedNames, actualNames);
        }

        [Test]
        public void ReadNamesFromFile_WhenInvalidFile_ThrowsException()
        {
            // Arrange
            string invalidFilePath = "nonexistent_file.txt";

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => Program.ReadNamesFromFile(invalidFilePath));
        }
    }
}
