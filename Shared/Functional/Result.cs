namespace Shared.Functional;

public readonly struct Result
{
    public static readonly Result Fail = new Result();
    public static readonly Result Success = new Result();


}
