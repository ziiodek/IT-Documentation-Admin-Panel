FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8084
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ITDocumentation.csproj","."]
RUN dotnet restore "ITDocumentation.csproj"
COPY . .
RUN dotnet build "ITDocumentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITDocumentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app/publish
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ITDocumentation.dll"]
