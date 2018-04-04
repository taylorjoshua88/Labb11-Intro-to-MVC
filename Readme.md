# PersonOfTheYear

**Author**: Joshua Taylor
**Version**: 1.0.0

## Overview

PersonOfTheYear is a demonstration of the MVC architecture in ASP.NET Core. It
provides a simple form using a Razor View asking for a minimum year and a
maximum year. Submitting this form results in a HTTP POST which redirects the
user to a results page containing all of the person of the year entries within
the specified years (inclusive) taken from a CSV source.

## Getting Started

PersonOfTheYear targets the .NET Core 2.0 platform. The .NET Core 2.0 SDK can
be downloaded from the following URL for Windows, Linux, and macOS:

https://www.microsoft.com/net/download/

The dotnet CLI utility would then be used to build and run the application:

    cd LinqInManhattan
    dotnet build
    dotnet run

The _dotnet run_ command will start an HTTP server on localhost using Kestrel
which can be accessed by the user's browser pointing to localhost on the port
provided by _dotnet run_'s console output.

Additionally, users can build and run PersonOfTheYear using Visual Studio
2017 or greater by opening the solution file at the root of this repository. 
Unit tests have been provided for only the CSV parsing code and make use of
the xUnit testing framework (included via a NuGet dependency).

## Example

#### Index View for the Home Controller ####
![Index View Screenshot](/assets/indexView.JPG)
#### Results View Using Input From the Index View ####
![Non-Empty Query Screenshot](/assets/resultsView.JPG)

## Architecture

PersonOfTheYear consists of a single MVC controller, HomeController, with
two actions, Index and Results. 

### HomeController

_HomeController_ defines two actions for the PersonOfTheYear application. Each 
action is associated with its own Razor View page detailed below. StaticFiles 
is used in conjunction with MVC in order to deliver the CSS3 style sheet for 
both Razor Views and the background image displayed in those views.

#### Index (Razor View and Action) ####

_Index_ delivers the user a simple HTML form asking for a minimum and maximum 
year from which Person of the Year awardees will be filtered in the _Results_ 
view. These years are input via HTML input tags and delivered to the _Home_ 
controller via HTTP POST.

#### Results (Razor View and Action) ####

_Results_ displays a listing of Time Person of the Year awardees within the
range of years specified by the user using the _Index_ action from HTTP POST.

### Data Model

The data model is composed of a single _Person_ class which contains properties 
for Year, Honor, Name, Country, Birth Year, Death Year, Title, Category, and 
Context. These values are populated by an included CSV file and placed into a 
.NET generic List object by the _Results_ action upon redirect from the _Index_ 
action's POST implementation. No manipulation of the source CSV file is
performed beyond reading from the file.

## Change Log

* 4.3.2018 [Joshua Taylor](mailto:taylor.joshua88@gmail.com) - Initial
release. All included tests are passing.