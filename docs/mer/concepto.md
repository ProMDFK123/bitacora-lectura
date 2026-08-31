# Modelo Conceptual
## 1. Entidades principales

El sistema se estructura alrededor de los siguientes conceptos fundamentales:

```text
USUARIO
   │
   │ posee
   ▼
BIBLIOTECA
   │
   │ contiene
   ▼
EDICIÓN
   │
   │ pertenece a
   ▼
OBRA
```

La relación entre una edición y la experiencia de lectura se representa mediante LECTURA:

```text
USUARIO
   │
   │ realiza
   ▼
LECTURA
   │
   │ utiliza
   ▼
EDICIÓN
```

Una lectura puede contener diferentes elementos asociados:

```text
LECTURA
 ├── SESIONES DE LECTURA
 ├── ENTRADAS DE BITÁCORA
 └── VALORACIÓN
```

Además, una edición posee un formato que determina cómo se registra su progreso:

```text
EDICIÓN
   │
   └── FORMATO
         │
         ├── FÍSICO      → páginas
         ├── PDF         → páginas
         ├── EBOOK       → porcentaje
         └── AUDIOLIBRO  → tiempo
```

## 2. Usuario

Representa a una persona que utiliza el sistema.

Un usuario puede:

- Tener múltiples ediciones en su biblioteca.
- Realizar múltiples lecturas.
- Registrar sesiones de lectura.
- Crear entradas de bitácora.
- Registrar valoraciones.
- Consultar sus estadísticas.
- Gestionar sus metas y rutinas.

Cada usuario solamente puede acceder y modificar sus propios registros personales de lectura.

## 3. Obra

Representa una obra intelectual, independientemente de la edición concreta.

Ejemplo:
```text
El Señor de los Anillos
```
Una obra puede tener:

- Múltiples autores.
- Múltiples géneros.
- Una saga opcional.
- Múltiples ediciones.

Las características que pueden variar entre ediciones, como editorial, ISBN o número de páginas, no pertenecen a la obra.

## 4. Edición

Representa una edición concreta de una obra.

Ejemplo:
```text
El Señor de los Anillos
└── Edición Minotauro 2001
```
Sus características pertenecen a la edición:

- ISBN.
- Editorial.
- Año de publicación.
- Número de páginas, cuando corresponda.
- Portada.
- Formato.

Una misma obra puede tener múltiples ediciones y un usuario puede registrar más de una de ellas en su biblioteca.

## 5. Formato

El formato determina la forma en que se representa el progreso de una edición.

Los formatos contemplados inicialmente son:

| Formato | Unidad de progreso |
|---------|--------------------|
| Físico	| Páginas |
| PDF	| Páginas |
| Ebook	| Porcentaje |
|Audiolibro	| Tiempo|

El formato pertenece conceptualmente a la edición, ya que una misma obra puede existir en diferentes formatos.

Por ejemplo:
```text
El Hobbit
│
├── Edición física
│     └── progreso → páginas
│
├── Edición PDF
│     └── progreso → páginas
│
└── Edición Ebook
      └── progreso → porcentaje
```
## 6. Biblioteca

Representa las ediciones que un usuario ha registrado dentro de su biblioteca personal.

La existencia de una edición en la biblioteca no implica que haya sido leída.

Por ejemplo:
```text
Usuario
└── Biblioteca
    ├── El Hobbit
    │    └── Lectura #1
    │
    ├── Dune
    │    └── Sin lecturas
    │
    └── Fuego y Sangre
         ├── Lectura #1
         └── Lectura #2
```
Esto permite diferenciar entre:

- Una edición que el usuario posee o tiene registrada.
- Una edición que el usuario está leyendo.
- Una edición que ya ha leído.
- Una edición que todavía no ha comenzado.
## 7. Lectura

Representa una experiencia concreta de un usuario leyendo una determinada edición.

Conceptualmente:
```text
Usuario + Edición = Lectura
```
Una misma edición puede ser leída múltiples veces por un mismo usuario.

Cada nueva lectura se registra como una instancia independiente, permitiendo conservar el historial de relecturas.

Ejemplo:
```text
El Hobbit — Edición Minotauro
├── Lectura #1
│   ├── Sesiones
│   ├── Bitácora
│   └── Valoración
│
└── Lectura #2
    ├── Sesiones
    ├── Bitácora
    └── Valoración
```
Las lecturas anteriores no son sobrescritas al registrar una relectura.

## 8. Sesión de lectura

Representa una instancia individual de lectura dentro de una lectura.
```text
Lectura
 ├── Sesión 1
 ├── Sesión 2
 ├── Sesión 3
 └── ...
```
Cada sesión registra el progreso alcanzado durante esa sesión.

El valor registrado depende del formato de la edición:
```text
Físico
→ página alcanzada

PDF
→ página alcanzada

Ebook
→ porcentaje alcanzado

Audiolibro
→ tiempo alcanzado
```
El sistema puede obtener el progreso inicial de una sesión a partir del progreso alcanzado en la sesión anterior.

Por ejemplo:
```text
Sesión 1
progreso → página 35

Sesión 2
inicio → página 35
progreso → página 78

Sesión 3
inicio → página 78
progreso → página 120
```
El progreso inicial no necesita almacenarse como un dato independiente si puede obtenerse a partir de la sesión anterior.

En el caso de los ebooks, el progreso se registra directamente como porcentaje debido a que su paginación puede variar según el dispositivo y configuración de lectura.

## 9. Progreso

El progreso no se almacena como un porcentaje general de la lectura.

Cada sesión registra el valor de progreso alcanzado, cuya unidad depende del formato de la edición.
```text
EDICIÓN
   │
   └── FORMATO
         │
         ▼
SESION_LECTURA.progreso
```
Por ejemplo:
```text
Libro físico
numero_paginas = 500
progreso = 250

→ 50 %
PDF
numero_paginas = 800
progreso = 400

→ 50 %
Ebook
progreso = 50

→ 50 %

Audiolibro
duracion_total = 10 horas
progreso = 5 horas

→ 50 %
```
El porcentaje general puede calcularse cuando sea necesario y no necesita almacenarse directamente.

## 10. Bitácora

Representa las reflexiones, notas y experiencias personales del usuario durante una lectura.

Una entrada pertenece a una lectura y puede asociarse opcionalmente a una sesión específica.
```text
Lectura
 │
 ├── Sesión 1
 │
 │    └── Entrada de bitácora
 │
 ├── Sesión 2
 │
 └── Entrada de bitácora
      └── Sin sesión específica
```
Esto permite registrar tanto pensamientos realizados durante una sesión concreta como reflexiones generales sobre la lectura.

Las entradas pueden indicar si contienen spoilers.

## 11. Valoración

Representa la opinión del usuario sobre una lectura específica.

La valoración pertenece a LECTURA y no directamente a OBRA o EDICIÓN.

Esto permite que una misma edición tenga diferentes valoraciones en diferentes lecturas.

Por ejemplo:
```text
El Hobbit — Lectura #1
→ ★★★★☆

El Hobbit — Lectura #2
→ ★★★★★
```
De esta forma, una relectura puede tener una valoración diferente sin modificar la valoración de la lectura anterior.

## 12. Relaciones
```text
USUARIO
 │
 ├────< BIBLIOTECA >──── EDICIÓN
 │
 └────< LECTURA >──────── EDICIÓN
              │
              ├────< SESION_LECTURA
              │
              ├────< ENTRADA_BITACORA
              │
              └──── VALORACION

OBRA
 │
 ├────< EDICION
 │
 ├────< OBRA_AUTOR >──── AUTOR
 │
 ├────< OBRA_GENERO >─── GENERO
 │
 └────── SAGA

EDICION
 │
 └────── FORMATO
```
Resumen de las relaciones
```text
USUARIO 1 ─── N BIBLIOTECA
EDICION 1 ─── N BIBLIOTECA

USUARIO 1 ─── N LECTURA
EDICION 1 ─── N LECTURA

OBRA 1 ─── N EDICION

LECTURA 1 ─── N SESION_LECTURA
LECTURA 1 ─── N ENTRADA_BITACORA
LECTURA 1 ─── 0..1 VALORACION

OBRA N ─── N AUTOR
OBRA N ─── N GENERO

SAGA 1 ─── N OBRA

EDICION 1 ─── 1 FORMATO
```
> **Nota**: La representación de `FORMATO` como atributo `ENUM` o como entidad independiente (`FORMATO`) todavía puede definirse en el modelo relacional. Conceptualmente, ambos representan el mismo concepto: el formato determina la unidad utilizada para registrar el progreso.