# 📚 Bitácora de Lectura

Aplicación web multiusuario para registrar, organizar y analizar el hábito de lectura.

El proyecto nace como una **bitácora de lectura personal**, donde no solo se registra qué libros se han leído, sino también **qué edición se utilizó, cuándo se leyó, cómo avanzó la lectura y qué experiencias o reflexiones surgieron durante el proceso**.

> 🚧 **Proyecto en desarrollo — actualmente en etapa de planificación y diseño.**

---

## ✨ Características principales

### 📚 Biblioteca personal

Permite organizar las obras y las diferentes ediciones disponibles.

Una misma obra puede tener múltiples ediciones, cada una con sus propias características:

* ISBN
* Editorial
* Año de publicación
* Número de páginas
* Portada
* Formato

### 📖 Seguimiento de lecturas

Una edición puede ser leída múltiples veces, permitiendo registrar:

* Primera lectura
* Relecturas
* Fecha de inicio
* Fecha de término
* Estado de lectura
* Progreso
* Valoración individual

Cada relectura conserva su propio historial.

### 📝 Bitácora

Permite registrar entradas personales durante una lectura.

Las entradas pueden incluir:

* Título
* Reflexiones
* Notas
* Fecha
* Asociación con una sesión de lectura
* Indicador de spoilers

### 📊 Progreso

El progreso se adapta al formato del contenido:

| Formato           | Progreso   |
| ----------------- | ---------- |
| 📖 Físico         | Páginas    |
| 📄 PDF            | Páginas    |
| 📱 Ebook / Kindle | Porcentaje |
| 🎧 Audiolibro     | Tiempo     |

### 📈 Estadísticas

La aplicación permitirá analizar el hábito de lectura mediante:

* Libros terminados
* Páginas leídas
* Tiempo de lectura
* Lecturas por mes
* Lecturas por año
* Géneros más leídos
* Autores más leídos
* Promedio de valoración

### 🎯 Metas y rutinas

Como funcionalidad futura:

* Metas anuales
* Metas mensuales
* Rachas de lectura
* Rutinas de lectura
* Seguimiento de objetivos

---

# 🧠 Modelo conceptual

Uno de los conceptos centrales del proyecto es separar **obra, edición, lectura y sesión de lectura**.

```text
                     ┌──────────────┐
                     │     OBRA     │
                     │              │
                     │ El Hobbit    │
                     └──────┬───────┘
                            │
                     múltiples ediciones
                            │
              ┌─────────────┴─────────────┐
              ▼                           ▼
       ┌──────────────┐            ┌──────────────┐
       │   EDICIÓN    │            │   EDICIÓN    │
       │  Minotauro   │            │  Otra edición│
       └──────┬───────┘            └──────────────┘
              │
           utilizada
              │
              ▼
       ┌──────────────┐
       │    LECTURA   │
       │   #1 / #2... │
       └──────┬───────┘
              │
       ┌──────┼──────────────┐
       ▼      ▼              ▼
   SESIONES BITÁCORA     VALORACIÓN
```

Esto permite, por ejemplo, registrar una obra como *El Señor de los Anillos*, poseer dos ediciones diferentes y realizar una lectura de cada edición sin perder el historial.

---

# 🛠️ Tecnologías

## Frontend

* [Next.js](https://nextjs.org/)
* [React](https://react.dev/)
* TypeScript
* Tailwind CSS

## Backend

* ASP.NET Core
* C#
* Entity Framework Core
* Swagger / OpenAPI

## Base de datos

* PostgreSQL

## Infraestructura

* Docker
* Docker Compose

## Otros

* JWT para autenticación
* Cloudinary para almacenamiento de portadas

---

# 🏗️ Arquitectura

El sistema seguirá una arquitectura cliente-servidor basada en una API REST.

```text
┌──────────────────────────┐
│        Next.js           │
│                          │
│ React + TypeScript       │
│ Tailwind CSS             │
└────────────┬─────────────┘
             │
             │ HTTP / REST
             ▼
┌──────────────────────────┐
│      ASP.NET Core        │
│                          │
│ Controllers              │
│ Services                 │
│ DTOs                     │
│ Repositories             │
└────────────┬─────────────┘
             │
             │ Entity Framework Core
             ▼
┌──────────────────────────┐
│        PostgreSQL        │
└──────────────────────────┘
```

---

# 📂 Estructura del proyecto

```text
bitacora-lectura/
│
├── README.md
│
├── docs/
│   ├── vision.md
│   ├── requisitos.md
│   ├── casos-uso.md
│   ├── modelo-conceptual.md
│   ├── modelo-er.md
│   ├── modelo-relacional.md
│   ├── diccionario-datos.md
│   ├── arquitectura.md
│   ├── api.md
│   ├── seguridad.md
│   ├── planificacion.md
│   └── roadmap.md
│
├── frontend/
│
├── backend/
│
├── database/
│
└── docker-compose.yml
```

---

# 🚀 Instalación

> La instalación estará disponible una vez finalizada la configuración inicial del proyecto.

### Requisitos

* Node.js
* .NET SDK
* PostgreSQL
* Docker y Docker Compose
* Git

### Clonar el repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
cd bitacora-lectura
```

### Ejecutar con Docker

```bash
docker compose up -d
```

Los pasos definitivos de configuración se documentarán cuando finalice el Sprint 1.

---

# 🗺️ Roadmap

## 🟡 Fase 0 — Análisis y diseño

* [x] Definición del concepto
* [x] Definición de obra y edición
* [x] Definición de lecturas y relecturas
* [x] Definición de formatos
* [x] Definición del sistema de progreso
* [x] Definición de soporte multiusuario
* [ ] Requisitos definitivos
* [ ] Modelo ER
* [ ] Modelo relacional
* [ ] Diccionario de datos
* [ ] Arquitectura definitiva

## ⚪ Fase 1 — Infraestructura

* [ ] Backend
* [ ] Frontend
* [ ] PostgreSQL
* [ ] Docker
* [ ] Autenticación

## ⚪ Fase 2 — Biblioteca

* [ ] Obras
* [ ] Ediciones
* [ ] Autores
* [ ] Géneros
* [ ] Sagas
* [ ] Biblioteca personal

## ⚪ Fase 3 — Lectura

* [ ] Lecturas
* [ ] Relecturas
* [ ] Sesiones
* [ ] Progreso
* [ ] Historial

## ⚪ Fase 4 — Bitácora

* [ ] Entradas
* [ ] Notas
* [ ] Spoilers
* [ ] Historial

## ⚪ Fase 5 — Estadísticas

* [ ] Dashboard
* [ ] Gráficas
* [ ] Estadísticas mensuales
* [ ] Estadísticas anuales

## ⚪ Fase 6 — Metas

* [ ] Objetivos
* [ ] Rutinas
* [ ] Rachas

## ⚪ Fase 7 — Release 1.0

* [ ] Tests
* [ ] Optimización
* [ ] Seguridad
* [ ] Responsive
* [ ] Documentación
* [ ] Despliegue

---

# 📖 Documentación

La documentación técnica y de diseño se encuentra en [`/docs`](./docs).

| Documento                                           | Descripción                             |
| --------------------------------------------------- | --------------------------------------- |
| [Visión](./docs/vision.md)                          | Propósito y alcance                     |
| [Requisitos](./docs/requisitos.md)                  | Requisitos funcionales y no funcionales |
| [Casos de uso](./docs/casos-uso.md)                 | Casos de uso del sistema                |
| [Modelo conceptual](./docs/modelo-conceptual.md)    | Entidades y relaciones                  |
| [Modelo ER](./docs/modelo-er.md)                    | Diagrama entidad-relación               |
| [Modelo relacional](./docs/modelo-relacional.md)    | Estructura de la base de datos          |
| [Diccionario de datos](./docs/diccionario-datos.md) | Definición de atributos                 |
| [Arquitectura](./docs/arquitectura.md)              | Arquitectura del sistema                |
| [API](./docs/api.md)                                | Documentación de endpoints              |
| [Seguridad](./docs/seguridad.md)                    | Decisiones de seguridad                 |
| [Planificación](./docs/planificacion.md)            | Sprints y planificación                 |
| [Roadmap](./docs/roadmap.md)                        | Evolución del proyecto                  |

---

# 🔮 Futuras funcionalidades

Algunas funcionalidades que podrían incorporarse después de la primera versión:

* Importación de información mediante ISBN.
* Integración con APIs de libros.
* Recomendaciones.
* Perfiles públicos.
* Compartir reseñas.
* Listas de lectura.
* Importación y exportación de datos.
* Integración con dispositivos de lectura.
* Sincronización de progreso de ebooks.
* Integración con plataformas de audiolibros.

Estas funcionalidades no forman parte del alcance inicial.

---

# 🎓 Propósito del proyecto

Este proyecto es desarrollado como **proyecto personal y de aprendizaje**, con el objetivo de profundizar en:

* Desarrollo web full-stack.
* Diseño y modelado de bases de datos.
* Desarrollo de APIs REST.
* Arquitectura de software.
* Autenticación y autorización.
* Desarrollo frontend moderno.
* Dockerización.
* Testing.
* Diseño de interfaces.
* Gestión y documentación de proyectos de software.

---

# 📜 Licencia

Proyecto personal desarrollado con fines de aprendizaje, práctica y experimentación en desarrollo web.
