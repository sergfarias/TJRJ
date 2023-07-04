FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#RUN apt-get update && apt-get upgrade -y
#RUN apt-get install -y htop
#RUN apt-get install -y mc

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR  /src
CMD ["dir"]
RUN ls -l /src
RUN ls -l /home
COPY ["src/WebApiMvc.Api.csproj", "src/WebApiMvc.Api/"]
COPY ["src/WebApiMvc.CrossCuting/WebApiMvc.CrossCuting.csproj", "src/WebApiMvc.CrossCuting/"]
COPY ["src/WebApiMvc.Model/WebApiMvc.Model.csproj", "src/WebApiMvc.Model/"]
COPY ["src/WebApiMvc.Repository/WebApiMvc.Repository.csproj", "src/WebApiMvc.Repository/"]
COPY ["src/WebApiMvc.Services/WebApiMvc.Services.csproj", "src/WebApiMvc.Services/"]
RUN dotnet restore "src/WebApiMvc.Api/WebApiMvc.Api.csproj"
COPY . .
WORKDIR "/src/src/WebApiMvc.Api"
RUN dotnet build "WebApiMvc.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiMvc.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiMvc.Api.dll"]