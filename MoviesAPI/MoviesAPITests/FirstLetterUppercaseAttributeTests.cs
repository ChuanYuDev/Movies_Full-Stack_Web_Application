using System.ComponentModel.DataAnnotations;
using CoreBusiness.Validations;

namespace MoviesAPITests;

[TestClass]
public sealed class FirstLetterUppercaseAttributeTests
{
    [TestMethod]
    public void IsValid_ShouldReturnSuccess_WhenValueIsEmpty()
    {
        // Preparation
        var firstLetterUppercaseAttribute = new FirstLetterUppercaseAttribute();
        var value = string.Empty;
        var validationContext = new ValidationContext(new object());
        
        // Testing
        var result = firstLetterUppercaseAttribute.GetValidationResult(value, validationContext);
        
        // Verification
        Assert.AreEqual(expected: ValidationResult.Success, actual: result);
    }
}