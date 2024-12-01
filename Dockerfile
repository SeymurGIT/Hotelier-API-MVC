#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApiConsume/HotelProject.WebAPI/HotelProject.WebAPI.csproj", "ApiConsume/HotelProject.WebAPI/"]
COPY ["ApiConsume/HotelProject.BusinessLayer/HotelProject.BusinessLayer.csproj", "ApiConsume/HotelProject.BusinessLayer/"]
COPY ["ApiConsume/HotelProject.DataAccessLayer/HotelProject.DataAccessLayer.csproj", "ApiConsume/HotelProject.DataAccessLayer/"]
COPY ["ApiConsume/HotelProject.EntityLayer/HotelProject.EntityLayer.csproj", "ApiConsume/HotelProject.EntityLayer/"]
COPY ["ApiConsume/HotelProject.DtoLayer/HotelProject.DtoLayer.csproj", "ApiConsume/HotelProject.DtoLayer/"]
RUN dotnet restore "./ApiConsume/HotelProject.WebAPI/HotelProject.WebAPI.csproj"
COPY . .
WORKDIR "/src/ApiConsume/HotelProject.WebAPI"
RUN dotnet build "./HotelProject.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HotelProject.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelProject.WebAPI.dll"]