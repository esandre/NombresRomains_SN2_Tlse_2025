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

    [Theory]
    [InlineData("V", 5)]
    [InlineData("X", 10)]
    [InlineData("XV", 15)]
    [InlineData("XX", 20)]
    public void SymbolesRemarquables(string representation, int valeur)
    {
        Assert.Equal(representation, valeur.ToRomanNumbers());
    }

    [Theory(DisplayName = "Entre 1 et 3 au-dessus d'un symbole, on r�p�te n - valeurSymbole * I")]
    [InlineData(5, 1)]
    [InlineData(5, 2)]
    [InlineData(5, 3)]
    [InlineData(10, 1)]
    [InlineData(10, 2)]
    [InlineData(10, 3)]
    [InlineData(15, 1)]
    [InlineData(15, 2)]
    [InlineData(15, 3)]
    public void TestUnit�sAuDessusSymbole(int valeurSymbole, int deltaAvecValeurSymbole)
    {
        var representationSymbole = valeurSymbole.ToRomanNumbers();
        var attendu = representationSymbole + new string('I', deltaAvecValeurSymbole);

        var nombreTest� = valeurSymbole + deltaAvecValeurSymbole;

        Assert.Equal(attendu, nombreTest�.ToRomanNumbers());
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

    [Fact]
    public void TestNonSupport�()
    {
        Assert.Equal(NombresRomainsExtensions.ErrorMessage, 21.ToRomanNumbers());
    }
}

