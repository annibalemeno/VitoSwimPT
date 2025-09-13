BEGIN TRANSACTION;
CREATE TABLE [Utenti] (
    [Id] uniqueidentifier NOT NULL,
    [Email] VARCHAR(300) NOT NULL,
    [FirstName] VARCHAR(200) NOT NULL,
    [LastName] VARCHAR(200) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Utenti] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250830105901_AddUsers', N'9.0.3');

COMMIT;
GO

