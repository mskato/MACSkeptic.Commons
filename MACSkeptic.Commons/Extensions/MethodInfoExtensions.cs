using System.Reflection;

namespace MACSkeptic.ExpLorer.Utils.Extensions
{
    internal static class MethodInfoExtensions
    {
        internal static bool IsGetter(this MethodInfo methodInfo)
        {
            if(methodInfo == null)
            {
                return false;
            }

            return methodInfo.IsSpecialName && methodInfo.Name.StartsWith("get_");
        }

        internal static string WhatGives(this MethodInfo methodInfo)
        {
            if (!methodInfo.IsGetter())
            {
                return null;
            }

            return methodInfo.Name.Replace("get_", string.Empty);
        }
    }
}
