Service-Level Agreement
This service-level agreement (SLA) describes the level of support that you should expect.

Uptime
95%+ uptime

The packages build successfully, and have their tests pass at least 95% of the time in a year.

Response Time
unspecified response time

Issues, pull requests and comments are responded to with no timing guarantees.

Breaking API Changes
No backwards compatibility

There are no hard backwards compatibility guarantees, but I try to update all affected code when I break an API. If you import my packages and I know of that via godoc.org importers, I will send a PR to update your package.

If you vendor our packages, it's your own responsibility to update when you want to.

Forward progress

Because there's no backwards compatibility promise, it's always okay to change things to make things better. Even if an API is not 100% optimal in the first commit, it's not frozen and can be improved later.

C# Version
Current stable .Net version

Current stable .Net version is supported. Previous versions may work, but aren't guaranteed to. I don't go out of my way to break support for previous versions, but I don't hold back on using new features from current stable .Net version.

Applicability
This SLA applies to all .Net applications under the following namespaces:
https://github.com/Arklaide/devopsITUproject/**

