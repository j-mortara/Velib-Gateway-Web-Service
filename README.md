# Velib Gateway Web Service

#### An IWS exposing the JCDecaux API to access the Velib Web Service.

## Project Structure

This project consists of two parts :

- An **Intermediate Web Server** (IWS) (contained in the `Server` directory) exposing a WS-SOAP API to access the Velib Web Service provided by [**JCDecaux**](https://developer.jcdecaux.com/#/opendata/vls?page=getstarted).
- A **GUI client** (contained in the `Client` directory) connecting to the IWS to fetch information coming from the **JCDecaux** API.

## Extensions

### Development

- [X] **GUI client**
- [ ] Asynchronous accesses to WS
- [X] Added cache to IWS