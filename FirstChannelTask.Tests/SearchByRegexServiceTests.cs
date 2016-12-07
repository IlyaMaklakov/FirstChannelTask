using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstChannelTask.Application.Services.SearchByRegexService;

namespace FirstChannelTask.Tests
{
    [TestClass]
    public class SearchByRegexServiceTests
    {
        [TestMethod]
        public void SearchInTxtByRegexServiceTest()
        {
            // Arrange
            var emailRegex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            var filePath =  @"..\..\Files\testFile1.txt";
            var searcherService = new SearchByRegexService();

            // Act
            var foundElements = searcherService.SearchByRegex(filePath, emailRegex);

            // Assert
            Assert.IsNotNull(foundElements);
            Assert.AreEqual(3, foundElements.Count);
        }

        [TestMethod]
        public void SearchInXlsxByRegexServiceTest()
        {
            // Arrange
            var emailRegex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            var filePath = @"..\..\Files\testFile2.xlsx";
            var searcherService = new SearchByRegexService();

            // Act
            var foundElements = searcherService.SearchByRegex(filePath, emailRegex);

            // Assert
            Assert.IsNotNull(foundElements);
            Assert.AreEqual(2, foundElements.Count);
        }
    }
}
