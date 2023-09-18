namespace Functional.UnitTests;

public class Option_Bind
{
    [Fact]
    public void Bind_None_T__To_Option_T__Returns_None()
    {
        var none = Option<Alpha>.None;

        var result = none.Bind(Bind.ReverseContent);

        result.GetType().Should().Be(typeof(Option<Alpha>));
        result.Should().Be(Option<Alpha>.None);
    }

    [Fact]
    public void Bind_None_T__To_Option_R__Returns_None()
    {
        var none = Option<Alpha>.None;

        var result = none.Bind(Bind.ParseContent);

        result.GetType().Should().Be(typeof(Option<Beta>));
        result.Should().Be(Option<Beta>.None);
    }

    [Fact]
    public void Bind_Some_T__To_Option_T__Returns_mapped_option()
    {
        var alpha = new Alpha("Some content");
        var some = Option<Alpha>.Some(alpha);
        var expected = Bind.ReverseContent(alpha);

        var result = some.Bind(Bind.ReverseContent);

        result.GetType().Should().Be(typeof(Option<Alpha>));
        result.Should().Be(expected);
    }

    [Fact]
    public void Bind_Some_T__To_Option_R__Returns_mapped_option()
    {
        var alpha = new Alpha("1");
        var some = Option<Alpha>.Some(alpha);
        var expected = Bind.ParseContent(alpha);

        var result = some.Bind(Bind.ParseContent);

        result.GetType().Should().Be(typeof(Option<Beta>));
        result.Should().Be(expected);
    }
}
