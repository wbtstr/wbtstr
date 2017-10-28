using System;
using System.Collections.Generic;
using System.Linq;

namespace WbTstr.Utilities.Extensions
{
    public static class IDictionaryExtensions
    {
        public static void DisposeAndClear<T>(this IDictionary<string, T> dictionary) where T : IDisposable
        {
            dictionary.Values.ToList().ForEach(o => o.Dispose());
            dictionary.Clear();
        }
    }
}
