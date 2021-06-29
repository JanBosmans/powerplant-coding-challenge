#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=https://*:8888

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProductionPlanAPI/ProductionPlanAPI.csproj", "ProductionPlanAPI/"]
RUN dotnet restore "ProductionPlanAPI/ProductionPlanAPI.csproj"
COPY . .
WORKDIR "/src/ProductionPlanAPI"
RUN dotnet build "ProductionPlanAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductionPlanAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductionPlanAPI.dll"]