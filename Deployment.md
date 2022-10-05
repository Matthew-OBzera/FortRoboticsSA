# Docker Deployment
For deployment move into the project folder

1. docker pull mcr.microsoft.com/mssql/server:2019-latest
2. docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=2Secure*Password2" -p 1433:1433 --name sqlserverdb -d mcr.microsoft.com/mssql/server:2019-latest
3. dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p pass12345
4. dotnet dev-certs https --trust
5. docker-compose up --build
6. Go to https://localhost:{dockerPort}/swagger/index.html
  - >Note: You will need to specify https in the link

# Using the API
1. Register a new user
  -Under Auth/Register click the Try it out
  -Replace the default values of string with your own credentials
  -Click execute
2. Login with registered user
  -Under Auth/Login click the Try it
  -Replace the default values of string with registred credentials
3. Grab bearer token from successful login response
6. Click on the Authorize button at the top and provide the following: bearer {token}
7. You will now be authozied to use the rest of the API (expiration time currently set to 1 day)


> Note: If you run into SSL Cert Errors Run the following and deploy the containers with docker-compose up --build

> docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=2Secure*Password2" -p 1433:1433 --name sqlserverdb -d mcr.microsoft.com/mssql/server:2019-latest

> dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p pass12345
