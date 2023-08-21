using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Functional;

// Result -> Option - GetSuccessResultOrDefault(/None)
public static class ResultExtensions
{
    public static TOut Match<TOut>(in this Result result, Func<TOut> OnSuccess, Func<TOut> OnFail)
        => result.IsSuccess
            ? OnSuccess()
            : OnFail();

    public static void Match(in this Result result, Action OnSuccess, Action OnFail)
    {
        if (result.IsSuccess) { OnSuccess(); }
        else { OnFail(); }
    }
}
