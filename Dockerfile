#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Organic_Shop_BackEnd/Organic_Shop_BackEnd.csproj", "Organic_Shop_BackEnd/"]
RUN dotnet restore "Organic_Shop_BackEnd/Organic_Shop_BackEnd.csproj"
COPY . .
WORKDIR "/src/Organic_Shop_BackEnd"
RUN dotnet build "Organic_Shop_BackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Organic_Shop_BackEnd.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Organic_Shop_BackEnd.dll"]