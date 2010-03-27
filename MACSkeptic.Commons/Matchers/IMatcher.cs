namespace MACSkeptic.Commons.Matchers
{
    public interface IMatcher<T> : IMatcher<T, T>
    {
        bool IsMatch(T target, params T[] others);
    }

    public interface IMatcher<TTarget, TOthers>
    {
        bool IsMatch(TTarget target, params TOthers[] others);
    }
}