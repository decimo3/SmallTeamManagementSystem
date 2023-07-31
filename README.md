# mestreruan.api


#### REQUERIMENTS
It is necessary to have [Docker](https://www.docker.com/) installed, The other tools you need will be downloaded from the [Docker Hub](https://hub.docker.com/).

#### SETUP ENVIROMENT
Adjust the variables of environments in the .env file

#### RUNNING
```sh
sudo docker-compose build --pull --no-cache
sudo docker-compose up --detach
```

#### TECNOLOGIES
* Docker - For a homogeneous environment;
* Dotnet - For api creation and dynamic pages;
* Postgre - For data persistence and better learning;

```sh
dotnet tool install --local dotnet-aspnet-codegenerator
dotnet tool install --local dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

```