FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update && apt-get upgrade -y
RUN apt-get install -y htop
RUN apt-get install -y mc

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["../src/WebApiMvc.Api/WebApiMvc.Api.csproj", "WebApiMvc.Api/"]
COPY ["../src/WebApiMvc.CrossCuting/WebApiMvc.CrossCuting.csproj", "WebApiMvc.CrossCuting/"]
COPY ["../src/WebApiMvc.Model/WebApiMvc.Model.csproj", "WebApiMvc.Model/"]
COPY ["../src/WebApiMvc.Repository/WebApiMvc.Repository.csproj", "WebApiMvc.Repository/"]
COPY ["../src/WebApiMvc.Services/WebApiMvc.Services.csproj", "WebApiMvc.Services/"]
RUN dotnet restore "WebApiMvc.Api/WebApiMvc.Api.csproj"
COPY . .
WORKDIR "/src"
#RUN dotnet build "./src/WebApiMvc.Api/WebApiMvc.Api.csproj" -c Release -o /app/build
RUN dotnet build "./src/WebApiMvc.Api/WebApiMvc.Api.csproj" -c Debug -o /app/build
FROM build AS publish
#RUN dotnet publish "./src/WebApiMvc.Api/WebApiMvc.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet publish "./src/WebApiMvc.Api/WebApiMvc.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiMvc.Api.dll"]