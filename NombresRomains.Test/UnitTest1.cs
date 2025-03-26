namespace NombresRomains.Test;

public class UnitTest1
{
    private static readonly IDictionary<string, int> Symboles = new Dictionary<string, int>
    {
        { "V", 5 },
        { "X", 10 },
        { "XV", 15 },
        { "XX", 20 },
    };

    [Theory(DisplayName = "Entre 1 et 3, on r�p�te n * I")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void TestUnit�(int nombreArabe)
    {
        Assert.Equal(new string('I', nombreArabe), nombreArabe.ToRomanNumbers());
    }

    public static IEnumerable<object[]> CasSymbolesRemarquables =>
        Symboles.Select(keyValue => new object[] { keyValue.Key, keyValue.Value });

    [Theory]
    [MemberData(nameof(CasSymbolesRemarquables))]
    public void SymbolesRemarquables(string representation, int valeur)
    {
        Assert.Equal(representation, valeur.ToRomanNumbers());
    }

    public static IEnumerable<object[]> CasUnit�sAuDessusSymbole()
    {
        foreach (var symbole in Symboles)
        {
            yield return [symbole.Value, 1];
            yield return [symbole.Value, 2];
            yield return [symbole.Value, 3];
        }
    }

    [Theory(DisplayName = "Entre 1 et 3 au-dessus d'un symbole, on r�p�te n - valeurSymbole * I")]
    [MemberData(nameof(CasUnit�sAuDessusSymbole))]
    public void TestUnit�sAuDessusSymbole(int valeurSymbole, int deltaAvecValeurSymbole)
    {
        var representationSymbole = valeurSymbole.ToRomanNumbers();
        var attendu = representationSymbole + new string('I', deltaAvecValeurSymbole);

        var nombreTest� = valeurSymbole + deltaAvecValeurSymbole;

        Assert.Equal(attendu, nombreTest�.ToRomanNumbers());
    }

    public static IEnumerable<object[]> CasUnAvantSymboleUnit�Pr�c�de() =>
        Symboles.Select(keyValue => new object[] { keyValue.Value - 1 });

    [Theory(DisplayName = "Une unit� avant un symbole s'�crit avec I pr�c�dant ce symbole")]
    [MemberData(nameof(CasUnAvantSymboleUnit�Pr�c�de))]
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
        Assert.Equal(NombresRomainsExtensions.ErrorMessage, 24.ToRomanNumbers());
    }
}

