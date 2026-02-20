# 🚀 SaaS Diver API
API para gestión de suscripciones bajo modelo SaaS, construida con **.NET 9**.

## 🏗️ Arquitectura
El proyecto utiliza una **Arquitectura en Capas** para asegurar el desacoplamiento:
- **Controllers:** Manejo de peticiones HTTP.
- **Services:** Lógica de negocio y validaciones (Service Pattern).
- **Data/Models:** Acceso a datos con EF Core y SQL Server.

## 🛠️ Características
- **Validación de Negocio:** Impide duplicidad de suscripciones activas.
- **Async/Await:** Programación asíncrona de extremo a extremo para escalabilidad.
- **Seed Data:** Base de datos pre-configurada para pruebas rápidas.
- **Revenue Tracking:** Cálculo automático de ingresos recurrentes.

## 🚀 Cómo ejecutar
1. Clona el repo.
2. Ejecuta `Update-Database` en la Package Manager Console de Visual Studio.
3. Presiona F5 para abrir **Swagger**.

<img width="1475" height="406" alt="image" src="https://github.com/user-attachments/assets/88a7b6fd-c120-4320-89d3-1d1eaf3e9874" />
<img width="1442" height="363" alt="image" src="https://github.com/user-attachments/assets/0217c305-2e59-4063-8b4a-0eea5568e820" />
