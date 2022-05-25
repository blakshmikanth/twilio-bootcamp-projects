
Twilio SMS Messaging - Weather application
---

To view the list of all API parameters, please visit [OpenWeatherMap API Parameter](https://openweathermap.org/current#data)

### Getting started

---

* Configure OpenWeather API Key in your environment variables. For mac, open `~./zshrc`
in your favourite text editor and add `export OpenWeather__Key="<Api Key>"`
* Restart your terminal and code editor
* Type `env` in your terminal and confirm that `OpenWeather__Key` exists with your API key value


### Units of Measurement

---

To get current temperate in celsius unit, append the query parameter 
`units = metric`

```text
https://api.openweathermap.org/data/2.5/weather?lat=57&lon=-2.15&appid={API key}&units=metric
```

Temperature is available in Fahrenheit, Celsius and Kelvin units.

* For temperature in Fahrenheit use units=imperial
* For temperature in Celsius use units=metric
* Temperature in Kelvin is used by default, no need to use units parameter in API call
