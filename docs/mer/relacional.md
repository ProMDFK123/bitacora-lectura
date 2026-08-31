# Modelo Relacional

## USUARIO

```text
USUARIO(

    id PK,
    nombre,
    email UNIQUE,
    password_hash,
    fecha_registro,
    activo

)
```

---

## OBRA

```text
OBRA(

    id PK,
    titulo,
    descripcion,
    fecha_publicacion_original,
    saga_id FK NULL

)
```

---

## AUTOR

```text
AUTOR(

    id PK,
    nombre,
    biografia

)
```

---

## OBRA_AUTOR

```text
OBRA_AUTOR(

    obra_id PK FK,
    autor_id PK FK

)
```

---

## GENERO

```text
GENERO(

    id PK,
    nombre UNIQUE

)
```

---

## OBRA_GENERO

```text
OBRA_GENERO(

    obra_id PK FK,
    genero_id PK FK

)
```

---

## SAGA

```text
SAGA(

    id PK,
    nombre,
    descripcion

)
```

---

## EDICION

Representa una edición concreta de una obra.

El atributo `formato` determina la unidad utilizada para registrar el progreso de las sesiones de lectura.

```text
EDICION(

    id PK,
    obra_id FK,
    isbn,
    editorial,
    anio_publicacion,
    numero_paginas NULL,
    portada_url,
    formato

)
```

Los valores iniciales de `formato` serán:

```text
FISICO
PDF
EBOOK
AUDIOLIBRO
```

`numero_paginas` puede ser `NULL` cuando el formato no utilice una cantidad de páginas estable, como ocurre con ebooks o audiolibros.

---

## BIBLIOTECA

Relaciona usuarios con las ediciones que han registrado en su biblioteca personal.

Una edición puede estar registrada en las bibliotecas de múltiples usuarios.

```text
BIBLIOTECA(

    usuario_id PK FK,
    edicion_id PK FK,
    fecha_agregado

)
```

La clave primaria compuesta `(usuario_id, edicion_id)` evita que un usuario registre la misma edición más de una vez en su biblioteca.

---

## LECTURA

Representa una experiencia concreta de lectura de una edición por parte de un usuario.

Una misma edición puede tener múltiples lecturas del mismo usuario para representar relecturas.

```text
LECTURA(

    id PK,
    usuario_id FK,
    edicion_id FK,
    fecha_inicio,
    fecha_fin NULL,
    estado,
    numero_relectura

)
```

El atributo `numero_relectura` permite identificar el orden de las diferentes lecturas de una misma edición.

Por ejemplo:

```text
LECTURA
├── numero_relectura = 1
├── numero_relectura = 2
└── numero_relectura = 3
```

---

## SESION_LECTURA

Registra una sesión individual dentro de una lectura.

El campo `progreso` representa el punto alcanzado al finalizar la sesión. Su unidad depende del formato de la edición.

```text
SESION_LECTURA(

    id PK,
    lectura_id FK,
    fecha,
    progreso,
    duracion_minutos NULL

)
```

El significado de `progreso` depende de `EDICION.formato`:

| Formato      | `progreso` representa |
| ------------ | --------------------- |
| `FISICO`     | Página alcanzada      |
| `PDF`        | Página alcanzada      |
| `EBOOK`      | Porcentaje alcanzado  |
| `AUDIOLIBRO` | Tiempo alcanzado      |

El progreso inicial de una sesión puede obtenerse a partir del progreso registrado en la sesión anterior, por lo que no es necesario almacenarlo como una columna independiente.

En la primera sesión, el progreso inicial se determina según el formato:

* `FISICO`: página inicial.
* `PDF`: página inicial.
* `EBOOK`: no requiere progreso inicial almacenado.
* `AUDIOLIBRO`: tiempo inicial, normalmente `0`.

---

## ENTRADA_BITACORA

Representa una nota o reflexión realizada durante una lectura.

La asociación con una sesión específica es opcional.

```text
ENTRADA_BITACORA(

    id PK,
    lectura_id FK,
    sesion_lectura_id FK NULL,
    fecha,
    titulo,
    contenido,
    contiene_spoilers

)
```

Una entrada puede ser:

* Asociada a una sesión concreta.
* Una reflexión general de la lectura sin una sesión específica.

---

## VALORACION

Representa la valoración de una lectura específica.

Una lectura puede tener como máximo una valoración.

```text
VALORACION(

    id PK,
    lectura_id UNIQUE FK,
    puntuacion,
    resena,
    fecha

)
```

El `UNIQUE` sobre `lectura_id` garantiza la relación `1:0..1`.

---

# Restricciones principales

* `USUARIO.email` debe ser único.
* Una edición debe pertenecer a una obra.
* Una lectura debe pertenecer a un usuario.
* Una lectura debe pertenecer a una edición.
* Una sesión debe pertenecer a una lectura.
* Una entrada de bitácora debe pertenecer a una lectura.
* La asociación entre una entrada de bitácora y una sesión es opcional.
* Una lectura puede tener como máximo una valoración.
* Una edición puede estar registrada una sola vez por usuario en `BIBLIOTECA`.
* `numero_relectura` debe ser consistente con las lecturas anteriores del usuario para esa edición.
* El valor de `progreso` debe validarse según el formato de la edición.
* Para `FISICO` y `PDF`, el progreso debe corresponder a una página válida.
* Para `EBOOK`, el progreso debe corresponder a un porcentaje válido entre `0` y `100`.
* Para `AUDIOLIBRO`, el progreso debe corresponder a una cantidad de tiempo válida.
* `numero_paginas` puede ser `NULL` cuando la edición no utilice una paginación estable.
* `fecha_fin` puede ser `NULL` mientras la lectura se encuentre en progreso.

> **Nota:** `formato` se mantiene actualmente como atributo de `EDICION`. Si posteriormente se considera necesario permitir formatos configurables o agregar metadatos propios de cada formato, puede transformarse en una entidad `FORMATO`.
