using System;
using MACSkeptic.Commons.Extensions;

namespace MACSkeptic.Commons.Matchers
{
    public class InstanceOfMatcher<TTarget> : IMatcher<TTarget, Type>
    {
        public bool IsMatch(TTarget target, params Type[] others)
        {
            if (others.IsEmpty() ||
                target.IsNull())
            {
                return false;
            }

            var isInstanceOfAll = true;
            others.Each(x => isInstanceOfAll = isInstanceOfAll && (x.IsInstanceOfType(target)));

            return isInstanceOfAll;
        }
    }
}