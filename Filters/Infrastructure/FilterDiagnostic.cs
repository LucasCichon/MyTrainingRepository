using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    public interface IFilterDiagnostic
    {
        IEnumerable<string> Message { get; }
        void AddMessage(string message);
    }
    public class DefaultFilterDiagnostic : IFilterDiagnostic
    {
        private List<string> messages = new List<string>();
        public IEnumerable<string> Message =>messages;

        public void AddMessage(string message)
        {
            messages.Add(message);
        }
    }
}
