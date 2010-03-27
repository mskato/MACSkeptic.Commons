using MACSkeptic.Commons.Extensions;

namespace MACSkeptic.Commons.Matchers
{
    public class NullMatcher<T> : IMatcher<T>
    {
        public bool IsMatch(T target, params T[] others)
        {
            return target.IsNull();
        }
    }
}