BEGIN TRANSACTION;
CREATE TABLE [Piani] (
    [PianoId] int NOT NULL IDENTITY,
    [NomePiano] nvarchar(max) NULL,
    [Descrizione] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    CONSTRAINT [PK_Piani] PRIMARY KEY ([PianoId])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250321104009_PianoRaw', N'9.0.3');

COMMIT;
GO

