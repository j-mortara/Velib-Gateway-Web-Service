# Velib Gateway Web Service

#### An IWS exposing the JCDecaux API to access the Velib Web Service.

## Project Structure

This project consists of two parts :

- An **Intermediate Web Server** (IWS) (contained in the `Server` directory) exposing a WS-SOAP API to access the Velib Web Service provided by [**JCDecaux**](https://developer.jcdecaux.com/#/opendata/vls?page=getstarted).
- A **GUI client** (contained in the `Client` directory) connecting to the IWS to fetch information coming from the **JCDecaux** API.

## Using your own API key

### Become a JCDecaux developer
In order to use the **JCDecaux** API, you need to have an API key delivered after subscription on [**their website**](https://developer.jcdecaux.com/#/signup).

### Include the key in the project
You then need to create an `api_key.txt` file in the `Server` directory containing only your key. The server will fetch the content of the file as a resource :

```cs
private static string API_KEY = Server.Properties.Resources.api_key;
```

## Extensions

### Development

- [X] **GUI client**
- [X] **Asynchronous accesses to WS**
- [X] **Added cache to IWS**

#### Note concerning the caching extension :

The `Station` object has a method `isInformationOutdated()` which returns a `bool` indicating if the value cached is too old to be reliable.  
For debugging purpose, this value has been set to 5 seconds but can be easily modified, as it is a field of the `Station` class.

```cs
// Number of seconds representing the timelapse we consider data as being up-to-date
private static readonly int dataUpToDateTimelapse = 5;
```

At runtime, when a station is selected, a message is logged in the `Debug` trace to show the cache behaviour :

- `Station never queried, adding to cache.` : This is the first time we query information about this station. A new `Station` object is added to the cache.
- `Outdated information, updating information.` : Information about this station is already present in the cache, but it needs to be updated. A new `Station` object replacing the old one is added to the cache.
- `Getting value from cache.` : Information about this station is already present in the cache and is considered as up-to-date. We directly get the value from the cache.