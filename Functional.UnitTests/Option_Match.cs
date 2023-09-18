namespace Functional.UnitTests;

public class Option_Match
{
    [Fact]
    public void Match_None__With_Action__Invokes_Action()
    {
        bool actionInvoked = false;
        var none = Option<Alpha>.None;
        Action onNone = () => actionInvoked = true;
        Action<Alpha> onSome = (a) => throw new InvalidOperationException();

        none.Match(onSome, onNone);

        actionInvoked.Should().BeTrue();
    }

    [Fact]
    public void Match_None__With_Func__Returns_Func_value()
    {
        var defaultValue = "replacement value";
        var none = Option<Alpha>.None;
        Func<string> onNone = () => defaultValue;
        Func<Alpha, string> onSome = (a) => throw new InvalidOperationException();

        var result = none.Match(onSome, onNone);

        result.Should().Be(defaultValue);
    }

    [Fact]
    public void Match_Some__With_Action__Invokes_Action()
    {
        bool actionInvoked = false;
        var some = Option<Alpha>.Some(new Alpha("some value"));
        Action onNone = () => throw new InvalidOperationException();
        Action<Alpha> onSome = (a) => actionInvoked = true;

        some.Match(onSome, onNone);

        actionInvoked.Should().BeTrue();
    }

    [Fact]
    public void Match_Some__With_Func__Returns_Func_value()
    {
        var content = "content";
        var expected = "processed content";
        var none = Option<Alpha>.Some(new Alpha(content));
        Func<string> onNone = () => throw new InvalidOperationException();
        Func<Alpha, string> onSome = (a) => "processed " + a.Content;

        var result = none.Match(onSome, onNone);

        result.Should().Be(expected);
    }
}
