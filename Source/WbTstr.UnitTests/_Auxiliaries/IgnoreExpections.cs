using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.UnitTests._Auxiliaries
{
    public static class IgnoreExpections
    {
        public static void Run(Action action)
        {
            try
            {
                action();
            }
            catch (Exception)
            {
                // This is not the exception you are looking for..
            }
        }
    }
}
