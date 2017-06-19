# ASP.NET Core Web Api Starter Template

AspNetCore-Api-Template

### Harness the power of ASP.NET Core.

### What is this repo? Live Demo here: [not-yet-available]

This repository is maintained by Atish Bhana (https://github.com/Magitekwarrior) and is meant to be an starter template
for creating a Web API with ASP.NET Core. 

This is meant to be a Feature-Rich Starter application containing the latest technologies.
This utilizes standards/patterns/practices such as Dependency injection, Multi-tiered, Factory, Singleton, etc

# Table of Contents

* [Features](#features)
* [Getting Started](#getting-started)
* [Deployment](#deployment)
* [Upcoming Features](#upcoming-features)
* [Application Structure](#application-structure)
* [Universal Gotchas](#universal-gotchas)
* [FAQ](#faq---also-check-out-the-faq-issues-label)
* [Special Thanks](#special-thanks)
* [License](#license)

---

# Features:

> These are just some of the features found in this starter!

- **ASP.NET Core 1.1**
  - Written in C#, VS2017 & SQL Database

- **Dependecy injection** :
  - Projects are structured to de-couple technology from the business logic
  - Configuration [appsettings.json] is integrated via "Options" Pattern with a configuration service

- **Swagger**
  - Api Documentation
  - Easy Web Api Methods access for testing

- **Logging** [Implementation available but not used]
  - Remote Logging
  - Using Gray Logging [replace serverUrl="http://graylog.xxxxx.co.za:12XXX/gelf" with appropriate address]

- **Exception Handling Middleware**
  - No need for pesky Try...Catch blocks 
  - ... at least wrt catching system errors. Still need to use them for throwing application exceptions ;)

- **Testing frameworks** [Not Yet Implemented]
  - Unit testing with MOQ
    - Fake Entities: Database is not called in Unit test


----

----
  
# Getting Started?

**Make sure you have .NET CORE SDK  installed & VS 2017 tooling **

### Visual Studio 2017

Make sure you have .NET Core 1.0+ [https://www.microsoft.com/net/download/core] installed and/or VS2017.
Installing VS2017 will automatically install all the neccessary .NET dependencies when you open the project.
Also, include this: [https://www.microsoft.com/net/core#windowsvs2017]

Simply push F5 to start debugging !

### Visual Studio Code

> Note: Make sure you have the C# extension & .NET Core Debugger installed.

# Upcoming Features:

-  ;) 

----

----

# Deployment

### Dotnet publish


# Application Structure:

> Note: This application has WebAPI (our API) setup inside the same solution, but of course all of this 
could be abstracted out into a completely separate project('s) ideally. 

**Root level files** 

Here we have the *usual suspects* found at the root level.

- `HC.Template`         - configuration file implemented through Options pattern
- `HC.Domain`           - configuration file implemented through Options pattern
- `HC.Infrastructure`   - configuration file implemented through Options pattern
- `HC.Interface`        - configuration file implemented through Options pattern
- `HC.WebAPI`           - configuration file implemented through Options pattern

- `appsettings.json`             - configuration file implemented through Options pattern. Replaces traditional App.config/Web.config
- `appsettings.Development.json` - configuration file implemented through Options pattern
- `appsettings.Production.json`  - configuration file implemented through Options pattern

- `nlog.config`         - configuration file necessary for implementing Nlog/Gray Logging

*** The service will use `appsettings.json` and one of 'Development' or 'Production' depending on the [env.EnvironmentName]

----
 
# FAQ

### How do I ask a question?

uuuuuhh. (>_<)
Email me: Magitekwarrior@gmail.com

----

# Special Thanks

Many thanks go out to Saalocin, WestHS & DocMad

----
 
# Found a Bug? Want to Contribute?

Nothing's ever perfect, but please let me know by creating an issue (make sure there isn't an existing one about it already), and we'll try and work out a fix for it! If you have any good ideas, or want to contribute, feel free to either make an Issue with the Proposal - Email me: Magitekwarrior@gmail.com

----

# License

[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](/LICENSE) 

Copyright (c) 2017-2018 [Atish Bhana](https://github.com/Magitekwarrior)

Twitter: [@Magitekwarrior](http://twitter.com/Magitekwarrior)

----
