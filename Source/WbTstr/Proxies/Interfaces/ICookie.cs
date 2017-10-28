using System;

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
