# WbTstr 

| master | develop |
| --- | --- |
| [![Build status](https://img.shields.io/appveyor/ci/onnovalkering/wbtstr/master.svg?style=flat-square)](https://ci.appveyor.com/project/onnovalkering/wbtstr/branch/master) [![Coveralls develop](https://img.shields.io/coveralls/wbtstr/wbtstr/master.svg?style=flat-square)](https://coveralls.io/github/wbtstr/wbtstr?branch=master) | [![Build status](https://img.shields.io/appveyor/ci/onnovalkering/wbtstr/develop.svg?style=flat-square)](https://ci.appveyor.com/project/onnovalkering/wbtstr/branch/develop) [![Coveralls develop](https://img.shields.io/coveralls/wbtstr/wbtstr/develop.svg?style=flat-square)](https://coveralls.io/github/wbtstr/wbtstr?branch=develop) |

## Overview
WbTstr is the successor of [WbTstr.Net](https://github.com/mirabeau-nl/WbTstr.Net), it's completely rewritten from scratch with extensibility in mind and by using the latest C# 7.1 features. Users of WbTstr are presented with an intuitive API that can be used to completely automate all facets of browser-based functional testing, without having to deal with the nitty-gritty details of Selenium.

__Noteworthy features include:__
- only uses native commands to control browser instances, doesn't rely on JavaScript;
- un-opinoinated towards choice of assertion framework, compatible with NUnit, xUnit and others;
- access to the source of individual elements for direct testing on HTML (e.g with AngleSharp);
- interact with cookies (read/write) and execute custom JavaScript (return values accessible in C#);
- experimental support for HTTP Basic authentication through the browser's alert/pop-up window;
- configurable WebDriver scope (browser instance per fixture, or per test case).

__Currently in development:__
- logging and benchmarking of performed commands;
- support for more browsers (Firefox, Internet Explorer);
- support for remote drivers (Selenium Hub, Selenoid, BrowserStack);
- plugin to allow direct access to Selenium WebDriver;
- plugin that adds PageObjects to WbTstr.

_See the [documentation](https://wbtstr.github.io) for more information._

[![NuGet version](https://img.shields.io/nuget/v/WbTstr.svg?style=flat-square)](https://www.nuget.org/packages/WbTstr) [![NuGet downloads](https://img.shields.io/nuget/dt/WbTstr.svg?style=flat-square)](https://www.nuget.org/packages/WbTstr) 

## Contributors
WbTstr is an open-source initaitive from [Mirabeau](https://www.mirabeau.nl/en).

We have the following contributors:

* [`@onnovalkering`](https://github.com/onnovalkering) 
* [`@lazytesting`](https://github.com/lazytesting)
* [`@rickvanschalkwijk`](https://github.com/rickvanschalkwijk)
