﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbTstr.Fixtures;
using WbTstr.Fixtures.Attributes;
using WbTstr.Session.Performers;
using WbTstr.Session.Recorders;
using WbTstr.Session.Trackers;

namespace WbTstr.UnitTests.Fixtures.Auxiliaries
{
    [WebDriverConfig("Chrome")]
    public class DerivedFromSimpleFixture : SimpleFixture<SequentialSessionPerformer>
    {
        public void TestMethod()
        {
            // Act
            I.NavigateTo("http://www.google.com")
                .ClickOn(".gb_P")
                .CheckThat(url: "https://www.google.com/gmail/about/");
        }
    }
}
