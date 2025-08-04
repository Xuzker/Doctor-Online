# Используем образ .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Копируем все csproj
COPY DoctorOnline.Domain/DoctorOnline.Domain.csproj DoctorOnline.Domain/
COPY DoctorOnline.Application/DoctorOnline.Application.csproj DoctorOnline.Application/
COPY DoctorOnline.Infrastructure/DoctorOnline.Infrastructure.csproj DoctorOnline.Infrastructure/
COPY DoctorOnline.WebAPI/DoctorOnline.WebAPI.csproj DoctorOnline.WebAPI/

# Восстанавливаем зависимости
RUN dotnet restore DoctorOnline.WebAPI/DoctorOnline.WebAPI.csproj

# Копируем весь исходный код
COPY DoctorOnline.Domain/ DoctorOnline.Domain/
COPY DoctorOnline.Application/ DoctorOnline.Application/
COPY DoctorOnline.Infrastructure/ DoctorOnline.Infrastructure/
COPY DoctorOnline.WebAPI/ DoctorOnline.WebAPI/

# Сборка
RUN dotnet publish DoctorOnline.WebAPI/DoctorOnline.WebAPI.csproj -c Release -o /out

# Runtime образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

ENTRYPOINT ["dotnet", "DoctorOnline.WebAPI.dll"]
