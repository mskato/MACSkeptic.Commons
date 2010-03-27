using MACSkeptic.Commons.Extensions;

namespace MACSkeptic.Commons.Matchers
{
    public class SameMatcher<T> : IMatcher<T>
    {
        public bool IsMatch(T target, params T[] others)
        {
            if (others.IsEmpty())
            {
                return false;
            }

            var allAreTheSame = true;
            others.Each(x => allAreTheSame = allAreTheSame && ReferenceEquals(target, x));

            return allAreTheSame;
        }
    }
}