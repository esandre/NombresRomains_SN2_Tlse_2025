namespace NombresRomains.Test;

public class UnitTest1
{
    [Theory(DisplayName = "Entre 1 et 3, on répète n * I")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void TestUnité(int nombreArabe)
    {
        Assert.Equal(new string('I', nombreArabe), nombreArabe.ToRomanNumbers());
    }

    [Theory(DisplayName = "Une unité avant un symbole s'écrit avec I précédant ce symbole")]
    [InlineData(4)]
    [InlineData(9)]
    [InlineData(14)]
    [InlineData(19)]
    public void UnAvantSymboleUnitéPrécède(int valeurTestée)
    {
        var valeurSymbole = valeurTestée + 1;
        var representationSymbole = valeurSymbole.ToRomanNumbers();
        var nombreRomainTesté = valeurTestée.ToRomanNumbers();

        var attendu = representationSymbole.Insert(representationSymbole.Length - 1, "I");
        Assert.Equal(attendu, nombreRomainTesté);
    }

    [Theory(DisplayName = "Entre 5 et 8, on met V plus (5-n) * I")]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    public void TestCinqPlusUnité(int nombreArabe)
    {
        Assert.Equal("V" + new string('I', nombreArabe - 5), nombreArabe.ToRomanNumbers());
    }

    [Theory(DisplayName = "Entre 10 et 13, on met X plus (10-n) * I")]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    public void TestDixPlusUnité(int nombreArabe)
    {
        Assert.Equal("X" + new string('I', nombreArabe - 10), nombreArabe.ToRomanNumbers());
    }

    [Theory(DisplayName = "Entre 15 et 18, on met XV plus (15-n) * I")]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
    public void TestQuinzePlusUnité(int nombreArabe)
    {
        Assert.Equal("XV" + new string('I', nombreArabe - 15), nombreArabe.ToRomanNumbers());
    }

    [Fact]
    public void Test20()
    {
        const int nombre = 20;
        Assert.Equal("XX", nombre.ToRomanNumbers());
    }

    [Fact]
    public void TestNonSupporté()
    {
        Assert.Equal(NombresRomainsExtensions.ErrorMessage, 21.ToRomanNumbers());
    }
}

