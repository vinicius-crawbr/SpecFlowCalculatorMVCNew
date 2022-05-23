#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SpecFlowCalculatorMVCNew/SpecFlowCalculatorMVCNew.csproj", "SpecFlowCalculatorMVCNew/"]
RUN dotnet restore "SpecFlowCalculatorMVCNew/SpecFlowCalculatorMVCNew.csproj"
COPY . .
WORKDIR "/src/SpecFlowCalculatorMVCNew"
RUN dotnet build "SpecFlowCalculatorMVCNew.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpecFlowCalculatorMVCNew.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpecFlowCalculatorMVCNew.dll"]