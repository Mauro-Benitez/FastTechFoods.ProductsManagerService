FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY . ./

RUN dotnet nuget add source "https://nuget.pkg.github.com/caiofabiogomes/index.json" \
    --name github \
    --username caiofabiogomes \
    --password "$ARG_SECRET_NUGET_PACKAGES" \
    --store-password-in-clear-text

RUN dotnet restore

RUN dotnet publish ./FastTechFoods.ProductsManagerService/FastTechFoods.ProductsManagerService.API/FastTechFoods.ProductsManagerService.API.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

COPY --from=build-env /App/out ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "FastTechFoods.ProductsManagerService.API.dll"]