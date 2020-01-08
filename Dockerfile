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
#Run test
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS test-env
WORKDIR /app
#COPY AspnetCoreTDDTests/*.csproj ./AspnetCoreTDDTests/
WORKDIR /app
COPY AspnetCoreTDDTests/*.csproj ./AspnetCoreTDDTests/
WORKDIR /app/AspnetCoreTDDTests
RUN dotnet restore
COPY AspnetCoreTDDTests/. ./
RUN dotnet build
RUN apt-get update -y
RUN apt-get install -y xvfb unzip
# Set up the Chrome PPA
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add -
RUN echo "deb http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list

# Update the package list and install chrome
RUN apt-get update -y
RUN apt-get install -y google-chrome-stable
# Set up Chromedriver Environment variables
ENV CHROMEDRIVER_VERSION 79.0.3945.36
ENV CHROMEDRIVER_DIR /chromedriver
RUN mkdir $CHROMEDRIVER_DIR
#https://chromedriver.storage.googleapis.com/79.0.3945.36/chromedriver_linux64.zip
# Download and install Chromedriver
RUN wget -q --continue -P $CHROMEDRIVER_DIR "https://chromedriver.storage.googleapis.com/$CHROMEDRIVER_VERSION/chromedriver_linux64.zip"
RUN unzip $CHROMEDRIVER_DIR/chromedriver* -d /usr/bin/google-chrome

# Put Chromedriver into the PATH
# ENV PATH $CHROMEDRIVER_DIR:$PATH

RUN dotnet test