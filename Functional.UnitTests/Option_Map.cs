namespace Functional.UnitTests;

public class Option_Map
{
    [Fact]
    public void Map_None_T__To_Option_T__Returns_None()
    {
        var none = Option<Alpha>.None;

        var result = none.Map(Map.ReverseContent);

        result.GetType().Should().Be(typeof(Option<Alpha>));
        result.Should().Be(Option<Alpha>.None);
    }

    [Fact]
    public void Map_None_T__To_Option_R__Returns_None()
    {
        var none = Option<Alpha>.None;

        var result = none.Map(Map.ParseContent);

        result.GetType().Should().Be(typeof(Option<Beta>));
        result.Should().Be(Option<Beta>.None);
    }

    [Fact]
    public void Map_Some_T__To_Option_T__When_T_mapped_to_null__Returns_None()
    {
        var some = Option<Alpha>.Some(new Alpha("Some content"));

        var result = some.Map(Map.NullA);

        result.GetType().Should().Be(typeof(Option<Alpha>));
        result.Should().Be(Option<Alpha>.None);
    }

    [Fact]
    public void Map_Some_T__To_Option_T__When_T_mapped_to_non_null__Returns_mapped_option()
    {
        var alpha = new Alpha("Some content");
        var some = Option<Alpha>.Some(alpha);
        var mapped = Map.ReverseContent(alpha);
        var expected = Option<Alpha>.Some(mapped);

        var result = some.Map(Map.ReverseContent);

        result.GetType().Should().Be(typeof(Option<Alpha>));
        result.Should().Be(expected);
    }

    [Fact]
    public void Map_Some_T__To_Option_R__When_T_mapped_to_null__Returns_None()
    {
        var some = Option<Alpha>.Some(new Alpha("Some content"));

        var result = some.Map(Map.NullB);

        result.GetType().Should().Be(typeof(Option<Beta>));
        result.Should().Be(Option<Beta>.None);
    }

    [Fact]
    public void Map_Some_T__To_Option_R__When_T_mapped_to_non_null__Returns_mapped_option()
    {
        var alpha = new Alpha("1");
        var some = Option<Alpha>.Some(alpha);
        var mapped = Map.ParseContent(alpha);
        var expected = Option<Beta>.Some(mapped!);

        var result = some.Map(Map.ParseContent);

        result.GetType().Should().Be(typeof(Option<Beta>));
        result.Should().Be(expected);
    }
}
