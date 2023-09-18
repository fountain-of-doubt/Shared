namespace Functional.UnitTests;

public class Option_None_Equality
{
    [Fact]
    public void None_T__Equals__Itself()
    {
        var na = Option<Alpha>.None;

        na.Should().Be(na);
    }

    [Fact]
    public void None_T__Equals__None_T()
    {
        var na1 = Option<Alpha>.None;
        var na2 = Option<Alpha>.None;

        na1.Should().Be(na2);
        na2.Should().Be(na1);
    }

    [Fact]
    public void None_T__Equals__None_R()
    {
        var na = Option<Alpha>.None;
        var nb = Option<Beta>.None;

        na.Should().Be(nb);
        nb.Should().Be(na);
    }

    [Fact]
    public void None_T__Not_Equals__Some_T()
    {
        var none = Option<Alpha>.None;
        var sa = Option<Alpha>.Some(new Alpha("alpha"));

        none.Should().NotBe(sa);
        sa.Should().NotBe(none);
    }

    [Fact]
    public void None_T__GetHashCode__Zero()
    {
        var none = Option<Alpha>.None;

        var hash = none.GetHashCode();

        hash.Should().Be(0);
    }
}
