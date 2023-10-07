FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5100
ENV ASPNETCORE_URLS="http://+:5100"

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG CONFIGURATION=Release
WORKDIR /src
COPY ["LoveLiveCZ/LoveLiveCZ.csproj", "LoveLiveCZ/"]
RUN dotnet restore "LoveLiveCZ/LoveLiveCZ.csproj"
COPY . .
WORKDIR "/src/LoveLiveCZ"
RUN dotnet build "LoveLiveCZ.csproj" -c ${CONFIGURATION} -o /app/build

FROM build AS publish
ARG CONFIGURATION=Release
RUN dotnet publish "LoveLiveCZ.csproj" -c ${CONFIGURATION} -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoveLiveCZ.dll"]
