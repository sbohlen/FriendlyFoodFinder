# Friendly Food Finder #
Friendly Food Finder (colloquially FFF, or just _F3_ for convenience) is an implementation of the general coding exercise identified [here](https://github.com/timfpark/take-home-engineering-challenge).


## How to Build ##
Follow these steps to build (and run) the provided solution:

1. Clone this repo locally.
1. Load the `FriendlyFoodFinder.sln` solution into Visual Studio.
1. You will observe that the `FriendlyFoodFinder.Core.Test` project will **not** build/compile due to a missing `local.settings.json` file. To (among other things) avoid committing private secrets to the repo, this solution makes liberal use of [the Proteus.Utility.Configuration library](https://github.com/ProteusProject/Proteus.Utility/tree/master/src/Proteus.Utility.Configuration).  In order to build/run the solution, you must provide your own copy of this missing `local.settings.json` file into the `FriendlyFoodFinder.Core.Test` in the `test\FriendlyFoodFinder.Core.Test\local.settings.json` location.  This file must contain your _own_ Bing Maps API Key in the following format:

```javascript
{
  "bingMapsApiKey" : "your-api-key-here"
}
```
4. Follow [these steps](https://www.bingmapsportal.com/) to secure your own Bing Maps API key.  Add the API key to your own `local.settings.json` file in the path identified above.
1. Build the solution and run all of the unit tests in the `FriendlyFoodFinder.Core.Test` project.  If you have configured your Bing Maps API key correctly, all test should now **PASS**.
1. For insight into how to use/consume/interact with the provided solution in your own code/project, refer to the `CompleteEndToEndUseCase.TestHarness` unit test in this project.

## Design Principles ##
The fundamental principles/objectives driving the design decisions made in this implementation include the following:

* **Testability**: compatibility/compliance with applying automated testing tools and methodologies
* **Clear Object Responsibilities**: objects have differentiated/distinct/coherent responsibilities
* **Composability**: dependency injection for object graph composition
* **Extensibility**: abstractions provide seams for alternate implementations of important components (e.g., reading food truck data, geocoding of addresses) at a future date as may be appropriate
* **Flexibility**: externalization of settings, parameters, etc. such that deploy-time decisions can be properly deferred to deployment time
* **Understandability**: naming of e.g., classes, methods are indicative of their responsibility/function/behavior within the code base


## Pri-0 Features ##
The following features received the top priority and as such are manifest in the initial (current) implementation:

1. Accept colloquial street address as origin point/user input.
1. GeoCode colloquial street address for later use.
1. Load food truck data set (CSV file) from disk.
1. Query for top 5 closest Food Trucks to origin point.  Assume planar distance is sufficient for initial needs because origin point and food truck location(s) are assumed to be (generally) proximate to each other.

## Pri-1 Features ##
A number of features received secondary/deferred priority in the initial (current) implementation.  As such, where feasible support for the subsequent implementation of these features has been _considered_ in the design of the initial (current) implementation but these features have not themselves been included.  Following is a list of these features and the (general) design decisions taken to ease their potential subsequent implementation.

 | Feature | Design Decisions in Support of the Feature |
 | --- | --- |
 | Client implementation | Implementation of any actual UI for the provided functionality has been deferred as its unlikely to be either differentiating or interesting work.  The provided unit test `CompleteEndToEndUseCase.TestHarness` documents plainly the intended pattern of consuming/interacting with the provided functionality, making the actual implementation of one or more client front-ends (e.g., web, mobile app, command-line) a comparatively simple exercise for a developer.  The provided implementation of the solution is intentionally client-platform-neutral precisely to support the flexibility of consuming it in multiple client scenarios.  Further, the use of dependency injection to compose complex object graphs lends itself to ease of consumption in client scenarios wishing to leverage an IoC container for dependency resolution. |
 | Support for more complex/compound query constraints | `FoodTruckQueryParameters` already contains additional properties hinting at potential future filters.  If additional filters are evolved, adding them to the same parameters object is simple/straightforward and consuming them in the `FoodTruckQuery` class is an equally simple/obvious extension point.
 | Support for GeoDistance calculations accounting for Earth's curvature | `ICalculateGeoDistance` abstraction supports alternate implementations other than the provided `PlanarGeoDistanceCalculator`. The `ICalculateGeoDistance.CalculateGeoDistanceBetween` method is designed to be awaited so that future implementations desiring to use e.g., an async remote service call to calculate geo distance can easily do so without requiring a (breaking) change to the interface design.  | 
 | Mapping/Graphic depiction of query result | As no client implementation is provided at present, this feature obviously has (also) been deferred as the details of its implementation would vary based on target client runtime features.  The design of the `FoodTruck` class intentionally contains sufficient properties (e.g., name, lat, lon) to support variable mechanisms of displaying results (including mapping with e.g., `FoodTruck.Name`, `FoodTruck.Address` as tooltip for each plotted point)  |
 | Alternate GeoCoding mechanism | The `IGeoCodeAddresses` interface provides for a straightforward injection of an alternate geocoder service/approach than the provided `BingMapsGeoCoderService`. |
 | Alternate source for Food Truck data | The `IReadFoodTruckData` interface provides for a straightforward injection of an alternate data loading service/approach than the provided `FoodTruckCsvDataReader`.  The design of the `IReadFoodTruckData.ReadData` method is intentionally designed to be awaitable so that data can be (eventually) accessed via e.g., an async remote service call without requiring a (breaking) change to the core interface declaration. |
 | Logging/Tracing | Although no logging/tracing is provided in the initial (current) implementation, the use of dependency inversion makes the old-style injection of e.g., an eventual `ILogger` interface implementation fairly straightforward.  Further, the friendliness of the solution to the use of an IoC container for composition of the object graph also makes the potential injection of e.g., a logging aspect into each method entirely feasible as well. |
 | `//TODO:` comments  | For a more comprehensive list of features/capabilities deferred, the reader is encouraged to review the plethora of `//TODO:` comments scattered liberally throughout the code base.   |