FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BMW.CloudAdoption.Parts.Api/BMW.CloudAdoption.Parts.Api.csproj", "BMW.CloudAdoption.Parts.Api/"]
RUN dotnet restore "BMW.CloudAdoption.Parts.Api/BMW.CloudAdoption.Parts.Api.csproj"
COPY . .
WORKDIR "/src/BMW.CloudAdoption.Parts.Api"
RUN dotnet build "BMW.CloudAdoption.Parts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BMW.CloudAdoption.Parts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BMW.CloudAdoption.Parts.Api.dll"]
