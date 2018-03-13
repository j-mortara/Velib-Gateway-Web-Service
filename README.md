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