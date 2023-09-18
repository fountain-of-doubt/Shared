namespace Functional.UnitTests;

public class Option_Some_Equality
{
    [Fact]
    public void Some_T__Equals__Itself()
    {
        var sa = Option<Alpha>.Some(new Alpha("alpha"));

        sa.Should().Be(sa);
    }

    [Fact]
    public void Some_T__Equals__Some_T__With_same_value()
    {
        var alpha = new Alpha("alpha");
        var sa1 = Option<Alpha>.Some(alpha);
        var sa2 = Option<Alpha>.Some(alpha);

        sa1.Should().Be(sa2);
        sa2.Should().Be(sa1);
    }

    [Fact]
    public void Some_Ts__Created_from_equals__Equal()
    {
        var v1 = new ValueObject("name", 100);
        var v2 = new ValueObject("name", 100);

        var sv1 = Option<ValueObject>.Some(v1);
        var sv2 = Option<ValueObject>.Some(v2);

        sv1.Should().Be(sv2);
        sv2.Should().Be(sv1);
    }

    [Fact]
    public void Some_Ts__Created_from_not_equals__Not_equal()
    {
        var sa1 = Option<Alpha>.Some(new Alpha("alpha-1"));
        var sa2 = Option<Alpha>.Some(new Alpha("alpha-2"));

        sa1.Should().NotBe(sa2);
        sa2.Should().NotBe(sa1);
    }

    [Fact]
    public void Some_T__Not_Equals__Some_R()
    {
        var sa = Option<Alpha>.Some(new Alpha("alpha"));
        var sb = Option<Beta>.Some(new Beta(2));

        sa.Should().NotBe(sb);
        sb.Should().NotBe(sa);
    }

    [Fact]
    public void Some_T__GetHashCode__Returns_value_hashcode()
    {
        var value = "Some option value";
        var s = Option<string>.Some(value);
        var expected = value.GetHashCode();

        var hash = s.GetHashCode();

        hash.Should().Be(expected);
    }
}
