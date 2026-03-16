# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar csproj y restaurar
COPY ["PruebaAutenticador2/PruebaAutenticador2.csproj", "PruebaAutenticador2/"]
RUN dotnet restore "PruebaAutenticador2/PruebaAutenticador2.csproj"

# Copiar todo y publicar
COPY . .
WORKDIR "/src/PruebaAutenticador2"
RUN dotnet publish -c Release -o /app/publish

# Etapa runtime ligera
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS="http://+:80"
EXPOSE 80
ENTRYPOINT ["dotnet", "PruebaAutenticador2.dll"]