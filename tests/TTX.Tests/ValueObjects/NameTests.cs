using TTX.Exceptions;
using TTX.ValueObjects;

namespace TTX.Tests.ValueObjects;

[TestClass]
public class NameTests
{
    [TestMethod]
    public void Create_WithValidName_ShouldReturnNameInstance()
    {
        var validName = "Valid_Name";

        var name = Name.Create(validName);

        Assert.IsNotNull(name);
        Assert.AreEqual(validName, name.Value);
    }

    [TestMethod]
    public void Create_WithNullOrEmptyName_ShouldThrowException()
    {
        var invalidName = "";

        Assert.ThrowsException<InvalidValueObjectException>(() => { Name.Create(invalidName); });
    }

    [TestMethod]
    public void Create_WithNameTooShort_ShouldThrowException()
    {
        var shortName = "ab";

        Assert.ThrowsException<InvalidValueObjectException>(() => { Name.Create(shortName); });
    }

    [TestMethod]
    public void Create_WithNameTooLong_ShouldThrowException()
    {
        var longName = new string('a', Name.MaxLength + 1);

        Assert.ThrowsException<InvalidValueObjectException>(() => { Name.Create(longName); });
    }

    [TestMethod]
    public void Create_WithInvalidCharacters_ShouldThrowException()
    {
        var invalidName = "Invalid@Name!";

        Assert.ThrowsException<InvalidValueObjectException>(() => { Name.Create(invalidName); });
    }

    [TestMethod]
    public void ImplicitConversion_FromString_ShouldReturnNameInstance()
    {
        var validName = "Another_ValidName";

        Name name = validName;

        Assert.AreEqual(validName, name.Value);
    }
}