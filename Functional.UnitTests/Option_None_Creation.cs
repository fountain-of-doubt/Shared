namespace Functional.UnitTests;

public class Option_None_Creation
{
    [Fact]
    public void None__Created_with_None_T__Equals__None_created_with_From()
    {
        var n1 = Option<Alpha>.None;
        var n2 = Option<Alpha>.From(null!);

        n1.Should().Be(n2);
    }

    [Fact]
    public void None__Created_with_None_T__Equals__None_created_with_implicit_conversion()
    {
        var n1 = Option<Alpha>.None;
        Option<Alpha> n2 = null!;

        n1.Should().Be(n2);
    }

    [Fact]
    public void None__Created_with_None_T__Equals__None_created_with_generic_From()
    {
        var n1 = Option<Alpha>.None;
        var n2 = Option.From(null! as Alpha);

        n1.Should().Be(n2);
    }
}
