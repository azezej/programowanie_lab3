FROM dotnet:8.0-sdk AS build

COPY . . 
WORKDIR /src
RUN dotnet restore "src/ConsoleApp1/ConsoleApp1.csproj"
RUN dotnet publish "src/ConsoleApp1/ConsoleApp1.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ConsoleApp1.dll"]
