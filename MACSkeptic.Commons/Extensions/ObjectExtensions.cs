namespace MACSkeptic.Commons.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object @object)
        {
            return ReferenceEquals(@object, null);
        }
    }
}