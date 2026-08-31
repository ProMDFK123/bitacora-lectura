# Casos de Uso

## 1. Actores

### Usuario

Actor principal del sistema.

Puede:

* Gestionar su cuenta.
* Gestionar su biblioteca.
* Gestionar obras y ediciones.
* Registrar lecturas.
* Registrar relecturas.
* Registrar sesiones de lectura.
* Gestionar entradas de bitácora.
* Gestionar valoraciones.
* Consultar estadísticas.

### Sistema

Responsable de:

* Autenticar usuarios.
* Validar reglas de negocio.
* Calcular el progreso de las lecturas.
* Generar estadísticas.
* Mantener la integridad de los datos.

---

# 2. Casos de uso principales

```text
                         ┌─────────────┐
                         │   Usuario   │
                         └──────┬──────┘
                                │
        ┌───────────────────────┼────────────────────────┐
        │                       │                        │
        ▼                       ▼                        ▼
 Gestionar cuenta       Gestionar biblioteca      Gestionar lecturas
                                │                        │
                                │                        ├── Registrar lectura
                                │                        ├── Registrar relectura
                                │                        ├── Registrar sesión
                                │                        ├── Finalizar lectura
                                │                        └── Abandonar lectura
                                │
                    ┌───────────┼───────────┐
                    │           │           │
                    ▼           ▼           ▼
                  Obras      Ediciones    Consultar biblioteca


        ┌───────────────────────┼────────────────────────┐
        │                       │                        │
        ▼                       ▼                        ▼
 Gestionar bitácora       Gestionar valoración    Consultar estadísticas
        │                       │                        │
        ├── Crear entrada       ├── Valorar lectura     ├── Progreso
        ├── Editar entrada     ├── Editar valoración   ├── Historial
        └── Eliminar entrada   └── Eliminar valoración └── Estadísticas
```

---

# 3. CU-01 — Registrar usuario

**Actor:** Usuario

### Precondiciones

Ninguna.

### Flujo principal

1. El usuario accede al formulario de registro.
2. Introduce sus datos.
3. El sistema valida la información.
4. El sistema verifica que el correo no esté registrado.
5. El sistema genera un hash de la contraseña.
6. Se crea el usuario.
7. El sistema confirma el registro.

### Resultado

El usuario queda registrado y puede autenticarse en el sistema.

### Excepciones

* El correo electrónico ya se encuentra registrado.
* Los datos proporcionados no son válidos.
* La contraseña no cumple los requisitos establecidos.

---

# 4. CU-02 — Iniciar sesión

**Actor:** Usuario

### Precondiciones

El usuario debe estar registrado y activo.

### Flujo principal

1. El usuario introduce su correo y contraseña.
2. El sistema busca la cuenta correspondiente.
3. El sistema verifica la contraseña.
4. El sistema valida que la cuenta esté activa.
5. El sistema autentica al usuario.

### Resultado

El usuario accede al sistema.

### Excepciones

* El correo no existe.
* La contraseña es incorrecta.
* La cuenta se encuentra inactiva.

---

# 5. CU-03 — Registrar obra

**Actor:** Usuario

### Precondiciones

El usuario debe estar autenticado.

### Flujo principal

1. El usuario accede a la gestión de obras.
2. Introduce la información de la obra.
3. Opcionalmente asigna autores.
4. Opcionalmente asigna géneros.
5. Opcionalmente asocia la obra a una saga.
6. El sistema valida la información.
7. Se registra la obra.

### Resultado

La obra queda registrada y puede utilizarse para crear una o más ediciones.

---

# 6. CU-04 — Registrar edición

**Actor:** Usuario

### Precondiciones

* El usuario debe estar autenticado.
* Debe existir una obra asociada.

### Flujo principal

1. El usuario selecciona una obra existente o crea una nueva.
2. Introduce los datos de la edición.
3. Selecciona el formato.
4. Introduce las características correspondientes al formato.
5. El sistema valida la información.
6. Se registra la edición.

### Resultado

La edición queda disponible para ser agregada a una biblioteca.

### Reglas específicas

* Los formatos `FISICO` y `PDF` requieren número de páginas.
* El formato `EBOOK` utiliza progreso porcentual.
* El formato `AUDIOLIBRO` requiere una duración total.
* El ISBN es opcional.

---

# 7. CU-05 — Agregar edición a biblioteca

**Actor:** Usuario

### Precondiciones

* El usuario debe estar autenticado.
* La edición debe existir.
* La edición no debe estar ya registrada en su biblioteca.

### Flujo principal

1. El usuario selecciona una edición.
2. Selecciona la opción de agregar a biblioteca.
3. El sistema verifica que no exista el registro.
4. Se crea la asociación entre usuario y edición.
5. Se registra la fecha de incorporación.

### Resultado

La edición queda registrada en la biblioteca personal del usuario.

### Excepciones

* La edición ya pertenece a la biblioteca del usuario.

---

# 8. CU-06 — Consultar biblioteca

**Actor:** Usuario

### Precondiciones

El usuario debe estar autenticado.

### Flujo principal

1. El usuario accede a su biblioteca.
2. El sistema obtiene las ediciones registradas.
3. El sistema muestra la información disponible.
4. El usuario puede consultar el detalle de una edición.

### Resultado

El usuario puede consultar las ediciones que tiene registradas en su biblioteca.

---

# 9. CU-07 — Registrar lectura

**Actor:** Usuario

### Precondiciones

* El usuario debe estar autenticado.
* La edición debe estar registrada en su biblioteca.

### Flujo principal

1. El usuario selecciona una edición.
2. Selecciona iniciar una nueva lectura.
3. El sistema verifica las lecturas anteriores de esa edición.
4. El sistema determina el número de lectura correspondiente.
5. Se crea una nueva instancia de `LECTURA`.
6. La lectura comienza con estado `LEYENDO`.
7. Se registra la fecha de inicio.

### Resultado

Se crea una nueva experiencia de lectura asociada al usuario y a la edición.

---

# 10. CU-08 — Registrar relectura

**Actor:** Usuario

### Precondiciones

* El usuario debe estar autenticado.
* El usuario debe haber leído anteriormente la edición.

### Flujo principal

1. El usuario selecciona una edición.
2. Consulta su historial de lecturas.
3. Selecciona iniciar una nueva lectura.
4. El sistema identifica que existen lecturas anteriores.
5. El sistema determina el siguiente número de relectura.
6. Se crea una nueva instancia de `LECTURA`.
7. La nueva lectura comienza con estado `LEYENDO`.

### Resultado

La nueva lectura queda registrada independientemente de las anteriores.

### Ejemplo

```text
Edición: El Hobbit

Lectura 1
├── Sesiones
├── Bitácora
└── Valoración

Lectura 2
├── Sesiones
├── Bitácora
└── Valoración
```

La segunda lectura no modifica los datos de la primera.

---

# 11. CU-09 — Registrar sesión de lectura

**Actor:** Usuario

### Precondiciones

* El usuario debe estar autenticado.
* Debe existir una lectura activa.
* La lectura debe pertenecer al usuario.

### Flujo principal

1. El usuario selecciona una lectura.
2. Registra la fecha y hora de la sesión.
3. Introduce el progreso alcanzado.
4. Opcionalmente registra la duración de la sesión.
5. El sistema identifica el formato de la edición.
6. El sistema valida el progreso según dicho formato.
7. Se registra la sesión.

### Resultado

El progreso queda registrado en el historial de la lectura.

### Reglas de progreso

```text
FISICO
→ página alcanzada

PDF
→ página alcanzada

EBOOK
→ porcentaje alcanzado

AUDIOLIBRO
→ tiempo alcanzado
```

El progreso inicial se obtiene a partir de la sesión anterior y no se almacena directamente.

---

# 12. CU-10 — Finalizar lectura

**Actor:** Usuario

### Precondiciones

Debe existir una lectura en estado `LEYENDO`.

### Flujo principal

1. El usuario selecciona la lectura.
2. Indica que desea finalizarla.
3. El sistema verifica que el progreso sea compatible con la finalización.
4. Se actualiza el estado a `TERMINADO`.
5. Se registra la fecha de finalización.

### Resultado

La lectura queda registrada como completada.

---

# 13. CU-11 — Abandonar lectura

**Actor:** Usuario

### Precondiciones

Debe existir una lectura activa.

### Flujo principal

1. El usuario selecciona la lectura.
2. Selecciona abandonar lectura.
3. El sistema solicita confirmación.
4. El estado de la lectura cambia a `ABANDONADO`.

### Resultado

La lectura queda registrada como abandonada y conserva las sesiones realizadas hasta ese momento.

---

# 14. CU-12 — Crear entrada de bitácora

**Actor:** Usuario

### Precondiciones

Debe existir una lectura perteneciente al usuario.

### Flujo principal

1. El usuario accede a la bitácora de la lectura.
2. Introduce un título.
3. Introduce el contenido.
4. Indica si contiene spoilers.
5. Opcionalmente selecciona una sesión asociada.
6. El sistema registra la fecha.
7. Se almacena la entrada.

### Resultado

La entrada queda asociada a la lectura.

---

# 15. CU-13 — Editar entrada de bitácora

**Actor:** Usuario

### Precondiciones

* La entrada debe existir.
* La entrada debe pertenecer al usuario.

### Flujo principal

1. El usuario selecciona una entrada.
2. Modifica su información.
3. El sistema valida los cambios.
4. Se actualiza la entrada.

### Resultado

La entrada queda actualizada.

---

# 16. CU-14 — Eliminar entrada de bitácora

**Actor:** Usuario

### Precondiciones

La entrada debe pertenecer al usuario.

### Flujo principal

1. El usuario selecciona una entrada.
2. Solicita eliminarla.
3. El sistema solicita confirmación.
4. Se elimina la entrada.

### Resultado

La entrada deja de formar parte de la bitácora.

---

# 17. CU-15 — Registrar valoración

**Actor:** Usuario

### Precondiciones

* Debe existir una lectura perteneciente al usuario.
* La lectura no debe tener una valoración registrada.

### Flujo principal

1. El usuario selecciona una lectura.
2. Introduce una puntuación.
3. Opcionalmente introduce una reseña.
4. El sistema valida la puntuación.
5. Se registra la valoración.

### Resultado

La lectura posee una valoración independiente.

### Regla

Una lectura puede tener como máximo una valoración.

---

# 18. CU-16 — Editar valoración

**Actor:** Usuario

### Precondiciones

La lectura debe tener una valoración perteneciente al usuario.

### Flujo principal

1. El usuario selecciona la valoración.
2. Modifica la puntuación o reseña.
3. El sistema valida los cambios.
4. Se actualiza la valoración.

### Resultado

La valoración queda actualizada.

---

# 19. CU-17 — Eliminar valoración

**Actor:** Usuario

### Precondiciones

La lectura debe tener una valoración.

### Flujo principal

1. El usuario selecciona la valoración.
2. Solicita eliminarla.
3. El sistema solicita confirmación.
4. Se elimina la valoración.

### Resultado

La lectura queda nuevamente sin valoración.

---

# 20. CU-18 — Consultar estadísticas

**Actor:** Usuario

### Precondiciones

El usuario debe estar autenticado.

### Flujo principal

1. El usuario accede al apartado de estadísticas.
2. El sistema obtiene las lecturas del usuario.
3. El sistema obtiene las sesiones asociadas.
4. El sistema procesa los datos de progreso.
5. El sistema genera las estadísticas.
6. El sistema muestra los resultados.

### Posibles estadísticas

* Libros terminados.
* Libros abandonados.
* Libros actualmente en lectura.
* Cantidad de lecturas.
* Cantidad de relecturas.
* Tiempo dedicado a la lectura.
* Páginas leídas.
* Progreso promedio.
* Actividad de lectura por período.

### Resultado

El usuario obtiene una visión general de su actividad de lectura.

---

# 21. Resumen de casos de uso

| ID    | Caso de uso                  | Actor   |
| ----- | ---------------------------- | ------- |
| CU-01 | Registrar usuario            | Usuario |
| CU-02 | Iniciar sesión               | Usuario |
| CU-03 | Registrar obra               | Usuario |
| CU-04 | Registrar edición            | Usuario |
| CU-05 | Agregar edición a biblioteca | Usuario |
| CU-06 | Consultar biblioteca         | Usuario |
| CU-07 | Registrar lectura            | Usuario |
| CU-08 | Registrar relectura          | Usuario |
| CU-09 | Registrar sesión de lectura  | Usuario |
| CU-10 | Finalizar lectura            | Usuario |
| CU-11 | Abandonar lectura            | Usuario |
| CU-12 | Crear entrada de bitácora    | Usuario |
| CU-13 | Editar entrada de bitácora   | Usuario |
| CU-14 | Eliminar entrada de bitácora | Usuario |
| CU-15 | Registrar valoración         | Usuario |
| CU-16 | Editar valoración            | Usuario |
| CU-17 | Eliminar valoración          | Usuario |
| CU-18 | Consultar estadísticas       | Usuario |

---

# 22. Consideraciones

Los casos de uso relacionados con **metas de lectura** quedan fuera de esta versión inicial, ya que actualmente no existe una entidad `META` ni reglas de negocio asociadas.

La funcionalidad podrá incorporarse posteriormente como una extensión del sistema si se decide implementar objetivos como:

* Cantidad de libros por año.
* Cantidad de páginas por período.
* Tiempo de lectura.
* Cantidad de sesiones.
* Desafíos de lectura.
