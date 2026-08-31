# Modelo Entidad-Relación

## 1. Diagrama

```text
┌──────────────┐
│    USUARIO   │
└──────┬───────┘
       │
       ├───────────────────────┐
       │                       │
       │ 1:N                   │ 1:N
       ▼                       ▼
┌──────────────┐        ┌──────────────┐
│  BIBLIOTECA  │        │    LECTURA   │
└──────┬───────┘        └──────┬───────┘
       │                       │
       │ N:1                   │
       │                       ├───────────────┐
       ▼                       │               │
┌──────────────┐               │ 1:N           │ 1:N
│    EDICION   │◄──────────────┘               │
└──────┬───────┘                               │
       │                                       ▼
       │ N:1                            ┌──────────────┐
       ▼                                │    SESION    │
┌──────────────┐                        └──────────────┘
│     OBRA     │
└──────┬───────┘
       │
       ├───────────────┐
       │               │
       │ N:M           │ N:M
       ▼               ▼
┌──────────────┐ ┌──────────────┐
│    AUTOR     │ │    GENERO    │
└──────────────┘ └──────────────┘
       │
       │
       │
       └────────────── SAGA


LECTURA
   │
   ├──────────────< BITACORA
   │
   └────────────── VALORACION


EDICION
   │
   └────────────── FORMATO
```

> **Nota:** `OBRA_AUTOR` y `OBRA_GENERO` son tablas intermedias necesarias para resolver las relaciones N:M. `FORMATO` puede implementarse como un atributo `ENUM` de `EDICION` o como una entidad independiente, decisión que se concretará en el modelo lógico/relacional.

---

## 2. Relaciones principales

### Usuario → Biblioteca

Un usuario puede registrar múltiples ediciones en su biblioteca.

Una entrada de biblioteca pertenece a un único usuario.

**Cardinalidad:** `1:N`

Una edición puede encontrarse en las bibliotecas de múltiples usuarios.

---

### Usuario → Lectura

Un usuario puede tener múltiples lecturas.

Una lectura pertenece a un único usuario.

**Cardinalidad:** `1:N`

---

### Biblioteca → Edición

Una entrada de biblioteca corresponde a una única edición.

Una edición puede estar registrada en las bibliotecas de múltiples usuarios.

**Cardinalidad:** `N:1` desde `BIBLIOTECA` hacia `EDICION`.

La relación entre `USUARIO` y `EDICION` es, conceptualmente, **N:M**, resuelta mediante `BIBLIOTECA`.

---

### Obra → Edición

Una obra puede tener múltiples ediciones.

Una edición pertenece a una única obra.

**Cardinalidad:** `1:N`

Por ejemplo:

```text
El Hobbit
├── Edición Minotauro
├── Edición Austral
└── Edición HarperCollins
```

---

### Edición → Lectura

Una edición puede ser utilizada en múltiples lecturas.

Una lectura corresponde a una única edición.

**Cardinalidad:** `1:N`

Esto permite que diferentes usuarios lean la misma edición y que un mismo usuario registre múltiples relecturas de ella.

---

### Lectura → Sesión

Una lectura puede tener múltiples sesiones.

Una sesión pertenece a una única lectura.

**Cardinalidad:** `1:N`

```text
LECTURA
├── SESION 1
├── SESION 2
├── SESION 3
└── ...
```

Cada sesión almacena el progreso alcanzado durante dicha sesión.

La unidad del progreso depende del formato de la edición:

| Formato      | Progreso   |
| ------------ | ---------- |
| `FISICO`     | Página     |
| `PDF`        | Página     |
| `EBOOK`      | Porcentaje |
| `AUDIOLIBRO` | Tiempo     |

El progreso inicial de una sesión puede obtenerse a partir del progreso registrado en la sesión anterior, por lo que no es necesario almacenarlo como un atributo independiente.

---

### Lectura → Bitácora

Una lectura puede tener múltiples entradas de bitácora.

Una entrada pertenece a una única lectura.

**Cardinalidad:** `1:N`

Una entrada de bitácora puede asociarse opcionalmente a una sesión específica.

Por lo tanto:

```text
LECTURA
├── SESION 1
│   └── BITACORA
├── SESION 2
│
└── BITACORA
    └── Sin sesión específica
```

---

### Lectura → Valoración

Una lectura puede tener como máximo una valoración.

Una valoración pertenece a una única lectura.

**Cardinalidad:** `1:0..1`

Esto permite que una lectura no tenga valoración o que tenga una única valoración.

Las diferentes relecturas pueden tener valoraciones independientes.

---

### Obra → Autor

Una obra puede tener múltiples autores y un autor puede participar en múltiples obras.

**Cardinalidad:** `N:M`

Se resuelve mediante:

`OBRA_AUTOR`

---

### Obra → Género

Una obra puede tener múltiples géneros y un género puede estar asociado a múltiples obras.

**Cardinalidad:** `N:M`

Se resuelve mediante:

`OBRA_GENERO`

---

### Saga → Obra

Una saga puede contener múltiples obras.

Una obra puede pertenecer opcionalmente a una única saga.

**Cardinalidad:** `1:N`

La participación de `OBRA` en esta relación es opcional.

Por ejemplo:

```text
SAGA
└── Canción de Hielo y Fuego
    ├── Juego de Tronos
    ├── Choque de Reyes
    └── Tormenta de Espadas
```

Mientras que una obra independiente puede no pertenecer a ninguna saga.

---

### Edición → Formato

Una edición posee un formato que determina cómo se registra su progreso.

**Cardinalidad conceptual:** `1:1`

Los formatos contemplados inicialmente son:

* `FISICO`
* `PDF`
* `EBOOK`
* `AUDIOLIBRO`

El formato determina la unidad utilizada por `SESION_LECTURA.progreso`.

```text
EDICION
   │
   └── FORMATO
         │
         ├── FISICO → páginas
         ├── PDF → páginas
         ├── EBOOK → porcentaje
         └── AUDIOLIBRO → tiempo
```
