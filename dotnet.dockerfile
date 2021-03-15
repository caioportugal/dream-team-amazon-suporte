FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
ENV ASPNETCORE_URLS=${ASPNETCORE_URLS}
ENV DOTNET_RUNNING_IN_CONTAINER=${DOTNET_RUNNING_IN_CONTAINER}
EXPOSE 5000/tcp
COPY . /app
WORKDIR /app
RUN dotnet tool install --global dotnet-ef --version 3.1
RUN dotnet restore
RUN dotnet build
ENTRYPOINT dotnet watch run