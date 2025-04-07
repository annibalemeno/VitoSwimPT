BEGIN TRANSACTION;
ALTER TABLE [Esercizi] ADD [StileId] int NOT NULL DEFAULT 0;

CREATE TABLE [Stili] (
    [StileId] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Sigla] nvarchar(2) NOT NULL,
    CONSTRAINT [PK_Stili] PRIMARY KEY ([StileId])
);

CREATE INDEX [IX_Esercizi_StileId] ON [Esercizi] ([StileId]);

ALTER TABLE [Esercizi] ADD CONSTRAINT [FK_Esercizi_Stili_StileId] FOREIGN KEY ([StileId]) REFERENCES [Stili] ([StileId]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250404144608_StileLookup', N'9.0.3');

COMMIT;
GO

