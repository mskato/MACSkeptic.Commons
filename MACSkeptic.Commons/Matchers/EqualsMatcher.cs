using MACSkeptic.Commons.Extensions;

namespace MACSkeptic.Commons.Matchers
{
    public class EqualsMatcher<T> : IMatcher<T>
    {
        public bool IsMatch(T target, params T[] others)
        {
            if (others.IsEmpty())
            {
                return false;
            }

            var allAreEqual = true;
            others.Each(x => allAreEqual = allAreEqual && Equals(target, x));

            return allAreEqual;
        }
    }
}