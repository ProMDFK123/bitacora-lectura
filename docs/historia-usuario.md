# Historias de Usuario

## 1. Introducción

Las historias de usuario describen las funcionalidades del sistema desde la perspectiva del usuario final.

Se utilizarán como base para:

* Construir el Product Backlog.
* Priorizar funcionalidades.
* Planificar los Sprints.
* Definir criterios de aceptación.
* Dividir las funcionalidades en tareas de desarrollo.

El formato utilizado será:

> **Como** [tipo de usuario], **quiero** [funcionalidad], **para** [beneficio].

---

# 2. Épicas

Las historias se agrupan en las siguientes épicas:

```text
EP-01  Gestión de cuenta
EP-02  Gestión de obras y ediciones
EP-03  Gestión de biblioteca
EP-04  Gestión de lecturas
EP-05  Gestión de sesiones
EP-06  Gestión de bitácora
EP-07  Gestión de valoraciones
EP-08  Estadísticas
```

---

# 3. EP-01 — Gestión de cuenta

## HU-01 — Registrar usuario

**Como** visitante,

**quiero** crear una cuenta en la plataforma,

**para** poder gestionar mi biblioteca y registrar mis lecturas.

### Criterios de aceptación

* El usuario debe proporcionar nombre, correo y contraseña.
* El correo debe ser único.
* La contraseña debe almacenarse mediante hash.
* El sistema debe informar si el correo ya está registrado.
* El usuario debe quedar activo después del registro exitoso.

**Prioridad:** Alta

---

## HU-02 — Iniciar sesión

**Como** usuario registrado,

**quiero** iniciar sesión,

**para** acceder a mi información personal.

### Criterios de aceptación

* El usuario debe proporcionar correo y contraseña.
* El sistema debe validar las credenciales.
* Un usuario inactivo no debe poder iniciar sesión.
* Una autenticación correcta debe permitir acceder a las funcionalidades privadas.

**Prioridad:** Alta

---

# 4. EP-02 — Gestión de obras y ediciones

## HU-03 — Registrar obra

**Como** usuario,

**quiero** registrar una obra,

**para** poder asociarle una o más ediciones.

### Criterios de aceptación

* Debe registrarse el título.
* Puede registrarse una descripción.
* Puede indicarse el tipo de obra.
* Puede registrarse la fecha de publicación original.
* Puede asociarse una saga.
* Puede asociarse uno o más autores.
* Puede asociarse uno o más géneros.

**Prioridad:** Alta

---

## HU-04 — Registrar edición

**Como** usuario,

**quiero** registrar una edición concreta de una obra,

**para** diferenciar las características de las distintas ediciones que puedo utilizar.

### Criterios de aceptación

* La edición debe pertenecer a una obra.
* Debe poder registrarse el ISBN cuando exista.
* Debe poder registrarse la editorial.
* Debe poder registrarse el año de publicación.
* Debe poder registrarse la portada.
* Debe seleccionarse un formato.
* El número de páginas debe validarse según el formato.
* La duración total debe validarse para audiolibros.

**Prioridad:** Alta

---

# 5. EP-03 — Gestión de biblioteca

## HU-05 — Agregar edición a biblioteca

**Como** usuario,

**quiero** agregar una edición a mi biblioteca,

**para** registrar los libros que poseo o quiero mantener registrados.

### Criterios de aceptación

* La edición debe existir.
* El usuario debe estar autenticado.
* Una edición no puede estar duplicada dentro de la biblioteca del mismo usuario.
* Debe registrarse la fecha en que fue agregada.

**Prioridad:** Alta

---

## HU-06 — Consultar biblioteca

**Como** usuario,

**quiero** consultar mi biblioteca,

**para** conocer las ediciones que tengo registradas.

### Criterios de aceptación

* Solo deben mostrarse las ediciones del usuario autenticado.
* Debe mostrarse información relevante de cada edición.
* Debe poder accederse al detalle de una edición.

**Prioridad:** Alta

---

## HU-07 — Eliminar edición de biblioteca

**Como** usuario,

**quiero** eliminar una edición de mi biblioteca,

**para** dejar de tenerla registrada cuando ya no sea relevante.

### Criterios de aceptación

* Solo debe poder eliminarse una edición perteneciente al usuario.
* El sistema debe solicitar confirmación.
* La eliminación no debería borrar la edición global ni sus obras asociadas.

**Prioridad:** Media

---

# 6. EP-04 — Gestión de lecturas

## HU-08 — Iniciar lectura

**Como** usuario,

**quiero** iniciar una lectura de una edición de mi biblioteca,

**para** registrar mi experiencia de lectura.

### Criterios de aceptación

* La edición debe pertenecer a la biblioteca del usuario.
* Se debe crear una nueva `LECTURA`.
* La lectura debe comenzar en estado `LEYENDO`.
* Debe registrarse la fecha de inicio.
* El sistema debe determinar automáticamente el número de lectura correspondiente.

**Prioridad:** Alta

---

## HU-09 — Registrar relectura

**Como** usuario,

**quiero** iniciar nuevamente una edición que ya he leído,

**para** mantener un historial independiente de cada lectura.

### Criterios de aceptación

* Debe existir al menos una lectura anterior de la edición.
* Se debe crear una nueva `LECTURA`.
* La nueva lectura debe tener un número de relectura consecutivo.
* Las sesiones de la nueva lectura deben ser independientes de las anteriores.
* Las entradas de bitácora deben ser independientes de las anteriores.
* La valoración debe ser independiente de las anteriores.

**Prioridad:** Alta

---

## HU-10 — Finalizar lectura

**Como** usuario,

**quiero** marcar una lectura como terminada,

**para** registrar que he completado la edición.

### Criterios de aceptación

* La lectura debe estar activa.
* El sistema debe validar el progreso.
* El estado debe cambiar a `TERMINADO`.
* Debe registrarse la fecha de finalización.

**Prioridad:** Alta

---

## HU-11 — Abandonar lectura

**Como** usuario,

**quiero** marcar una lectura como abandonada,

**para** conservar el registro de una lectura que no terminé.

### Criterios de aceptación

* La lectura debe estar activa.
* El sistema debe solicitar confirmación.
* El estado debe cambiar a `ABANDONADO`.
* Las sesiones realizadas deben conservarse.

**Prioridad:** Media

---

# 7. EP-05 — Gestión de sesiones

## HU-12 — Registrar sesión de lectura

**Como** usuario,

**quiero** registrar una sesión de lectura,

**para** mantener actualizado mi progreso.

### Criterios de aceptación

* Debe existir una lectura activa.
* Debe registrarse la fecha y hora.
* Debe registrarse el progreso alcanzado.
* La duración debe ser opcional.
* El sistema debe validar el progreso según el formato.
* El progreso debe ser consistente con la sesión anterior.

**Prioridad:** Alta

---

## HU-13 — Consultar progreso

**Como** usuario,

**quiero** consultar el progreso de mi lectura,

**para** conocer cuánto he avanzado.

### Criterios de aceptación

* El progreso debe obtenerse a partir de la última sesión.
* Para libros físicos y PDF debe calcularse mediante páginas.
* Para ebooks debe utilizarse el porcentaje registrado.
* Para audiolibros debe utilizarse el tiempo registrado.
* El sistema debe mostrar el progreso como porcentaje.

**Prioridad:** Alta

---

# 8. EP-06 — Gestión de bitácora

## HU-14 — Crear entrada de bitácora

**Como** usuario,

**quiero** crear una entrada en mi bitácora,

**para** registrar mis pensamientos y reflexiones sobre una lectura.

### Criterios de aceptación

* La entrada debe pertenecer a una lectura.
* Debe tener título.
* Debe tener contenido.
* Debe indicar si contiene spoilers.
* Puede asociarse a una sesión concreta.
* Debe registrarse la fecha de creación.

**Prioridad:** Alta

---

## HU-15 — Editar entrada de bitácora

**Como** usuario,

**quiero** editar una entrada de mi bitácora,

**para** corregir o actualizar su contenido.

### Criterios de aceptación

* Solo el propietario puede modificar la entrada.
* Debe poder modificarse el título.
* Debe poder modificarse el contenido.
* Debe poder modificarse la indicación de spoilers.
* Puede modificarse la sesión asociada.

**Prioridad:** Media

---

## HU-16 — Eliminar entrada de bitácora

**Como** usuario,

**quiero** eliminar una entrada,

**para** retirar contenido que ya no deseo conservar.

### Criterios de aceptación

* Solo el propietario puede eliminarla.
* El sistema debe solicitar confirmación.
* La entrada debe eliminarse sin afectar la lectura asociada.

**Prioridad:** Media

---

# 9. EP-07 — Gestión de valoraciones

## HU-17 — Valorar lectura

**Como** usuario,

**quiero** valorar una lectura,

**para** registrar mi opinión sobre ella.

### Criterios de aceptación

* La valoración debe pertenecer a una lectura.
* Debe existir una puntuación.
* La reseña debe ser opcional.
* Una lectura no puede tener más de una valoración.
* La valoración debe poder ser diferente en cada relectura.

**Prioridad:** Media

---

## HU-18 — Editar valoración

**Como** usuario,

**quiero** modificar mi valoración,

**para** actualizar mi opinión sobre una lectura.

### Criterios de aceptación

* Debe existir una valoración.
* Solo el propietario puede modificarla.
* Debe poder modificarse la puntuación.
* Debe poder modificarse la reseña.

**Prioridad:** Baja

---

## HU-19 — Eliminar valoración

**Como** usuario,

**quiero** eliminar mi valoración,

**para** retirar mi opinión de una lectura.

### Criterios de aceptación

* Debe existir una valoración.
* Solo el propietario puede eliminarla.
* El sistema debe solicitar confirmación.

**Prioridad:** Baja

---

# 10. EP-08 — Estadísticas

## HU-20 — Consultar estadísticas de lectura

**Como** usuario,

**quiero** consultar estadísticas sobre mis lecturas,

**para** conocer y analizar mis hábitos de lectura.

### Criterios de aceptación

El sistema debería poder mostrar, como mínimo:

* Libros terminados.
* Libros abandonados.
* Libros actualmente en lectura.
* Cantidad de lecturas.
* Cantidad de relecturas.
* Páginas leídas.
* Tiempo dedicado a la lectura.
* Actividad de lectura por período.

**Prioridad:** Media

---

# 11. Product Backlog inicial

| ID    | Historia                       | Épica             | Prioridad |
| ----- | ------------------------------ | ----------------- | --------- |
| HU-01 | Registrar usuario              | Gestión de cuenta | Alta      |
| HU-02 | Iniciar sesión                 | Gestión de cuenta | Alta      |
| HU-03 | Registrar obra                 | Obras y ediciones | Alta      |
| HU-04 | Registrar edición              | Obras y ediciones | Alta      |
| HU-05 | Agregar edición a biblioteca   | Biblioteca        | Alta      |
| HU-06 | Consultar biblioteca           | Biblioteca        | Alta      |
| HU-07 | Eliminar edición de biblioteca | Biblioteca        | Media     |
| HU-08 | Iniciar lectura                | Lecturas          | Alta      |
| HU-09 | Registrar relectura            | Lecturas          | Alta      |
| HU-10 | Finalizar lectura              | Lecturas          | Alta      |
| HU-11 | Abandonar lectura              | Lecturas          | Media     |
| HU-12 | Registrar sesión               | Sesiones          | Alta      |
| HU-13 | Consultar progreso             | Sesiones          | Alta      |
| HU-14 | Crear entrada de bitácora      | Bitácora          | Alta      |
| HU-15 | Editar entrada                 | Bitácora          | Media     |
| HU-16 | Eliminar entrada               | Bitácora          | Media     |
| HU-17 | Valorar lectura                | Valoraciones      | Media     |
| HU-18 | Editar valoración              | Valoraciones      | Baja      |
| HU-19 | Eliminar valoración            | Valoraciones      | Baja      |
| HU-20 | Consultar estadísticas         | Estadísticas      | Media     |

---

# 12. MVP

Para la primera versión funcional del sistema se propone incluir:

```text id="mvp001"
AUTENTICACIÓN
├── HU-01 Registrar usuario
└── HU-02 Iniciar sesión

OBRAS Y EDICIONES
├── HU-03 Registrar obra
└── HU-04 Registrar edición

BIBLIOTECA
├── HU-05 Agregar edición
└── HU-06 Consultar biblioteca

LECTURAS
├── HU-08 Iniciar lectura
├── HU-09 Registrar relectura
├── HU-10 Finalizar lectura
└── HU-11 Abandonar lectura

SESIONES
├── HU-12 Registrar sesión
└── HU-13 Consultar progreso

BITÁCORA
└── HU-14 Crear entrada

VALORACIONES
└── HU-17 Valorar lectura
```

Las funcionalidades de edición y eliminación pueden incorporarse posteriormente.

---

# 13. Funcionalidades futuras

Las siguientes funcionalidades quedan fuera del MVP y podrán evaluarse posteriormente:

* Metas de lectura.
* Desafíos de lectura.
* Estadísticas avanzadas.
* Gráficos de actividad.
* Filtros avanzados de biblioteca.
* Importación de libros.
* Integración con APIs externas de libros.
* Recomendaciones.
* Compartir lecturas.
* Perfiles públicos.
* Seguimiento de otros usuarios.
* Exportación de la bitácora.
