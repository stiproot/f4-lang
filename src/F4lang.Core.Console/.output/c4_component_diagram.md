```mermaid
graph TB
    subgraph Web API
        subgraph Controller
            WeatherForecastController
        end
        subgraph Service
            WeatherForecastService-->Database
        end
    end
    subgraph Database
        WeatherForecastData
    end
    WeatherForecastController-->WeatherForecastService
```
