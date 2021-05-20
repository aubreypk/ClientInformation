# ClientInformation
Application for managing client information

1. Data
SQLite database used for easy deployment
Includes SQLite database and init script to create initial database with sample records
project: client-data
Deploy: Copy client.db to root of API

2. API
.Net Core 3.1 API with manual DB access (no entity framework)
Project: client-api
Deploy: use "dotnet run" cli command. Default route is "https://localhost:5001/api/clients/"

3. Web Client
Vue 3 Web client application
Project: client-web
Deploy: use "npm run serve" cli command. App rund on http://localhost:8080/


[Known bugs]
Althogh cors is enabled on api, http Post gives cors error when creating new 
Content type issue on delete

[ToDO]
Save to csv incomplete
