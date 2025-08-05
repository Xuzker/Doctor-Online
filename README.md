# DoctorOnline — это модульное веб-приложение для онлайн-бронирования медицинских встреч и управления доступностью врачей, реализованное по принципам чистой архитектуры (Clean Architecture).

🧱 Архитектура

Проект организован по слоям:
```
DoctorOnline
│
├── DoctorOnline.Domain         // Бизнес-логика, сущности, интерфейсы
├── DoctorOnline.Application    // Приложение: команды, запросы, интерфейсы использования
├── DoctorOnline.Infrastructure // Реализация внешних сервисов и доступа к данным
└── DoctorOnline.WebAPI         // Веб-интерфейс: API-контроллеры, точки входа
```

✅ Применённые паттерны и подходы

Паттерн / Подход         | Описание
--------------------------|---------
Clean Architecture        | Разделение по слоям: Domain → Application → Infrastructure → WebAPI
CQRS                      | Использование команд и запросов (Commands / Queries)
DDD                       | Используется в DoctorOnline.Domain
Dependency Injection      | Внедрение зависимостей между слоями через интерфейсы
Repository                | Отделение логики доступа к данным через интерфейсы
Value Objects             | Чистые типы значений в домене (например, Email, TimeRange)
Domain Events             | Расширение бизнес-логики через события в домене
SOLID-принципы            | Каждый модуль выполняет только одну ответственность и зависит от абстракций
Docker                    | Контейнеризация проекта для развёртывания

🗂️ Содержание слоёв

DoctorOnline.Domain:
- Сущности, ValueObjects, события домена (DomainEvents)
- Интерфейсы IRepository, ISchedulerService
- Не зависит от других слоёв

DoctorOnline.Application:
- Команды и запросы (CQRS)
- Использует MediatR (предположительно)
- Логика обработки пользовательских сценариев

DoctorOnline.Infrastructure:
- Реализация Repositories и Services
- Настройка БД и внешних интеграций
- Чтение конфигураций

DoctorOnline.WebAPI:
- Точка входа
- Controllers, маршрутизация
- Подключение DI, Swagger, запуск приложения
- Dockerfile для контейнеризации

🔌 Используемые технологии

- ASP.NET Core Web API
- Entity Framework Core
- Clean Architecture
- MediatR (если используется)
- Swagger
- Docker
- PostgreSQL
