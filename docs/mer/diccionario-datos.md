# Diccionario de Datos

## USUARIO

| Campo            | Tipo      | Descripción                         |
| ---------------- | --------- | ----------------------------------- |
| `id`             | UUID      | Identificador único del usuario     |
| `nombre`         | VARCHAR   | Nombre del usuario                  |
| `email`          | VARCHAR   | Correo electrónico                  |
| `password_hash`  | VARCHAR   | Contraseña almacenada mediante hash |
| `fecha_registro` | TIMESTAMP | Fecha de registro                   |
| `activo`         | BOOLEAN   | Estado de la cuenta                 |

---

## OBRA

| Campo                        | Tipo    | Descripción                               |
| ---------------------------- | ------- | ----------------------------------------- |
| `id`                         | UUID    | Identificador único de la obra            |
| `titulo`                     | VARCHAR | Título de la obra                         |
| `descripcion`                | TEXT    | Descripción general de la obra            |
| `fecha_publicacion_original` | DATE    | Fecha de publicación original             |
| `saga_id`                    | UUID    | Saga a la que pertenece la obra, opcional |

---

## AUTOR

| Campo       | Tipo    | Descripción                   |
| ----------- | ------- | ----------------------------- |
| `id`        | UUID    | Identificador único del autor |
| `nombre`    | VARCHAR | Nombre del autor              |
| `biografia` | TEXT    | Biografía del autor, opcional |

---

## OBRA_AUTOR

Tabla intermedia que representa la relación muchos a muchos entre obras y autores.

| Campo      | Tipo | Descripción              |
| ---------- | ---- | ------------------------ |
| `obra_id`  | UUID | Identificador de la obra |
| `autor_id` | UUID | Identificador del autor  |

La clave primaria está compuesta por `obra_id` y `autor_id`.

---

## GENERO

| Campo    | Tipo    | Descripción                    |
| -------- | ------- | ------------------------------ |
| `id`     | UUID    | Identificador único del género |
| `nombre` | VARCHAR | Nombre del género              |

El campo `nombre` debe ser único.

---

## OBRA_GENERO

Tabla intermedia que representa la relación muchos a muchos entre obras y géneros.

| Campo       | Tipo | Descripción              |
| ----------- | ---- | ------------------------ |
| `obra_id`   | UUID | Identificador de la obra |
| `genero_id` | UUID | Identificador del género |

La clave primaria está compuesta por `obra_id` y `genero_id`.

---

## SAGA

| Campo         | Tipo    | Descripción                      |
| ------------- | ------- | -------------------------------- |
| `id`          | UUID    | Identificador único de la saga   |
| `nombre`      | VARCHAR | Nombre de la saga                |
| `descripcion` | TEXT    | Descripción de la saga, opcional |

---

## EDICION

Representa una edición concreta de una obra.

| Campo              | Tipo         | Descripción                                 |
| ------------------ | ------------ | ------------------------------------------- |
| `id`               | UUID         | Identificador único de la edición           |
| `obra_id`          | UUID         | Obra a la que pertenece                     |
| `isbn`             | VARCHAR      | ISBN de la edición, cuando corresponda      |
| `editorial`        | VARCHAR      | Editorial responsable de la edición         |
| `anio_publicacion` | INTEGER      | Año de publicación de la edición            |
| `numero_paginas`   | INTEGER      | Número total de páginas, cuando corresponde |
| `portada_url`      | VARCHAR      | URL de la portada                           |
| `formato`          | VARCHAR/ENUM | Formato utilizado para la lectura           |

El valor de `formato` determina la unidad utilizada para registrar el progreso de las sesiones de lectura.

---

## BIBLIOTECA

Relaciona a un usuario con las ediciones que ha registrado en su biblioteca personal.

| Campo            | Tipo      | Descripción                                          |
| ---------------- | --------- | ---------------------------------------------------- |
| `usuario_id`     | UUID      | Usuario propietario del registro                     |
| `edicion_id`     | UUID      | Edición registrada                                   |
| `fecha_agregado` | TIMESTAMP | Fecha en que la edición fue agregada a la biblioteca |

La clave primaria está compuesta por `usuario_id` y `edicion_id`.

---

## LECTURA

Representa una experiencia concreta de lectura de una edición por parte de un usuario.

| Campo              | Tipo         | Descripción                       |
| ------------------ | ------------ | --------------------------------- |
| `id`               | UUID         | Identificador único de la lectura |
| `usuario_id`       | UUID         | Usuario que realiza la lectura    |
| `edicion_id`       | UUID         | Edición utilizada                 |
| `fecha_inicio`     | DATE         | Fecha de inicio de la lectura     |
| `fecha_fin`        | DATE         | Fecha de finalización, opcional   |
| `estado`           | VARCHAR/ENUM | Estado actual de la lectura       |
| `numero_relectura` | INTEGER      | Número de lectura de la edición   |

El campo `numero_relectura` permite diferenciar entre la primera lectura y las posteriores relecturas de una misma edición.

---

## SESION_LECTURA

Representa una sesión individual dentro de una lectura.

| Campo              | Tipo      | Descripción                                |
| ------------------ | --------- | ------------------------------------------ |
| `id`               | UUID      | Identificador único de la sesión           |
| `lectura_id`       | UUID      | Lectura a la que pertenece                 |
| `fecha`            | TIMESTAMP | Fecha y hora de la sesión                  |
| `progreso`         | DECIMAL   | Progreso alcanzado al finalizar la sesión  |
| `duracion_minutos` | INTEGER   | Duración de la sesión en minutos, opcional |

El significado de `progreso` depende del formato de la edición asociada a la lectura.

El progreso inicial de una sesión puede obtenerse a partir del progreso registrado en la sesión anterior, por lo que no se almacena como un campo independiente.

---

## ENTRADA_BITACORA

Representa una nota, reflexión o anotación realizada durante una lectura.

| Campo               | Tipo      | Descripción                            |
| ------------------- | --------- | -------------------------------------- |
| `id`                | UUID      | Identificador único de la entrada      |
| `lectura_id`        | UUID      | Lectura asociada                       |
| `sesion_lectura_id` | UUID      | Sesión asociada, opcional              |
| `fecha`             | TIMESTAMP | Fecha de creación de la entrada        |
| `titulo`            | VARCHAR   | Título de la entrada                   |
| `contenido`         | TEXT      | Contenido de la entrada                |
| `contiene_spoilers` | BOOLEAN   | Indica si la entrada contiene spoilers |

La asociación con una sesión de lectura es opcional, permitiendo registrar reflexiones generales sobre una lectura.

---

## VALORACION

Representa la valoración realizada por el usuario sobre una lectura específica.

| Campo        | Tipo      | Descripción                                 |
| ------------ | --------- | ------------------------------------------- |
| `id`         | UUID      | Identificador único de la valoración        |
| `lectura_id` | UUID      | Lectura valorada                            |
| `puntuacion` | DECIMAL   | Puntuación otorgada                         |
| `resena`     | TEXT      | Reseña o comentario de la lectura, opcional |
| `fecha`      | TIMESTAMP | Fecha de registro de la valoración          |

`lectura_id` debe ser único para garantizar que una lectura tenga como máximo una valoración.

---

# Estados de Lectura

Los estados contemplados inicialmente son:

| Estado       | Descripción                                         |
| ------------ | --------------------------------------------------- |
| `PENDIENTE`  | La lectura está registrada pero aún no ha comenzado |
| `LEYENDO`    | La lectura se encuentra actualmente en progreso     |
| `TERMINADO`  | La lectura fue completada                           |
| `ABANDONADO` | La lectura fue interrumpida sin finalizar           |

---

# Formatos

| Formato      | Unidad de progreso | `numero_paginas` |
| ------------ | ------------------ | ---------------- |
| `FISICO`     | Páginas            | Requerido        |
| `PDF`        | Páginas            | Requerido        |
| `EBOOK`      | Porcentaje         | Opcional         |
| `AUDIOLIBRO` | Tiempo             | No corresponde   |

El campo `SESION_LECTURA.progreso` se interpreta según el formato:

```text
FISICO
→ progreso = página alcanzada

PDF
→ progreso = página alcanzada

EBOOK
→ progreso = porcentaje (0-100)

AUDIOLIBRO
→ progreso = tiempo alcanzado
```

Para audiolibros, el tiempo puede almacenarse internamente como una cantidad numérica de segundos y convertirse a horas, minutos y segundos en la interfaz.

---

# Consideraciones sobre el progreso

El progreso general de una lectura **no se almacena directamente**.

Se calcula a partir del último progreso registrado y de las características de la edición.

### Físico y PDF

```text
progreso_porcentaje =
(progreso_actual / numero_paginas) × 100
```

### Ebook

```text
progreso_porcentaje =
progreso_actual
```

### Audiolibro

```text
progreso_porcentaje =
(tiempo_actual / duracion_total) × 100
```

De esta forma, se evita almacenar información derivada que podría quedar desactualizada.
