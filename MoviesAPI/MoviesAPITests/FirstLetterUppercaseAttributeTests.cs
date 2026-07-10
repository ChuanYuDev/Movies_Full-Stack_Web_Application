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
    [DataRow("Felipe")]
    public void IsValid_ShouldReturnSuccess_WhenValueIsEmptyOrNullOrStartsWithUppercase(string value)
    {
        // Preparation
        var firstLetterUppercaseAttribute = new FirstLetterUppercaseAttribute();
        var validationContext = new ValidationContext(new object());
        
        // Testing
        var result = firstLetterUppercaseAttribute.GetValidationResult(value, validationContext);
        
        // Verification
        Assert.AreEqual(expected: ValidationResult.Success, actual: result);
    }
    
    [TestMethod]
    [DataRow("felipe")]
    public void IsValid_ShouldReturnFail_WhenValueStartsWithLowercase(string value)
    {
        var firstLetterUppercaseAttribute = new FirstLetterUppercaseAttribute();
        var validationContext = new ValidationContext(new object());
        
        var result = firstLetterUppercaseAttribute.GetValidationResult(value, validationContext);
        
        Assert.AreEqual(expected: "The first letter should be uppercase", actual: result?.ErrorMessage);
    }
}