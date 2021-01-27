



Setup Azure Data Studio

 sudo docker pull mcr.microsoft.com/mssql/server:2019-latest



sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<Password1234$>" \
   -p 1433:1433 --name sqlQuotes -h sqlQuotes \
   -d mcr.microsoft.com/mssql/server:2019-latest