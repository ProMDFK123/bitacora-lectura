using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bitacora_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "generos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    contrasena_hasheada = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    activo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    biografia = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.id);
                    table.ForeignKey(
                        name: "FK_autores_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sagas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sagas", x => x.id);
                    table.ForeignKey(
                        name: "FK_sagas_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obras",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    sinopsis = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    tipo_obra = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    fecha_publicacion = table.Column<DateOnly>(type: "date", nullable: true),
                    saga_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obras", x => x.id);
                    table.ForeignKey(
                        name: "FK_obras_sagas_saga_id",
                        column: x => x.saga_id,
                        principalTable: "sagas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_obras_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutorObra",
                columns: table => new
                {
                    AutoresId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObrasId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorObra", x => new { x.AutoresId, x.ObrasId });
                    table.ForeignKey(
                        name: "FK_AutorObra_autores_AutoresId",
                        column: x => x.AutoresId,
                        principalTable: "autores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorObra_obras_ObrasId",
                        column: x => x.ObrasId,
                        principalTable: "obras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ediciones",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    obra_id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    editorial = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    anio_publicacion = table.Column<int>(type: "integer", nullable: true),
                    numero_paginas = table.Column<int>(type: "integer", nullable: true),
                    duracion_minutos = table.Column<int>(type: "integer", nullable: true),
                    portada_url = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    isbn = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    formato = table.Column<int>(type: "integer", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ediciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_ediciones_obras_obra_id",
                        column: x => x.obra_id,
                        principalTable: "obras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ediciones_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneroObra",
                columns: table => new
                {
                    GenerosId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObrasId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroObra", x => new { x.GenerosId, x.ObrasId });
                    table.ForeignKey(
                        name: "FK_GeneroObra_generos_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroObra_obras_ObrasId",
                        column: x => x.ObrasId,
                        principalTable: "obras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obra_autor",
                columns: table => new
                {
                    ObraId = table.Column<Guid>(type: "uuid", nullable: false),
                    AutorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obra_autor", x => new { x.ObraId, x.AutorId });
                    table.ForeignKey(
                        name: "FK_obra_autor_autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "autores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_obra_autor_obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "obras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obra_genero",
                columns: table => new
                {
                    ObraId = table.Column<Guid>(type: "uuid", nullable: false),
                    GeneroId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obra_genero", x => new { x.ObraId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_obra_genero_generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_obra_genero_obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "obras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bibliotecas",
                columns: table => new
                {
                    EdicionId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_agregado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bibliotecas", x => new { x.UsuarioId, x.EdicionId });
                    table.ForeignKey(
                        name: "FK_bibliotecas_ediciones_EdicionId",
                        column: x => x.EdicionId,
                        principalTable: "ediciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bibliotecas_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lecturas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    edicion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    estado = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    numero_relecturas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lecturas", x => x.id);
                    table.ForeignKey(
                        name: "FK_lecturas_ediciones_edicion_id",
                        column: x => x.edicion_id,
                        principalTable: "ediciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lecturas_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sesiones_lectura",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    lectura_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    progreso = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    duracion_minutos = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sesiones_lectura", x => x.id);
                    table.ForeignKey(
                        name: "FK_sesiones_lectura_lecturas_lectura_id",
                        column: x => x.lectura_id,
                        principalTable: "lecturas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "valoraciones",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    lectura_id = table.Column<Guid>(type: "uuid", nullable: false),
                    puntuacion = table.Column<int>(type: "integer", precision: 2, scale: 1, nullable: false),
                    resena = table.Column<string>(type: "text", nullable: true),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valoraciones", x => x.id);
                    table.CheckConstraint("ck_valoracion_puntuacion", "puntuacion >= 0 AND puntuacion <= 5");
                    table.ForeignKey(
                        name: "FK_valoraciones_lecturas_lectura_id",
                        column: x => x.lectura_id,
                        principalTable: "lecturas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entradas_bitacora",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    sesio_lectura_id = table.Column<Guid>(type: "uuid", nullable: false),
                    lectura_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    contenido = table.Column<string>(type: "text", nullable: false),
                    contiene_spoilers = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradas_bitacora", x => x.id);
                    table.ForeignKey(
                        name: "FK_entradas_bitacora_lecturas_lectura_id",
                        column: x => x.lectura_id,
                        principalTable: "lecturas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entradas_bitacora_sesiones_lectura_sesio_lectura_id",
                        column: x => x.sesio_lectura_id,
                        principalTable: "sesiones_lectura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_autores_UsuarioId",
                table: "autores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AutorObra_ObrasId",
                table: "AutorObra",
                column: "ObrasId");

            migrationBuilder.CreateIndex(
                name: "IX_bibliotecas_EdicionId",
                table: "bibliotecas",
                column: "EdicionId");

            migrationBuilder.CreateIndex(
                name: "IX_ediciones_isbn",
                table: "ediciones",
                column: "isbn",
                unique: true,
                filter: "isbn IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ediciones_obra_id",
                table: "ediciones",
                column: "obra_id");

            migrationBuilder.CreateIndex(
                name: "IX_ediciones_UsuarioId",
                table: "ediciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_entradas_bitacora_lectura_id",
                table: "entradas_bitacora",
                column: "lectura_id");

            migrationBuilder.CreateIndex(
                name: "IX_entradas_bitacora_sesio_lectura_id",
                table: "entradas_bitacora",
                column: "sesio_lectura_id");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroObra_ObrasId",
                table: "GeneroObra",
                column: "ObrasId");

            migrationBuilder.CreateIndex(
                name: "IX_generos_nombre",
                table: "generos",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lecturas_edicion_id",
                table: "lecturas",
                column: "edicion_id");

            migrationBuilder.CreateIndex(
                name: "IX_lecturas_usuario_id_edicion_id_numero_relecturas",
                table: "lecturas",
                columns: new[] { "usuario_id", "edicion_id", "numero_relecturas" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_obra_autor_AutorId",
                table: "obra_autor",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_obra_genero_GeneroId",
                table: "obra_genero",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_obras_saga_id",
                table: "obras",
                column: "saga_id");

            migrationBuilder.CreateIndex(
                name: "IX_obras_UsuarioId",
                table: "obras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_sagas_UsuarioId",
                table: "sagas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_sesiones_lectura_lectura_id_fecha",
                table: "sesiones_lectura",
                columns: new[] { "lectura_id", "fecha" });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_email",
                table: "usuarios",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_valoraciones_lectura_id",
                table: "valoraciones",
                column: "lectura_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorObra");

            migrationBuilder.DropTable(
                name: "bibliotecas");

            migrationBuilder.DropTable(
                name: "entradas_bitacora");

            migrationBuilder.DropTable(
                name: "GeneroObra");

            migrationBuilder.DropTable(
                name: "obra_autor");

            migrationBuilder.DropTable(
                name: "obra_genero");

            migrationBuilder.DropTable(
                name: "valoraciones");

            migrationBuilder.DropTable(
                name: "sesiones_lectura");

            migrationBuilder.DropTable(
                name: "autores");

            migrationBuilder.DropTable(
                name: "generos");

            migrationBuilder.DropTable(
                name: "lecturas");

            migrationBuilder.DropTable(
                name: "ediciones");

            migrationBuilder.DropTable(
                name: "obras");

            migrationBuilder.DropTable(
                name: "sagas");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
