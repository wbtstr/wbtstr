using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.Commands.Interfaces
{
    public interface IReturnCommand<T> : ICommand
    {
        T Execute(object webDriverObj);
    }
}
