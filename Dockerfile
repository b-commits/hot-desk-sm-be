FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./HotDesk.API/HotDesk.API.csproj" --disable-parallel
RUN dotnet publish "./HotDesk.API/HotDesk.API.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "HotDesk.API.dll"]