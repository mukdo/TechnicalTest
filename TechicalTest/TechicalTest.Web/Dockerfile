FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["TechicalTest.Web/*.csproj", "TechicalTest.Web/"]
COPY ["TT.Data/*.csproj", "TT.Data/"]
COPY ["TT.Library/*.csproj", "TT.Library/"]
COPY ["TT.MemberShip/*.csproj", "TT.MemberShip/"]
RUN dotnet restore "TechicalTest.Web.csproj" 
COPY . .
WORKDIR "/src/TechicalTest.Web"
RUN dotnet build "TechicalTest.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TechicalTest.Web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TechicalTest.Web.dll"]