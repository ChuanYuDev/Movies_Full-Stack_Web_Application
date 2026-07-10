using System.ComponentModel.DataAnnotations;
using CoreBusiness.Validations;

namespace MoviesAPITests;

[TestClass]
public sealed class FirstLetterUppercaseAttributeTests
{
    [TestMethod]
    [DataRow("")]
    [DataRow("      ")]
    [DataRow(null)]
    public void IsValid_ShouldReturnSuccess_WhenValueIsEmptyOrNull(string value)
    {
        // Preparation
        var firstLetterUppercaseAttribute = new FirstLetterUppercaseAttribute();
        var validationContext = new ValidationContext(new object());
        
        // Testing
        var result = firstLetterUppercaseAttribute.GetValidationResult(value, validationContext);
        
        // Verification
        Assert.AreEqual(expected: ValidationResult.Success, actual: result);
    }
}