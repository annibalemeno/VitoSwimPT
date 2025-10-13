BEGIN TRANSACTION;
CREATE TABLE [AllenamentiUtente] (
    [AllenamentoUtenteId] int NOT NULL IDENTITY,
    [AllenamentoId] int NOT NULL,
    [InsertDateTime] datetime2 NOT NULL DEFAULT (getdate()),
    [UpdateDateTime] datetime2 NOT NULL DEFAULT (getdate()),
    [DatePlanned] datetime2 NULL,
    [DateDone] datetime2 NULL,
    [DoneBy] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AllenamentiUtente] PRIMARY KEY ([AllenamentoUtenteId]),
    CONSTRAINT [FK_AllenamentiUtente_Allenamenti_AllenamentoId] FOREIGN KEY ([AllenamentoId]) REFERENCES [Allenamenti] ([AllenamentoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_AllenamentiUtente_Utenti_DoneBy] FOREIGN KEY ([DoneBy]) REFERENCES [Utenti] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_AllenamentiUtente_AllenamentoId] ON [AllenamentiUtente] ([AllenamentoId]);

CREATE INDEX [IX_AllenamentiUtente_DoneBy] ON [AllenamentiUtente] ([DoneBy]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251013132454_AllenamentoUtente', N'9.0.3');

COMMIT;
GO

