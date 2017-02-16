using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WbTstr.Commands.Interfaces
{
    public interface IActionCommand : ICommand
    {
        void Execute(object webDriverObj);
    }
}
