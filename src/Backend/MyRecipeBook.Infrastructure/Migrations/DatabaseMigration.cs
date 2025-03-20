﻿using Dapper;
using MySqlConnector;

namespace MyRecipeBook.Infrastructure.Migrations;

public static class DatabaseMigration
{
    public static void Migrate(string connectionString)
    {
        EnsureDatabaseCreated_MySQL(connectionString);
    }

    private static void EnsureDatabaseCreated_MySQL(string connectionString)
    {
        var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);

        var databaseName = connectionStringBuilder.Database;

        // Remove o nome do banco de dados da string de conexão.
        connectionStringBuilder.Database = "";

        using var dbConnection = new MySqlConnection(connectionStringBuilder.ConnectionString);

        // Parâmetros para a consulta SQL.
        var parameters = new DynamicParameters();
        parameters.Add("name", databaseName);

        // Consulta para verificar se o banco de dados já existe.
        var records = dbConnection.Query("SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name", parameters);

        // Se não encontrar o banco de dados, cria-o.
        if (!records.Any())
        {
            dbConnection.Execute($"CREATE DATABASE `{databaseName}`");
        }
    }
}
