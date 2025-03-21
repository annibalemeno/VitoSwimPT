IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Esercizi] (
    [EsercizioId] int NOT NULL IDENTITY,
    [Ripetizioni] int NOT NULL,
    [Distanza] int NOT NULL,
    [Recupero] int NOT NULL,
    [Stile] nvarchar(max) NULL,
    CONSTRAINT [PK_Esercizi] PRIMARY KEY ([EsercizioId])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250318093050_InitialSwimDB', N'9.0.3');

COMMIT;
GO

