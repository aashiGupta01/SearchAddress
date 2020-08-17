# Search Location

This service exposes the functionality of creating and search locations. We can aditionally sort the search result based on the defined strategy.
For persistance this project uses SQL Server. We have single source of truth. The services are build using ASP.NET Core 3.1 and uses built in configuration
provider and default DI framework. For ORM , I have used Dapper.
The services can be tested using swagger which is already implemented. 
There are 2 endpoints-
1. To add address location-
/api/Location/Create
2. To search and sort results by Address or Frequency
Note: Here, sortBy is the enumerator.
api/Location/Search?query=del&sortBy=0
api/Location/Search?query=del&sortBy=1


#How to run it 

1. Do dotnet restore to restore all the dependencies required by the project, post which try to build it. 
2. Replace the configuriation for connection string to point to your database. The configuration is present in appSettings.json
3. Run DB restore using the db script present in the DbScripts folder. 
3. Run and test the application. 
