
using System.Collections.Generic;
using System.Linq;

namespace MACSkeptic.Commons.Language
{
    public class Switcher<T,TReturn>
    {
        private IList<Case<T,TReturn>> Cases { get; set; }
        private Case<T, TReturn> DefaultCase { get; set; }

        public Switcher()
        {
            Cases = new List<Case<T, TReturn>>();
        }

        public Case<T, TReturn> When(T value)
        {
            var @case = new Case<T, TReturn> { Value = value, Owner = this };
            Cases.Add(@case);
            return @case;
        }

        public Case<T, TReturn> Default()
        {
            DefaultCase = new Case<T, TReturn> { Owner = this };
            return DefaultCase;
        }

        public TReturn ConsiderThisCase(T target)
        {
            var cases = Cases.Where(c => c.Value.Equals(target));
            return cases.Count() > 0
                       ? cases.First().Action.Invoke()
                       : DefaultCase.Action.Invoke();
        }
    }
}