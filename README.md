# M13n (MvcLocalication)
In this prototype I’m trying to explore some practices about ASP.Net MVC localization using Windows resource files (.resx).

## Points of interest (tl:dr)
- All the localization process is server side using Windows resources (.resx) files
- An enumeration defines every language available and it is used as a route constraint and as the source of available cultures to show to the user
- Explicit localization using routing with a custom route handler

## Getting in the details
### CultureIdentifier Enumeration
Base on the ISO 639-1 code of names for languages and its numeric value is the culture identifier (LCID) of the `System.Globalization.CultureInfo` class.
```csharp
public enum CultureIdentifier
{
	en       = 0x0009,	// English
	fr       = 0x000C,	// French
	es       = 0x000A   // Spanish
}
```
To help you with all these codes and values there is a text file 'CultureIdentifier.cs.MoreExtensiveListOf_ISO639-1.txt' with most of the ISO 639-1 codes.  For the moment cultures with country/region-code-2 are not included right now. "en-AU", "en-US" don't make good enums... I'm looking for a simple and elegant solution to this problem.

### Custom Routing And Localization
There are some helpers for you to handle explicit localization by using the URL.  

First, there is a custom route handler `MultiCultureMvcRouteHandler`.  It handles the culture in the URL and it sets it in the current thread.  Here is an example on how to use it:
```csharp
// Default route with explicit localization
routes.MapRoute( 
    name: "MultiCulture", 
    url: "{controller}/{action}/{id}",
    defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
).RouteHandler = new MultiCultureMvcRouteHandler();
```

Second, there is an utility method to include at the end of the route registration in the `RouteConfig` class.
```csharp
public static void RegisterRoutes(RouteCollection routes)
{
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
	[...]
    LocalizeRoutes(routes);
}
```
The method has an optional parameter to set the default language and it can be used like this:
```csharp
public static void RegisterRoutes(RouteCollection routes)
{
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
	[...]
    LocalizeRoutes(routes, CultureIdentifier.es);
}
```
The LocalizeRoutes method adds (to each route with a `MultiCultureMvcRouteHandler`): the culture segment in the URL, an optional default culture and a culture constraint (so we get a 404 if the culture code is not in the `CultureIdentifier` enum).  

### Resources Files
The resources files are stored in a folder simply named 'Resources'.  At the root of this folder there are the global resource files.  There are the AppString.\*.resx files acting as global localized strings.  There are the ValidationErrors.\*.resx files containing some error and validation messages, it is easier to put them in a separate file so we can reuse them in another project without too much modification.  There is the CultureNames.resx file containing some culture names in their native name (like Deutsch for German).

The other sub-folders mimic the namespace structure of the localizable objects (mainly views) in the project.

### Implicit localization
To enable implicit localization (without the routing) we must edit the Web.config with something like:
```xml
<configuration>
  [...]
  <system.web>
    <globalization culture="en" uiCulture="auto:en" />
    [...]
```

## What we might expect next (a.k.a. todo)
- Improve the documentation
- Improve the localization coverage of the prototype
- Find an elegant approach to manage the country/region in the localization enumeration (like en-US and en-GB)
- Rework the CultureSwitchControl and drop the `CultureController`
- Get some decent unit tests
- Code formatting in localized text
 

## License
M13n is licensed under [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form"). Refer to license.MIT.txt for more information.
