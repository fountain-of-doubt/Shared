namespace Functional.UnitTests;

public class Option_Reduce
{
    [Fact]
    public void Reduce_None_T__With_default_value__Returns_wrapped_value()
    {
        var defaultValue = new Alpha("Replacement");
        var none = Option<Alpha>.None;

        var result = none.Reduce(defaultValue);

        result.Should().Be(defaultValue);
    }

    [Fact]
    public void Reduce_None_T__With_default_function__Returns_wrapped_value()
    {
        var defaultValue = new Alpha("Replacement");
        var none = Option<Alpha>.None;

        var result = none.Reduce(() => new Alpha("Replacement"));

        result.Should().Be(defaultValue);
    }

    [Fact]
    public void Reduce_Some_T__With_default_value__Returns_wrapped_value()
    {
        var value = new Alpha("Some string");
        var defaultValue = new Alpha("Replacement");
        var some = Option<Alpha>.Some(value);

        var result = some.Reduce(defaultValue);

        result.Should().Be(value);
    }

    [Fact]
    public void Reduce_Some_T__With_default_function__Returns_wrapped_value()
    {
        var value = new Alpha("Some string");
        var some = Option<Alpha>.Some(value);

        var result = some.Reduce(() => new Alpha("Replacement"));

        result.Should().Be(value);
    }
}
