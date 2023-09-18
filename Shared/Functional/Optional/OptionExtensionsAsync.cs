namespace Shared.Functional.Optional;

public static partial class OptionExtensionsAsync
{

}

public static class OptionAsyncConfig
{
    public record class Map(bool configureAwaitOption, bool configureAwaitMap, CancellationToken cancellationToken)
    {
        public static readonly Map Default = new(false, false, CancellationToken.None);
    }

    public record class Bind(bool configureAwaitOption, bool configureAwaitBind, CancellationToken cancellationToken)
    {
        public static readonly Bind Default = new(false, false, CancellationToken.None);
    }

    public record class Reduce(bool configureAwaitOption, bool configureAwaitDefault, CancellationToken cancellationToken)
    {
        public static readonly Reduce Default = new(false, false, CancellationToken.None);
    }

    public record class Match(bool configureAwaitOption, bool configureAwaitOnNone, bool configureAwaitOnSome, CancellationToken cancellationToken)
    {
        public static readonly Match Default = new(false, false, false, CancellationToken.None);
    }
}
