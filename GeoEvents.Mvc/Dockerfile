#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8003

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GeoEvents.Mvc/GeoEvents.Mvc.csproj", "GeoEvents.Mvc/"]
COPY ["GeoEvents.Application/GeoEvents.Application.csproj", "GeoEvents.Application/"]
COPY ["Geodata.Domain/GeoEvents.Domain.csproj", "Geodata.Domain/"]
COPY ["GeoEvents.Persistence/GeoEvents.Persistence.csproj", "GeoEvents.Persistence/"]
RUN dotnet restore "GeoEvents.Mvc/GeoEvents.Mvc.csproj"
COPY . .
WORKDIR "/src/GeoEvents.Mvc"
RUN dotnet build "GeoEvents.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeoEvents.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeoEvents.Mvc.dll"]