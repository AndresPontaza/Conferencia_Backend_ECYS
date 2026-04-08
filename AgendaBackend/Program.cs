using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string connectionString = "Data Source=database.db";

using (var connection = new SqliteConnection(connectionString))
{
    connection.Open();

    string sql = "CREATE TABLE IF NOT EXISTS Contactos (Id INTEGER PRIMARY KEY AUTOINCREMENT, Nombre TEXT, Telefono TEXT)";

    using var command = new SqliteCommand(sql, connection);
    command.ExecuteNonQuery();
}

// *** Endpoints de la API ***

// 1. Obtener todos los contactos (GET)
app.MapGet("/contactos", () =>
{
    var lista = new List<object>();

    using var connection = new SqliteConnection(connectionString);
    connection.Open();
    using var command = new SqliteCommand("SELECT * FROM Contactos", connection);
    using var reader = command.ExecuteReader();

    while (reader.Read())
    {
        lista.Add(new
        {
            Id = reader["Id"],
            Nombre = reader["Nombre"],
            Telefono = reader["Telefono"]
        });
    }

    return Results.Ok(lista);
});

// 2. Crear un nuevo contacto (POST)
app.MapPost("/contactos", (Contacto nuevo) =>
{
    using var connection = new SqliteConnection(connectionString);
    connection.Open();
    string sql = "INSERT INTO Contactos (Nombre, Telefono) VALUES (@Nombre, @Telefono)";
    using var command = new SqliteCommand(sql, connection);
    command.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
    command.Parameters.AddWithValue("@Telefono", nuevo.Telefono);
    command.ExecuteNonQuery();

    return Results.Created($"/contactos/{nuevo.Nombre}", nuevo);
});

// 3. eliminar un contacto por ID (DELETE)
app.MapDelete("/contactos/{id}", (int id) =>
{
    using var connection = new SqliteConnection(connectionString);
    connection.Open();
    
    using var command = new SqliteCommand("DELETE FROM Contactos WHERE Id = @Id", connection);
    command.Parameters.AddWithValue("@Id", id);
    int filas = command.ExecuteNonQuery();
    return filas > 0 ? Results.Ok("Contacto eliminado") : Results.NotFound();
});


//4. Actualizar un contacto por ID (PUT)
app.MapPut("/contactos/{id}", (int id, Contacto actualizado) =>
{
    using var connection = new SqliteConnection(connectionString);
    connection.Open();
    
    string sql = "UPDATE Contactos SET Nombre = @Nombre, Telefono = @Telefono WHERE Id = @Id";
    using var command = new SqliteCommand(sql, connection);

    command.Parameters.AddWithValue("@Nombre", actualizado.Nombre);
    command.Parameters.AddWithValue("@Telefono", actualizado.Telefono);
    command.Parameters.AddWithValue("@Id", id);

    int filas = command.ExecuteNonQuery();
    return filas > 0 ? Results.Ok("Contacto actualizado") : Results.NotFound();
});

app.Run();

record Contacto(string Nombre, string Telefono);