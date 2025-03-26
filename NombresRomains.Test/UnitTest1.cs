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

    [Fact]
    public void Test4()
    {
        const int nombre = 4;
        Assert.Equal("IV", nombre.ToRomanNumbers());
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

    [Fact]
    public void Test5()
    {
        const int nombre = 5;
        Assert.Equal("V", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test6()
    {
        const int nombre = 6;
        Assert.Equal("VI", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test7()
    {
        const int nombre = 7;
        Assert.Equal("VII", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test8()
    {
        const int nombre = 8;
        Assert.Equal("VIII", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test9()
    {
        const int nombre = 9;
        Assert.Equal("IX", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test10()
    {
        const int nombre = 10;
        Assert.Equal("X", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test11()
    {
        const int nombre = 11;
        Assert.Equal("XI", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test12()
    {
        const int nombre = 12;
        Assert.Equal("XII", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test13()
    {
        const int nombre = 13;
        Assert.Equal("XIII", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test14()
    {
        const int nombre = 14;
        Assert.Equal("XIV", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test15()
    {
        const int nombre = 15;
        Assert.Equal("XV", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test16()
    {
        const int nombre = 16;
        Assert.Equal("XVI", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test17()
    {
        const int nombre = 17;
        Assert.Equal("XVII", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test18()
    {
        const int nombre = 18;
        Assert.Equal("XVIII", nombre.ToRomanNumbers());
    }

    [Fact]
    public void Test19()
    {
        const int nombre = 19;
        Assert.Equal("XIX", nombre.ToRomanNumbers());
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

