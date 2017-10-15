using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.Proxies.Interfaces
{
    public interface ICookie
    {
        string Name { get; }

        string Value { get; }

        string Domain { get; }

        string Path { get; }

        bool Secure { get; }

        bool IsHttpOnly { get; }

        DateTime? Expiry { get; }
    }
}
