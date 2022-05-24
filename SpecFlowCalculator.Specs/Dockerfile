#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5002
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SpecFlowCalculator.Specs.csproj", "SpecFlowCalculator.Specs/"]
RUN dotnet restore "SpecFlowCalculator.Specs/SpecFlowCalculator.Specs.csproj"
COPY . .
WORKDIR "/src/SpecFlowCalculator.Specs"
RUN dotnet build "SpecFlowCalculator.Specs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpecFlowCalculator.Specs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpecFlowCalculator.Specs.dll"]