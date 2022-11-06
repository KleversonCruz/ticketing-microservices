#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TicketService.Api/TicketService.Api.csproj", "src/TicketService.Api/"]
COPY ["src/TicketService.Lib/TicketService.Lib.csproj", "src/TicketService.Lib/"]
RUN dotnet restore "src/TicketService.Api/TicketService.Api.csproj"
COPY . .
WORKDIR "/src/src/TicketService.Api"
RUN dotnet build "TicketService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketService.Api.dll"]