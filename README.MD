

This project is a simple dot net core quotes api

## Setup Azure Data Studio and run the  following

sudo docker pull mcr.microsoft.com/mssql/server:2019-latest



sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<Password1234$>" \
   -p 1433:1433 --name sqlQuotes -h sqlQuotes \
   -d mcr.microsoft.com/mssql/server:2019-latest

