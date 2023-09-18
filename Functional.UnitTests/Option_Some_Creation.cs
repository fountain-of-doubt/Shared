namespace Functional.UnitTests;

public class Option_Some_Creation
{
    [Fact]
    public void Some__Created_with_null_value__Throws()
    {
        var act = () =>
        {
            var s = Option<Alpha>.Some(null!);
        };

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Some__Created_with_Some_T__Equals__Some_created_with_From()
    {
        var alpha = new Alpha("alpha");
        var sa1 = Option<Alpha>.Some(alpha);
        var sa2 = Option<Alpha>.From(alpha);

        sa1.Should().Be(sa2);
    }

    [Fact]
    public void Some__Created_with_Some_T__Equals__Some_created_with_generic_Some()
    {
        var alpha = new Alpha("alpha");
        var sa1 = Option<Alpha>.Some(alpha);
        var sa2 = Option.Some(alpha);

        sa1.Should().Be(sa2);
    }

    [Fact]
    public void Some__Created_with_Some_T__Equals__Some_created_with_implicit_conversion()
    {
        var alpha = new Alpha("alpha");
        var sa1 = Option<Alpha>.Some(alpha);
        Option<Alpha> sa2 = alpha;

        sa1.Should().Be(sa2);
    }

    [Fact]
    public void Some__Created_with_Some_T__Equals__Some_created_with_generic_From()
    {
        var alpha = new Alpha("alpha");
        var sa1 = Option<Alpha>.Some(alpha);
        var sa2 = Option.From(alpha);

        sa1.Should().Be(sa2);
    }
}
