# WbTstr 
WbTstr is the successor of [WbTstr.Net](https://github.com/mirabeau-nl/WbTstr.Net), it's completely rewritten from scratch with extensibility in mind and by using the latest C# 7.1 features. Users of WbTstr are provided with an intuitive API that can be used to completely automate all facets of automated browser-based functional testing, without having to deal with the nitty-gritty details of Selenium.

__Noteworthy features include:__
- only uses native instructions to control browser instances: doesn't rely on JavaScript;
- un-opinoinated towards choice of assertion framework, compatible with NUnit, xUnit and others;
- access to the source of individual page elements for direct testing on HTML (e.g. with AngleSharp);
- interact with cookies (read/write) and execute custom JavaScript (return values accessible in C#);
- experimental support for HTTP Basic authentication through the browser's alert/pop-up window;
- configurable WebDriver scope (browser instance per fixture, or per test case).

__Planned:__
- extensive logging and benchmarking capabilities;
- support for more drivers (Selenium Hub, BrowserStack, Firefox, ...);
- plugin that adds PageObjects to WbTstr.

_See the [documentation](https://wbtstr.github.io) for more information._

[![NuGet version](https://img.shields.io/nuget/v/WbTstr.svg?style=flat-square)](https://www.nuget.org/packages/WbTstr) [![NuGet downloads](https://img.shields.io/nuget/dt/WbTstr.svg?style=flat-square)](https://www.nuget.org/packages/WbTstr) 

## Contributors
WbTstr is an open-source initaitive from [Mirabeau](https://www.mirabeau.nl/en).

We have the following contributors:

* [`@ovalkering`](https://github.com/ovalkering) 
* [`@lazytesting`](https://github.com/lazytesting)
* [`@rickvanschalkwijk`](https://github.com/rickvanschalkwijk)
