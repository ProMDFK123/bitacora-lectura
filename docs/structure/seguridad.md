# Seguridad

## 1. Autenticación

La aplicación utilizará autenticación basada en JWT.

El token será utilizado para acceder a endpoints protegidos.

```text
Usuario
   │
   │ Login
   ▼
Backend
   │
   │ JWT
   ▼
Usuario
   │
   │ Authorization: Bearer <token>
   ▼
Endpoint protegido
```

---

# 2. Contraseñas

Las contraseñas nunca deberán almacenarse en texto plano.

Se almacenará únicamente un hash seguro.

---

# 3. Autorización

Los recursos personales deberán estar asociados al usuario autenticado.

Por ejemplo:

```text
GET /api/readings/{id}
```

deberá verificar que la lectura pertenezca al usuario autenticado.

Un usuario no deberá poder consultar o modificar:

* Lecturas de otros usuarios.
* Sesiones de otros usuarios.
* Entradas de bitácora de otros usuarios.
* Valoraciones de otros usuarios.
* Metas de otros usuarios.

---

# 4. Datos públicos y personales

### Datos potencialmente compartidos

* Obras.
* Autores.
* Géneros.
* Sagas.
* Ediciones.

### Datos privados

* Biblioteca personal.
* Lecturas.
* Sesiones.
* Bitácora.
* Valoraciones.
* Metas.
* Rutinas.

---

# 5. Variables de entorno

Las credenciales y secretos no deberán almacenarse directamente en el repositorio.

Ejemplo:

```env
DATABASE_CONNECTION_STRING=
JWT_SECRET=
CLOUDINARY_CLOUD_NAME=
CLOUDINARY_API_KEY=
CLOUDINARY_API_SECRET=
```

El archivo `.env` deberá estar incluido en `.gitignore`.

---

# 6. Validación

Los datos recibidos desde el frontend deberán validarse también en el backend.

Nunca se deberá confiar exclusivamente en las validaciones del cliente.

---

# 7. Progreso

El backend deberá validar que el progreso corresponda al formato de la edición.

Ejemplos:

```text
FISICO → páginas
PDF → páginas
EBOOK → porcentaje
AUDIOLIBRO → tiempo
```

No se deberá permitir registrar valores incompatibles con el formato.
