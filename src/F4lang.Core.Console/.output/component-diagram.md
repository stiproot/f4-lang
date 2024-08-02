```mermaid
C4Component
  title Component diagram for weather forecast API

  Frame_Boundary(systemBoundary, "System Boundary") {

  Container(api, "Weather Forecast API", "written in .NET Core") {
    Component(postEndpoint, "POST Endpoint", "Receives http requests and returns a weather forecast stored in database")
  }

  Container(database, "Database", "Keeps stored the Weather Forecast")
  }

  Rel(api, database, "<<interacts>>", "Sends a SELECT query to the database to retrieve a weather forecast")

```
