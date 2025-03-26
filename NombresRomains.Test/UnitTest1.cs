namespace NombresRomains.Test;

public class UnitTest1
{
    [Theory(DisplayName = "Entre 1 et 3, on r�p�te n * I")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void TestUnit�(int nombreArabe)
    {
        Assert.Equal(new string('I', nombreArabe), nombreArabe.ToRomanNumbers());
    }

    [Theory(DisplayName = "Une unit� avant un symbole s'�crit avec I pr�c�dant ce symbole")]
    [InlineData(4)]
    [InlineData(9)]
    [InlineData(14)]
    [InlineData(19)]
    public void UnAvantSymboleUnit�Pr�c�de(int valeurTest�e)
    {
        var valeurSymbole = valeurTest�e + 1;
        var representationSymbole = valeurSymbole.ToRomanNumbers();
        var nombreRomainTest� = valeurTest�e.ToRomanNumbers();

        var attendu = representationSymbole.Insert(representationSymbole.Length - 1, "I");
        Assert.Equal(attendu, nombreRomainTest�);
    }

    [Theory(DisplayName = "Entre 5 et 8, on met V plus (5-n) * I")]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    public void TestCinqPlusUnit�(int nombreArabe)
    {
        Assert.Equal("V" + new string('I', nombreArabe - 5), nombreArabe.ToRomanNumbers());
    }

    [Theory(DisplayName = "Entre 10 et 13, on met X plus (10-n) * I")]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    public void TestDixPlusUnit�(int nombreArabe)
    {
        Assert.Equal("X" + new string('I', nombreArabe - 10), nombreArabe.ToRomanNumbers());
    }

    [Theory(DisplayName = "Entre 15 et 18, on met XV plus (15-n) * I")]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
    public void TestQuinzePlusUnit�(int nombreArabe)
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
    public void TestNonSupport�()
    {
        Assert.Equal(NombresRomainsExtensions.ErrorMessage, 21.ToRomanNumbers());
    }
}

