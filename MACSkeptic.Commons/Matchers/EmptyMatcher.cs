using System.Collections;
using MACSkeptic.Commons.Extensions;

namespace MACSkeptic.Commons.Matchers
{
    public class EmptyMatcher : IMatcher<IEnumerable>, IMatcher<string>
    {
        public bool IsMatch(IEnumerable target, params IEnumerable[] others)
        {
            return target.IsEmpty();
        }

        public bool IsMatch(string target, params string[] others)
        {
            return target.IsEmpty();
        }
    }
}