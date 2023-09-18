namespace Functional.UnitTests;

public class Option_None_Value
{
    [Fact]
    public void None_Value__Equals__Itself()
    {
        var none = None.Value;

        none.Should().Be(none);
    }

    [Fact]
    public void None_Value__Equals__None_T()
    {
        var n = None.Value;
        var na = Option<Alpha>.None;

        na.Should().Be(n);
        n.Should().Be(na);
    }

    [Fact]
    public void None_Value__Not_Equals__Some_T()
    {
        var none = None.Value;
        var sa = Option<Alpha>.Some(new Alpha("alpha"));

        none.Should().NotBe(sa);
        sa.Should().NotBe(none);
    }
}
