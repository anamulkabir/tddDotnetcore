FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
# copy csproj and restore as distinct layers
COPY *.sln .
COPY AspnetCoreTDD/*.csproj ./AspnetCoreTDD/
COPY AspnetCoreTDDTests/*.csproj ./AspnetCoreTDDTests/
RUN dotnet restore
# copy everything else and build app
COPY AspnetCoreTDD/. ./AspnetCoreTDD/
COPY AspnetCoreTDDTests/. ./AspnetCoreTDDTests/
RUN dotnet build

#WORKDIR /app/AspnetCoreTDD
RUN dotnet publish ./AspnetCoreTDD/ -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "AspnetCoreTDD.dll"]
