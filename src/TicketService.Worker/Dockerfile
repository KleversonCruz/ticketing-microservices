#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TicketService.Worker/TicketService.Worker.csproj", "TicketService.Worker/"]
RUN dotnet restore "TicketService.Worker/TicketService.Worker.csproj"
COPY . .
WORKDIR "/src/TicketService.Worker"
RUN dotnet build "TicketService.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketService.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketService.Worker.dll"]