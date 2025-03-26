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

    [Theory(DisplayName = "Entre 1 et 3, on répète n * I")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void TestUnité(int nombreArabe)
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

    public static IEnumerable<object[]> CasUnitésAuDessusSymbole()
    {
        foreach (var symbole in Symboles)
        {
            yield return [symbole.Value, 1];
            yield return [symbole.Value, 2];
            yield return [symbole.Value, 3];
        }
    }

    [Theory(DisplayName = "Entre 1 et 3 au-dessus d'un symbole, on répète n - valeurSymbole * I")]
    [MemberData(nameof(CasUnitésAuDessusSymbole))]
    public void TestUnitésAuDessusSymbole(int valeurSymbole, int deltaAvecValeurSymbole)
    {
        var representationSymbole = valeurSymbole.ToRomanNumbers();
        var attendu = representationSymbole + new string('I', deltaAvecValeurSymbole);

        var nombreTesté = valeurSymbole + deltaAvecValeurSymbole;

        Assert.Equal(attendu, nombreTesté.ToRomanNumbers());
    }

    public static IEnumerable<object[]> CasUnAvantSymboleUnitéPrécède() =>
        Symboles.Select(keyValue => new object[] { keyValue.Value - 1 });

    [Theory(DisplayName = "Une unité avant un symbole s'écrit avec I précédant ce symbole")]
    [MemberData(nameof(CasUnAvantSymboleUnitéPrécède))]
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
        Assert.Equal(NombresRomainsExtensions.ErrorMessage, 24.ToRomanNumbers());
    }
}

