using System;
using System.Collections;
using MACSkeptic.Commons.Matchers;

namespace MACSkeptic.Commons.Expectations
{
    public static class ShouldIStayOrShouldIGo
    {
        public static Expectation<T> Should<T>(this T o)
        {
            return new Expectation<T>(true, o);
        }

        public static Expectation<T> ShouldNot<T>(this T o)
        {
            return new Expectation<T>(false, o);
        }
    }

    public class Expectation<T>
    {
        private readonly T _target;
        private readonly bool _truthness;

        public Expectation(bool truthness, T target)
        {
            _truthness = truthness;
            _target = target;
        }

        internal bool Apply<TOthers>(IMatcher<T, TOthers> matcher, params TOthers[] others)
        {
            return matcher.IsMatch(_target, others) == _truthness;
        }

        internal bool Apply(IMatcher<T> matcher)
        {
            return matcher.IsMatch(_target) == _truthness;
        }

        public bool BeNull()
        {
            return Apply(new NullMatcher<T>());
        }

        public bool BeTheSameAs(T other)
        {
            return Apply(new SameMatcher<T>(), other);
        }

        public bool BeEqualTo(T other)
        {
            return Apply(new EqualsMatcher<T>(), other);
        }

        public bool BeAnInstanceOf(Type other)
        {
            return Apply(new InstanceOfMatcher<T>(), other);
        }
    }

    public static class StringMatchers
    {
        public static bool BeEmpty(this Expectation<string> expectation)
        {
            return expectation.Apply(new EmptyMatcher());
        }
    }

    public static class CollectionMatchers
    {
        public static bool BeEmpty(this Expectation<IEnumerable> expectation)
        {
            return expectation.Apply(new EmptyMatcher());
        }
    }
}