# Reglas de Negocio

## 1. Usuarios

### RN-01 — Registro de usuario

Todo usuario debe registrarse con un nombre, correo electrónico y contraseña.

### RN-02 — Correo único

El correo electrónico de un usuario debe ser único dentro del sistema.

No pueden existir dos cuentas con el mismo correo.

### RN-03 — Estado de usuario

Un usuario puede encontrarse activo o inactivo.

Un usuario inactivo no podrá utilizar las funcionalidades que requieran autenticación.

---

# 2. Obras

### RN-04 — Identificación de una obra

Una `OBRA` representa una obra intelectual independientemente de la edición concreta que posea el usuario.

Por ejemplo:

```text
OBRA
└── El Señor de los Anillos
```

Las características específicas de una edición no deben almacenarse en `OBRA`.

### RN-05 — Registro de obras por usuario

Las obras son registradas directamente por el usuario al incorporar un libro a su biblioteca.

Cada registro de obra pertenece al usuario que lo creó.

El sistema no utilizará inicialmente un catálogo bibliográfico global de obras.

Por lo tanto, diferentes usuarios pueden registrar independientemente la misma obra.

Ejemplo:

```text
Usuario A
└── OBRA: El Señor de los Anillos

Usuario B
└── OBRA: El Señor de los Anillos
```

Estos registros representan la misma obra conceptualmente, pero son registros independientes dentro del sistema.

### RN-06 — Múltiples ediciones

Una obra puede tener múltiples ediciones.

```text
El Señor de los Anillos

├── Edición Minotauro
├── Edición Penguin
└── Edición HarperCollins
```

Cada edición mantiene sus propias características.

### RN-07 — Autores

Una obra puede tener uno o múltiples autores.

Un autor puede participar en múltiples obras.

La relación se gestiona mediante `OBRA_AUTOR`.

Los autores son registrados por el usuario y pertenecen al usuario que los creó.

Diferentes usuarios pueden registrar independientemente al mismo autor, generando registros duplicados.

### RN-08 — Géneros

Una obra puede pertenecer a uno o múltiples géneros.

Un género puede estar asociado a múltiples obras.

Esta relación se gestiona mediante `OBRA_GENERO`.

Los géneros son los únicos elementos bibliográficos predefinidos y compartidos por todos los usuarios.

Los usuarios no podrán crear nuevos géneros desde la aplicación.

### RN-09 — Saga opcional

Una obra puede pertenecer opcionalmente a una saga.

Una saga puede contener múltiples obras.

Una obra independiente no necesita pertenecer a ninguna saga.

Las sagas son registradas por el usuario y pertenecen al usuario que las creó.

Diferentes usuarios pueden registrar independientemente la misma saga.

---

# 3. Ediciones

### RN-10 — Edición perteneciente a una obra

Toda edición debe estar asociada a una única obra.

Una edición no puede existir sin una obra asociada.

### RN-11 — Registro de ediciones por usuario

Las ediciones son registradas por el usuario al incorporar un libro a su biblioteca.

Una edición pertenece al usuario que la registró.

Diferentes usuarios pueden registrar independientemente la misma edición, incluso si sus datos bibliográficos son idénticos.

### RN-12 — Características de la edición

Los datos que pueden variar entre diferentes ediciones deben almacenarse en `EDICION`.

Entre ellos:

* ISBN.
* Editorial.
* Año de publicación.
* Número de páginas.
* Portada.
* Formato.
* Duración total, cuando corresponda.

### RN-13 — ISBN

El ISBN identifica una edición cuando este existe.

No todas las ediciones necesariamente disponen de ISBN, por lo que el campo puede ser opcional.

El sistema no debe asumir que el ISBN sea único globalmente entre los registros de diferentes usuarios.

### RN-14 — Número de páginas

`numero_paginas` será obligatorio para los formatos que utilicen una cantidad de páginas estable.

Para formatos como audiolibros o ebooks puede ser `NULL`.

### RN-15 — Duración total

`duracion_total_minutos` será obligatorio para las ediciones en formato `AUDIOLIBRO`.

Para otros formatos será `NULL`.

Este valor permitirá calcular el porcentaje de progreso de un audiolibro.

---

# 4. Formatos

### RN-16 — Formato de edición

Cada edición debe tener un formato definido.

Los formatos contemplados inicialmente son:

```text
FISICO
PDF
EBOOK
AUDIOLIBRO
```

### RN-17 — Unidad de progreso

El formato determina la unidad utilizada para registrar el progreso.

| Formato      | Unidad     |
| ------------ | ---------- |
| `FISICO`     | Páginas    |
| `PDF`        | Páginas    |
| `EBOOK`      | Porcentaje |
| `AUDIOLIBRO` | Tiempo     |

### RN-18 — Progreso de libros físicos

Para una edición física, el progreso representa la página alcanzada.

Ejemplo:

```text
Edición: 500 páginas

Sesión: progreso = 125

→ 25 % de progreso
```

### RN-19 — Progreso de PDF

Los PDF utilizan el mismo sistema de progreso basado en páginas que los libros físicos.

### RN-20 — Progreso de ebook

Los ebooks utilizan directamente un porcentaje de progreso.

Esto evita depender de la cantidad de páginas mostradas por un dispositivo o aplicación, ya que esta puede variar según:

* Tamaño de fuente.
* Dispositivo.
* Configuración de lectura.
* Aplicación utilizada.

El valor debe encontrarse entre `0` y `100`.

### RN-21 — Progreso de audiolibros

Los audiolibros utilizan el tiempo de reproducción como unidad de progreso.

El progreso representa el tiempo alcanzado dentro del audiolibro y se registra en minutos.

---

# 5. Biblioteca

### RN-22 — Registro en biblioteca

Un usuario puede registrar una edición en su biblioteca personal.

Registrar una edición en la biblioteca no implica haber comenzado una lectura.

### RN-23 — Edición única en biblioteca

Un usuario no puede registrar la misma edición más de una vez en su biblioteca.

La combinación:

```text
(usuario_id, edicion_id)
```

debe ser única.

### RN-24 — Biblioteca independiente de lecturas

Una edición puede permanecer en la biblioteca aunque el usuario:

* Nunca la haya leído.
* Haya terminado su lectura.
* Haya abandonado una lectura.
* La haya leído múltiples veces.

### RN-25 — Propiedad de la biblioteca

Cada registro de biblioteca pertenece exclusivamente a un usuario.

Un usuario solo puede consultar, agregar o eliminar registros de su propia biblioteca.

---

# 6. Lecturas

### RN-26 — Creación de una lectura

Una lectura representa una experiencia concreta de un usuario leyendo una edición.

Por lo tanto, una lectura pertenece obligatoriamente a:

* Un usuario.
* Una edición.

### RN-27 — Múltiples lecturas

Un usuario puede realizar múltiples lecturas de una misma edición.

Esto permite registrar relecturas.

```text
Edición

├── Lectura #1
├── Lectura #2
└── Lectura #3
```

Cada lectura mantiene sus propios:

* Fechas.
* Sesiones.
* Entradas de bitácora.
* Valoración.

### RN-28 — Número de lectura

`numero_relectura` identifica el orden de lectura de una edición por parte del usuario.

Ejemplo:

```text
Primera lectura → 1
Segunda lectura → 2
Tercera lectura → 3
```

La primera lectura corresponde al valor `1`.

### RN-29 — Estado de lectura

Una lectura puede encontrarse en alguno de los siguientes estados:

```text
PENDIENTE
LEYENDO
TERMINADO
ABANDONADO
```

El sistema deberá controlar las transiciones válidas entre estados.

### RN-30 — Fecha de inicio

Una lectura debe registrar la fecha en que comenzó.

### RN-31 — Fecha de finalización

`fecha_fin` puede permanecer `NULL` mientras la lectura no haya terminado.

Cuando una lectura pasa a `TERMINADO`, debe registrarse su fecha de finalización.

---

# 7. Sesiones de lectura

### RN-32 — Pertenencia a una lectura

Toda sesión de lectura debe pertenecer a una única `LECTURA`.

### RN-33 — Múltiples sesiones

Una lectura puede contener múltiples sesiones.

```text
LECTURA

├── Sesión 1
├── Sesión 2
├── Sesión 3
└── ...
```

### RN-34 — Progreso de la sesión

Cada sesión registra únicamente el progreso alcanzado al finalizar dicha sesión mediante el campo `progreso`.

No se almacena un `progreso_inicial` independiente.

### RN-35 — Progreso inicial implícito

El progreso inicial de una sesión se obtiene a partir del progreso registrado en la sesión anterior.

Ejemplo:

```text
Sesión 1

progreso = 30

Sesión 2

progreso inicial = 30
progreso final = 75
```

En la base de datos solo se almacena:

```text
Sesión 2

progreso = 75
```

### RN-36 — Primera sesión

Cuando no existe una sesión anterior, el progreso inicial se considera el punto de inicio correspondiente al formato.

```text
FISICO/PDF
→ página 0

EBOOK
→ 0 %

AUDIOLIBRO
→ 0 minutos
```

### RN-37 — Progreso secuencial

Una sesión no debe registrar un progreso inferior al alcanzado en la sesión inmediatamente anterior dentro de la misma lectura.

Esto evita inconsistencias como:

```text
Sesión 1 → página 150
Sesión 2 → página 100
```

salvo que posteriormente se implemente explícitamente soporte para retroceder en una lectura.

### RN-38 — Progreso máximo

El progreso registrado no puede superar el límite correspondiente a la edición.

Para formatos paginados:

```text
0 ≤ progreso ≤ numero_paginas
```

Para ebooks:

```text
0 ≤ progreso ≤ 100
```

Para audiolibros:

```text
0 ≤ progreso ≤ duracion_total_minutos
```

### RN-39 — Duración de sesión

La duración de una sesión puede registrarse opcionalmente mediante `duracion_minutos`.

Esta información es independiente del progreso.

Ejemplo:

```text
Sesión:

progreso = página 150
duracion_minutos = 45
```

---

# 8. Entradas de bitácora

### RN-40 — Pertenencia a una lectura

Toda entrada de bitácora debe pertenecer a una lectura.

### RN-41 — Asociación opcional con sesión

Una entrada puede asociarse opcionalmente a una sesión específica.

Por lo tanto:

```text
Entrada → Lectura
Entrada → Sesión (opcional)
```

Esto permite registrar:

* Reflexiones realizadas durante una sesión.
* Comentarios generales sobre la lectura.

### RN-42 — Consistencia de la sesión asociada

Si una entrada tiene una `sesion_lectura_id`, dicha sesión debe pertenecer a la misma lectura indicada por `lectura_id`.

No se permitirá asociar una entrada de una lectura con una sesión perteneciente a otra lectura.

### RN-43 — Spoilers

Cada entrada debe indicar si contiene spoilers.

Esto permitirá controlar posteriormente la visualización de contenido relacionado con la trama de la obra.

---

# 9. Valoraciones

### RN-44 — Valoración por lectura

Una valoración pertenece a una lectura específica y no directamente a una obra o edición.

Esto permite que una misma obra o edición reciba diferentes valoraciones en diferentes lecturas.

### RN-45 — Una valoración por lectura

Una lectura puede tener como máximo una valoración.

```text
LECTURA
└── VALORACION
```

La relación es:

```text
1 : 0..1
```

### RN-46 — Valoración independiente en relecturas

Las relecturas pueden tener valoraciones diferentes.

Ejemplo:

```text
Lectura #1 → ★★★★☆
Lectura #2 → ★★★★★
```

La valoración anterior no se modifica al crear una nueva lectura.

### RN-47 — Rango de puntuación

La puntuación de una valoración deberá encontrarse entre `0.0` y `5.0`.

### RN-48 — Incrementos de puntuación

Las puntuaciones podrán registrarse en incrementos de `0.5`.

Los valores válidos serán:

```text
0.0
0.5
1.0
1.5
2.0
2.5
3.0
3.5
4.0
4.5
5.0
```

---

# 10. Cálculo del progreso

### RN-49 — Progreso calculado

El porcentaje general de progreso no se almacena directamente.

Se calcula utilizando el último progreso registrado en una sesión y las características de la edición.

### RN-50 — Libros paginados

Para formatos `FISICO` y `PDF`:

```text
porcentaje =
(progreso / numero_paginas) × 100
```

### RN-51 — Ebook

Para `EBOOK`:

```text
porcentaje = progreso
```

El progreso ya representa directamente un porcentaje.

### RN-52 — Audiolibro

Para `AUDIOLIBRO`:

```text
porcentaje =
(tiempo_actual / duracion_total_minutos) × 100
```

La duración total se obtiene desde `EDICION.duracion_total_minutos`.

---

# 11. Finalización de una lectura

### RN-53 — Lectura terminada

Una lectura podrá pasar al estado `TERMINADO` cuando el usuario indique que ha finalizado la obra.

Como validación adicional, el sistema podrá verificar que el progreso registrado corresponda al final de la edición.

### RN-54 — Progreso al finalizar

Cuando una lectura se marque como `TERMINADO`, el progreso final deberá corresponder al 100 %.

El sistema podrá establecer automáticamente el progreso final según el formato:

```text
FISICO/PDF
→ numero_paginas

EBOOK
→ 100 %

AUDIOLIBRO
→ duracion_total_minutos
```

---

# 12. Integridad de datos

### RN-55 — Referencias obligatorias

No pueden existir:

* Ediciones sin obra.
* Lecturas sin usuario.
* Lecturas sin edición.
* Sesiones sin lectura.
* Entradas de bitácora sin lectura.
* Valoraciones sin lectura.

### RN-56 — Referencias opcionales

Pueden existir:

* Obras sin saga.
* Entradas de bitácora sin sesión.
* Lecturas sin fecha de finalización.
* Ediciones sin ISBN.
* Ediciones sin número de páginas cuando el formato no lo requiera.
* Lecturas sin valoración.

### RN-57 — Propiedad de los datos

Un usuario solo podrá consultar y modificar sus propias:

* Obras.
* Ediciones.
* Autores.
* Sagas.
* Lecturas.
* Sesiones.
* Entradas de bitácora.
* Valoraciones.
* Registros de biblioteca.

Los géneros son una excepción, ya que corresponden a un catálogo predefinido y compartido.

Los datos personales y registros privados de un usuario no deben ser accesibles ni modificables por otros usuarios.

---

# 13. Gestión del catálogo bibliográfico

### RN-58 — Registro de información bibliográfica

La información bibliográfica será registrada directamente por los usuarios al incorporar una edición a su biblioteca personal.

Los elementos bibliográficos administrados por los usuarios son:

* Obras.
* Ediciones.
* Autores.
* Sagas.

Estos registros estarán asociados al usuario que los creó y podrán ser utilizados posteriormente dentro de su biblioteca.

### RN-59 — Independencia de los registros bibliográficos

Los registros bibliográficos de un usuario serán independientes de los registros creados por otros usuarios.

El sistema no establecerá inicialmente un catálogo bibliográfico global para obras, autores, ediciones o sagas.

Por lo tanto, dos usuarios pueden registrar independientemente una misma obra, edición, autor o saga.

Ejemplo:

```text
Usuario A
└── OBRA: El Señor de los Anillos
    └── EDICIÓN: Minotauro 2001

Usuario B
└── OBRA: El Señor de los Anillos
    └── EDICIÓN: Minotauro 2001
```

Aunque ambos registros representen conceptualmente la misma obra y edición, serán entidades independientes dentro del sistema.

### RN-60 — Duplicidad de registros

El sistema permitirá la existencia de registros bibliográficos duplicados entre diferentes usuarios.

No será responsabilidad del sistema detectar, fusionar ni normalizar automáticamente estos registros.

Esta decisión busca simplificar la gestión del catálogo y mantener la autonomía de cada usuario sobre su propia biblioteca.

### RN-61 — Géneros predefinidos

Los géneros constituirán la única información bibliográfica predefinida y compartida entre todos los usuarios.

Los géneros serán administrados por el sistema y estarán disponibles para ser asociados a las obras registradas por los usuarios.

Los usuarios no podrán crear, modificar ni eliminar géneros.

### RN-62 — Asociación de géneros

Una obra podrá asociarse a uno o múltiples géneros existentes.

La relación entre obras y géneros se gestionará mediante `OBRA_GENERO`.

Un mismo género podrá estar asociado a obras pertenecientes a diferentes usuarios.

---

# 14. Gestión de lecturas simultáneas y reanudación

### RN-63 — Lecturas simultáneas

Un usuario podrá mantener múltiples lecturas en estado `LEYENDO`.

No existirá una restricción que impida tener simultáneamente varias lecturas activas.

Esto incluye la posibilidad de mantener más de una lectura activa sobre una misma edición.

### RN-64 — Lecturas simultáneas de diferentes ediciones

Un usuario podrá leer simultáneamente diferentes ediciones de una misma obra.

Por ejemplo:

```text
El Señor de los Anillos

├── Edición física
│   └── Lectura → LEYENDO
│
└── Edición ebook
    └── Lectura → LEYENDO
```

Cada lectura mantendrá su propio historial y progreso.

### RN-65 — Abandono y reanudación

Una lectura en estado `ABANDONADO` podrá volver posteriormente al estado `LEYENDO`.

La reanudación de una lectura abandonada no generará una nueva relectura.

Se creará una nueva instancia de `LECTURA` únicamente cuando el usuario inicie explícitamente una nueva experiencia de lectura de la edición.

---

# 15. Gestión de sesiones

### RN-66 — Eliminación de sesiones

Las sesiones podrán eliminarse.

Cuando se elimine una sesión, el progreso inicial implícito de las sesiones posteriores se determinará utilizando la sesión anterior que permanezca registrada.

Si se elimina la última sesión, el progreso actual de la lectura corresponderá al progreso registrado en la nueva última sesión.

Si no quedan sesiones registradas, el progreso actual de la lectura volverá a considerarse igual al punto inicial definido para el formato.

### RN-67 — Modificación de sesiones

Las sesiones podrán modificarse después de haber sido registradas.

Cuando se modifique el progreso de una sesión, el sistema deberá validar nuevamente la secuencia de progreso con respecto a las sesiones inmediatamente anterior y posterior.

No se permitirá que la modificación genere una secuencia de progreso inconsistente.

---

# 16. Reglas derivadas

Algunos datos del sistema deben calcularse y no almacenarse directamente.

| Dato                   | Se obtiene a partir de                        |
| ---------------------- | --------------------------------------------- |
| Porcentaje de progreso | Última sesión + características de la edición |
| Progreso inicial       | Sesión anterior                               |
| Cantidad de sesiones   | Registros de `SESION_LECTURA`                 |
| Cantidad de relecturas | Registros de `LECTURA`                        |
| Cantidad de entradas   | Registros de `ENTRADA_BITACORA`               |
| Historial de lectura   | `LECTURA` + `SESION_LECTURA`                  |
| Estado de lectura      | Estado almacenado en `LECTURA`                |

Esto ayuda a evitar almacenar información duplicada que pueda quedar inconsistente.
