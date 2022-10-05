docker pull mcr.microsoft.com/mssql/server:2019-latest
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=2Secure*Password2" -p 1433:1433 --name sqlserverdb -d mcr.microsoft.com/mssql/server:2019-latest
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p pass12345
dotnet dev-certs https --trust
docker-compose up --build
Go to https://localhost:{dockerPort}/swagger/index.html
Register a new user
Login with registered user
Grab bearer token from successful login response
Authorize and provide the following: bearer {token}
