FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS app
WORKDIR /app
COPY --from=build /app .
ENV DOTNET_RUNNING_IN_CONTAINER=true
HEALTHCHECK CMD curl --fail http://localhost:5000/ || exit 1
ENTRYPOINT ["dotnet", "Recify.dll"]