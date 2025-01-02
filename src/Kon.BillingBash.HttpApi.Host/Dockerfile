# 请参阅 https://aka.ms/customizecontainer 以了解如何自定义调试容器，以及 Visual Studio 如何使用此 Dockerfile 生成映像以更快地进行调试。

# 此阶段用于在快速模式(默认为调试配置)下从 VS 运行时
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Kon.BillingBash.HttpApi.Host/Kon.BillingBash.HttpApi.Host.csproj", "src/Kon.BillingBash.HttpApi.Host/"]
COPY ["src/Kon.BillingBash.Application/Kon.BillingBash.Application.csproj", "src/Kon.BillingBash.Application/"]
COPY ["src/Kon.BillingBash.Domain/Kon.BillingBash.Domain.csproj", "src/Kon.BillingBash.Domain/"]
COPY ["src/Kon.BillingBash.Domain.Shared/Kon.BillingBash.Domain.Shared.csproj", "src/Kon.BillingBash.Domain.Shared/"]
COPY ["src/Kon.BillingBash.Application.Contracts/Kon.BillingBash.Application.Contracts.csproj", "src/Kon.BillingBash.Application.Contracts/"]
COPY ["src/Kon.BillingBash.EntityFrameworkCore/Kon.BillingBash.EntityFrameworkCore.csproj", "src/Kon.BillingBash.EntityFrameworkCore/"]
COPY ["src/Kon.BillingBash.HttpApi/Kon.BillingBash.HttpApi.csproj", "src/Kon.BillingBash.HttpApi/"]
RUN dotnet restore "./src/Kon.BillingBash.HttpApi.Host/Kon.BillingBash.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Kon.BillingBash.HttpApi.Host"
RUN dotnet build "./Kon.BillingBash.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Kon.BillingBash.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kon.BillingBash.HttpApi.Host.dll"]