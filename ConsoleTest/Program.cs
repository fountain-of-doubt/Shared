using Shared.Functional;

namespace ConsoleTest;

internal class Program
{
    static void Main(string[] args)
    {
        //var t = typeof(Option<>);
        //var o1 = new Option<int>();
        //var t2 = typeof(Option<int>);

        //Console.WriteLine(t2.IsAssignableFrom(t));

        var n1 = Option<int>.None;
        var n2 = Option<string>.None;

        Console.WriteLine(n1.Equals(n2));
    }
}
