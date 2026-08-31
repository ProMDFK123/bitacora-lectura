# Requisitos

## 1. Requisitos funcionales

| ID    | Requisito                                      |
| ----- | ---------------------------------------------- |
| RF-01 | Registrar usuario                              |
| RF-02 | Iniciar sesión                                 |
| RF-03 | Cerrar sesión                                  |
| RF-04 | Gestionar perfil                               |
| RF-05 | Registrar una obra                             |
| RF-06 | Consultar obras                                |
| RF-07 | Modificar una obra                             |
| RF-08 | Eliminar una obra                              |
| RF-09 | Registrar una edición                          |
| RF-10 | Consultar ediciones de una obra                |
| RF-11 | Modificar una edición                          |
| RF-12 | Eliminar una edición                           |
| RF-13 | Gestionar autores                              |
| RF-14 | Gestionar géneros                              |
| RF-15 | Gestionar sagas                                |
| RF-16 | Agregar una edición a la biblioteca personal   |
| RF-17 | Eliminar una edición de la biblioteca personal |
| RF-18 | Registrar una lectura                          |
| RF-19 | Registrar una relectura                        |
| RF-20 | Consultar historial de lecturas                |
| RF-21 | Registrar una sesión de lectura                |
| RF-22 | Consultar sesiones de lectura                  |
| RF-23 | Registrar progreso                             |
| RF-24 | Registrar entrada de bitácora                  |
| RF-25 | Modificar entrada de bitácora                  |
| RF-26 | Eliminar entrada de bitácora                   |
| RF-27 | Consultar historial de bitácora                |
| RF-28 | Registrar valoración                           |
| RF-29 | Modificar valoración                           |
| RF-30 | Consultar estadísticas                         |
| RF-31 | Registrar meta de lectura                      |
| RF-32 | Gestionar rutinas de lectura                   |

---

## 2. Requisitos no funcionales

| ID     | Requisito                                                            |
| ------ | -------------------------------------------------------------------- |
| RNF-01 | La aplicación debe ser responsive.                                   |
| RNF-02 | El sistema debe soportar múltiples usuarios.                         |
| RNF-03 | Los datos personales de lectura deben estar aislados entre usuarios. |
| RNF-04 | La API debe utilizar autenticación.                                  |
| RNF-05 | La API debe implementar autorización.                                |
| RNF-06 | Las contraseñas deben almacenarse mediante hash seguro.              |
| RNF-07 | La base de datos debe utilizar PostgreSQL.                           |
| RNF-08 | El backend debe desarrollarse con ASP.NET Core.                      |
| RNF-09 | El frontend debe desarrollarse con Next.js.                          |
| RNF-10 | La API debe documentarse mediante OpenAPI/Swagger.                   |
| RNF-11 | La información sensible debe utilizar variables de entorno.          |
| RNF-12 | El proyecto debe poder ejecutarse mediante Docker.                   |
| RNF-13 | Los datos de entrada deben ser validados.                            |
| RNF-14 | La aplicación debe manejar errores de forma controlada.              |

---

## 3. Reglas de negocio

### RN-01 — Obra y edición

Una obra puede tener múltiples ediciones.

### RN-02 — Edición

Una edición pertenece a una única obra.

### RN-03 — Biblioteca

Un usuario puede registrar una edición en su biblioteca personal.

### RN-04 — Lectura

Una lectura pertenece a un usuario y a una edición.

### RN-05 — Relectura

Un usuario puede registrar múltiples lecturas de una misma edición.

### RN-06 — Sesión

Una sesión pertenece a una lectura.

### RN-07 — Bitácora

Una entrada de bitácora pertenece a una lectura y puede asociarse opcionalmente a una sesión.

### RN-08 — Valoración

Una valoración pertenece a una lectura.

### RN-09 — Progreso

La unidad de progreso depende del formato de la edición.

### RN-10 — Páginas

Los formatos paginados utilizan páginas para registrar progreso.

### RN-11 — Audiolibro

Los audiolibros utilizan tiempo como unidad de progreso.

### RN-12 — Ebook

Los ebooks utilizan porcentaje como unidad de progreso.

### RN-13 — PDF

Los PDF utilizan páginas como unidad de progreso.

### RN-14 — Historial

Las lecturas anteriores deben conservarse cuando se registra una relectura.
