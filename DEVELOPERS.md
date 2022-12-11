# User API Dev Guide
API is integrated with Swagger so all required information to run APIs is available on index page.

## Building
1. Make sure your Docker Desktop is running.
2. run the solution first with Docker Compose so it will fetch all required images and start the container.
3. after mssql container starts, you can stop the solution and run followinf command on dotner CLI.
    dotnet-ef database update
4. now your database should be created. you can use the connectionstring from appSettings.json to connect to database in Sql Server Management Studio.
5. you can Start using the app.
## Testing
 No test cases are included. 
## Deploying

## Additional Information