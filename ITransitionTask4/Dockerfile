#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN sed -i 's/SECLEVEL=2/SECLEVEL=1/g' /etc/ssl/openssl.cnf
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ITransitionTask4/ITransitionTask4.csproj", "ITransitionTask4/"]
RUN dotnet restore "ITransitionTask4/ITransitionTask4.csproj"
COPY . .
WORKDIR "/src/ITransitionTask4"
RUN dotnet build "ITransitionTask4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITransitionTask4.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ITransitionTask4.dll"]