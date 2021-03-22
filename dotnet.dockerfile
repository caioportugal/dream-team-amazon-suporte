FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
#ENV ASPNETCORE_URLS=${ASPNETCORE_URLS}
#ENV DOTNET_RUNNING_IN_CONTAINER=${DOTNET_RUNNING_IN_CONTAINER}
ENV PATH="${PATH}:/root/.dotnet/tools"

COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build /app/out .
ENTRYPOINT dotnet Amazon-Suporte.dll