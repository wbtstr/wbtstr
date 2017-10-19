using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Session.Performers.Interfaces;

namespace WbTstr.Utilities.Extensions
{
    public static class IDictionaryExtensions
    {
        public static void DisposeAndRemoveAll<T>(this IDictionary<string, T> dictionary) where T : IDisposable
        {
            dictionary.Values.ToList().ForEach(o => o.Dispose());
            dictionary.RemoveAll();
        }

        public static void RemoveAll<T>(this IDictionary<string, T> dictionary)
        {
            dictionary.Keys.ToList().ForEach(k => dictionary.Remove(k));
        }
    }
}
