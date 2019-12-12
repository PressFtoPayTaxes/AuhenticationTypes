FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["CookieAuthLesson/CookieAuthLesson.csproj", "CookieAuthLesson/"]
RUN dotnet restore "CookieAuthLesson/CookieAuthLesson.csproj"
COPY . .
WORKDIR "/src/CookieAuthLesson"
RUN dotnet build "CookieAuthLesson.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CookieAuthLesson.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CookieAuthLesson.dll"]