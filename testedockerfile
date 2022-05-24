FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY *.sln ./
COPY ["SpecFlowCalculatorMVCNew/SpecFlowCalculatorMVCNew.csproj", "SpecFlowCalculatorMVCNew/"]
COPY ["SpecFlowCalculator.Specs/SpecFlowCalculator.Specs.csproj", "SpecFlowCalculator.Specs/"]
COPY . ./

RUN dotnet build "/src/SpecFlowCalculatorMVCNew/SpecFlowCalculatorMVCNew.csproj" -c Release -o /app
RUN dotnet build "/src/SpecFlowCalculator.Specs/SpecFlowCalculator.Specs.csproj" -c Release -o /app



FROM build AS publish
RUN dotnet publish "/src/SpecFlowCalculatorMVCNew/SpecFlowCalculatorMVCNew.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SpecFlowCalculatorMVCNew.dll"]