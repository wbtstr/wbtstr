﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Commands.Interfaces;
using WbTstr.Configuration.WebDrivers.Interfaces;

namespace WbTstr.Session.Performers.Interfaces
{
    public interface ISessionPerformer : IDisposable
    {
        ISessionPerformer Initialize(IWebDriverConfig webDriverConfig);

        bool DirectPlay { get; set; }

        void Perform(ICommand command);

        void Play();
    }
}
