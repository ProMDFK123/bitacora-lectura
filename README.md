# 📚 Bitácora

Aplicación web personal para registrar, organizar y consultar experiencias de lectura.

El proyecto busca funcionar como una **bitácora de lectura digital**, permitiendo a los usuarios mantener una biblioteca personal, registrar sus sesiones de lectura, escribir reflexiones y valorar sus lecturas.

El sistema está diseñado como una aplicación **multiusuario** y diferencia entre una obra intelectual y las distintas ediciones que pueden existir de ella.

---

## ✨ Características principales

* 👤 Registro y autenticación de usuarios.
* 📚 Biblioteca personal.
* 📖 Gestión de obras y ediciones.
* ✍️ Registro de autores.
* 🏷️ Clasificación mediante géneros.
* 📚 Gestión de sagas.
* 📕 Registro de lecturas.
* 🔄 Registro de relecturas.
* ⏱️ Registro de sesiones de lectura.
* 📈 Seguimiento del progreso.
* 📝 Entradas de bitácora.
* ⚠️ Marcado de spoilers.
* ⭐ Valoración independiente por lectura.
* 📊 Estadísticas de lectura.
* 🎯 Metas y seguimiento de hábitos de lectura.

---

## 🧠 Concepto principal

El sistema diferencia entre **obra**, **edición** y **lectura**.

Por ejemplo:

```text
El Señor de los Anillos
│
├── Edición Minotauro 2001
│   └── Lectura #1
│       ├── Sesión 1
│       ├── Sesión 2
│       └── Sesión 3
│
└── Edición Penguin 2020
    └── Lectura #1
        ├── Sesión 1
        └── Sesión 2
```

Una misma obra puede poseer múltiples ediciones y un usuario puede leer una misma edición más de una vez.

Cada lectura mantiene independientemente sus:

* Fechas.
* Sesiones.
* Progreso.
* Entradas de bitácora.
* Valoración.

---

## 📊 Formatos de lectura

El sistema contempla inicialmente cuatro formatos:

| Formato      | Unidad de progreso |
| ------------ | ------------------ |
| `FISICO`     | Páginas            |
| `PDF`        | Páginas            |
| `EBOOK`      | Porcentaje         |
| `AUDIOLIBRO` | Tiempo             |

El progreso se registra de acuerdo con las características del formato.

### Libros físicos y PDF

El progreso corresponde a la página alcanzada.

```text
500 páginas
Progreso: 125

125 / 500 × 100 = 25 %
```

### Ebook

El progreso se registra directamente como porcentaje.

Esto evita depender de la paginación proporcionada por dispositivos como Kindle, ya que esta puede variar según el tamaño de fuente, dispositivo o configuración.

### Audiolibro

El progreso se registra mediante el tiempo alcanzado.

```text
Duración total: 600 minutos
Progreso: 300 minutos

300 / 600 × 100 = 50 %
```

---

## 🏗️ Arquitectura

El proyecto utiliza una arquitectura cliente-servidor.

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
│ Entity Framework Core       │
└─────────────┬───────────────┘
              │
              │ EF Core
              ▼
┌─────────────────────────────┐
│         POSTGRESQL          │
└─────────────────────────────┘
```

El repositorio utiliza una estructura de **monorepo**, manteniendo frontend y backend dentro del mismo repositorio Git.

```text
bitacora/
│
├── backend/
│   └── Bitacora.Api/
│
├── frontend/
│   └── bitacora-web/
│
├── docs/
│
├── .gitignore
└── README.md
```

---

## 🛠️ Tecnologías

### Frontend

* Next.js
* React
* TypeScript
* Tailwind CSS

### Backend

* ASP.NET Core
* C#
* Entity Framework Core
* JWT

### Base de datos

* PostgreSQL

### Herramientas

* Git
* GitHub
* Docker
* Swagger / OpenAPI

---

## 📋 Requisitos previos

Para ejecutar el proyecto localmente se requiere instalar:

* [Node.js](https://nodejs.org/)
* [.NET SDK](https://dotnet.microsoft.com/)
* PostgreSQL
* Git
* Docker *(opcional)*

---

## 🚀 Instalación

### 1. Clonar el repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
cd bitacora
```

### 2. Backend

```bash
cd backend/Bitacora.Api
dotnet restore
```

Configurar las variables de entorno o el archivo de configuración correspondiente para la conexión con PostgreSQL.

Posteriormente:

```bash
dotnet run
```

### 3. Frontend

En otra terminal:

```bash
cd frontend/bitacora-web
npm install
npm run dev
```

El frontend estará disponible normalmente en:

```text
http://localhost:3000
```

---

## 🐳 Docker

El proyecto contempla el uso de Docker para facilitar la configuración del entorno de desarrollo.

La configuración permitirá ejecutar los principales servicios del sistema mediante:

```bash
docker compose up -d
```

La configuración definitiva de Docker se documentará una vez finalizada la configuración de backend, frontend y PostgreSQL.

---

## 📖 Documentación

La documentación técnica y de diseño se encuentra en la carpeta `docs/`.

| Documento                                         | Descripción                            |
| ------------------------------------------------- | -------------------------------------- |
| [Modelo conceptual](docs/modelo-conceptual.md)    | Entidades y conceptos principales      |
| [Modelo ER](docs/modelo-er.md)                    | Relaciones y cardinalidades            |
| [Modelo relacional](docs/modelo-relacional.md)    | Estructura lógica de la base de datos  |
| [Diccionario de datos](docs/diccionario-datos.md) | Descripción de tablas y atributos      |
| [Reglas de negocio](docs/reglas-negocio.md)       | Reglas y restricciones del sistema     |
| [Casos de uso](docs/casos-uso.md)                 | Funcionalidades principales            |
| [Arquitectura](docs/arquitectura.md)              | Arquitectura técnica del sistema       |
| [API](docs/api.md)                                | Endpoints y convenciones de la API     |
| [Planificación](docs/planificacion.md)            | Sprints y planificación del desarrollo |

---

## 🗄️ Modelo de datos

El modelo de datos se centra en las siguientes entidades:

```text
USUARIO
   │
   └── BIBLIOTECA
           │
           ▼
        EDICION
           │
           ▼
         OBRA
        / │  \
       /  │   \
   AUTOR GENERO SAGA


USUARIO
   │
   ▼
 LECTURA
   │
   ├── SESION_LECTURA
   │
   ├── ENTRADA_BITACORA
   │
   └── VALORACION
```

La base de datos se diseñará utilizando PostgreSQL y será administrada mediante Entity Framework Core.

---

## 📌 Estado del proyecto

Actualmente el proyecto se encuentra en fase de **análisis y diseño**, avanzando posteriormente hacia la implementación de la infraestructura.

### Progreso

* [x] Definición de la idea
* [x] Definición del alcance
* [x] Modelo conceptual
* [x] Modelo entidad-relación
* [x] Modelo relacional
* [x] Diccionario de datos
* [x] Reglas de negocio
* [x] Casos de uso
* [x] Arquitectura inicial
* [x] Diseño inicial de API
* [x] Planificación inicial
* [x] Inicialización completa del backend
* [x] Inicialización completa del frontend
* [ ] Configuración de PostgreSQL
* [ ] Implementación de entidades
* [ ] Implementación de autenticación
* [ ] Implementación de biblioteca
* [ ] Implementación de lecturas
* [ ] Implementación de bitácora
* [ ] Implementación de estadísticas
* [ ] Implementación de metas
* [ ] Primera versión estable

---

## 🗺️ Plan de desarrollo

El desarrollo se organizará mediante los siguientes sprints:

```text
Sprint 0  → Análisis y diseño
Sprint 1  → Infraestructura
Sprint 2  → Autenticación
Sprint 3  → Catálogo
Sprint 4  → Biblioteca
Sprint 5  → Lectura
Sprint 6  → Bitácora
Sprint 7  → Valoraciones
Sprint 8  → Estadísticas
Sprint 9  → Metas
Sprint 10 → Release
```

---

## 🔐 Seguridad

El sistema utilizará autenticación mediante **JWT** para proteger los recursos que requieran usuario autenticado.

Las contraseñas no se almacenarán directamente, sino mediante un mecanismo de hash seguro.

Cada usuario solamente podrá consultar y modificar sus propios datos personales y registros de actividad.

Las variables sensibles, como credenciales de base de datos y secretos de autenticación, no deberán almacenarse en el repositorio.

---

## 🧪 Pruebas

Se incorporarán pruebas automatizadas progresivamente durante el desarrollo.

Se contemplan:

* Pruebas unitarias.
* Pruebas de integración.
* Pruebas de API.
* Validación de reglas de negocio.

---

## 📄 Licencia

La licencia del proyecto será definida posteriormente.

