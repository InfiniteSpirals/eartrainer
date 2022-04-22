#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aud.io/Aud.io.csproj", "Aud.io/"]
RUN dotnet restore "Aud.io/Aud.io.csproj"
COPY . .
WORKDIR "/src/Aud.io"
RUN dotnet build "Aud.io.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aud.io.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aud.io.dll"]