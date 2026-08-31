# Planificación

El desarrollo del proyecto se organizará mediante **Sprints**, siguiendo una metodología incremental.

Cada Sprint tendrá un objetivo concreto y producirá una parte funcional del sistema.

---

# Sprint 0 — Análisis y diseño

**Objetivo:** Definir las bases funcionales, técnicas y de diseño del sistema antes de comenzar la implementación.

### Tareas

* Definir visión del proyecto.
* Definir alcance.
* Definir requisitos funcionales.
* Definir requisitos no funcionales.
* Definir reglas de negocio.
* Definir casos de uso.
* Definir historias de usuario.
* Diseñar modelo conceptual.
* Diseñar modelo entidad-relación.
* Diseñar modelo relacional.
* Crear diccionario de datos.
* Definir arquitectura.
* Diseñar API.
* Definir tecnologías.
* Definir estructura inicial del repositorio.

**Estado:** 🟡 En progreso

---

# Sprint 1 — Infraestructura

**Objetivo:** Preparar el entorno de desarrollo y establecer la estructura inicial del proyecto.

### Backend

* Crear proyecto ASP.NET Core.
* Configurar estructura por capas.
* Configurar PostgreSQL.
* Configurar Entity Framework Core.
* Configurar migraciones.
* Configurar Swagger/OpenAPI.
* Configurar manejo global de errores.

### Frontend

* Crear proyecto Next.js.
* Configurar React.
* Configurar TypeScript.
* Configurar Tailwind CSS.
* Crear estructura inicial de componentes.
* Configurar comunicación con la API.

### Entorno

* Crear Dockerfile del backend.
* Crear Dockerfile del frontend.
* Configurar PostgreSQL mediante Docker.
* Crear `docker-compose.yml`.
* Configurar variables de entorno.
* Configurar `.gitignore`.

**Estado:** ⚪ Pendiente

---

# Sprint 2 — Autenticación

**Objetivo:** Implementar el sistema de usuarios y la seguridad básica.

### Tareas

* Registrar usuario.
* Validar correo electrónico.
* Almacenar contraseña mediante hash.
* Implementar login.
* Implementar JWT.
* Implementar middleware de autenticación.
* Implementar autorización.
* Proteger endpoints privados.
* Crear interfaz de registro.
* Crear interfaz de login.
* Implementar cierre de sesión.

**Estado:** ⚪ Pendiente

---

# Sprint 3 — Catálogo bibliográfico

**Objetivo:** Implementar las entidades necesarias para representar obras y sus ediciones.

### Tareas

* Crear obras.
* Consultar obras.
* Modificar obras.
* Eliminar obras.
* Crear ediciones.
* Consultar ediciones.
* Modificar ediciones.
* Eliminar ediciones.
* Gestionar autores.
* Gestionar géneros.
* Gestionar sagas.
* Gestionar tipos de obra.
* Implementar formatos.
* Validar datos bibliográficos.

### Formatos iniciales

```text
FISICO
PDF
EBOOK
AUDIOLIBRO
```

**Estado:** ⚪ Pendiente

---

# Sprint 4 — Biblioteca

**Objetivo:** Permitir al usuario administrar las ediciones que posee o ha registrado en su biblioteca personal.

### Tareas

* Agregar edición a la biblioteca.
* Eliminar edición de la biblioteca.
* Consultar biblioteca.
* Consultar detalle de una edición.
* Filtrar biblioteca.
* Ordenar biblioteca.
* Buscar libros.

### Consideraciones

La biblioteca almacenará la relación entre:

```text
Usuario
    │
    ▼
Biblioteca
    │
    ▼
Edición
```

Agregar o eliminar una edición de la biblioteca no afectará a la información global de la obra o edición.

**Estado:** ⚪ Pendiente

---

# Sprint 5 — Lecturas y progreso

**Objetivo:** Implementar el registro de experiencias de lectura y el seguimiento del progreso.

### Tareas

* Crear lectura.
* Identificar automáticamente si corresponde a una relectura.
* Registrar número de lectura.
* Registrar fecha de inicio.
* Registrar sesiones.
* Consultar sesiones.
* Modificar sesiones.
* Eliminar sesiones.
* Registrar progreso.
* Calcular progreso.
* Registrar duración.
* Finalizar lectura.
* Abandonar lectura.
* Consultar historial de lecturas.

### Progreso según formato

| Formato    | Unidad de progreso |
| ---------- | ------------------ |
| FISICO     | Página             |
| PDF        | Página             |
| EBOOK      | Porcentaje         |
| AUDIOLIBRO | Tiempo             |

El sistema determinará automáticamente el progreso inicial de una sesión a partir de la última sesión registrada.

En el caso de los ebooks, el usuario registrará directamente el porcentaje alcanzado.

**Estado:** ⚪ Pendiente

---

# Sprint 6 — Bitácora

**Objetivo:** Implementar el registro de reflexiones y anotaciones realizadas durante las lecturas.

### Tareas

* Crear entradas.
* Consultar entradas.
* Editar entradas.
* Eliminar entradas.
* Asociar entradas a una lectura.
* Asociar opcionalmente entradas a sesiones.
* Registrar fecha.
* Registrar título.
* Registrar contenido.
* Marcar entradas con spoilers.
* Consultar historial de entradas.

### Estructura

```text
LECTURA
   │
   ├── SESIONES
   │
   └── ENTRADAS DE BITÁCORA
           │
           └── Sesión (opcional)
```

**Estado:** ⚪ Pendiente

---

# Sprint 7 — Valoraciones

**Objetivo:** Permitir al usuario registrar su opinión sobre cada experiencia de lectura.

### Tareas

* Crear valoración.
* Registrar puntuación.
* Registrar reseña.
* Consultar valoración.
* Modificar valoración.
* Eliminar valoración.

Una lectura podrá tener como máximo una valoración.

Las valoraciones estarán asociadas a una lectura y no directamente a la edición, permitiendo que diferentes lecturas de una misma edición tengan valoraciones independientes.

**Estado:** ⚪ Pendiente

---

# Sprint 8 — Estadísticas

**Objetivo:** Proporcionar información sobre los hábitos y actividad de lectura del usuario.

### Tareas

* Crear dashboard.
* Mostrar libros terminados.
* Mostrar libros abandonados.
* Mostrar lecturas activas.
* Mostrar cantidad de lecturas.
* Mostrar cantidad de relecturas.
* Mostrar páginas leídas.
* Mostrar tiempo de escucha.
* Mostrar estadísticas mensuales.
* Mostrar estadísticas anuales.
* Mostrar estadísticas por género.
* Mostrar estadísticas por autor.

### Consideración

Las estadísticas deberán adaptarse al formato de los libros.

Por ejemplo:

```text
FISICO / PDF
→ páginas

EBOOK
→ porcentaje

AUDIOLIBRO
→ tiempo
```

**Estado:** ⚪ Pendiente

---

# Sprint 9 — Metas

**Objetivo:** Incorporar funcionalidades orientadas a establecer y realizar seguimiento de objetivos de lectura.

### Tareas

* Crear metas.
* Editar metas.
* Eliminar metas.
* Definir objetivo de lectura.
* Definir período.
* Registrar progreso.
* Mostrar cumplimiento.
* Mostrar metas activas.
* Mostrar metas completadas.

### Funcionalidades futuras

Las siguientes funcionalidades podrán implementarse posteriormente si se consideran necesarias:

* Rutinas de lectura.
* Rachas de lectura.
* Recordatorios.
* Notificaciones.

**Estado:** ⚪ Pendiente

---

# Sprint 10 — Calidad y Release

**Objetivo:** Preparar una versión estable y desplegable del sistema.

### Tareas

#### Testing

* Tests unitarios.
* Tests de integración.
* Tests de API.
* Tests de frontend.
* Validación de casos de uso.

#### Seguridad

* Revisar autenticación.
* Revisar autorización.
* Revisar validaciones.
* Revisar manejo de errores.
* Revisar exposición de información sensible.

#### Frontend

* Responsive design.
* Accesibilidad básica.
* Manejo de estados de carga.
* Manejo de errores.

#### Backend

* Optimización de consultas.
* Manejo consistente de excepciones.
* Validación de entradas.
* Revisión de logs.

#### Documentación

* Actualizar README.
* Actualizar documentación técnica.
* Documentar API.
* Documentar instalación.
* Documentar configuración.

#### Despliegue

* Preparar entorno de producción.
* Configurar variables de entorno.
* Configurar base de datos.
* Desplegar backend.
* Desplegar frontend.
* Verificar funcionamiento.

**Estado:** ⚪ Pendiente

---

# MVP

La primera versión funcional del proyecto se centrará en las funcionalidades esenciales:

```text
┌─────────────────────────────┐
│           MVP               │
├─────────────────────────────┤
│                             │
│  Autenticación              │
│        │                    │
│        ▼                    │
│  Catálogo                   │
│        │                    │
│        ▼                    │
│  Biblioteca                 │
│        │                    │
│        ▼                    │
│  Lecturas                   │
│        │                    │
│        ├── Sesiones         │
│        │                    │
│        ├── Progreso         │
│        │                    │
│        └── Relecturas       │
│        │                    │
│        ▼                    │
│  Bitácora                   │
│        │                    │
│        ▼                    │
│  Valoraciones               │
│                             │
└─────────────────────────────┘
```

Las estadísticas y metas se consideran funcionalidades posteriores al núcleo del sistema.

---

# Dependencias entre Sprints

El desarrollo seguirá aproximadamente el siguiente flujo:

```text
Sprint 0
   │
   ▼
Sprint 1
   │
   ▼
Sprint 2
   │
   ▼
Sprint 3
   │
   ▼
Sprint 4
   │
   ▼
Sprint 5
   │
   ├──────────► Sprint 6
   │
   └──────────► Sprint 7
                    │
                    ▼
                 Sprint 8
                    │
                    ▼
                 Sprint 9
                    │
                    ▼
                Sprint 10
```

Los Sprints 6 y 7 pueden desarrollarse parcialmente en paralelo una vez que el sistema de lecturas se encuentre operativo.

---

# Estado general

| Sprint | Descripción       | Estado         |
| ------ | ----------------- | -------------- |
| 0      | Análisis y diseño | 🟡 En progreso |
| 1      | Infraestructura   | ⚪ Pendiente    |
| 2      | Autenticación     | ⚪ Pendiente    |
| 3      | Catálogo          | ⚪ Pendiente    |
| 4      | Biblioteca        | ⚪ Pendiente    |
| 5      | Lecturas          | ⚪ Pendiente    |
| 6      | Bitácora          | ⚪ Pendiente    |
| 7      | Valoraciones      | ⚪ Pendiente    |
| 8      | Estadísticas      | ⚪ Pendiente    |
| 9      | Metas             | ⚪ Pendiente    |
| 10     | Calidad y Release | ⚪ Pendiente    |

