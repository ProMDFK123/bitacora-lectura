# Arquitectura

## 1. Arquitectura general

El sistema utilizará una arquitectura **cliente-servidor**, separando la aplicación en tres componentes principales:

1. **Frontend:** interfaz de usuario.
2. **Backend:** API REST y lógica de negocio.
3. **Base de datos:** persistencia de la información.

```text
┌─────────────────────────────┐
│          FRONTEND           │
│                             │
│ Next.js                     │
│ React                       │
│ TypeScript                  │
│ Tailwind CSS                │
└─────────────┬───────────────┘
              │
              │ REST / HTTP
              ▼
┌─────────────────────────────┐
│           BACKEND           │
│                             │
│ ASP.NET Core                │
│                             │
│ API                         │
│ Application                 │
│ Domain                      │
│ Infrastructure              │
└─────────────┬───────────────┘
              │
              │ Entity Framework Core
              ▼
┌─────────────────────────────┐
│          PostgreSQL         │
└─────────────────────────────┘
```

La arquitectura busca mantener separadas las responsabilidades de cada componente, facilitando el mantenimiento, las pruebas y la evolución del sistema.

---

# 2. Tecnologías

| Componente        | Tecnología            |
| ----------------- | --------------------- |
| Frontend          | Next.js               |
| Interfaz          | React                 |
| Lenguaje frontend | TypeScript            |
| Estilos           | Tailwind CSS          |
| Backend           | ASP.NET Core          |
| Lenguaje backend  | C#                    |
| ORM               | Entity Framework Core |
| Base de datos     | PostgreSQL            |
| Contenedores      | Docker                |
| Orquestación      | Docker Compose        |
| Comunicación      | REST / HTTP           |

---

# 3. Backend

El backend utilizará **ASP.NET Core** y seguirá una separación de responsabilidades inspirada en una arquitectura por capas.

```text
backend/
│
├── API/
│   ├── Controllers/
│   ├── Middleware/
│   └── Extensions/
│
├── Application/
│   ├── DTOs/
│   ├── Interfaces/
│   └── Services/
│
├── Domain/
│   ├── Entities/
│   ├── Enums/
│   └── Interfaces/
│
└── Infrastructure/
    ├── Persistence/
    │   ├── DbContext/
    │   ├── Configurations/
    │   └── Repositories/
    │
    └── Services/
```

## 3.1. API

Contiene los elementos relacionados con la exposición de la API.

### Controllers

Reciben las solicitudes HTTP y delegan las operaciones correspondientes a la capa de aplicación.

Ejemplo:

```text
GET /api/lecturas
POST /api/lecturas
GET /api/lecturas/{id}
```

### Middleware

Contiene componentes que procesan las solicitudes y respuestas de manera transversal.

Podrá incluir:

* Manejo global de excepciones.
* Registro de solicitudes.
* Autenticación y autorización cuando corresponda.

### Extensions

Contendrá métodos de extensión utilizados para configurar servicios y componentes de ASP.NET Core.

---

# 4. Application

La capa `Application` contiene la lógica de aplicación y coordina las operaciones realizadas por el sistema.

## DTOs

Los DTOs (`Data Transfer Objects`) definirán los datos que entran y salen de la API.

Esto evita exponer directamente las entidades de dominio.

Ejemplo:

```text
CreateReadingDto
UpdateReadingDto
ReadingDto
CreateSessionDto
CreateDiaryEntryDto
```

## Services

Contiene los servicios encargados de ejecutar los casos de uso de la aplicación.

Ejemplos:

```text
ReadingService
SessionService
DiaryService
EditionService
LibraryService
```

## Interfaces

Define contratos utilizados por la aplicación y las implementaciones correspondientes.

---

# 5. Domain

La capa `Domain` representa el núcleo del sistema.

Contendrá las entidades y conceptos fundamentales de la aplicación.

```text
Domain/
├── Entities/
├── Enums/
└── Interfaces/
```

## Entidades

Entre las principales entidades se encuentran:

```text
Usuario
Obra
Autor
Genero
Saga
Edicion
Biblioteca
Lectura
SesionLectura
EntradaBitacora
Valoracion
```

## Enums

Los valores controlados por el sistema se representarán mediante enumeraciones cuando corresponda.

Por ejemplo:

```text
Formato
├── FISICO
├── PDF
├── EBOOK
└── AUDIOLIBRO
```

Y:

```text
EstadoLectura
├── PENDIENTE
├── LEYENDO
├── TERMINADO
└── ABANDONADO
```

---

# 6. Infrastructure

La capa `Infrastructure` contiene las implementaciones relacionadas con recursos externos al dominio.

## Persistence

Contiene los componentes relacionados con PostgreSQL y Entity Framework Core.

```text
Persistence/
├── DbContext/
├── Configurations/
└── Repositories/
```

### DbContext

`DbContext` será el punto de acceso de Entity Framework Core a la base de datos.

### Configurations

Contendrá las configuraciones de las entidades mediante `IEntityTypeConfiguration<T>`.

Aquí se definirán, entre otros:

* Claves primarias.
* Claves foráneas.
* Restricciones.
* Índices.
* Longitudes.
* Relaciones.
* Tipos de datos.

### Repositories

Contendrá las implementaciones utilizadas para acceder a los datos cuando sea necesario abstraer el acceso a persistencia.

---

# 7. Frontend

El frontend será desarrollado utilizando **Next.js, React, TypeScript y Tailwind CSS**.

La estructura inicial será:

```text
frontend/
│
├── app/
├── components/
├── features/
├── hooks/
├── services/
├── types/
└── lib/
```

## 7.1. App

Contendrá las rutas y páginas de la aplicación utilizando el sistema de routing de Next.js.

Ejemplo:

```text
app/
├── login/
├── registro/
├── biblioteca/
├── lecturas/
├── bitacora/
└── estadisticas/
```

## 7.2. Components

Contendrá componentes reutilizables de interfaz.

Ejemplos:

```text
BookCard
ProgressBar
SessionForm
DiaryEntry
Rating
```

## 7.3. Features

Contendrá funcionalidades agrupadas por dominio o característica.

Por ejemplo:

```text
features/
├── auth/
├── library/
├── readings/
├── diary/
└── statistics/
```

## 7.4. Hooks

Contendrá hooks personalizados utilizados para encapsular lógica reutilizable.

## 7.5. Services

Contendrá la comunicación con la API REST.

Ejemplo:

```text
authService
libraryService
readingService
sessionService
diaryService
ratingService
```

## 7.6. Types

Contendrá los tipos e interfaces utilizados por el frontend.

---

# 8. Comunicación entre componentes

El frontend se comunicará con el backend mediante una **API REST sobre HTTP/HTTPS**.

El flujo general será:

```text
Usuario
   │
   ▼
Frontend
   │
   │ HTTP / HTTPS
   ▼
Controller
   │
   ▼
Application Service
   │
   ▼
Repository / Infrastructure
   │
   ▼
PostgreSQL
```

El backend será responsable de:

* Validar las solicitudes.
* Aplicar las reglas de negocio.
* Gestionar la autenticación y autorización.
* Acceder a los datos.
* Devolver las respuestas correspondientes.

El frontend será responsable principalmente de:

* Presentar la información.
* Gestionar la interacción del usuario.
* Validar aspectos de interfaz.
* Consumir la API.
* Gestionar el estado de la aplicación.

---

# 9. Persistencia

**PostgreSQL** será el sistema gestor de base de datos principal.

**Entity Framework Core** será utilizado como ORM para realizar la comunicación entre el backend y PostgreSQL.

```text
ASP.NET Core
     │
     ▼
Entity Framework Core
     │
     ▼
PostgreSQL
```

## 9.1. Migraciones

La estructura de la base de datos será gestionada mediante migraciones de Entity Framework Core.

Las migraciones permitirán:

* Crear la base de datos.
* Crear tablas.
* Modificar estructuras existentes.
* Agregar o eliminar columnas.
* Modificar relaciones.
* Mantener un historial de cambios del esquema.

---

# 10. Autenticación y autorización

El sistema será multiusuario, por lo que las funcionalidades privadas deberán estar asociadas al usuario autenticado.

La autenticación se implementará mediante tokens de acceso.

Inicialmente se contempla:

```text
Registro
   │
   ▼
Inicio de sesión
   │
   ▼
Autenticación
   │
   ▼
Token de acceso
   │
   ▼
Solicitudes autenticadas
```

El backend deberá verificar que el usuario autenticado sea propietario de los recursos que intenta modificar o consultar.

Por ejemplo:

```text
Usuario A
   │
   └── Lectura A

Usuario B
   │
   └── Lectura B
```

El usuario A no podrá acceder ni modificar la lectura perteneciente al usuario B.

---

# 11. Seguridad

El sistema deberá considerar, como mínimo:

* Contraseñas almacenadas mediante hash seguro.
* Autenticación para funcionalidades privadas.
* Autorización basada en usuario.
* Validación de datos recibidos.
* Protección de endpoints privados.
* No exponer contraseñas ni información sensible en las respuestas.
* Uso de HTTPS en entornos de producción.

---

# 12. Contenedores

El proyecto utilizará **Docker** para facilitar la configuración y ejecución del entorno de desarrollo.

La aplicación podrá dividirse en los siguientes servicios:

```text
┌─────────────────────────┐
│       Frontend          │
│        Next.js          │
└────────────┬────────────┘
             │
             ▼
┌─────────────────────────┐
│        Backend          │
│      ASP.NET Core       │
└────────────┬────────────┘
             │
             ▼
┌─────────────────────────┐
│       PostgreSQL        │
└─────────────────────────┘
```

La configuración de los servicios se centralizará mediante:

```text
docker-compose.yml
```

El uso de Docker permitirá que el proyecto pueda ejecutarse de manera consistente independientemente del entorno local.

---

# 13. Entornos

Se contemplan inicialmente tres entornos:

```text
Desarrollo
    │
    ▼
Pruebas
    │
    ▼
Producción
```

### Desarrollo

Utilizado para implementar y probar nuevas funcionalidades.

### Pruebas

Utilizado para validar cambios antes de desplegarlos.

### Producción

Entorno donde se ejecutará la versión disponible para los usuarios.

La configuración de cada entorno deberá mantenerse separada para evitar utilizar accidentalmente recursos de producción durante el desarrollo.

---

# 14. Principios arquitectónicos

El proyecto seguirá los siguientes principios:

### Separación de responsabilidades

Cada componente deberá encargarse de una responsabilidad específica.

### Bajo acoplamiento

Las capas deberán depender lo menos posible de implementaciones concretas.

### Alta cohesión

Los elementos relacionados deberán mantenerse agrupados.

### Reutilización

Los componentes y servicios comunes deberán diseñarse para ser reutilizables.

### Seguridad por diseño

Las operaciones deberán validar autenticación, autorización y datos de entrada.

### Evolución incremental

La arquitectura deberá permitir agregar funcionalidades futuras sin necesidad de modificar completamente la estructura existente.

---

# 15. Estructura general del proyecto

La estructura propuesta para el repositorio será:

```text
bitacora/
│
├── backend/
│   ├── API/
│   ├── Application/
│   ├── Domain/
│   └── Infrastructure/
│
├── frontend/
│   ├── app/
│   ├── components/
│   ├── features/
│   ├── hooks/
│   ├── services/
│   ├── types/
│   └── lib/
│
├── docs/
│   ├── 01-modelo-conceptual.md
│   ├── 02-modelo-entidad-relacion.md
│   ├── 03-modelo-relacional.md
│   ├── 04-diccionario-datos.md
│   ├── 05-reglas-negocio.md
│   ├── 06-casos-de-uso.md
│   ├── 07-historias-usuario.md
│   └── 08-arquitectura.md
│
├── docker-compose.yml
└── README.md
```

---

# 16. Consideraciones futuras

La arquitectura deberá permitir incorporar posteriormente funcionalidades como:

* Metas de lectura.
* Desafíos de lectura.
* Estadísticas avanzadas.
* Integración con servicios externos de información bibliográfica.
* Importación de libros.
* Exportación de la bitácora.
* Perfiles públicos.
* Funcionalidades sociales.
* Notificaciones.

Estas funcionalidades no forman parte del MVP actual y no deberán condicionar innecesariamente la primera implementación.
