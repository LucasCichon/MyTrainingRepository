using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        private ConcurrentQueue<double> actionTimes = new ConcurrentQueue<double>();
        private ConcurrentQueue<double> resultTimes = new ConcurrentQueue<double>();

        private IFilterDiagnostic diagnostic;

        public TimeFilter(IFilterDiagnostic diag)
        {
            diagnostic = diag;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            Stopwatch timer = Stopwatch.StartNew();
            await next();
            timer.Stop();
            actionTimes.Enqueue(timer.Elapsed.TotalMilliseconds);
            diagnostic.AddMessage($@"Czas działania filtru akcji: {timer.Elapsed.TotalMilliseconds}ms, średnio: {actionTimes.Average():F2}ms.");
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Stopwatch timer = Stopwatch.StartNew();
            await next();
            timer.Stop();
            resultTimes.Enqueue(timer.Elapsed.TotalMilliseconds);
            diagnostic.AddMessage($@"Czas działania filtru wyniku: {timer.Elapsed.TotalMilliseconds}ms, średnio: {resultTimes.Average():F2}ms.");
        }

       

    }
}
