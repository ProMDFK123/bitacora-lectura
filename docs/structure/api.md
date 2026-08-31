# API

## 1. Convenciones

La API seguirá principios de arquitectura **REST**.

La ruta base será:

```text
/api
```

Las respuestas utilizarán formato **JSON**.

Los endpoints protegidos requerirán autenticación mediante **JWT**.

Las solicitudes que modifiquen información deberán utilizar el método HTTP correspondiente:

| Método   | Uso                 |
| -------- | ------------------- |
| `GET`    | Consultar recursos  |
| `POST`   | Crear recursos      |
| `PUT`    | Actualizar recursos |
| `DELETE` | Eliminar recursos   |

Los identificadores de recursos serán representados mediante UUID.

---

# 2. Autenticación

## 2.1. Registrar usuario

```http
POST /api/auth/register
```

Permite crear una nueva cuenta.

### Body

```json
{
  "nombre": "Gabriel",
  "email": "usuario@example.com",
  "password": "********"
}
```

### Respuesta

```http
201 Created
```

---

## 2.2. Iniciar sesión

```http
POST /api/auth/login
```

Permite autenticar a un usuario registrado.

### Body

```json
{
  "email": "usuario@example.com",
  "password": "********"
}
```

### Respuesta

```json
{
  "token": "...",
  "expiresAt": "..."
}
```

---

# 3. Obras

Las obras representan el contenido intelectual independientemente de sus ediciones.

## 3.1. Obtener obras

```http
GET /api/works
```

Permite consultar las obras disponibles.

Puede admitir posteriormente parámetros de:

* Búsqueda.
* Ordenamiento.
* Paginación.
* Filtrado por género.
* Filtrado por autor.
* Filtrado por saga.

---

## 3.2. Obtener obra

```http
GET /api/works/{id}
```

Obtiene el detalle de una obra.

---

## 3.3. Crear obra

```http
POST /api/works
```

Crea una nueva obra.

---

## 3.4. Actualizar obra

```http
PUT /api/works/{id}
```

Actualiza la información de una obra.

---

## 3.5. Eliminar obra

```http
DELETE /api/works/{id}
```

Elimina una obra cuando las reglas de integridad lo permitan.

---

# 4. Ediciones

Las ediciones representan una versión concreta de una obra.

## 4.1. Obtener ediciones de una obra

```http
GET /api/works/{id}/editions
```

Obtiene las ediciones asociadas a una obra.

---

## 4.2. Crear edición

```http
POST /api/works/{id}/editions
```

Crea una edición asociada a una obra.

El sistema deberá validar los datos específicos del formato.

---

## 4.3. Obtener edición

```http
GET /api/editions/{id}
```

Obtiene el detalle de una edición.

---

## 4.4. Actualizar edición

```http
PUT /api/editions/{id}
```

Actualiza los datos de una edición.

---

## 4.5. Eliminar edición

```http
DELETE /api/editions/{id}
```

Elimina una edición cuando las reglas de integridad lo permitan.

---

# 5. Biblioteca

La biblioteca representa la relación entre un usuario y las ediciones que ha registrado.

## 5.1. Consultar biblioteca

```http
GET /api/library
```

Obtiene la biblioteca del usuario autenticado.

---

## 5.2. Agregar edición

```http
POST /api/library/{editionId}
```

Agrega una edición a la biblioteca del usuario autenticado.

### Posibles respuestas

```http
201 Created
```

Si la edición fue agregada correctamente.

```http
409 Conflict
```

Si la edición ya pertenece a la biblioteca.

---

## 5.3. Eliminar edición

```http
DELETE /api/library/{editionId}
```

Elimina la asociación entre el usuario y la edición.

La eliminación de la biblioteca **no elimina la edición del sistema**.

---

# 6. Lecturas

## 6.1. Crear lectura

```http
POST /api/editions/{editionId}/readings
```

Crea una nueva lectura de una edición.

El sistema determinará automáticamente el número correspondiente de lectura/relectura.

---

## 6.2. Obtener lecturas de una edición

```http
GET /api/editions/{editionId}/readings
```

Obtiene el historial de lecturas del usuario autenticado para una edición.

---

## 6.3. Obtener lectura

```http
GET /api/readings/{id}
```

Obtiene el detalle de una lectura.

La respuesta podrá incluir:

* Datos de la edición.
* Estado.
* Fecha de inicio.
* Fecha de finalización.
* Número de lectura.
* Progreso actual.
* Cantidad de sesiones.
* Cantidad de entradas de bitácora.
* Valoración.

---

## 6.4. Actualizar lectura

```http
PUT /api/readings/{id}
```

Permite actualizar los datos modificables de una lectura.

---

## 6.5. Finalizar lectura

```http
POST /api/readings/{id}/finish
```

Marca una lectura como `TERMINADO`.

El sistema registra la fecha de finalización.

---

## 6.6. Abandonar lectura

```http
POST /api/readings/{id}/abandon
```

Marca una lectura como `ABANDONADO`.

Las sesiones y entradas registradas previamente se conservan.

---

# 7. Sesiones de lectura

## 7.1. Crear sesión

```http
POST /api/readings/{id}/sessions
```

Registra una nueva sesión de lectura.

### Body conceptual

```json
{
  "fecha": "2026-08-31T18:30:00",
  "progreso": 150,
  "duracionMinutos": 45
}
```

El significado de `progreso` dependerá del formato de la edición.

```text
FISICO     → página
PDF        → página
EBOOK      → porcentaje
AUDIOLIBRO → tiempo
```

El progreso inicial se obtiene automáticamente a partir de la sesión anterior.

---

## 7.2. Consultar sesiones

```http
GET /api/readings/{id}/sessions
```

Obtiene todas las sesiones de una lectura.

---

## 7.3. Obtener sesión

```http
GET /api/sessions/{id}
```

Obtiene una sesión específica.

---

## 7.4. Actualizar sesión

```http
PUT /api/sessions/{id}
```

Permite corregir los datos de una sesión cuando sea necesario.

El sistema deberá volver a validar la consistencia del progreso con las sesiones posteriores.

---

## 7.5. Eliminar sesión

```http
DELETE /api/sessions/{id}
```

Elimina una sesión.

La eliminación deberá considerar el impacto que pueda tener sobre el progreso de las sesiones posteriores.

---

# 8. Bitácora

## 8.1. Crear entrada

```http
POST /api/readings/{id}/entries
```

Crea una entrada de bitácora asociada a una lectura.

Opcionalmente puede asociarse a una sesión.

---

## 8.2. Consultar entradas

```http
GET /api/readings/{id}/entries
```

Obtiene las entradas de bitácora de una lectura.

---

## 8.3. Obtener entrada

```http
GET /api/entries/{id}
```

Obtiene una entrada específica.

---

## 8.4. Actualizar entrada

```http
PUT /api/entries/{id}
```

Actualiza una entrada existente.

---

## 8.5. Eliminar entrada

```http
DELETE /api/entries/{id}
```

Elimina una entrada de bitácora.

---

# 9. Valoraciones

Una lectura puede tener como máximo una valoración.

## 9.1. Crear valoración

```http
POST /api/readings/{id}/rating
```

Crea una valoración para una lectura.

---

## 9.2. Obtener valoración

```http
GET /api/readings/{id}/rating
```

Obtiene la valoración asociada a una lectura.

---

## 9.3. Actualizar valoración

```http
PUT /api/readings/{id}/rating
```

Actualiza la valoración existente.

---

## 9.4. Eliminar valoración

```http
DELETE /api/readings/{id}/rating
```

Elimina la valoración de una lectura.

---

# 10. Estadísticas

Las estadísticas serán generadas a partir de la información almacenada en lecturas y sesiones.

## 10.1. Resumen general

```http
GET /api/statistics/overview
```

Obtiene un resumen general de la actividad del usuario.

Puede incluir:

* Total de libros terminados.
* Total de libros abandonados.
* Lecturas activas.
* Total de lecturas.
* Total de relecturas.
* Páginas leídas.
* Tiempo de lectura.

---

## 10.2. Estadísticas mensuales

```http
GET /api/statistics/monthly
```

Obtiene estadísticas agrupadas por mes.

---

## 10.3. Estadísticas por género

```http
GET /api/statistics/genres
```

Obtiene estadísticas agrupadas por género.

---

## 10.4. Estadísticas por autor

```http
GET /api/statistics/authors
```

Obtiene estadísticas agrupadas por autor.

---

# 11. Autorización

Todas las operaciones que involucren información personal deberán verificar que el recurso pertenece al usuario autenticado.

Por ejemplo:

```text
Usuario A
│
├── Biblioteca A
├── Lecturas A
├── Sesiones A
├── Bitácora A
└── Valoraciones A
```

El usuario A no podrá acceder ni modificar recursos pertenecientes al usuario B.

Las operaciones de consulta de obras, autores, géneros y sagas podrán considerarse recursos compartidos del sistema, mientras que las operaciones de biblioteca, lecturas, sesiones, bitácora y valoraciones serán específicas del usuario.

---

# 12. Validación del progreso

El backend será responsable de validar el progreso recibido.

## FISICO

```text
0 ≤ progreso ≤ numero_paginas
```

## PDF

```text
0 ≤ progreso ≤ numero_paginas
```

## EBOOK

```text
0 ≤ progreso ≤ 100
```

## AUDIOLIBRO

```text
0 ≤ progreso ≤ duracion_total_segundos
```

Además, el progreso de una sesión deberá ser consistente con el progreso alcanzado anteriormente dentro de la misma lectura.

---

# 13. Respuestas

Las respuestas exitosas utilizarán JSON cuando corresponda.

Ejemplo:

```json
{
  "id": "550e8400-e29b-41d4-a716-446655440000",
  "titulo": "El Señor de los Anillos",
  "formato": "FISICO",
  "progreso": 65.5
}
```

Las operaciones que no requieran devolver contenido podrán utilizar:

```http
204 No Content
```

---

# 14. Errores

Las respuestas de error utilizarán una estructura consistente.

Ejemplo:

```json
{
  "status": 400,
  "message": "El progreso ingresado no es válido para el formato de la edición.",
  "errors": []
}
```

Cuando existan errores específicos de validación:

```json
{
  "status": 400,
  "message": "La solicitud contiene errores de validación.",
  "errors": {
    "email": [
      "El correo electrónico no es válido."
    ]
  }
}
```

---

# 15. Códigos HTTP

| Código | Uso                             |
| ------ | ------------------------------- |
| `200`  | Operación exitosa               |
| `201`  | Recurso creado                  |
| `204`  | Operación exitosa sin contenido |
| `400`  | Solicitud inválida              |
| `401`  | No autenticado                  |
| `403`  | Sin permisos                    |
| `404`  | Recurso no encontrado           |
| `409`  | Conflicto                       |
| `422`  | Entidad no procesable           |
| `500`  | Error interno del servidor      |

---

# 16. Resumen de endpoints

| Recurso    | Método   | Endpoint                             |
| ---------- | -------- | ------------------------------------ |
| Auth       | `POST`   | `/api/auth/register`                 |
| Auth       | `POST`   | `/api/auth/login`                    |
| Works      | `GET`    | `/api/works`                         |
| Works      | `GET`    | `/api/works/{id}`                    |
| Works      | `POST`   | `/api/works`                         |
| Works      | `PUT`    | `/api/works/{id}`                    |
| Works      | `DELETE` | `/api/works/{id}`                    |
| Editions   | `GET`    | `/api/works/{id}/editions`           |
| Editions   | `POST`   | `/api/works/{id}/editions`           |
| Editions   | `GET`    | `/api/editions/{id}`                 |
| Editions   | `PUT`    | `/api/editions/{id}`                 |
| Editions   | `DELETE` | `/api/editions/{id}`                 |
| Library    | `GET`    | `/api/library`                       |
| Library    | `POST`   | `/api/library/{editionId}`           |
| Library    | `DELETE` | `/api/library/{editionId}`           |
| Readings   | `POST`   | `/api/editions/{editionId}/readings` |
| Readings   | `GET`    | `/api/editions/{editionId}/readings` |
| Readings   | `GET`    | `/api/readings/{id}`                 |
| Readings   | `PUT`    | `/api/readings/{id}`                 |
| Readings   | `POST`   | `/api/readings/{id}/finish`          |
| Readings   | `POST`   | `/api/readings/{id}/abandon`         |
| Sessions   | `POST`   | `/api/readings/{id}/sessions`        |
| Sessions   | `GET`    | `/api/readings/{id}/sessions`        |
| Sessions   | `GET`    | `/api/sessions/{id}`                 |
| Sessions   | `PUT`    | `/api/sessions/{id}`                 |
| Sessions   | `DELETE` | `/api/sessions/{id}`                 |
| Entries    | `POST`   | `/api/readings/{id}/entries`         |
| Entries    | `GET`    | `/api/readings/{id}/entries`         |
| Entries    | `GET`    | `/api/entries/{id}`                  |
| Entries    | `PUT`    | `/api/entries/{id}`                  |
| Entries    | `DELETE` | `/api/entries/{id}`                  |
| Rating     | `POST`   | `/api/readings/{id}/rating`          |
| Rating     | `GET`    | `/api/readings/{id}/rating`          |
| Rating     | `PUT`    | `/api/readings/{id}/rating`          |
| Rating     | `DELETE` | `/api/readings/{id}/rating`          |
| Statistics | `GET`    | `/api/statistics/overview`           |
| Statistics | `GET`    | `/api/statistics/monthly`            |
| Statistics | `GET`    | `/api/statistics/genres`             |
| Statistics | `GET`    | `/api/statistics/authors`            |

---

# 17. Documentación de la API

La API deberá contar con documentación interactiva mediante **OpenAPI/Swagger** durante el desarrollo.

Esto permitirá consultar:

* Endpoints disponibles.
* Parámetros.
* DTOs.
* Respuestas.
* Códigos HTTP.
* Requisitos de autenticación.

La documentación OpenAPI será generada automáticamente a partir de la implementación del backend.
