FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY trabalho-devops-infnet.slnx ./
COPY src/TrabalhoDevOpsInfnet.Domain/TrabalhoDevOpsInfnet.Domain.csproj       src/TrabalhoDevOpsInfnet.Domain/
COPY src/TrabalhoDevOpsInfnet.Data/TrabalhoDevOpsInfnet.Data.csproj           src/TrabalhoDevOpsInfnet.Data/
COPY src/TrabalhoDevOpsInfnet.Application/TrabalhoDevOpsInfnet.Application.csproj src/TrabalhoDevOpsInfnet.Application/
COPY src/TrabalhoDevOpsInfnet.API/TrabalhoDevOpsInfnet.API.csproj             src/TrabalhoDevOpsInfnet.API/

RUN dotnet restore src/TrabalhoDevOpsInfnet.API/TrabalhoDevOpsInfnet.API.csproj

COPY src/ src/

RUN dotnet publish src/TrabalhoDevOpsInfnet.API/TrabalhoDevOpsInfnet.API.csproj \
    -c Release \
    --no-restore \
    -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "TrabalhoDevOpsInfnet.API.dll"]
