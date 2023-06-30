using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(string? message) : base(message)
        {
        }

        public NegativesNotAllowedException(string? message, List<int> list) : this(message)
        {
            string values = string.Join(",", list
                .Where(i => i < 0)
                .Select(n => n.ToString()).ToArray());
            throw new NegativesNotAllowedException($"\n{message}: {values}");
        }
    }
}
