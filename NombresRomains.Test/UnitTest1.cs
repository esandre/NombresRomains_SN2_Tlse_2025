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

    [Theory]
    [InlineData("V", 5)]
    [InlineData("X", 10)]
    [InlineData("XV", 15)]
    [InlineData("XX", 20)]
    public void SymbolesRemarquables(string representation, int valeur)
    {
        Assert.Equal(representation, valeur.ToRomanNumbers());
    }

    [Theory(DisplayName = "Entre 1 et 3 au-dessus d'un symbole, on répète n - valeurSymbole * I")]
    [InlineData(5, 1)]
    [InlineData(5, 2)]
    [InlineData(5, 3)]
    [InlineData(10, 1)]
    [InlineData(10, 2)]
    [InlineData(10, 3)]
    [InlineData(15, 1)]
    [InlineData(15, 2)]
    [InlineData(15, 3)]
    public void TestUnitésAuDessusSymbole(int valeurSymbole, int deltaAvecValeurSymbole)
    {
        var representationSymbole = valeurSymbole.ToRomanNumbers();
        var attendu = representationSymbole + new string('I', deltaAvecValeurSymbole);

        var nombreTesté = valeurSymbole + deltaAvecValeurSymbole;

        Assert.Equal(attendu, nombreTesté.ToRomanNumbers());
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

    [Fact]
    public void TestNonSupporté()
    {
        Assert.Equal(NombresRomainsExtensions.ErrorMessage, 21.ToRomanNumbers());
    }
}

